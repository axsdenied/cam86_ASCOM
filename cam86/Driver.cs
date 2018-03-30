// --------------------------------------------------------------------------------
// ASCOM Camera driver for cam86 v.0.7L
// Edit Log:
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 29-aug-2016  VSS 0.1     Initial
// 31-jan-2016  Luka Pravica     0.2     Add night mode
//                                       Add option to adjust frame reading delays
//                                       Add info (min/max, StdDev)
// 3-feb-2017   Luka Pravica     0.3     Add firmware and LL driver version reading
//                                       Implement TEC during reading
//                                       Add mono sensor setting
// 19-feb-2017  Luka Pravica     0.4     Add bias-before-exposure option
// 27-feb-2017  Luka Pravica     0.5     Remove settings form and move all settings to the profile dialog
//                                           Profile dialog with settings is modified significantly and can be called via ascom profile or via imaging software
//                                           Different options can be displayed depending how it is opened
//                                       Numerous ASCOM improvements and bug fixes
//                                       Make driver ASCOM compliant, ASCOM compliance checker passes without errors now
// 2-mar-2017   Luka Pravica     0.6     Add about box to settings
//                                       Add humidity/dew point information
//                                       Add TEC starting power and maximum power settings
//                                       Add warnings about possible condensation
//                                       Rewrite how live-change of settings is handled
//                                       Tidy up the interface
// 4-mar-2017   Luka Pravica     0.6.1   Bug fixes, interface tidy up
//                                       Storing of the location of the settings window if camera connected
// 4-mar-2017   Luka Pravica     0.6.2   Minor bug fixes, minor interface corrections
// 8-mar-2017   Luka Pravica     0.6.3   Fix bug in dew warning
//                                       Add Open On Start option to the settings
//                                       LLD fixed >999s exposures
// 11-mar-2017  Luka Pravica     0.6.4   Fix a bug in dew warning
//                                       Fixed >1000s exposure bug in the LLD
// 17-mar-2017  Luka Pravica     0.6.5   Add control of the TEC cooling PID parameter KP (proportional gain)
// 18-mar-2017  Luka Pravica     0.6.6   Fix night colours for the KP parameter in settings
//                                       Fix Kp default value throwing exception in countries where , is used for real numbers instead of .
// 5-apr-2017   Luka Pravica     0.7     Add option to select if the humidity sensor is present
//                                       Fix few typos
//                                       Minor bug fixes
// 5-may-2017   Luka Pravica     0.7.1   Minor bug fixes regarding the dew warnings
//                                       Fix bug in startExposure logging
// 17-jun-2017  Luka Pravica     0.7.2   Fix bug where maxGain was reported as 64 instead of 63
//                                       Modify the layout of the settings form
//                                       Add a button to minimise the settings form
//                                       Add a button to toggle between image info only or settings as well when camera is connected
// 27-Sep-2017  Luka Pravica     0.7.3   Increase revision number because of the white-line bug fixes in the LLD when CCD temperature control (like Cooling Aid in APT) is used
// 24-Nov-2017  Oscar Casanova   0.7.5   Add Ki and Kd to be compatible with full PID control implemented
// 13-Dec-2017  Luka Pravica     0.7.6   Minor interface tweaks. 
//                                       Temperature in settings shows set temperature as well.
//                                       Added option to double-click temperature label to set temperature, independent of the imaging software.
// 17-Dec-2017  Luka Pravica     0.7.7   Update version information only due to a mistake in the reased version
// 18-Dec-2017  Luka Pravica     0.7.8   Fix bug where manually set temperature was resetting itself
//                                       Manual temperature control is double-click now instead of single click
//                                       Minor interface bug fixes
// 10-Mar-2018  Luka Pravica     0.7.9   Include an updated low level DLL (with bug fixes)
// 17-Mar-2018  Luka Pravica     0.7.10  Removed delays in the low level DLL (see previous version) and moved them here
// 25-Mar-2018  Luka Pravica     0.8.0   Minor bug fixes and interface tweaks
//                                       Added display of cooling power in addition to the temperature
//                                       Show mean value of the image
//                                       Reduce image acquisition time by doing calculations of stdDev inline
//                                       
// --------------------------------------------------------------------------------

/*  Copyright © 2017 Gilmanov Rim, Vakulenko Sergiy and Luka Pravica
   
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#define Camera


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using System.Globalization;
using System.Collections;
using System.Threading;
using System.Timers;
using System.Reflection;

namespace ASCOM.cam86
{
    /// <summary>
    /// ASCOM Camera Driver for cam86.
    /// </summary>
    [Guid("677df06a-d784-4a3b-9028-d597e58131a4")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Camera : ICameraV2
    {
        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        internal static string driverID = "ASCOM.cam86.Camera";

        bool cameraStartingUp = true;
        int startUpDelay = 100; // 100ms delay after each command during the startup period. 

        /// <summary>
        /// Driver description that displays in the ASCOM Chooser.
        /// </summary>
        internal static string driverVersion = "0.8.1";
        private static string driverDescription = "Cam86 v" + driverVersion + " ASCOM Driver";
        internal static string driverLLversion = "";
        internal static string driverFirmwareVersion = "";

        //parameters fro ASCOM profile read/write
        internal static string traceStateProfileName = "Trace Level";
        internal static string gainStateProfileName = "gain";
        internal static string offsetStateProfileName = "offset";
        internal static string readingTimeStateProfileName = "readingTime";
        internal static string onTopStateProfileName = "onTop";
        internal static string slowCoolingEnabledProfileName = "slowCooling";
        internal static string slowCoolingSpeedProfileName = "slowCoolingSpeed";
        internal static string TECduringReadingProfileName = "TECduringReading";
        internal static string monoSensorProfileName = "mono";
        internal static string sensorClearBeforeExposureTimeProfileName = "SensorClearBeforeExposureTime";
        internal static string nightModeSettingsProfileName = "NightModeSettings";
        internal static string TECcoolingMaxPowerPercentProfileName = "TECcoolingMaxPowerPercent";
        internal static string TECcoolingStartingPowerPercentProfileName = "TECcoolingStartingPowerPercent";
        internal static string settingsWindowLocationProfileName = "WindowLocation";
        internal static string settingsWindowOpenOnConnectProfileName = "SettingsWindowOpenOnConnect";
        internal static string settingsWindowSizeProfileName = "SettingsWindowSize";
        internal static string PIDproportionalGainProfileName = "PIDproportionalGain";
        internal static string PIDintegralGainProfileName = "PIDintegralGain";
        internal static string PIDderivativeGainProfileName = "PIDderivativeGain";
        internal static string DHT22presentProfileName = "DHT22Present";

        internal static string traceStateDefault = "false";
        internal static string gainStateDefault = "0";
        internal static string offsetStateDefault = "-6";
        internal static string readingTimeStateDefault = "0";
        internal static string onTopStateDefault = "true";
        internal static string slowCoolingEnabledStateDefault = "false";
        internal static string slowCoolingSpeedStateDefault = "5";
        internal static string coolerDuringReadingStateDefault = "false";
        internal static string monoSensorStateDefault = "false";
        internal static string sensorClearBeforeExposureTimeDefault = "36000";
        internal static string nightModeSettingsDefault = "false";
        internal static string TECcoolingMaxPowerPercentDefault = "100";
        internal static string TECcoolingStartingPowerPercentDefault = "60";
        internal static string settingsWindowLocationDefault = "0,0";
        internal static string settingsWindowOpenOnConnectDefault = "true";
        internal static string settingsWindowSizeDefault = Enum.GetName(typeof(settingsWindowSizeE), settingsWindowSizeE.cameraOnFullOptions);
        internal static string PIDproportionalGainDefault = 50.0.ToString(); // dirty way to take care of the internalisation
        internal static string PIDintegralGainDefault = 0.0.ToString(); // dirty way to take care of the internalisation
        internal static string PIDderivativeGainDefault = 0.0.ToString(); // dirty way to take care of the internalisation
        internal static string DHT22presentDefault = "false";
        internal static double tempCCDTemp = 0.0;
        internal static double tempCoolingPower = 0.0;

        internal static bool traceState;
        internal static short gainState;
        internal static short offsetState;
        internal static short readingTimeState;
        internal static bool onTopState;
        internal static bool slowCoolingEnabledState;
        internal static short slowCoolingSpeedState;
        internal static bool coolerDuringReadingState;
        internal static bool monoSensorState;
        internal static ushort sensorClearBeforeExposureTimeState;
        internal static bool nightModeSettingsState;
        internal static short coolingMaxPowerPercentState;
        internal static short coolingStartingPowerPercentState;
        internal static System.Drawing.Point settingsWindowLocationState;
        internal static bool settingsWindowOpenOnConnectState;
        internal static settingsWindowSizeE settingsWindowSizeState;
        internal static double PIDproportionalGainState;
        internal static double PIDintegralGainState;
        internal static double PIDderivativeGainState;
        internal static bool DHT22presentState;

        // flags if the setting has been changed and needs to be sent to camera
        internal static bool gainStateDirty = true;
        internal static bool offsetStateDirty = true;
        internal static bool readingTimeStateDirty = true;
        internal static bool onTopStateDirty = true;
        internal static bool slowCoolingEnabledStateDirty = true;
        internal static bool coolerDuringReadingStateDirty = true;
        internal static bool monoSensorStateDirty = true;
        internal static bool nightModeSettingsStateDirty = true;
        internal static bool coolingMaxPowerPercentStateDirty = true;
        internal static bool coolingStartingPowerPercentStateDirty = true;
        internal static bool settingsWindowLocationStateDirty = true;
        internal static bool settingsWindowOpenOnConnectStateDirty = true;
        internal static bool settingsWindowSizeStateDirty = true;
        internal static bool PIDproportionalGainStateDirty = true;
        internal static bool PIDintegralGainStateDirty = true;
        internal static bool PIDderivativeGainStateDirty = true;
        internal static bool DHT22presentStateDirty = true;
        internal static bool tempCCDTempDirty = true;


        /// <summary>
        /// Private variable to hold the connected state
        /// </summary>
        private bool cameraConnectedState;

        /// <summary>
        /// Private variable to hold an ASCOM Utilities object
        /// </summary>
        private Util utilities;

        /// <summary>
        /// Private variables to hold exposure start and stop for accurate calculations of real time including all overheads
        /// </summary>
        private DateTime exposureStartTimestamp, exposureStopTimestamp;

        /// <summary>
        /// Form for settings (it may be opened as showdialog or as show)
        /// </summary>
        private SetupDialogForm setupForm = null;

        System.Timers.Timer DHTTimer = new System.Timers.Timer();

        /// <summary>
        /// Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
        /// </summary>
        private static TraceLogger tl;

        private const string LowLevelDLL = "cam86ll.dll";

        //Imports cam86ll.dll functions
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraConnect();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraDisconnect();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraIsConnected();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraStartExposure(int Bin, int StartX, int StartY, int NumX, int NumY, double Duration, bool light);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraStopExposure();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern int cameraGetCameraState();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraGetImageReady();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern uint cameraGetImage();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetGain(int val);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetOffset(int val);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern int cameraGetError();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern double cameraGetTemp();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetTemp(double temp);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern double cameraGetSetTemp();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraCoolingOn();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraCoolingOff();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraGetCoolerOn();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern double cameraGetCoolerPower();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetReadingTime(int readingTime);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetCoolerDuringReading(byte value);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern byte cameraGetFirmwareVersion();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern byte cameraGetLLDriverVersion();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetBiasBeforeExposure(byte value);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern double cameraGetTempDHT();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern double cameraGetHumidityDHT();
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetCoolingStartingPowerPercentage(int val);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetCoolingMaximumPowerPercentage(int val);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetPIDproportionalGain(double proportionalGain);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetPIDintegralGain(double integralGain);
        [DllImport(LowLevelDLL, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern bool cameraSetPIDderivativeGain(double derivativeGain);

        /// <summary>
        /// Initializes a new instance of the <see cref="cam86"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Camera()
        {
            // Read device configuration from the ASCOM Profile store
            ReadProfile();
            //Init debug logger
            tl = new TraceLogger("", "cam86");
            tl.Enabled = traceState;
            tl.LogMessage("Camera", "Starting initialisation");
            // Initialise connected to false
            cameraConnectedState = false;
            //Initialise util object
            utilities = new Util();

            slowCoolingTimer = new System.Timers.Timer(60000);
            slowCoolingTimer.Enabled = false;
            slowCoolingTimer.Elapsed += slowCoolingTimerTick;

            // get low level driver version
            driverLLversion = cameraGetLLDriverVersion().ToString();
            // cannot read firmware version as we are not connected to the camera yet
            driverFirmwareVersion = "0";

            // used for reading of the DHT sensor
            DHTTimer.Elapsed += new ElapsedEventHandler(OnDHTTimedEvent);
            DHTTimer.Interval = 10000; // update every 10 seconds
            DHTTimer.Enabled = false;

            tl.LogMessage("Camera", "Completed initialisation");
        }


        //
        // PUBLIC COM INTERFACE ICameraV2 IMPLEMENTATION
        //

        #region Common properties and methods.

        /// <summary>
        /// Displays the Setup Dialog form.
        /// If the user clicks the OK button to dismiss the form, then
        /// the new settings are saved, otherwise the old values are reloaded.
        /// THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
        /// </summary>
        public void SetupDialog()
        {
            if (setupForm != null)
                setupForm.Close();
            setupForm = new SetupDialogForm();

            // show camera settings form
            // the settins will look different depending if the camera is connected or not
            if (IsConnected)
            {
                setupForm.cameraConnected = true;
                setupForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                setupForm.Location = settingsWindowLocationState;
                setupForm.Show();
                setupForm.BringToFront();
                setupForm.updateMainFormCameraParameters += updateCameraParametersEvent; // register event from the main form that will trigger updates of camera parameters
            }
            else
            {
                setupForm.cameraConnected = false;
                var result = setupForm.ShowDialog();
                setupForm.Dispose();
                setupForm = null;
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // Persist device configuration values to the ASCOM Profile store
                    WriteProfile();
                }
            }
        }

        public ArrayList SupportedActions
        {
            get
            {
                tl.LogMessage("SupportedActions Get", "Returning empty arraylist");
                return new ArrayList();
            }
        }

        public string Action(string actionName, string actionParameters)
        {
            tl.LogMessage("Action", "Not implemented");
            throw new ASCOM.ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");
        }

        public void CommandBlind(string command, bool raw)
        {
            tl.LogMessage("CommandBlind", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("CommandBlind");
        }

        public bool CommandBool(string command, bool raw)
        {
            tl.LogMessage("CommandBool", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("CommandBool");
        }

        public string CommandString(string command, bool raw)
        {
            tl.LogMessage("CommandString", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("CommandString");
        }

        public void Dispose()
        {
            // Clean up the tracelogger, settings form and util objects
            tl.Enabled = false;
            tl.Dispose();
            tl = null;
            utilities.Dispose();
            utilities = null;
        }

        public bool Connected
        {
            get
            {
                tl.LogMessage("Connected Get", IsConnected.ToString());
                return IsConnected;
            }
            set
            {
                tl.LogMessage("Connected Set", value.ToString());
                if (value == IsConnected) return;
                if (value)
                {
                    tl.LogMessage("Connected Set", "Connecting to camera, call cameraConnect from " + LowLevelDLL);
                    if (cameraConnect() == false)
                    {
                        tl.LogMessage("Connected Set", "Cant connect to " + this.Name);
                        throw new ASCOM.NotConnectedException("Cant connect to " + this.Name);
                    }
                    tl.LogMessage("Connected Set", "cameraConnectedState=true");
                    cameraConnectedState = true;

                    // set any parameters that have changed recently

                    cameraStartingUp = true; // used to slow down sending of commands to camera during the initialisation
                    updateCameraParametersEvent(this, null);
                    cameraStartingUp = false;

                    // do we need to open the settings window
                    if (settingsWindowOpenOnConnectState)
                        SetupDialog();

                    // start DHT timer to update humidity/temperature reading
                    if (DHT22presentState)
                        DHTTimer.Enabled = true;
                    else
                        DHTTimer.Enabled = false;

                    try
                    {
                        driverFirmwareVersion = cameraGetFirmwareVersion().ToString(); // it will return 0 if the cam86 is not connected
                    }
                    catch
                    {
                        driverFirmwareVersion = "0";
                    }
                }
                else
                {
                    tl.LogMessage("Connected Set", "Disconnecting from camera, call cameraConnect from" + LowLevelDLL);
                    if (cameraDisconnect() == false)
                    {
                        tl.LogMessage("Connected Set", "Cant disconnect " + this.Name);
                        throw new ASCOM.NotConnectedException("Cant disconnect " + this.Name);
                    }
                    tl.LogMessage("Connected Set", "cameraConnectedState=false");
                    cameraConnectedState = false;

                    if (setupForm != null)
                    {
                        setupForm.Close();
                        setupForm = null;
                    }

                    cameraStartingUp = true;

                    // mark all camera parameters dirty so they get uploaded if we connect again
                    gainStateDirty = true;
                    offsetStateDirty = true;
                    readingTimeStateDirty = true;
                    onTopStateDirty = true;
                    slowCoolingEnabledStateDirty = true;
                    coolerDuringReadingStateDirty = true;
                    monoSensorStateDirty = true;
                    nightModeSettingsStateDirty = true;
                    coolingMaxPowerPercentStateDirty = true;
                    coolingStartingPowerPercentStateDirty = true;
                    settingsWindowLocationStateDirty = true;
                    settingsWindowOpenOnConnectStateDirty = true;
                    settingsWindowSizeStateDirty = true;
                    PIDproportionalGainStateDirty = true;
                    PIDintegralGainStateDirty = true;
                    PIDderivativeGainStateDirty = true;
                    DHT22presentStateDirty = true;
                    tempCCDTempDirty = true;

                    DHTTimer.Enabled = false;

                   //save settings for ASCOM profile
                   WriteProfile();
                }
            }
        }

        public string Description
        {
            get
            {
                tl.LogMessage("Description Get", driverDescription);
                return driverDescription;
            }
        }

        public string DriverInfo
        {
            get
            {
                tl.LogMessage("DriverInfo Get", driverDescription);
                return driverDescription;
            }
        }

        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                tl.LogMessage("DriverVersion Get", driverVersion);
                return driverVersion;
            }
        }

        public short InterfaceVersion
        {
            // set by the driver wizard
            get
            {
                tl.LogMessage("InterfaceVersion Get", "2");
                return Convert.ToInt16("2");
            }
        }

        public string Name
        {
            get
            {
                tl.LogMessage("Name Get", "cam86");
                return "cam86";
            }
        }
        #endregion

        #region ICamera Implementation

        // Constants to define the ccd pixel dimenstions
        private const int ccdWidth = 3000;
        private const int ccdHeight = 2000;
        // Constant for the pixel physical dimension um
        private const double pixelSize = 7.8;
        private const int maxPixelADU = 65535;

        private const int CameraStateIdle = 0;
        private const int CameraStateWaiting = 1;
        private const int CameraStateExposing = 2;
        private const int CameraStateReading = 3;
        private const int CameraStateDownloading = 4;
        private const int CameraSteteError = 5;

        // Initialise variables to hold values required for functionality tested by Conform
        private int cameraNumX = ccdWidth;
        private int cameraNumY = ccdHeight;
        private int cameraStartX = 0;
        private int cameraStartY = 0;
        private short cameraBinX = 1;
        private short cameraBinY = 1;
        private DateTime exposureStart = DateTime.MinValue;
        private double cameraLastExposureDuration = 0.0;

        private bool cameraImageReady = false;
        private int[,] cameraImageArray;
        private object[,] cameraimageArrayVariant;

        private int cameraError = 0;

        private const double MinSetTemp = -50.0;
        private const double MaxSetTemp = 50.0;

        private static double slowCoolingInterm = 0.0;
        private static bool slowCoolingCoolingDirection = true; //true==cooling, false==heating
        private static double slowCoolingTarger = 0.0;
        private static System.Timers.Timer slowCoolingTimer;



        public void AbortExposure()
        {
            tl.LogMessage("AbortExposure", "Aborting exposure, call cameraStopExposure from " + LowLevelDLL);
            if (cameraStopExposure() == false)
            {
                tl.LogMessage("AbortExposure", "PropertyNotImplementedException Abort Exposure failed");
                throw new ASCOM.PropertyNotImplementedException("Abort Exposure failed");
            }
        }

        public short BayerOffsetX
        {
            get
            {
                tl.LogMessage("BayerOffsetX Get ", "1");
                if (monoSensorState)
                {
                    tl.LogMessage("BayerOffsetX", "PropertyNotImplementedException BayerOffsetX failed");
                    throw new ASCOM.PropertyNotImplementedException("BayerOffsetX failed");
                }

                return 1;
            }
        }

        public short BayerOffsetY
        {
            get
            {
                tl.LogMessage("BayerOffsetY Get ", "0");

                if (monoSensorState)
                {
                    tl.LogMessage("BayerOffsetY", "PropertyNotImplementedException BayerOffsetY failed");
                    throw new ASCOM.PropertyNotImplementedException("BayerOffsetY failed");
                }
                return 0;
            }
        }

        public short BinX
        {
            get
            {
                tl.LogMessage("BinX Get", cameraBinX.ToString());
                return cameraBinX;
            }
            set
            {
                tl.LogMessage("BinX Set", value.ToString());
                if ((value < 1) || (value > this.MaxBinX))
                {
                    tl.LogMessage("BinX Set", "InvalidValueException BinX must be in range [1;MaxBinX]");
                    throw new ASCOM.InvalidValueException("BinX", value.ToString(), "BinX must be in range [1;MaxBinX]");
                }

                cameraStartX = (cameraStartX * cameraBinX) / value;
                cameraNumX = (cameraNumX * cameraBinX) / value;
                cameraBinX = value;
            }
        }

        public short BinY
        {
            get
            {
                tl.LogMessage("BinY Get", cameraBinY.ToString());
                return cameraBinY;
            }
            set
            {
                tl.LogMessage("BinY Set", value.ToString());
                if ((value < 1) || (value > this.MaxBinY))
                {
                    tl.LogMessage("BinY Set", "InvalidValueException BinY must be in range [1;MaxBinY]");
                    throw new ASCOM.InvalidValueException("BinY", value.ToString(), "BinY must be in range [1;MaxBinY]");
                }
                cameraStartY = (cameraStartY * cameraBinY) / value;
                cameraNumY = (cameraNumY * cameraBinY) / value;
                cameraBinY = value;
            }
        }

        public double CCDTemperature
        {
            get
            {
                double temp = cameraGetTemp();
                tl.LogMessage("CCDTemperature Get", temp.ToString());

                // update only if the data needs to be displayed
                if (setupForm != null)
                {
                    setupForm.updateTemperatureLabel(temp, tempCoolingPower);
                }

                return temp;
            }
        }

        public CameraStates CameraState
        {
            get
            {
                tl.LogMessage("CameraState Get", "Call cameraGetError from " + LowLevelDLL);
                if (cameraError != (int)cameraGetError())
                {
                    tl.LogMessage("CameraState Get", "cameraError = " + cameraError.ToString());
                }
                tl.LogMessage("CameraState Get", "Call cameraGetCameraState from " + LowLevelDLL);
                switch ((short)cameraGetCameraState())
                {
                    case CameraStateIdle:
                        {
                            tl.LogMessage("CameraState Get", CameraStates.cameraIdle.ToString());
                            return CameraStates.cameraIdle;
                        }
                    case CameraStateWaiting:
                        {
                            tl.LogMessage("CameraState Get", CameraStates.cameraWaiting.ToString());
                            return CameraStates.cameraWaiting;
                        }
                    case CameraStateExposing:
                        {
                            tl.LogMessage("CameraState Get", CameraStates.cameraExposing.ToString());
                            return CameraStates.cameraExposing;
                        }
                    case CameraStateReading:
                        {
                            tl.LogMessage("CameraState Get", CameraStates.cameraReading.ToString());
                            return CameraStates.cameraReading;
                        }
                    case CameraStateDownloading:
                        {
                            tl.LogMessage("CameraState Get", CameraStates.cameraDownload.ToString());
                            return CameraStates.cameraDownload;
                        }
                    default:
                        {
                            tl.LogMessage("CameraState Get", CameraStates.cameraError.ToString());
                            return CameraStates.cameraError;
                        }
                }
            }
        }

        public int CameraXSize
        {
            get
            {
                tl.LogMessage("CameraXSize Get", ccdWidth.ToString());
                return ccdWidth;
            }
        }

        public int CameraYSize
        {
            get
            {
                tl.LogMessage("CameraYSize Get", ccdHeight.ToString());
                return ccdHeight;
            }
        }

        public bool CanAbortExposure
        {
            get
            {
                tl.LogMessage("CanAbortExposure Get", true.ToString());
                return true;
            }
        }

        public bool CanAsymmetricBin
        {
            get
            {
                tl.LogMessage("CanAsymmetricBin Get", false.ToString());
                return false;
            }
        }

        public bool CanFastReadout
        {
            get
            {
                tl.LogMessage("CanFastReadout Get", false.ToString());
                return false;
            }
        }

        public bool CanGetCoolerPower
        {
            get
            {
                tl.LogMessage("CanGetCoolerPower Get", true.ToString());
                return true;
            }
        }

        public bool CanPulseGuide
        {
            get
            {
                tl.LogMessage("CanPulseGuide Get", false.ToString());
                return false;
            }
        }

        public bool CanSetCCDTemperature
        {
            get
            {
                tl.LogMessage("CanSetCCDTemperature Get", "true");
                return true;
            }
        }

        public bool CanStopExposure
        {
            get
            {
                tl.LogMessage("CanStopExposure Get", true.ToString());
                return true;
            }
        }

        public bool CoolerOn
        {
            get
            {
                bool coolerState = cameraGetCoolerOn();
                tl.LogMessage("CoolerOn Get", coolerState.ToString());
                return coolerState;
            }
            set
            {
                tl.LogMessage("CoolerOn Set", value.ToString());
                if (value)
                {
                    this.SetCCDTemperature = this.SetCCDTemperature;
                    cameraCoolingOn();
                }
                else
                {
                    slowCoolingTimer.Enabled = false;
                    cameraCoolingOff();

                    tempCoolingPower = 0;
                    if (setupForm != null)
                        setupForm.setCoolerPower = 0;
                }
            }
        }

        public double CoolerPower
        {
            get
            {
                tempCoolingPower = cameraGetCoolerPower();

                if (setupForm != null)
                    setupForm.setCoolerPower = tempCoolingPower;

                tl.LogMessage("CoolerPower Get", tempCoolingPower.ToString());
                return tempCoolingPower;
            }
        }

        public double ElectronsPerADU
        {
            get
            {
                tl.LogMessage("ElectronsPerADU Get ", "0.4");
                return 0.4;
            }
        }

        public double ExposureMax
        {
            get
            {
                tl.LogMessage("ExposureMax Get", "36000.00");
                return 36000.00;
            }
        }

        public double ExposureMin
        {
            get
            {
                tl.LogMessage("ExposureMin Get", "0.0");
                return 0.0;
            }
        }

        public double ExposureResolution
        {
            get
            {
                tl.LogMessage("ExposureResolution Get", "0.01");
                return 0.01;
            }
        }

        public bool FastReadout
        {
            get
            {
                tl.LogMessage("FastReadout Get", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("FastReadout", false);
            }
            set
            {
                tl.LogMessage("FastReadout Set", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("FastReadout", true);
            }
        }

        public double FullWellCapacity
        {
            get
            {
                tl.LogMessage("FullWellCapacity Get", "25000e");
                return 25000.0;
            }
        }

        public short Gain
        {
            get
            {
                tl.LogMessage("Gain Get", gainState.ToString());
                return gainState;
            }
            set
            {
                if (cameraSetGain(value) == false)
                {
                    tl.LogMessage("Gain", "Can't set gain to " + value);
                    throw new ASCOM.InvalidValueException("Can't set gain to " + value);
                }

                gainState = value;
                tl.LogMessage("Gain Set", gainState.ToString());
            }
        }

        public short GainMax
        {
            get
            {
                tl.LogMessage("GainMax Get", "63");
                return 64;
            }
        }

        public short GainMin
        {
            get
            {
                tl.LogMessage("GainMin Get", "0");
                return 0;
            }
        }

        public ArrayList Gains
        {
            get
            {
                tl.LogMessage("Gains Get", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("Gains", true);
            }
        }

        public bool HasShutter
        {
            get
            {
                tl.LogMessage("HasShutter Get", false.ToString());
                return false;
            }
        }

        public double HeatSinkTemperature
        {
            get
            {
                tl.LogMessage("HeatSinkTemperature Get", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("HeatSinkTemperature", false);
            }
        }

        public object ImageArray
        {
            get
            {
                int minIntensity = 0;
                int maxIntensity = 0;
                double mean = 0;
                double mean_stdDevLine = 0;
                double exposureDuration = 0;

                double stdDevFrame = 0;
                double stdDevLine = 0;

                if (!cameraImageReady)
                {
                    tl.LogMessage("ImageArray Get", "Throwing InvalidOperationException because of a call to ImageArray before the first image has been taken!");
                    throw new ASCOM.InvalidOperationException("Call to ImageArray before the first image has been taken!");
                }

                uint imagepoint;
                //Get image pointer
                tl.LogMessage("ImageArray Get", "Call cameraGetImage from " + LowLevelDLL);
                imagepoint = cameraGetImage();
                unsafe
                {
                    int* zeropixelpoint, pixelpoint;
                    //Set pixelpointers
                    zeropixelpoint = pixelpoint = (int*)imagepoint;
                    //Create image array
                    cameraImageArray = new int[cameraNumX, cameraNumY];
                    int i, j;
                    int ci, cj;

                    // used for calculation of standard deviation
                    IList<int> dataFrameStdDev = new List<int>();

                    minIntensity = maxPixelADU;
                    maxIntensity = 0;
                    long intensitySum = 0;
                    int pixelCounter = 0;
                    int pixelCounterLine = 0;
                    double M2_frame = 0;
                    double M2_line = 0;
                    if (cameraBinX == 1)
                    {
                        cj = 0;
                        for (j = cameraStartY; j < (cameraStartY + cameraNumY); j++)
                        {
                            ci = 0;
                            for (i = cameraStartX; i < (cameraStartX + cameraNumX); i++)
                            {
                                pixelpoint = (int*)(zeropixelpoint + (j * ccdWidth + i));
                                int intensity = *pixelpoint;
                                cameraImageArray[ci, cj] = intensity;

                                if (intensity > maxPixelADU) intensity = maxPixelADU;

                                if (intensity < minIntensity)
                                    minIntensity = intensity;
                                if (intensity > maxIntensity)
                                    maxIntensity = intensity;

                                intensitySum += intensity;

                                // add new point to the calculation of the standard deviation for the frame
                                pixelCounter++;
                                double delta = (double)intensity - mean;
                                mean += delta / pixelCounter;
                                M2_frame += delta * (intensity - mean);

                                // add new pont to the calculation of the standard deviation for the two middle lines
                                //if ((cj == cameraStartY + cameraNumY / 2) || (cj == cameraStartY + cameraNumY / 2 + 1))
                                if ((cj == 500) || (cj == 501))
                                {
                                    pixelCounterLine++;
                                    delta = (double)intensity - mean_stdDevLine;
                                    mean_stdDevLine += delta / pixelCounterLine;
                                    M2_line += delta * (intensity - mean_stdDevLine);
                                }

                                ci++;
                            }
                            cj++;
                        }
                    }
                    else
                    {
                        cj = 0;
                        for (j = cameraStartY; j < (cameraStartY + cameraNumY); j++)
                        {
                            ci = 0;
                            for (i = cameraStartX; i < (cameraStartX + cameraNumX); i++)
                            {
                                pixelpoint = (int*)(zeropixelpoint + (2 * j * ccdWidth + i * 2));
                                int intensity = *pixelpoint;
                                cameraImageArray[ci, cj] = intensity;

                                if (intensity > maxPixelADU)
                                    intensity = maxPixelADU;

                                if (intensity < minIntensity)
                                    minIntensity = intensity;
                                if (intensity > maxIntensity)
                                    maxIntensity = intensity;

                                intensitySum += intensity;

                                // add new point to the calculation of the standard deviation for the frame
                                pixelCounter++;
                                double delta = (double)intensity - mean;
                                mean += delta / pixelCounter;
                                M2_frame += delta * (intensity - mean);

                                // add new pont to the calculation of the standard deviation for the two middle lines
                                //if ((cj == cameraStartY + cameraNumY / 2) || (cj == cameraStartY + cameraNumY / 2 + 1))
                                if ((cj == 500) || (cj == 501))
                                {
                                    pixelCounterLine++;
                                    delta = (double)intensity - mean_stdDevLine;
                                    mean_stdDevLine += delta / pixelCounterLine++; ;
                                    M2_line += delta * (intensity - mean_stdDevLine);
                                }

                                ci++;
                            }
                            cj++;
                        }
                    }

                    // final calculation of the standard deviation for the two middle lines
                    try
                    {
                        stdDevLine = Math.Sqrt((double)(M2_line / pixelCounterLine));
                    }
                    catch
                    {
                        stdDevLine = 0;
                    }

                    // final calculation of the standard deviation for the frame
                    try
                    {
                        stdDevFrame = Math.Sqrt((double)(M2_frame / pixelCounter));
                    }
                    catch
                    {
                        stdDevFrame = 0;
                    }
                }

                exposureStopTimestamp = DateTime.Now;
                exposureDuration = (exposureStopTimestamp - exposureStartTimestamp).TotalSeconds;
                
                if (setupForm != null)
                {
                    /* moved inline to the frame reading code
                     * to speed up calculations
                     * 
                    // calculate the standard deviation of a line
                    //for x:= 0 to 2 * Width - 1 do tts[x]:= bufim[x + 500 * Width];
                    //skv2:= PopnStdDev(tts);
                    IList<int> dataLineStdDev = new List<int>();
                    for (int y = 0; y < 2; y++) // we will loop 2 rows starting at 500 (why 500, probably it does not matter, may be the centre of the image???)
                    {
                        for (int x = 0; x < cameraNumX; x++) // loop all columns for the two rows
                            dataLineStdDev.Add(cameraImageArray[x, 500 + y]);
                    }
                    double lineStdDev = 0;
                    try
                    {
                        lineStdDev = Math.Sqrt(VarianceP(dataLineStdDev));
                    }
                    catch
                    {
                        lineStdDev = 0;
                    }
                    */

                    /* moved inline to the frame reading code
                     * to speed up calculations
                     * 
                    // calculate the standard deviation of the frame.
                    // for x:= 0 to Width * Height - 1 do tts[x]:= bufim[x];
                    // skv:= PopnStdDev(tts);
                    IList<int> dataFrameStdDev = new List<int>();
                    for (int y = 0; y < cameraNumY; y++) //loop all rows
                    {
                        for (int x = 0; x < cameraNumX; x++) // loop all columns
                            dataFrameStdDev.Add(cameraImageArray[x, y]);
                    }
                    double frameStdDev = 0;
                    elapsed1 = DateTime.Now - start;
                    try
                    {
                        frameStdDev = Math.Sqrt(VarianceP(dataFrameStdDev));
                    }
                    catch
                    {
                        frameStdDev = 0;
                    }
                    */
                    
                    setupForm.updateInfoLabels(minIntensity, maxIntensity, mean, exposureDuration, stdDevLine, stdDevFrame);
                }

                // set any parameters that have changed recently
                updateCameraParametersEvent(this, null);

                return cameraImageArray;
            }
        }

        public object ImageArrayVariant
        {
            get
            {
                if (!cameraImageReady)
                {
                    tl.LogMessage("ImageArrayVariant Get", "Throwing InvalidOperationException because of a call to ImageArrayVariant before the first image has been taken!");
                    throw new ASCOM.InvalidOperationException("Call to ImageArrayVariant before the first image has been taken!");
                }
                tl.LogMessage("ImageArrayVariant Get", "Call ImageArray method");

                this.cameraimageArrayVariant = new object[cameraNumX, cameraNumY];
                for (int i = 0; i < this.cameraNumY; i++)
                {
                    for (int j = 0; j < this.cameraNumX; j++)
                    {
                        cameraimageArrayVariant[j, i] = this.cameraImageArray[j, i];
                    }

                }

                return cameraimageArrayVariant;
            }
        }

        public bool ImageReady
        {
            get
            {
                tl.LogMessage("ImageReady Get", "Call cameraGetImageReady from " + LowLevelDLL);
                cameraImageReady = cameraGetImageReady();
                tl.LogMessage("ImageReady Get", cameraImageReady.ToString());
                return cameraImageReady;
            }
        }

        public bool IsPulseGuiding
        {
            get
            {
                tl.LogMessage("IsPulseGuiding Get", "false");
                return false;
            }
        }

        public double LastExposureDuration
        {
            get
            {
                if (!cameraImageReady)
                {
                    tl.LogMessage("LastExposureDuration Get", "Throwing InvalidOperationException because of a call to LastExposureDuration before the first image has been taken!");
                    throw new ASCOM.InvalidOperationException("Call to LastExposureDuration before the first image has been taken!");
                }
                tl.LogMessage("LastExposureDuration Get", cameraLastExposureDuration.ToString());
                return cameraLastExposureDuration;
            }
        }

        public string LastExposureStartTime
        {
            get
            {
                if (!cameraImageReady)
                {
                    tl.LogMessage("LastExposureStartTime Get", "Throwing InvalidOperationException because of a call to LastExposureStartTime before the first image has been taken!");
                    throw new ASCOM.InvalidOperationException("Call to LastExposureStartTime before the first image has been taken!");
                }
                string exposureStartString = exposureStart.ToString("yyyy-MM-ddTHH:mm:ss");
                tl.LogMessage("LastExposureStartTime Get", exposureStartString.ToString());
                return exposureStartString;
            }
        }

        public int MaxADU
        {
            get
            {
                tl.LogMessage("MaxADU Get", maxPixelADU.ToString());
                return maxPixelADU;
            }
        }

        public short MaxBinX
        {
            get
            {
                tl.LogMessage("MaxBinX Get", "2");
                return 2;
            }
        }

        public short MaxBinY
        {
            get
            {
                tl.LogMessage("MaxBinY Get", "2");
                return 2;
            }
        }

        public int NumX
        {
            get
            {
                tl.LogMessage("NumX Get", cameraNumX.ToString());
                return cameraNumX;
            }
            set
            {
                tl.LogMessage("NumX set", value.ToString());
                cameraNumX = value;
            }
        }

        public int NumY
        {
            get
            {
                tl.LogMessage("NumY Get", cameraNumY.ToString());
                return cameraNumY;
            }
            set
            {
                tl.LogMessage("NumY set", value.ToString());
                cameraNumY = value;
            }
        }

        public short PercentCompleted
        {
            get
            {
                if (CameraState == CameraStates.cameraExposing || CameraState == CameraStates.cameraReading)
                {
                    double elapsed_time = (DateTime.Now - exposureStartTimestamp).TotalSeconds;
                    double total_duration = cameraLastExposureDuration; // use only exposure duration // + 2 + readingTimeState/10; // this is a rough estimate. The frame reading time is about 2s + delays.
                    short percentage = (short) (elapsed_time / total_duration *100.0);
                    
                    // boundary checks
                    if (percentage < 0)
                        percentage = 0;
                    if (percentage > 100)
                        percentage = 100;

                    tl.LogMessage("PercentCompleted Get", percentage.ToString());
                    return percentage;
                }
                else
                {
                    tl.LogMessage("PercentCompleted Get", "Throwing InvalidOperationException because PercentCompleted Get called when camera not exposing or reading");
                    throw new ASCOM.InvalidOperationException("PercentCompleted");
                }
            }
        }

        public double PixelSizeX
        {
            get
            {
                tl.LogMessage("PixelSizeX Get", pixelSize.ToString());
                return pixelSize;
            }
        }

        public double PixelSizeY
        {
            get
            {
                tl.LogMessage("PixelSizeY Get", pixelSize.ToString());
                return pixelSize;
            }
        }

        public void PulseGuide(GuideDirections Direction, int Duration)
        {
            tl.LogMessage("PulseGuide", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("PulseGuide");
        }

        public short ReadoutMode
        {
            get
            {
                tl.LogMessage("ReadoutMode Get", "0");
                return 0;
            }
            set
            {
                if (value != 0)
                {
                    tl.LogMessage("ReadoutMode Set", "Throwing InvalidValueException ReadoutMode must be 0");
                    throw new ASCOM.InvalidValueException("ReadoutMode");
                }
                // we only support mode 0 (standard) so do nothing
                tl.LogMessage("ReadoutMode Set", "0");
            }
        }

        public ArrayList ReadoutModes
        {
            get
            {
                ArrayList al = new ArrayList();
                al.Add("Standard");
                tl.LogMessage("ReadoutModes Get", al.ToString());
                return al;
            }
        }

        public string SensorName
        {
            get
            {
                tl.LogMessage("SensorName Get", "ICX453AQ");
                return "ICX453AQ";
            }
        }

        public SensorType SensorType
        {
            get
            {
                if (monoSensorState)
                {
                    tl.LogMessage("SensorType Get", "SensorType.Monochrome");
                    return SensorType.Monochrome;
                }

                tl.LogMessage("SensorType Get", "SensorType.RGGB");
                return SensorType.RGGB;
            }
        }

        public double SetCCDTemperature
        {
            get
            {
                double temp = cameraGetSetTemp();

                if (setupForm != null)
                    setupForm.setCCDTemperature = temp;

                tl.LogMessage("SetCCDTemperature Get", temp.ToString());
                return temp;
            }
            set
            {
                tl.LogMessage("SetCCDTemperature Set", value.ToString());

                if (setupForm != null)
                    setupForm.setCCDTemperature = value;

                if ((value < MinSetTemp) || (value > MaxSetTemp))
                {
                    tl.LogMessage("SetCCDTemperature Set", "InvalidValueException SetCCDTemperature must be in range [minSetTemp;maxSetTemp]");
                    throw new InvalidValueException("SetCCDTemperature Set", value.ToString(), "SetCCDTemperature must be in range [-50;50]");
                }

                if ((slowCoolingEnabledState) && (this.CoolerOn))
                {
                    tl.LogMessage("SetCCDTemperature Set", "start slow cooling with step size=" + (slowCoolingSpeedState).ToString());
                    slowCoolingTarger = value;
                    slowCoolingInterm = this.CCDTemperature;
                    if ((this.CCDTemperature - value) > 0)
                    {
                        slowCoolingCoolingDirection = true;
                        slowCoolingTimer.Enabled = true;
                    }
                    else if ((this.CCDTemperature - value) < 0)
                    {
                        slowCoolingCoolingDirection = false;
                        slowCoolingTimer.Enabled = true;
                    }
                    else
                    {
                        slowCoolingTimer.Enabled = false;
                        cameraSetTemp(value);
                    }
                }
                else
                {
                    cameraSetTemp(value);
                }
            }
        }

        private static void slowCoolingTimerTick(Object source, ElapsedEventArgs e)
        {
            if (slowCoolingTimer.Enabled && slowCoolingEnabledState)
            {
                tl.LogMessage("slowCoolingTimerTick", "slowCoolingInterm=" + slowCoolingInterm.ToString() + " step size=" + (slowCoolingSpeedState).ToString());
                if (slowCoolingCoolingDirection)
                {
                    slowCoolingInterm -= (slowCoolingSpeedState);
                    if (slowCoolingInterm <= slowCoolingTarger)
                    {
                        slowCoolingInterm = slowCoolingTarger;
                    }
                }
                else
                {
                    slowCoolingInterm += (slowCoolingSpeedState);
                    if (slowCoolingInterm >= slowCoolingTarger)
                    {
                        slowCoolingInterm = slowCoolingTarger;
                    }
                }
                cameraSetTemp(slowCoolingInterm);
                if (System.Math.Abs(slowCoolingInterm - slowCoolingTarger) <= 0.01)
                {
                    slowCoolingTimer.Enabled = false;
                }
            }
        }

        public void StartExposure(double Duration, bool Light)
        {
            tl.LogMessage("StartExposure", "Duration=" + Duration.ToString() + " Light=" + Light.ToString());

            //check exposure parameters
            // cameraNumX
            if (cameraNumX < 0 || cameraNumX > ccdWidth/cameraBinX)
            {
                tl.LogMessage("StartExposure", "InvalidValueException cameraNumX must be > 0 and < (ccdWidth / cameraBinX)");
                throw new InvalidValueException("StartExposure", cameraNumX.ToString(), "cameraNumX must be < (ccdWidth / cameraBinX)");
            }

            // cameraNumY
            if (cameraNumY < 0 || cameraNumY > ccdHeight / cameraBinY)
            {
                tl.LogMessage("StartExposure", "InvalidValueException cameraNumY must be > 0 and < (ccdHeight / cameraBinY)");
                throw new InvalidValueException("StartExposure", cameraNumY.ToString(), "cameraNumY must be < (ccdHeight / cameraBinY)");
            }

            // cameraStartX
            if ((cameraStartX < 0) || (cameraStartX >= (ccdWidth / cameraBinX)))
            {
                tl.LogMessage("StartExposure", "InvalidValueException cameraStartX must be > 0 and < (ccdWidth / cameraBinX)");
                throw new InvalidValueException("StartExposure", cameraStartX.ToString(), "cameraStartX must be > 0 and < (ccdWidth / cameraBinX)");
            }

            // cameraStartY
            if ((cameraStartY < 0) || (cameraStartY >= (ccdHeight / cameraBinY)))
            {
                tl.LogMessage("StartExposure", "InvalidValueException cameraStartY must be > 0 and < (ccHeight / cameraBinY)");
                throw new InvalidValueException("StartExposure", cameraStartY.ToString(), "cameraStartY must be > 0 and < (ccHeight / cameraBinY)");
            }

            
            // image size
            if ((cameraStartX + cameraNumX) > (ccdWidth / cameraBinX))
            {
                tl.LogMessage("StartExposure", "InvalidValueException (cameraStartX + cameraNumX) must be < {ccdWidth / cameraBinX}");
                throw new InvalidValueException("StartExposure", (cameraStartX + cameraNumX).ToString(), "(cameraStartX + cameraNumX) must be < (ccdWidth / cameraBinX)");
            }
            if ((cameraStartY + cameraNumY) > (ccdHeight / cameraBinY))
            {
                tl.LogMessage("StartExposure", "InvalidValueException (cameraStartY + cameraNumY) must be < (ccdHeight / cameraBinY)");
                throw new InvalidValueException("StartExposure", (cameraStartY + cameraNumY).ToString(), "(cameraStartY + cameraNumY) must be < (ccdHeight / cameraBinY)");
            }

            // binning
            if ((cameraBinX < 1) || (cameraBinX > this.MaxBinX))
            {
                tl.LogMessage("StartExposure", "InvalidValueException BinX must be in range [1;MaxBinX]");
                throw new InvalidValueException("StartExposure", BinX.ToString(), "BinX must be in range [1;MaxBinX]");
            }
            if ((cameraBinY < 1) || (cameraBinY > this.MaxBinY))
            {
                tl.LogMessage("StartExposure", "InvalidValueException BinY must be in range [1;MaxBinY]");
                throw new InvalidValueException("StartExposure", BinY.ToString(), "BinY must be in range [1;MaxBinY]");
            }
            if (cameraBinX != cameraBinY)
            {
                tl.LogMessage("StartExposure", "InvalidOperationException BinX and BinY are not the same");
                throw new InvalidOperationException("StartExposure, BinX and BinY are not the same");
            }

            // duration
            if ((Duration < ExposureMin) || (Duration > ExposureMax))
            {
                tl.LogMessage("StartExposure", "InvalidValueException Duration must be in range [MinExposure;MaxExposure]");
                throw new InvalidValueException("StartExposure", Duration.ToString(), "Duration must be in range [MinExposure;MaxExposure]");
            }

            // light frames must have exposure > 0
            // dark (or bias) do not have to 
            if (Light && Duration == 0)
            {
                tl.LogMessage("StartExposure", "InvalidValueException Duration for light frame must be > 0");
                throw new InvalidValueException("StartExposure", Duration.ToString(), "Duration for light frame must be > 0");
            }


            // set if sensor needs to be cleared (bias taken) before the exposure
            if (sensorClearBeforeExposureTimeState < Duration)
            {
                tl.LogMessage("StartExposure", "Call cameraSetBiasBeforeExposure from " + LowLevelDLL + " args: value=" + (sensorClearBeforeExposureTimeState < Duration ? (byte)1 : (byte)0).ToString());
                if (cameraSetBiasBeforeExposure(sensorClearBeforeExposureTimeState < Duration ? (byte)1 : (byte)0) == false)
                {
                    tl.LogMessage("StartExposure", "Can't set sensor clearing before exposure (bias before exposure) to " + this.Name);
                    throw new ASCOM.InvalidOperationException("Can't set sensor clearing before exposure (bias before exposure) to " + this.Name);
                }
            }


            // set any parameters that have changed recently
            updateCameraParametersEvent(this, null);


            //settle delay
            Thread.Sleep(100);

            //Save parameters
            cameraLastExposureDuration = Duration;
            exposureStart = DateTime.Now;
            
            // note the time for the later calculation
            exposureStartTimestamp = DateTime.Now;

            //start exposure
            tl.LogMessage("StartExposure", "Call cameraStartExposure from " + LowLevelDLL + " args: ");
            tl.LogMessage("StartExposure", " cameraBinX=" + cameraBinX.ToString() +
                                           " cameraStartX=" + cameraStartX.ToString() +
                                           " cameraStartY=" + cameraStartY.ToString() +
                                           " cameraNumX=" + cameraNumX.ToString() +
                                           " cameraNumY=" + cameraNumY.ToString() +
                                           " Duration=" + Duration.ToString() +
                                           " Light=" + Light.ToString());
            cameraStartExposure((int)cameraBinX, cameraStartX * cameraBinX, cameraStartY * cameraBinY, cameraNumX * cameraBinX, cameraNumY * cameraBinY, Duration, Light);
        }

        public int StartX
        {
            get
            {
                tl.LogMessage("StartX Get", cameraStartX.ToString());
                return cameraStartX;
            }
            set
            {
                tl.LogMessage("StartX Set", value.ToString());
                cameraStartX = value;
            }
        }

        public int StartY
        {
            get
            {
                tl.LogMessage("StartY Get", cameraStartY.ToString());
                return cameraStartY;
            }
            set
            {
                tl.LogMessage("StartY set", value.ToString());
                cameraStartY = value;
            }
        }

        public void StopExposure()
        {
            tl.LogMessage("StopExposure", "Aborting exposure, call cameraStopExposure from " + LowLevelDLL);
            if (cameraStopExposure() == false)
            {
                tl.LogMessage("StopExposure", "PropertyNotImplementedException Stop Exposure failed");
                throw new ASCOM.PropertyNotImplementedException("Stop Exposure failed");
            }
        }
        #endregion

        #region Private properties and methods
        // here are some useful properties and methods that can be used as required
        // to help with driver development

        #region ASCOM Registration

        // Register or unregister driver for ASCOM. This is harmless if already
        // registered or unregistered. 
        //
        /// <summary>
        /// Register or unregister the driver with the ASCOM Platform.
        /// This is harmless if the driver is already registered/unregistered.
        /// </summary>
        /// <param name="bRegister">If <c>true</c>, registers the driver, otherwise unregisters it.</param>
        private static void RegUnregASCOM(bool bRegister)
        {
            using (var P = new ASCOM.Utilities.Profile())
            {
                P.DeviceType = "Camera";
                if (bRegister)
                {
                    P.Register(driverID, driverDescription);
                }
                else
                {
                    P.Unregister(driverID);
                }
            }
        }

        /// <summary>
        /// This function registers the driver with the ASCOM Chooser and
        /// is called automatically whenever this class is registered for COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is successfully built.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During setup, when the installer registers the assembly for COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually register a driver with ASCOM.
        /// </remarks>
        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            RegUnregASCOM(true);
        }

        /// <summary>
        /// This function unregisters the driver from the ASCOM Chooser and
        /// is called automatically whenever this class is unregistered from COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is cleaned or prior to rebuilding.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During uninstall, when the installer unregisters the assembly from COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually unregister a driver from ASCOM.
        /// </remarks>
        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            RegUnregASCOM(false);
        }

        #endregion

        /// <summary>
        /// Returns true if there is a valid connection to the driver hardware
        /// </summary>
        private bool IsConnected
        {
            get
            {
                tl.LogMessage("IsConnected Get", "Call cameraIsConnected from " + LowLevelDLL);
                cameraConnectedState = cameraIsConnected();
                tl.LogMessage("IsConnected Get", "connectedState=" + cameraConnectedState.ToString());
                return cameraConnectedState;
            }
        }

        /// <summary>
        /// Use this function to throw an exception if we aren't connected to the hardware
        /// </summary>
        /// <param name="message"></param>
        private void CheckConnected(string message)
        {
            if (!IsConnected)
            {
                tl.LogMessage("CheckConnected", "connectedState=false" + message);
                throw new ASCOM.NotConnectedException(message);
            }
        }

        /// <summary>
        /// Read the device configuration from the ASCOM Profile store
        /// </summary>
        internal void ReadProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Camera";
                traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, string.Empty, traceStateDefault));
                gainState = Convert.ToInt16(driverProfile.GetValue(driverID, gainStateProfileName, string.Empty, gainStateDefault));
                offsetState = Convert.ToInt16(driverProfile.GetValue(driverID, offsetStateProfileName, string.Empty, offsetStateDefault));
                readingTimeState = Convert.ToInt16(driverProfile.GetValue(driverID, readingTimeStateProfileName, string.Empty, readingTimeStateDefault));
                onTopState = Convert.ToBoolean(driverProfile.GetValue(driverID, onTopStateProfileName, string.Empty, onTopStateDefault));
                slowCoolingEnabledState = Convert.ToBoolean(driverProfile.GetValue(driverID, slowCoolingEnabledProfileName, string.Empty, slowCoolingEnabledStateDefault));
                slowCoolingSpeedState = Convert.ToInt16(driverProfile.GetValue(driverID, slowCoolingSpeedProfileName, string.Empty, slowCoolingSpeedStateDefault));
                coolerDuringReadingState = Convert.ToBoolean(driverProfile.GetValue(driverID, TECduringReadingProfileName, string.Empty, coolerDuringReadingStateDefault));
                monoSensorState = Convert.ToBoolean(driverProfile.GetValue(driverID, monoSensorProfileName, string.Empty, monoSensorStateDefault));
                sensorClearBeforeExposureTimeState = Convert.ToUInt16(driverProfile.GetValue(driverID, sensorClearBeforeExposureTimeProfileName, string.Empty, sensorClearBeforeExposureTimeDefault));
                nightModeSettingsState = Convert.ToBoolean(driverProfile.GetValue(driverID, nightModeSettingsProfileName, string.Empty, nightModeSettingsDefault));
                coolingMaxPowerPercentState = Convert.ToInt16(driverProfile.GetValue(driverID, TECcoolingMaxPowerPercentProfileName, string.Empty, TECcoolingMaxPowerPercentDefault));
                coolingStartingPowerPercentState = Convert.ToInt16(driverProfile.GetValue(driverID, TECcoolingStartingPowerPercentProfileName, string.Empty, TECcoolingStartingPowerPercentDefault));
                settingsWindowOpenOnConnectState = Convert.ToBoolean(driverProfile.GetValue(driverID, settingsWindowOpenOnConnectProfileName, string.Empty, settingsWindowOpenOnConnectDefault));
                settingsWindowSizeState = (settingsWindowSizeE) Enum.Parse(typeof(settingsWindowSizeE), driverProfile.GetValue(driverID, settingsWindowSizeProfileName, string.Empty, settingsWindowSizeDefault));
                
                bool Kp_valid = Double.TryParse(driverProfile.GetValue(driverID, PIDproportionalGainProfileName, string.Empty, PIDproportionalGainDefault), out PIDproportionalGainState);
                if (!Kp_valid)
                    PIDproportionalGainState = Convert.ToDouble(PIDproportionalGainDefault);
                bool Ki_valid = Double.TryParse(driverProfile.GetValue(driverID, PIDintegralGainProfileName, string.Empty, PIDintegralGainDefault), out PIDintegralGainState);
                if (!Ki_valid)
                    PIDintegralGainState = Convert.ToDouble(PIDintegralGainDefault);
                bool Kd_valid = Double.TryParse(driverProfile.GetValue(driverID, PIDderivativeGainProfileName, string.Empty, PIDderivativeGainDefault), out PIDderivativeGainState);
                if (!Kd_valid)
                    PIDderivativeGainState = Convert.ToDouble(PIDderivativeGainDefault);

                // need to extract the window coordinates first
                string[] windowLocation = (driverProfile.GetValue(driverID, settingsWindowLocationProfileName, string.Empty, settingsWindowLocationDefault)).Split(',');
                settingsWindowLocationState = new System.Drawing.Point(int.Parse(windowLocation[0]), int.Parse(windowLocation[1]));

                DHT22presentState = Convert.ToBoolean(driverProfile.GetValue(driverID, DHT22presentProfileName, string.Empty, DHT22presentDefault));
                
            }
        }

        /// <summary>
        /// Write the device configuration to the  ASCOM  Profile store
        /// </summary>
        internal void WriteProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Camera";
                driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString());
                driverProfile.WriteValue(driverID, gainStateProfileName, gainState.ToString());
                driverProfile.WriteValue(driverID, offsetStateProfileName, offsetState.ToString());
                driverProfile.WriteValue(driverID, readingTimeStateProfileName, readingTimeState.ToString());
                driverProfile.WriteValue(driverID, onTopStateProfileName, onTopState.ToString());
                driverProfile.WriteValue(driverID, slowCoolingEnabledProfileName, slowCoolingEnabledState.ToString());
                driverProfile.WriteValue(driverID, slowCoolingSpeedProfileName, slowCoolingSpeedState.ToString());
                driverProfile.WriteValue(driverID, TECduringReadingProfileName, coolerDuringReadingState.ToString());
                driverProfile.WriteValue(driverID, monoSensorProfileName, monoSensorState.ToString());
                driverProfile.WriteValue(driverID, sensorClearBeforeExposureTimeProfileName, sensorClearBeforeExposureTimeState.ToString());
                driverProfile.WriteValue(driverID, nightModeSettingsProfileName, nightModeSettingsState.ToString());
                driverProfile.WriteValue(driverID, TECcoolingMaxPowerPercentProfileName, coolingMaxPowerPercentState.ToString());
                driverProfile.WriteValue(driverID, TECcoolingStartingPowerPercentProfileName, coolingStartingPowerPercentState.ToString());
                driverProfile.WriteValue(driverID, settingsWindowOpenOnConnectProfileName, settingsWindowOpenOnConnectState.ToString());
                driverProfile.WriteValue(driverID, settingsWindowSizeProfileName, settingsWindowSizeState.ToString());
                driverProfile.WriteValue(driverID, settingsWindowLocationProfileName, settingsWindowLocationState.X + "," + settingsWindowLocationState.Y);
                driverProfile.WriteValue(driverID, PIDproportionalGainProfileName, PIDproportionalGainState.ToString());
                driverProfile.WriteValue(driverID, PIDintegralGainProfileName, PIDintegralGainState.ToString());
                driverProfile.WriteValue(driverID, PIDderivativeGainProfileName, PIDderivativeGainState.ToString());
                driverProfile.WriteValue(driverID, DHT22presentProfileName, DHT22presentState.ToString());

            }
        }

        /// <summary>
        /// Computes the population Variance of a sequence of int values.
        /// </summary>
        /// <param name="source">A sequence of int values to calculate the population Variance of.</param>
        /// <returns>       
        ///     The Variance of the sequence of values.
        /// </returns>
        private double VarianceP(IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            long n = 0;
            double mean = 0;
            double M2 = 0;

            checked
            {
                foreach (var x in source)
                {
                    n++;

                    double delta = (double)x - mean;
                    mean += delta / n;
                    M2 += delta * ((double)x - mean);
                }
            }

            if (n < 1)
                throw new InvalidOperationException("source sequence contains no elements");

            return (double)(M2 / n);
        }

        private void updateDHTSensorInfo()
        {
            if (DHT22presentState)
            {
                tl.LogMessage("updateDHTSensorInfo (not ASCOM function)", "Call cameraGetHum and cameraGetTempDHT from " + LowLevelDLL);
                setupForm.updateDHTinfoLabels(cameraGetHumidityDHT(), cameraGetTempDHT());
            }
            else
            {
                tl.LogMessage("updateDHTSensorInfo (not ASCOM function)", "Call updateDHTSensorInfo while sensor is disabled in settings");
            }
        }

        private void OnDHTTimedEvent(object source, ElapsedEventArgs e)
        {
            // sanity check
            if (!cameraConnectedState)
            {
                DHTTimer.Enabled = false;
                return;
            }

            // update only if the data needs to be displayed
            if (setupForm != null)
            {
                if (DHT22presentState)
                    updateDHTSensorInfo();
            }
        }

        private void updateCameraParametersEvent(Object sender, EventArgs e)
        {
            bool updateProfile = false;

            // only update parameters if the camera is connected
            if (!cameraIsConnected())
                return;

            // do not apply any changes if camera is busy exposing, reading or download (the latter can lead to data corruption)
            CameraStates state = (CameraStates) cameraGetCameraState();
            if ((state == CameraStates.cameraExposing) || (state == CameraStates.cameraReading) || (state == CameraStates.cameraDownload))
                return;


            if (gainStateDirty)
            {
                if (cameraSetGain(gainState))
                {
                    gainStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "Gain set to " + gainState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set gain to " + gainState);
                    //throw new ASCOM.InvalidOperationException("Can't set gain to " + gainState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (offsetStateDirty)
            {
                if (cameraSetOffset(offsetState))
                {
                    offsetStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "Offset set to " + offsetState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set offset to " + offsetState);
                    //throw new ASCOM.InvalidOperationException("Can't set offset to " + offsetState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (readingTimeStateDirty)
            {
                if (cameraSetReadingTime(readingTimeState))
                {
                    readingTimeStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "Reading delay set to " + readingTimeState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set reading delay to " + readingTimeState);
                    //throw new ASCOM.InvalidOperationException("Can't set reading delay to " + readingTimeState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (coolerDuringReadingStateDirty)
            {
                if (cameraSetCoolerDuringReading(coolerDuringReadingState ? (byte)1 : (byte)0))
                {
                    coolerDuringReadingStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "'TEC during reading' set to " + coolerDuringReadingState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set 'TEC during reading' to " + coolerDuringReadingState);
                    //throw new ASCOM.InvalidOperationException("Can't set 'TEC during reading' to " + TECduringReadingState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (monoSensorStateDirty)
            {
                tl.LogMessage("updateCameraParametersEvent", "Mono sensor set to " + monoSensorState);
                monoSensorStateDirty = false;

                updateProfile = true;
            }

            if (onTopStateDirty)
            {
                tl.LogMessage("updateCameraParametersEvent", "On top set to " + onTopState);
                onTopStateDirty = false;

                updateProfile = true;
            }

            if (nightModeSettingsStateDirty)
            {
                tl.LogMessage("updateCameraParametersEvent", "Night mode set to " + nightModeSettingsState);
                nightModeSettingsStateDirty = false;

                updateProfile = true;
            }


            if (coolingStartingPowerPercentStateDirty)
            {
                if (cameraSetCoolingStartingPowerPercentage(coolingStartingPowerPercentState))
                {
                    coolingStartingPowerPercentStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "TEC starting power set to " + coolingStartingPowerPercentState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set TEC starting power to " + coolingStartingPowerPercentState);
                    //throw new ASCOM.InvalidOperationException("Can't set 'TEC during reading' to " + TECduringReadingState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (coolingMaxPowerPercentStateDirty)
            {
                if (cameraSetCoolingMaximumPowerPercentage(coolingMaxPowerPercentState))
                {
                    coolingMaxPowerPercentStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "TEC max power set to " + coolingMaxPowerPercentState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set TEC max power to to " + coolingMaxPowerPercentState);
                    //throw new ASCOM.InvalidOperationException("Can't set 'TEC during reading' to " + TECduringReadingState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (slowCoolingEnabledStateDirty)
            {
                // if cooler is on then reset it to set the slow cooling
                if (CoolerOn)
                {
                    SetCCDTemperature = CCDTemperature;
                }

                slowCoolingEnabledStateDirty = false;
                updateProfile = true;
            }
            
            if (settingsWindowLocationStateDirty)
            {
                settingsWindowLocationStateDirty = false;
                updateProfile = true;
            }

            if (settingsWindowOpenOnConnectStateDirty)
            {
                settingsWindowOpenOnConnectStateDirty = false;
                updateProfile = true;
            }

            if (settingsWindowSizeStateDirty)
            {
                settingsWindowSizeStateDirty = false;
                updateProfile = true;
            }

            if (PIDproportionalGainStateDirty)
            {
                if (cameraSetPIDproportionalGain(PIDproportionalGainState))
                {
                    PIDproportionalGainStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "PID Kp set to " + PIDproportionalGainState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set PID Kp to " + PIDproportionalGainState);
                    //throw new ASCOM.InvalidOperationException("Can't set 'cameraSetPIDproportionalGain' to " + PIDproportionalGainState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (PIDintegralGainStateDirty)
            {
                if (cameraSetPIDintegralGain(PIDintegralGainState))
                {
                    PIDintegralGainStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "PID Ki set to " + PIDintegralGainState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set PID Ki to " + PIDintegralGainState);
                    //throw new ASCOM.InvalidOperationException("Can't set 'cameraSetPIDintegralGain' to " + PIDintegralGainState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (PIDderivativeGainStateDirty)
            {
                if (cameraSetPIDderivativeGain(PIDderivativeGainState))
                {
                    PIDderivativeGainStateDirty = false;
                    tl.LogMessage("updateCameraParametersEvent", "PID Kd set to " + PIDderivativeGainState);
                }
                else
                {
                    tl.LogMessage("updateCameraParametersEvent", "Can't set PID Kd to " + PIDderivativeGainState);
                    //throw new ASCOM.InvalidOperationException("Can't set 'cameraSetPIDderivativeGain' to " + PIDderviativeGainState);
                }

                // do we need to have a small delay during the startup time?
                if (cameraStartingUp)
                    System.Threading.Thread.Sleep(startUpDelay);

                updateProfile = true;
            }

            if (tempCCDTempDirty)
            {
                this.SetCCDTemperature = tempCCDTemp;
                tempCCDTempDirty = false;
            }

            if (DHT22presentStateDirty)
            {
                // start DHT timer to update humidity/temperature reading
                if (DHT22presentState)
                    DHTTimer.Enabled = true;
                else
                    DHTTimer.Enabled = false;

                DHT22presentStateDirty = false;
                tl.LogMessage("updateCameraParametersEvent", "DHT22 sensor is set to " + DHT22presentState.ToString());

                updateProfile = true;
            }
            
            if (updateProfile)
                WriteProfile();
        }

        #endregion

    }
}
