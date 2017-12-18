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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using FTD2XX_NET;

namespace ASCOM.cam86
{
    enum settingsWindowSizeE
    {
        cameraOff,
        cameraOnNoOptions,
        cameraOnFullOptions,
    }

    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        public event EventHandler updateMainFormCameraParameters;

        public bool cameraConnected = false;

        // we need to prevent numericUpDown controls from sending all values to the camera, for example if a button up or down is being held.
        // we will use timers to delay sending of the value
        private const short timerIntervals = 250; // send value to camera if the value has not been changed for 250ms
        private System.Timers.Timer timerGain;
        private System.Timers.Timer timerOffset;
        private System.Timers.Timer timerReadTime;
        private System.Timers.Timer timerCoolingStartingPowerPercent;
        private System.Timers.Timer timerCoolingMaximumPowerPercent;
        private System.Timers.Timer timerPIDproportionalGain;
        private System.Timers.Timer timerPIDintegralGain;
        private System.Timers.Timer timerPIDderivativeGain;
        private decimal tempGain;
        private decimal tempOffset;
        private decimal tempReadTime;
        private decimal tempCoolingStartingPowerPercent;
        private decimal tempCoolingMaximumPowerPercent;
        private decimal tempPIDproportionalGain;
        private decimal tempPIDintegralGain;
        private decimal tempPIDderivativeGain;
        private const int invalidValue = -10000;

        private double tempCCDbackup = 0;
        private double dewPointBackup = 0;
        private string backuplabelVersionInformation = "";

        private double ccdTemp = 0;

        private settingsWindowSizeE windowSize = settingsWindowSizeE.cameraOnFullOptions;

        void timerGainElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempGain != invalidValue)
            {
                Camera.gainState = (short)gainNumUpDown.Value;
                Camera.gainStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempGain = invalidValue;
            }
        }

        void timerOffsetElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempOffset != invalidValue)
            {
                Camera.offsetState = (short)offsetNumUpDown.Value;
                Camera.offsetStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempOffset = invalidValue;
            }
        }

        void timerReadTimeElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempReadTime != invalidValue)
            {
                Camera.readingTimeState = (short)numericUpDownReadingTime.Value;
                Camera.readingTimeStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempReadTime = invalidValue;
            }
        }

        void timerCoolingStartingPowerPercentElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempCoolingStartingPowerPercent != invalidValue)
            {
                Camera.coolingStartingPowerPercentState = (short)numericUpDownTECstartupPowerPercent.Value;
                Camera.coolingStartingPowerPercentStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempCoolingStartingPowerPercent = invalidValue;
            }
        }

        void timerCoolingMaximumPowerPercentElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempCoolingMaximumPowerPercent != invalidValue)
            {
                Camera.coolingMaxPowerPercentState = (short)numericUpDownTECmaximumPowerPercent.Value;
                Camera.coolingMaxPowerPercentStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempCoolingMaximumPowerPercent = invalidValue;
            }
        }

        void timerPIDproportionalGainElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempPIDproportionalGain != invalidValue)
            {
                Camera.PIDproportionalGainState = (double)numericUpDownPIDKp.Value;
                Camera.PIDproportionalGainStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempPIDproportionalGain = invalidValue;
            }
        }

        void timerPIDintegralGainElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempPIDintegralGain != invalidValue)
            {
                Camera.PIDintegralGainState = (double)numericUpDownPIDKi.Value;
                Camera.PIDintegralGainStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempPIDintegralGain = invalidValue;
            }
        }

        void timerPIDderivativeGainElapsedHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tempPIDderivativeGain != invalidValue)
            {
                Camera.PIDderivativeGainState = (double)numericUpDownPIDKd.Value;
                Camera.PIDderivativeGainStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);

                tempPIDderivativeGain = invalidValue;
            }
        }

        public void updateInfoLabels(int minIntensity, int maxIntensity, double exposureDuration, double stdDevLine, double stdDevFrame)
        {
            labelMinMaxIntensities.Text = "Min=" + minIntensity.ToString() + ", Max=" + maxIntensity.ToString();
            labelExposureDuration.Text = "Time:" + exposureDuration.ToString("F2") + "s";
            labelStdDev.Text = "StdDev L=" + stdDevLine.ToString("F1") + ", F=" + stdDevFrame.ToString("F1");
        }

        public void updateDHTinfoLabels(double humidity, double temperature)
        {
            if (temperature == -127.0)
            { 
                labelDHTinfo.Text = "DHT: no sensor";

                labelVersionInformation.Text = backuplabelVersionInformation;
               
                return;
            }

            const double a = 17.27;
            const double b = 237.7;
            double dewpoint = 0;

            if (temperature > 100 || temperature < -80)
            {
                labelDHTinfo.Text = "DHT: bad sensor reading";

                labelVersionInformation.Text = backuplabelVersionInformation;

                return;
            }

            // calculate dew point
            if (humidity > 0)
            {
                double c = Math.Log(humidity / 100) + a * temperature / (b + temperature);
                dewpoint = b * c / (a - c);
            }

            if (humidity < 0 || humidity > 100)
            {
                labelDHTinfo.Text = "DHT: bad sensor reading";

                labelVersionInformation.Text = backuplabelVersionInformation;

                return;
            }

            labelDHTinfo.Text = "DHT: H=" + humidity.ToString("F1") + "% , T=" + temperature.ToString("F1") + "C , DP=" + dewpoint.ToString("F1") + "C";

            dewPointBackup = dewpoint;

            // check for possible condensation
            checkTemperatureForPossibleCondensation();
        }

        private void checkTemperatureForPossibleCondensation()
        {
            if (tempCCDbackup < dewPointBackup + (short)numericUpDownCondensationWarningTemperatureDifference.Value)
            {
                labelVersionInformation.Text = "WARNING, possible condensation!!!";
                labelVersionInformation.BackColor = Color.Yellow;
            }
            else
            {
                labelVersionInformation.Text = backuplabelVersionInformation;
                if(checkBoxNightMode.Checked)
                    labelVersionInformation.BackColor = Color.Black;
                else
                    labelVersionInformation.BackColor = SystemColors.Control;
                labelVersionInformation.BackColor = SystemColors.Control;
            }
        }

        public void updateTemperatureLabel(double sensorTemperature)
        {
            tempCCDbackup = sensorTemperature;
            labelTemperature.Text = "T=" + sensorTemperature.ToString("F1") + "/" + ccdTemp.ToString("F1") + "C";
        }

        public SetupDialogForm()
        {
            InitializeComponent();

            timerGain = new System.Timers.Timer(timerIntervals);
            timerGain.SynchronizingObject = this;
            timerGain.AutoReset = false;
            timerGain.Elapsed += timerGainElapsedHandler;

            timerOffset = new System.Timers.Timer(timerIntervals);
            timerOffset.SynchronizingObject = this;
            timerOffset.AutoReset = false;
            timerOffset.Elapsed += timerOffsetElapsedHandler;

            timerReadTime = new System.Timers.Timer(timerIntervals);
            timerReadTime.SynchronizingObject = this;
            timerReadTime.AutoReset = false;
            timerReadTime.Elapsed += timerReadTimeElapsedHandler;

            timerCoolingStartingPowerPercent = new System.Timers.Timer(timerIntervals);
            timerCoolingStartingPowerPercent.SynchronizingObject = this;
            timerCoolingStartingPowerPercent.AutoReset = false;
            timerCoolingStartingPowerPercent.Elapsed += timerCoolingStartingPowerPercentElapsedHandler;

            timerCoolingMaximumPowerPercent = new System.Timers.Timer(timerIntervals);
            timerCoolingMaximumPowerPercent.SynchronizingObject = this;
            timerCoolingMaximumPowerPercent.AutoReset = false;
            timerCoolingMaximumPowerPercent.Elapsed += timerCoolingMaximumPowerPercentElapsedHandler;

            timerPIDproportionalGain = new System.Timers.Timer(timerIntervals);
            timerPIDproportionalGain.SynchronizingObject = this;
            timerPIDproportionalGain.AutoReset = false;
            timerPIDproportionalGain.Elapsed += timerPIDproportionalGainElapsedHandler;

            timerPIDintegralGain = new System.Timers.Timer(timerIntervals);
            timerPIDintegralGain.SynchronizingObject = this;
            timerPIDintegralGain.AutoReset = false;
            timerPIDintegralGain.Elapsed += timerPIDintegralGainElapsedHandler;

            timerPIDderivativeGain = new System.Timers.Timer(timerIntervals);
            timerPIDderivativeGain.SynchronizingObject = this;
            timerPIDderivativeGain.AutoReset = false;
            timerPIDderivativeGain.Elapsed += timerPIDderivativeGainElapsedHandler;

        }

        private void setupWindowSize()
        {
            if (windowSize == settingsWindowSizeE.cameraOnNoOptions)
            {
                panelAscom.Visible = false;

                panelImageInfo.Location = new Point(8, labelVersionInformation.Location.X + labelVersionInformation.Size.Height);
                panelImageInfo.Visible = true;
                panelSettings.Visible = false;
                panelGainOffset.Visible = false;
                panelCooling.Visible = false;

                cmdOK.Visible = false;
                cmdCancel.Visible = false;

                buttonHideSettings.Text = "▼";
                buttonHideSettings.Visible = true;
            }
            else if (windowSize == settingsWindowSizeE.cameraOnFullOptions)
            {
                panelAscom.Visible = false;

                panelImageInfo.Location = new Point(8, labelVersionInformation.Location.X + labelVersionInformation.Size.Height);
                panelSettings.Location = new Point(8, panelImageInfo.Location.Y + panelImageInfo.Size.Height);
                panelGainOffset.Location = new Point(8, panelSettings.Location.Y + panelSettings.Size.Height);
                panelCooling.Location = new Point(8, panelGainOffset.Location.Y + panelGainOffset.Size.Height);

                cmdOK.Location = new Point(8, panelCooling.Location.Y + panelCooling.Size.Height + 6);
                cmdCancel.Location = new Point(156, panelCooling.Location.Y + panelCooling.Size.Height + 6);

                panelImageInfo.Visible = true;
                panelSettings.Visible = true;
                panelGainOffset.Visible = true;
                panelCooling.Visible = true;

                cmdOK.Visible = false;
                cmdCancel.Visible = false;

                buttonHideSettings.Text = "▲";
                buttonHideSettings.Visible = true;
            }
            else if (windowSize == settingsWindowSizeE.cameraOff)
            {
                panelAscom.Visible = true;

                panelSettings.Location = new Point(8, labelVersionInformation.Location.X + labelVersionInformation.Size.Height);
                panelGainOffset.Location = new Point(8, panelSettings.Location.Y + panelSettings.Size.Height);
                panelCooling.Location = new Point(8, panelGainOffset.Location.Y + panelGainOffset.Size.Height);

                cmdOK.Location = new Point(8, panelCooling.Location.Y + panelCooling.Size.Height + 6);
                cmdCancel.Location = new Point(156, panelCooling.Location.Y + panelCooling.Size.Height + 6);

                panelImageInfo.Visible = false;
                panelSettings.Visible = true;
                panelGainOffset.Visible = true;
                panelCooling.Visible = true;

                cmdOK.Visible = true;
                cmdCancel.Visible = true;

                buttonHideSettings.Visible = false;
            }

        }

        private void SetupDialogForm_Shown(object sender, EventArgs e)
        {
            labelVersionInformation.Text = "CAM86 " + "v=" + Camera.driverVersion + ", LL=" + Camera.driverLLversion;
            backuplabelVersionInformation = labelVersionInformation.Text;

            // should we show all camera parameters or only some
            windowSize = Camera.settingsWindowSizeState;

            if (cameraConnected)
            {
                // make sure the value is valid
                if (windowSize == settingsWindowSizeE.cameraOff)
                    windowSize = settingsWindowSizeE.cameraOnNoOptions;

                setupWindowSize();

                // add firmware label
                labelVersionInformation.Text += ", FW=" + Camera.driverFirmwareVersion; // will always be zero unless read after initial camera connection
                backuplabelVersionInformation = labelVersionInformation.Text;
            }
            else
            {
                // make sure the value is valid
                if (windowSize != settingsWindowSizeE.cameraOff)
                    windowSize = settingsWindowSizeE.cameraOff;

                setupWindowSize();

                // Get info about the connected FTDI Cam86 devices
                UInt32 ftdiDeviceCount = 0;
                FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
                // Create new instance of the FTDI device class
                FTDI tempFtdiDevice = new FTDI();
                // Determine the number of FTDI devices connected to the machine
                ftStatus = tempFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
                // Check status
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                    AvailableDevicesListBox.Items.Add("# of FTDI devices = " + ftdiDeviceCount.ToString());
                else
                    throw new ASCOM.InvalidValueException("Error getting count FTDI devices");
                if (ftdiDeviceCount > 0)
                {
                    // Allocate storage for device info list
                    FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
                    // Populate our device list
                    ftStatus = tempFtdiDevice.GetDeviceList(ftdiDeviceList);
                    //Show device properties
                    if (ftStatus == FTDI.FT_STATUS.FT_OK)
                    {
                        for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                        {
                            if (ftdiDeviceList[i].SerialNumber.Contains("CAM86"))
                            {
                                AvailableDevicesListBox.Items.Add("Device Index: " + i.ToString());
                                AvailableDevicesListBox.Items.Add("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags));
                                AvailableDevicesListBox.Items.Add("Type: " + ftdiDeviceList[i].Type.ToString());
                                AvailableDevicesListBox.Items.Add("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID));
                                AvailableDevicesListBox.Items.Add("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId));
                                AvailableDevicesListBox.Items.Add("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString());
                                AvailableDevicesListBox.Items.Add("Description: " + ftdiDeviceList[i].Description.ToString());
                                AvailableDevicesListBox.Items.Add("");
                            }
                        }
                    }
                    else throw new ASCOM.InvalidValueException("Error getting parameters from FTDI devices");
                }
                //Close device
                ftStatus = tempFtdiDevice.Close();

                // Initialise current values of user settings from the ASCOM Profile 
                chkTrace.Checked = Camera.traceState;
            }

            // Initialise current values of user settings from the ASCOM Profile 
            checkBoxNightMode.Checked = Camera.nightModeSettingsState;
            checkBoxOnTop.Checked = Camera.onTopState;
            checkBoxTEConDuringRead.Checked = Camera.coolerDuringReadingState;
            checkBoxMono.Checked = Camera.monoSensorState;
            slowCoolingCheckBox.Checked = Camera.slowCoolingEnabledState;
            slowCoolingNumUpDown.Value = (decimal)(Camera.slowCoolingSpeedState / 10.0);
            numericUpDownSensorClearTime.Value = Camera.sensorClearBeforeExposureTimeState;
            numericUpDownTECstartupPowerPercent.Value = Camera.coolingStartingPowerPercentState;
            numericUpDownTECmaximumPowerPercent.Value = Camera.coolingMaxPowerPercentState;
            checkBoxOpenSettingsOnConnect.Checked = Camera.settingsWindowOpenOnConnectState;

            gainNumUpDown.Value = Camera.gainState;
            offsetNumUpDown.Value = Camera.offsetState;
            numericUpDownReadingTime.Value = Camera.readingTimeState;
            numericUpDownPIDKp.Value = (decimal)Camera.PIDproportionalGainState;
            numericUpDownPIDKi.Value = (decimal)Camera.PIDintegralGainState;
            numericUpDownPIDKd.Value = (decimal)Camera.PIDderivativeGainState;

            checkBoxDHT22.Checked = Camera.DHT22presentState;
            if (!checkBoxDHT22.Checked)
                labelDHTinfo.Text = "DHT: no sensor";
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // that the OK button is hiden if the camera is connected, just double check
            if (cameraConnected)
                return;
            Camera.traceState = chkTrace.Checked;

            Camera.nightModeSettingsState = checkBoxNightMode.Checked;
            Camera.onTopState = checkBoxOnTop.Checked;
            Camera.coolerDuringReadingState = checkBoxTEConDuringRead.Checked;
            Camera.monoSensorState = checkBoxMono.Checked;
            Camera.slowCoolingEnabledState = slowCoolingCheckBox.Checked;
            Camera.slowCoolingSpeedState = (short)(((double)slowCoolingNumUpDown.Value) * 10.0);
            Camera.sensorClearBeforeExposureTimeState = (ushort)numericUpDownSensorClearTime.Value;
            Camera.coolingStartingPowerPercentState = (short)numericUpDownTECstartupPowerPercent.Value;
            Camera.coolingMaxPowerPercentState = (short)numericUpDownTECmaximumPowerPercent.Value;

            Camera.gainState = (short)gainNumUpDown.Value;
            Camera.offsetState = (short)offsetNumUpDown.Value;
            Camera.readingTimeState = (short)numericUpDownReadingTime.Value;

            Camera.PIDproportionalGainState = (double)numericUpDownPIDKp.Value;
            Camera.PIDintegralGainState = (double)numericUpDownPIDKi.Value;
            Camera.PIDderivativeGainState = (double)numericUpDownPIDKd.Value;

            Camera.DHT22presentState = checkBoxDHT22.Checked;

            // do not want to store location of this window when camera is not connected
            //Camera.settingsWindowLocationState = Location;
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void gainNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            short G = Convert.ToInt16(gainNumUpDown.Value);

            double gain = 6.0 / (1 + 5.0 * (63 - G) / 63);
            labelGainReal.Text = "G=" + gain.ToString("F2") + "x";

            if (cameraConnected)
            {
                if (!timerGain.Enabled)
                {
                    timerGain.Start();
                    tempGain = gainNumUpDown.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerGain.Stop();
                    timerGain.Start();

                    tempGain = gainNumUpDown.Value;
                }
            }
        }

        private void checkBoxNightMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNightMode.Checked)
            {
                BackColor = Color.Black;
                ForeColor = Color.Red;

                AvailableDevicesListBox.BackColor = Color.DarkRed;
                AvailableDevicesListBox.ForeColor = Color.Orange;
                slowCoolingNumUpDown.BackColor = Color.DarkRed;
                slowCoolingNumUpDown.ForeColor = Color.Orange;
                numericUpDownTECstartupPowerPercent.BackColor = Color.DarkRed;
                numericUpDownTECstartupPowerPercent.ForeColor = Color.Orange;
                numericUpDownTECmaximumPowerPercent.BackColor = Color.DarkRed;
                numericUpDownTECmaximumPowerPercent.ForeColor = Color.Orange;
                gainNumUpDown.BackColor = Color.DarkRed;
                gainNumUpDown.ForeColor = Color.Orange;
                offsetNumUpDown.BackColor = Color.DarkRed;
                offsetNumUpDown.ForeColor = Color.Orange;
                numericUpDownReadingTime.BackColor = Color.DarkRed;
                numericUpDownReadingTime.ForeColor = Color.Orange;
                numericUpDownSensorClearTime.BackColor = Color.DarkRed;
                numericUpDownSensorClearTime.ForeColor = Color.Orange;
                cmdOK.BackColor = Color.DarkRed;
                cmdOK.ForeColor = Color.Orange;
                cmdCancel.BackColor = Color.DarkRed;
                cmdCancel.ForeColor = Color.Orange;
                numericUpDownCondensationWarningTemperatureDifference.BackColor = Color.DarkRed;
                numericUpDownCondensationWarningTemperatureDifference.ForeColor = Color.Orange;
                buttonAbout.BackColor = Color.DarkRed;
                buttonAbout.ForeColor = Color.Orange;
                numericUpDownPIDKp.BackColor = Color.DarkRed;
                numericUpDownPIDKp.ForeColor = Color.Orange;
                numericUpDownPIDKi.BackColor = Color.DarkRed;
                numericUpDownPIDKi.ForeColor = Color.Orange;
                numericUpDownPIDKd.BackColor = Color.DarkRed;
                numericUpDownPIDKd.ForeColor = Color.Orange;

                if (labelVersionInformation.BackColor != Color.Yellow)
                    labelVersionInformation.BackColor = Color.Black;
            }
            else
            {
                BackColor = SystemColors.Control;
                ForeColor = SystemColors.ControlText;

                AvailableDevicesListBox.BackColor = SystemColors.Window;
                AvailableDevicesListBox.ForeColor = SystemColors.WindowText;
                slowCoolingNumUpDown.BackColor = SystemColors.Window;
                slowCoolingNumUpDown.ForeColor = SystemColors.WindowText;
                numericUpDownTECstartupPowerPercent.BackColor = SystemColors.Window;
                numericUpDownTECstartupPowerPercent.ForeColor = SystemColors.WindowText;
                numericUpDownTECmaximumPowerPercent.BackColor = SystemColors.Window;
                numericUpDownTECmaximumPowerPercent.ForeColor = SystemColors.WindowText;
                gainNumUpDown.BackColor = SystemColors.Window;
                gainNumUpDown.ForeColor = SystemColors.WindowText;
                offsetNumUpDown.BackColor = SystemColors.Window;
                offsetNumUpDown.ForeColor = SystemColors.WindowText;
                numericUpDownReadingTime.BackColor = SystemColors.Window;
                numericUpDownReadingTime.ForeColor = SystemColors.WindowText;
                numericUpDownSensorClearTime.BackColor = SystemColors.Window;
                numericUpDownSensorClearTime.ForeColor = SystemColors.WindowText;
                cmdOK.BackColor = SystemColors.Window;
                cmdOK.ForeColor = SystemColors.WindowText;
                cmdCancel.BackColor = SystemColors.Window;
                cmdCancel.ForeColor = SystemColors.WindowText;
                numericUpDownCondensationWarningTemperatureDifference.BackColor = SystemColors.Window;
                numericUpDownCondensationWarningTemperatureDifference.ForeColor = SystemColors.WindowText;
                buttonAbout.BackColor = SystemColors.Window;
                buttonAbout.ForeColor = SystemColors.WindowText;
                numericUpDownPIDKp.BackColor = SystemColors.Window;
                numericUpDownPIDKp.ForeColor = SystemColors.WindowText;
                numericUpDownPIDKi.BackColor = SystemColors.Window;
                numericUpDownPIDKi.ForeColor = SystemColors.WindowText;
                numericUpDownPIDKd.BackColor = SystemColors.Window;
                numericUpDownPIDKd.ForeColor = SystemColors.WindowText;

                if (labelVersionInformation.BackColor != Color.Yellow)
                    labelVersionInformation.BackColor = SystemColors.Control;
            }

            if (cameraConnected)
            {
                Camera.nightModeSettingsState = checkBoxNightMode.Checked;
                Camera.nightModeSettingsStateDirty = true;
            }
        }

        private void offsetNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            short offset = 0;
            try
            {
                offset = Convert.ToInt16(offsetNumUpDown.Value);
            }
            catch
            {
                labelRealOffset.Text = "O=?";
                return;
            }
            // note that we are not using the full resolution of offset, 127 -> 256 -> scale to +-300mV
            labelRealOffset.Text = "O=" + ((int)((offset * 2) / 256.0 * 300.0)).ToString() + "mV";

            if (cameraConnected)
            {
                if (!timerOffset.Enabled)
                {
                    timerOffset.Start();
                    tempOffset = offsetNumUpDown.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerOffset.Stop();
                    timerOffset.Start();

                    tempOffset = offsetNumUpDown.Value;
                }
            }
        }

        private void onTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOnTop.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;

            if (cameraConnected)
            {
                Camera.onTopState = checkBoxOnTop.Checked;
                Camera.onTopStateDirty = true;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            FormAbout aboutForm = new FormAbout();

            aboutForm.ShowDialog();
        }

        private void numericUpDownReadingTime_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                if (!timerReadTime.Enabled)
                {
                    timerReadTime.Start();
                    tempReadTime = numericUpDownReadingTime.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerReadTime.Stop();
                    timerReadTime.Start();

                    tempReadTime = numericUpDownReadingTime.Value;
                }
            }
        }

        private void checkBoxTEConDuringRead_CheckedChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                Camera.coolerDuringReadingState = checkBoxTEConDuringRead.Checked;
                Camera.coolerDuringReadingStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);
            }
        }

        private void checkBoxMono_CheckedChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                Camera.monoSensorState = checkBoxMono.Checked;
                Camera.monoSensorStateDirty = true;
                //MessageBox.Show("Please restart your imaging software for this change to take effect!", "Restart needed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);
            }
        }

        private void numericUpDownTECstartupPowerPercent_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                if (!timerCoolingStartingPowerPercent.Enabled)
                {
                    timerCoolingStartingPowerPercent.Start();
                    tempCoolingStartingPowerPercent = numericUpDownTECstartupPowerPercent.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerCoolingStartingPowerPercent.Stop();
                    timerCoolingStartingPowerPercent.Start();

                    tempCoolingStartingPowerPercent = numericUpDownTECstartupPowerPercent.Value;
                }
            }
        }

        private void numericUpDownTECmaximumPowerPercent_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                if (!timerCoolingMaximumPowerPercent.Enabled)
                {
                    timerCoolingMaximumPowerPercent.Start();
                    tempCoolingMaximumPowerPercent = numericUpDownTECmaximumPowerPercent.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerCoolingMaximumPowerPercent.Stop();
                    timerCoolingMaximumPowerPercent.Start();

                    tempCoolingMaximumPowerPercent = numericUpDownTECmaximumPowerPercent.Value;
                }
            }
        }

        private void numericUpDownSensorClearTime_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                Camera.sensorClearBeforeExposureTimeState = (ushort)numericUpDownSensorClearTime.Value;
            }
        }

        private void slowCoolingNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                Camera.slowCoolingSpeedState = (short)slowCoolingNumUpDown.Value;
            }
        }

        private void slowCoolingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                Camera.slowCoolingEnabledState = slowCoolingCheckBox.Checked;
                Camera.slowCoolingEnabledStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);
            }
        }

        private void SetupDialogForm_ResizeEnd(object sender, EventArgs e)
        {
            // this event gets fired also when the form stops being moved. We will use this to store the window coordinates if the camera is connected
            if (cameraConnected)
            {
                Camera.settingsWindowLocationState = Location;
                Camera.settingsWindowLocationStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);
            }
        }

        private void checkBoxOpenSettingsOnConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                Camera.settingsWindowOpenOnConnectState = checkBoxOpenSettingsOnConnect.Checked;
                Camera.settingsWindowOpenOnConnectStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);
            }
        }

        private void numericUpDownPIDKp_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                if (!timerPIDproportionalGain.Enabled)
                {
                    timerPIDproportionalGain.Start();
                    tempPIDproportionalGain = numericUpDownPIDKp.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerPIDproportionalGain.Stop();
                    timerPIDproportionalGain.Start();

                    tempPIDproportionalGain = numericUpDownPIDKp.Value;
                }
            }
        }

        private void numericUpDownPIDKi_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                if (!timerPIDintegralGain.Enabled)
                {
                    timerPIDintegralGain.Start();
                    tempPIDintegralGain = numericUpDownPIDKi.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerPIDintegralGain.Stop();
                    timerPIDintegralGain.Start();

                    tempPIDintegralGain = numericUpDownPIDKi.Value;
                }
            }
        }

        private void numericUpDownPIDKd_ValueChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                if (!timerPIDderivativeGain.Enabled)
                {
                    timerPIDderivativeGain.Start();
                    tempPIDderivativeGain = numericUpDownPIDKd.Value;
                }
                else
                {
                    // restart the timer, we don't need to update the camera while values are being changed
                    timerPIDderivativeGain.Stop();
                    timerPIDderivativeGain.Start();

                    tempPIDderivativeGain = numericUpDownPIDKd.Value;
                }
            }
        }

        private void checkBoxDHT22_CheckedChanged(object sender, EventArgs e)
        {
            if (cameraConnected)
            {
                Camera.DHT22presentState = checkBoxDHT22.Checked;
                Camera.DHT22presentStateDirty = true;

                // call event from the main form
                if (updateMainFormCameraParameters != null)
                    updateMainFormCameraParameters(sender, e);
            }

            if (!checkBoxDHT22.Checked)
            {
                labelDHTinfo.Text = "DHT: no sensor";
                labelVersionInformation.Text = backuplabelVersionInformation;

                // remove yellow warning colour if it was used
                if (checkBoxNightMode.Checked)
                {
                    labelVersionInformation.BackColor = Color.Black;
                }
                else
                {
                    labelVersionInformation.BackColor = SystemColors.Control;
                }
            }
        }

        private void buttonHideSettings_Click(object sender, EventArgs e)
        {
            if (windowSize == settingsWindowSizeE.cameraOff)
                return;

            if (windowSize == settingsWindowSizeE.cameraOnFullOptions)
                windowSize = settingsWindowSizeE.cameraOnNoOptions;
            else
                windowSize = settingsWindowSizeE.cameraOnFullOptions;
            setupWindowSize();

            Camera.settingsWindowSizeState = windowSize;
            Camera.settingsWindowSizeStateDirty = true;
        }

        private void labelVersionInformation_Click(object sender, EventArgs e)
        {

        }

        public double setCCDTemperature
        {
            get { return ccdTemp; }
            set
            {
                ccdTemp = value;
                updateTemperatureLabel(tempCCDbackup);
            }
        }

        public DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            if (checkBoxNightMode.Checked)
            {
                form.BackColor = Color.Black;
                form.ForeColor = Color.Red;

                buttonOk.BackColor = Color.Red;
                buttonOk.ForeColor = Color.Orange;
                buttonCancel.BackColor = Color.Red;
                buttonCancel.ForeColor = Color.Orange;

                label.ForeColor = Color.Red;

                textBox.BackColor = Color.DarkRed;
                textBox.ForeColor = Color.Orange;
            }

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void labelTemperature_DoubleClick(object sender, EventArgs e)
        {
            String value = "0.0";

            if (InputBox("Enter temperature", "Please enter the sensor temperature. Note that this may be overriden by the imaging software!"
                , ref value) == DialogResult.OK)
            {
                try
                {
                    double setTemp = double.Parse(value);
                    if (cameraConnected)
                    {
                        Camera.tempCCDTemp = setTemp;
                        Camera.tempCCDTempDirty = true;

                        // call event from the main form
                        if (updateMainFormCameraParameters != null)
                            updateMainFormCameraParameters(sender, e);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid temperature entered", "Invalid Temperature", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}