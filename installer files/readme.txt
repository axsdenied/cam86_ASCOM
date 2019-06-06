20/6/2017 Cam86 ASCOM driver v.0.7.2L Readme

Directory description:
Default installation directory: C:\Program Files\Common Files\ASCOM\Camera\cam86
FTD2XX_NET.dll  NET interface for FTDI ftd2xx.dll
cam86.dll     cam86 driver, high-level interaction with camera (C#, Visual Studio 2015 project)  
cam85ll.dll   cam86 driver, low-level interaction with camera (Delphi 7 project)

Release history:
0.1  - [1] Initial release for cam86 based on cam85m v.0.1 ASCOM driver
0.2L     Add night mode
	Add option to adjust frame reading delays
	Add info (min/max, StdDev)
0.3L   Add firmware and LL driver version reading
	Implement TEC during reading
	Add mono sensor setting
0.4L   Add bias-before-exposure option
0.5L   Remove settings form and move all settings to the profile dialog
	Profile dialog with settings is modified significantly and can be called via ascom profile or via imaging software
	Different options can be displayed depending how it is opened
	Numerous ASCOM improvements and bug fixes
	Make driver ASCOM compliant, ASCOM compliance checker passes without errors now
	Add about box to settings
	Add humidity/dew point information
	Add TEC starting power and maximum power settings
	Add warnings about possible condensation
	Rewrite how live-change of settings is handled
	Tidy up the interface
0.6.1L Bug fixes, interface tidy up
	Storing of the location of the settings window if camera connected
0.6.2L Minor bug fixes, minor interface corrections
0.6.3  Fix bug in dew warning
        Add Open On Start option to the settings
        LLD fixed >999s exposures
0.6.4   Fix a bug in dew warning
        Fixed >1000s exposure bug in the LLD
0.6.5   Add control of the TEC cooling PID parameter KP (proportional gain)
0.6.6   Fix night colours for the KP parameter in settings
        Fix Kp default value throwing exception in countries where , is used for real numbers instead of .
0.7     Add option to select if the humidity sensor is present
        Fix few typos
        Minor bug fixes
0.7.1   Minor bug fixes regarding the dew warnings
        Fix bug in startExposure logging
0.7.2   Fix bug where maxGain was reported as 64 instead of 63
        Modify the layout of the settings form
        Add a button to minimise the settings form
	Add a button to toggle between image info only or settings as well when camera is connected
0.7.3   Bug fix release to solve the "white line" issue when cooling is used


Known issues:
na

Requirements:
Installed FTDI D2XX Driver (http://www.ftdichip.com/Drivers/D2XX.htm, version 2.08.24 or newer)
Net Framework 3.5 SP1 (http://www.microsoft.com/en-us/download/details.aspx?id=25150)
ASCOM Platform 6 (http://ascom-standards.org/Downloads/Index.htm)

Supported OS: WinXP SP3 x32/x64, Win7 x32/x64, Win8 x32/x64.

Installation instructions:
1) Install Net Framework 3.5 SP1 (http://www.microsoft.com/en-us/download/details.aspx?id=25150), install ASCOM 6 SP1 platform (http://ascom-standards.org/Downloads/Index.htm);
2) Connect cam86 to PC and install FTDI driver ver. 2.08.24 (http://www.ftdichip.com/Drivers/D2XX.htm); In Device Manager find 2 new devices: USB Serial Converter A, USB Serial Converter B, uncheck "Load VCP" checkbox in the device properties on Advanced tab;
3) If you have installed previous version of Cam86 ASCOM driver - uninstall it through Start-Control Panel-Add & Remove Programs.
4) Run cam86_v0.1_setup.exe, next-next-next
5) If cam86 is correctly flashed through MProg 3.5 and AVR cam86 Programmer utility (http://astroccd.org/2013/01/cam8_mprog_flashing/) you can connect cam86 like a ASCOM compatible camera to your software.

Uninstall instructions:
From Start-Control Panel-Add & Remove Programs select ASCOM cam86 Camera Driver 0.1 and click to Remove button.

Authors:
Camera hardware and low-level camera interaction - Gilmanov Rim, grim63 (at) yandex.ru
Camera high-level interaction with ASCOM - Vakulenko Sergiy, sergiy.vakulenko (at) gmail.com 
Modifications/extensions to the firmware/low-level driver/ASCOM driver- Luka Pravica, lukatravel (at) hotmail.com
Additional information by this project you can find at www.astroccd.org
