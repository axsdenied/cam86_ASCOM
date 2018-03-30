namespace ASCOM.cam86
{
    partial class SetupDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.AvailableDevicesListBox = new System.Windows.Forms.ListBox();
            this.panelGainOffset = new System.Windows.Forms.Panel();
            this.labelRealOffset = new System.Windows.Forms.Label();
            this.labelGainReal = new System.Windows.Forms.Label();
            this.gainLabel = new System.Windows.Forms.Label();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.minMaxGainLabel = new System.Windows.Forms.Label();
            this.minMaxOffsetLabel = new System.Windows.Forms.Label();
            this.numericUpDownReadingTime = new System.Windows.Forms.NumericUpDown();
            this.gainNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelMinMaxReadingTime = new System.Windows.Forms.Label();
            this.offsetNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelReadingTime = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.checkBoxDHT22 = new System.Windows.Forms.CheckBox();
            this.checkBoxOpenSettingsOnConnect = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownCondensationWarningTemperatureDifference = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSensorClearTime = new System.Windows.Forms.NumericUpDown();
            this.checkBoxOnTop = new System.Windows.Forms.CheckBox();
            this.labelSensorClear = new System.Windows.Forms.Label();
            this.checkBoxMono = new System.Windows.Forms.CheckBox();
            this.labelSensorClearSeconds = new System.Windows.Forms.Label();
            this.checkBoxNightMode = new System.Windows.Forms.CheckBox();
            this.checkBoxTEConDuringRead = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownTECmaximumPowerPercent = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTECstartupPowerPercent = new System.Windows.Forms.NumericUpDown();
            this.slowCoolingCheckBox = new System.Windows.Forms.CheckBox();
            this.slowCoolingNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.slowCoolingLabel = new System.Windows.Forms.Label();
            this.labelVersionInformation = new System.Windows.Forms.Label();
            this.panelAscom = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDownPIDKp = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPIDKd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPIDKi = new System.Windows.Forms.NumericUpDown();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.panelImageInfo = new System.Windows.Forms.Panel();
            this.buttonHideSettings = new System.Windows.Forms.Button();
            this.labelDHTinfo = new System.Windows.Forms.Label();
            this.labelStdDev = new System.Windows.Forms.Label();
            this.labelMinMaxIntensities = new System.Windows.Forms.Label();
            this.labelExposureDuration = new System.Windows.Forms.Label();
            this.panelCooling = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCloudsOffAprilFoolsDay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.panelGainOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadingTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNumUpDown)).BeginInit();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCondensationWarningTemperatureDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorClearTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTECmaximumPowerPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTECstartupPowerPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slowCoolingNumUpDown)).BeginInit();
            this.panelAscom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPIDKp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPIDKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPIDKi)).BeginInit();
            this.panelImageInfo.SuspendLayout();
            this.panelCooling.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(7, 381);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(63, 24);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(156, 381);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(63, 24);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available devices";
            // 
            // picASCOM
            // 
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.cam86.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(135, -1);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(59, 7);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(69, 17);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Trace on";
            this.toolTip1.SetToolTip(this.chkTrace, "Used for debugging (log files can be found in Documents/ASCOM)");
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // AvailableDevicesListBox
            // 
            this.AvailableDevicesListBox.FormattingEnabled = true;
            this.AvailableDevicesListBox.Location = new System.Drawing.Point(5, 61);
            this.AvailableDevicesListBox.Name = "AvailableDevicesListBox";
            this.AvailableDevicesListBox.Size = new System.Drawing.Size(180, 238);
            this.AvailableDevicesListBox.TabIndex = 7;
            this.AvailableDevicesListBox.TabStop = false;
            this.toolTip1.SetToolTip(this.AvailableDevicesListBox, "List of detected Cam86 (FTDI) devices");
            // 
            // panelGainOffset
            // 
            this.panelGainOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGainOffset.Controls.Add(this.labelRealOffset);
            this.panelGainOffset.Controls.Add(this.labelGainReal);
            this.panelGainOffset.Controls.Add(this.gainLabel);
            this.panelGainOffset.Controls.Add(this.offsetLabel);
            this.panelGainOffset.Controls.Add(this.minMaxGainLabel);
            this.panelGainOffset.Controls.Add(this.minMaxOffsetLabel);
            this.panelGainOffset.Controls.Add(this.numericUpDownReadingTime);
            this.panelGainOffset.Controls.Add(this.gainNumUpDown);
            this.panelGainOffset.Controls.Add(this.labelMinMaxReadingTime);
            this.panelGainOffset.Controls.Add(this.offsetNumUpDown);
            this.panelGainOffset.Controls.Add(this.labelReadingTime);
            this.panelGainOffset.Location = new System.Drawing.Point(8, 207);
            this.panelGainOffset.Name = "panelGainOffset";
            this.panelGainOffset.Size = new System.Drawing.Size(212, 76);
            this.panelGainOffset.TabIndex = 67;
            // 
            // labelRealOffset
            // 
            this.labelRealOffset.AutoSize = true;
            this.labelRealOffset.Location = new System.Drawing.Point(157, 34);
            this.labelRealOffset.Name = "labelRealOffset";
            this.labelRealOffset.Size = new System.Drawing.Size(42, 13);
            this.labelRealOffset.TabIndex = 58;
            this.labelRealOffset.Text = "O=0mV";
            // 
            // labelGainReal
            // 
            this.labelGainReal.AutoSize = true;
            this.labelGainReal.Location = new System.Drawing.Point(157, 11);
            this.labelGainReal.Name = "labelGainReal";
            this.labelGainReal.Size = new System.Drawing.Size(41, 13);
            this.labelGainReal.TabIndex = 57;
            this.labelGainReal.Text = "G=0.0x";
            // 
            // gainLabel
            // 
            this.gainLabel.AutoSize = true;
            this.gainLabel.Location = new System.Drawing.Point(3, 9);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(29, 13);
            this.gainLabel.TabIndex = 29;
            this.gainLabel.Text = "Gain";
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(3, 30);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(35, 13);
            this.offsetLabel.TabIndex = 32;
            this.offsetLabel.Text = "Offset";
            // 
            // minMaxGainLabel
            // 
            this.minMaxGainLabel.AutoSize = true;
            this.minMaxGainLabel.Location = new System.Drawing.Point(44, 9);
            this.minMaxGainLabel.Name = "minMaxGainLabel";
            this.minMaxGainLabel.Size = new System.Drawing.Size(31, 13);
            this.minMaxGainLabel.TabIndex = 33;
            this.minMaxGainLabel.Text = "0..63";
            // 
            // minMaxOffsetLabel
            // 
            this.minMaxOffsetLabel.AutoSize = true;
            this.minMaxOffsetLabel.Location = new System.Drawing.Point(44, 30);
            this.minMaxOffsetLabel.Name = "minMaxOffsetLabel";
            this.minMaxOffsetLabel.Size = new System.Drawing.Size(52, 13);
            this.minMaxOffsetLabel.TabIndex = 34;
            this.minMaxOffsetLabel.Text = "-127..127";
            // 
            // numericUpDownReadingTime
            // 
            this.numericUpDownReadingTime.Location = new System.Drawing.Point(100, 50);
            this.numericUpDownReadingTime.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownReadingTime.Name = "numericUpDownReadingTime";
            this.numericUpDownReadingTime.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownReadingTime.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numericUpDownReadingTime, "Delay after reading each line - increase value if you have image corruptions");
            this.numericUpDownReadingTime.ValueChanged += new System.EventHandler(this.numericUpDownReadingTime_ValueChanged);
            // 
            // gainNumUpDown
            // 
            this.gainNumUpDown.Location = new System.Drawing.Point(100, 6);
            this.gainNumUpDown.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.gainNumUpDown.Name = "gainNumUpDown";
            this.gainNumUpDown.Size = new System.Drawing.Size(51, 20);
            this.gainNumUpDown.TabIndex = 0;
            this.toolTip1.SetToolTip(this.gainNumUpDown, "Gain of the camera");
            this.gainNumUpDown.ValueChanged += new System.EventHandler(this.gainNumUpDown_ValueChanged);
            // 
            // labelMinMaxReadingTime
            // 
            this.labelMinMaxReadingTime.AutoSize = true;
            this.labelMinMaxReadingTime.Location = new System.Drawing.Point(63, 52);
            this.labelMinMaxReadingTime.Name = "labelMinMaxReadingTime";
            this.labelMinMaxReadingTime.Size = new System.Drawing.Size(31, 13);
            this.labelMinMaxReadingTime.TabIndex = 54;
            this.labelMinMaxReadingTime.Text = "0..20";
            // 
            // offsetNumUpDown
            // 
            this.offsetNumUpDown.Location = new System.Drawing.Point(100, 28);
            this.offsetNumUpDown.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.offsetNumUpDown.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.offsetNumUpDown.Name = "offsetNumUpDown";
            this.offsetNumUpDown.Size = new System.Drawing.Size(51, 20);
            this.offsetNumUpDown.TabIndex = 1;
            this.toolTip1.SetToolTip(this.offsetNumUpDown, "Offset of the camera");
            this.offsetNumUpDown.ValueChanged += new System.EventHandler(this.offsetNumUpDown_ValueChanged);
            // 
            // labelReadingTime
            // 
            this.labelReadingTime.AutoSize = true;
            this.labelReadingTime.Location = new System.Drawing.Point(3, 52);
            this.labelReadingTime.Name = "labelReadingTime";
            this.labelReadingTime.Size = new System.Drawing.Size(59, 13);
            this.labelReadingTime.TabIndex = 53;
            this.labelReadingTime.Text = "Read Time";
            // 
            // panelSettings
            // 
            this.panelSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettings.Controls.Add(this.checkBoxDHT22);
            this.panelSettings.Controls.Add(this.checkBoxOpenSettingsOnConnect);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.numericUpDownCondensationWarningTemperatureDifference);
            this.panelSettings.Controls.Add(this.numericUpDownSensorClearTime);
            this.panelSettings.Controls.Add(this.checkBoxOnTop);
            this.panelSettings.Controls.Add(this.labelSensorClear);
            this.panelSettings.Controls.Add(this.checkBoxMono);
            this.panelSettings.Controls.Add(this.labelSensorClearSeconds);
            this.panelSettings.Controls.Add(this.checkBoxNightMode);
            this.panelSettings.Controls.Add(this.checkBoxTEConDuringRead);
            this.panelSettings.Location = new System.Drawing.Point(8, 109);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(212, 98);
            this.panelSettings.TabIndex = 68;
            // 
            // checkBoxDHT22
            // 
            this.checkBoxDHT22.AutoSize = true;
            this.checkBoxDHT22.Location = new System.Drawing.Point(3, 46);
            this.checkBoxDHT22.Name = "checkBoxDHT22";
            this.checkBoxDHT22.Size = new System.Drawing.Size(61, 17);
            this.checkBoxDHT22.TabIndex = 79;
            this.checkBoxDHT22.Text = "DHT22";
            this.toolTip1.SetToolTip(this.checkBoxDHT22, "If DHT22 humidity/temperature sensor is present");
            this.checkBoxDHT22.UseVisualStyleBackColor = true;
            this.checkBoxDHT22.CheckedChanged += new System.EventHandler(this.checkBoxDHT22_CheckedChanged);
            // 
            // checkBoxOpenSettingsOnConnect
            // 
            this.checkBoxOpenSettingsOnConnect.AutoSize = true;
            this.checkBoxOpenSettingsOnConnect.Location = new System.Drawing.Point(120, 23);
            this.checkBoxOpenSettingsOnConnect.Name = "checkBoxOpenSettingsOnConnect";
            this.checkBoxOpenSettingsOnConnect.Size = new System.Drawing.Size(90, 17);
            this.checkBoxOpenSettingsOnConnect.TabIndex = 78;
            this.checkBoxOpenSettingsOnConnect.Text = "Open on start";
            this.toolTip1.SetToolTip(this.checkBoxOpenSettingsOnConnect, "If settings window will automatically open when the camera is connected");
            this.checkBoxOpenSettingsOnConnect.UseVisualStyleBackColor = true;
            this.checkBoxOpenSettingsOnConnect.CheckedChanged += new System.EventHandler(this.checkBoxOpenSettingsOnConnect_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Condens warning";
            // 
            // numericUpDownCondensationWarningTemperatureDifference
            // 
            this.numericUpDownCondensationWarningTemperatureDifference.Location = new System.Drawing.Point(158, 45);
            this.numericUpDownCondensationWarningTemperatureDifference.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCondensationWarningTemperatureDifference.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDownCondensationWarningTemperatureDifference.Name = "numericUpDownCondensationWarningTemperatureDifference";
            this.numericUpDownCondensationWarningTemperatureDifference.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownCondensationWarningTemperatureDifference.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numericUpDownCondensationWarningTemperatureDifference, "A warning will be given if the difference between the sensor temperature and the " +
        "condensation temperature is less than this value.");
            this.numericUpDownCondensationWarningTemperatureDifference.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownSensorClearTime
            // 
            this.numericUpDownSensorClearTime.Location = new System.Drawing.Point(129, 71);
            this.numericUpDownSensorClearTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownSensorClearTime.Name = "numericUpDownSensorClearTime";
            this.numericUpDownSensorClearTime.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownSensorClearTime.TabIndex = 5;
            this.numericUpDownSensorClearTime.Tag = "";
            this.toolTip1.SetToolTip(this.numericUpDownSensorClearTime, "If exposure is longer than this value a bias frame will be taken (and discarded) " +
        "before the real exposure.\r\nThis may help if you have charge accumulation problem" +
        "s.\r\nSeems to help with mono cameras.");
            this.numericUpDownSensorClearTime.Value = new decimal(new int[] {
            36000,
            0,
            0,
            0});
            this.numericUpDownSensorClearTime.ValueChanged += new System.EventHandler(this.numericUpDownSensorClearTime_ValueChanged);
            // 
            // checkBoxOnTop
            // 
            this.checkBoxOnTop.AutoSize = true;
            this.checkBoxOnTop.Location = new System.Drawing.Point(145, 3);
            this.checkBoxOnTop.Name = "checkBoxOnTop";
            this.checkBoxOnTop.Size = new System.Drawing.Size(62, 17);
            this.checkBoxOnTop.TabIndex = 1;
            this.checkBoxOnTop.Text = "On Top";
            this.toolTip1.SetToolTip(this.checkBoxOnTop, "If window always stays on top");
            this.checkBoxOnTop.UseVisualStyleBackColor = true;
            this.checkBoxOnTop.CheckedChanged += new System.EventHandler(this.onTopCheckBox_CheckedChanged);
            // 
            // labelSensorClear
            // 
            this.labelSensorClear.AutoSize = true;
            this.labelSensorClear.Location = new System.Drawing.Point(4, 73);
            this.labelSensorClear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSensorClear.Name = "labelSensorClear";
            this.labelSensorClear.Size = new System.Drawing.Size(117, 13);
            this.labelSensorClear.TabIndex = 69;
            this.labelSensorClear.Text = "Sensor clr if exposure >";
            // 
            // checkBoxMono
            // 
            this.checkBoxMono.AutoSize = true;
            this.checkBoxMono.Location = new System.Drawing.Point(90, 3);
            this.checkBoxMono.Name = "checkBoxMono";
            this.checkBoxMono.Size = new System.Drawing.Size(53, 17);
            this.checkBoxMono.TabIndex = 3;
            this.checkBoxMono.Text = "Mono";
            this.toolTip1.SetToolTip(this.checkBoxMono, "Mono (de-Bayered) or colour sensor. Restart software after changing.");
            this.checkBoxMono.UseVisualStyleBackColor = true;
            this.checkBoxMono.CheckedChanged += new System.EventHandler(this.checkBoxMono_CheckedChanged);
            // 
            // labelSensorClearSeconds
            // 
            this.labelSensorClearSeconds.AutoSize = true;
            this.labelSensorClearSeconds.Location = new System.Drawing.Point(129, 47);
            this.labelSensorClearSeconds.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSensorClearSeconds.Name = "labelSensorClearSeconds";
            this.labelSensorClearSeconds.Size = new System.Drawing.Size(12, 13);
            this.labelSensorClearSeconds.TabIndex = 68;
            this.labelSensorClearSeconds.Text = "s";
            // 
            // checkBoxNightMode
            // 
            this.checkBoxNightMode.AutoSize = true;
            this.checkBoxNightMode.Location = new System.Drawing.Point(2, 2);
            this.checkBoxNightMode.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxNightMode.Name = "checkBoxNightMode";
            this.checkBoxNightMode.Size = new System.Drawing.Size(81, 17);
            this.checkBoxNightMode.TabIndex = 0;
            this.checkBoxNightMode.Text = "Night Mode";
            this.toolTip1.SetToolTip(this.checkBoxNightMode, "Red/black or regular colours");
            this.checkBoxNightMode.UseVisualStyleBackColor = true;
            this.checkBoxNightMode.CheckedChanged += new System.EventHandler(this.checkBoxNightMode_CheckedChanged);
            // 
            // checkBoxTEConDuringRead
            // 
            this.checkBoxTEConDuringRead.AutoSize = true;
            this.checkBoxTEConDuringRead.Location = new System.Drawing.Point(3, 23);
            this.checkBoxTEConDuringRead.Name = "checkBoxTEConDuringRead";
            this.checkBoxTEConDuringRead.Size = new System.Drawing.Size(117, 17);
            this.checkBoxTEConDuringRead.TabIndex = 2;
            this.checkBoxTEConDuringRead.Text = "Cooling during read";
            this.toolTip1.SetToolTip(this.checkBoxTEConDuringRead, "If cooling  will be on during frame reading/data transfer.");
            this.checkBoxTEConDuringRead.UseVisualStyleBackColor = true;
            this.checkBoxTEConDuringRead.CheckedChanged += new System.EventHandler(this.checkBoxTEConDuringRead_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "max";
            // 
            // numericUpDownTECmaximumPowerPercent
            // 
            this.numericUpDownTECmaximumPowerPercent.Location = new System.Drawing.Point(161, 70);
            this.numericUpDownTECmaximumPowerPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTECmaximumPowerPercent.Name = "numericUpDownTECmaximumPowerPercent";
            this.numericUpDownTECmaximumPowerPercent.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownTECmaximumPowerPercent.TabIndex = 9;
            this.toolTip1.SetToolTip(this.numericUpDownTECmaximumPowerPercent, "Limits the maximum cooling power %");
            this.numericUpDownTECmaximumPowerPercent.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTECmaximumPowerPercent.ValueChanged += new System.EventHandler(this.numericUpDownTECmaximumPowerPercent_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Cool pwr % start";
            // 
            // numericUpDownTECstartupPowerPercent
            // 
            this.numericUpDownTECstartupPowerPercent.Location = new System.Drawing.Point(89, 69);
            this.numericUpDownTECstartupPowerPercent.Name = "numericUpDownTECstartupPowerPercent";
            this.numericUpDownTECstartupPowerPercent.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownTECstartupPowerPercent.TabIndex = 8;
            this.toolTip1.SetToolTip(this.numericUpDownTECstartupPowerPercent, "Sets the starting cooling power % for faster/slower cooling");
            this.numericUpDownTECstartupPowerPercent.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTECstartupPowerPercent.ValueChanged += new System.EventHandler(this.numericUpDownTECstartupPowerPercent_ValueChanged);
            // 
            // slowCoolingCheckBox
            // 
            this.slowCoolingCheckBox.AutoSize = true;
            this.slowCoolingCheckBox.Location = new System.Drawing.Point(116, 5);
            this.slowCoolingCheckBox.Name = "slowCoolingCheckBox";
            this.slowCoolingCheckBox.Size = new System.Drawing.Size(87, 17);
            this.slowCoolingCheckBox.TabIndex = 6;
            this.slowCoolingCheckBox.Text = "Slow Cooling";
            this.toolTip1.SetToolTip(this.slowCoolingCheckBox, "Slow cooling of the camera");
            this.slowCoolingCheckBox.UseVisualStyleBackColor = true;
            this.slowCoolingCheckBox.CheckedChanged += new System.EventHandler(this.slowCoolingCheckBox_CheckedChanged);
            // 
            // slowCoolingNumUpDown
            // 
            this.slowCoolingNumUpDown.DecimalPlaces = 1;
            this.slowCoolingNumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.slowCoolingNumUpDown.Location = new System.Drawing.Point(116, 25);
            this.slowCoolingNumUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.slowCoolingNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.slowCoolingNumUpDown.Name = "slowCoolingNumUpDown";
            this.slowCoolingNumUpDown.Size = new System.Drawing.Size(51, 20);
            this.slowCoolingNumUpDown.TabIndex = 7;
            this.toolTip1.SetToolTip(this.slowCoolingNumUpDown, "Rate of cooling");
            this.slowCoolingNumUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.slowCoolingNumUpDown.ValueChanged += new System.EventHandler(this.slowCoolingNumUpDown_ValueChanged);
            // 
            // slowCoolingLabel
            // 
            this.slowCoolingLabel.AutoSize = true;
            this.slowCoolingLabel.Location = new System.Drawing.Point(173, 31);
            this.slowCoolingLabel.Name = "slowCoolingLabel";
            this.slowCoolingLabel.Size = new System.Drawing.Size(35, 13);
            this.slowCoolingLabel.TabIndex = 51;
            this.slowCoolingLabel.Text = "C/min";
            // 
            // labelVersionInformation
            // 
            this.labelVersionInformation.AutoSize = true;
            this.labelVersionInformation.Location = new System.Drawing.Point(12, 9);
            this.labelVersionInformation.Name = "labelVersionInformation";
            this.labelVersionInformation.Size = new System.Drawing.Size(40, 13);
            this.labelVersionInformation.TabIndex = 0;
            this.labelVersionInformation.Text = "Cam86";
            this.labelVersionInformation.Click += new System.EventHandler(this.labelVersionInformation_Click);
            // 
            // panelAscom
            // 
            this.panelAscom.Controls.Add(this.buttonAbout);
            this.panelAscom.Controls.Add(this.AvailableDevicesListBox);
            this.panelAscom.Controls.Add(this.picASCOM);
            this.panelAscom.Controls.Add(this.label1);
            this.panelAscom.Controls.Add(this.chkTrace);
            this.panelAscom.Location = new System.Drawing.Point(234, 26);
            this.panelAscom.Name = "panelAscom";
            this.panelAscom.Size = new System.Drawing.Size(188, 304);
            this.panelAscom.TabIndex = 2;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(6, 3);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(47, 23);
            this.buttonAbout.TabIndex = 71;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // numericUpDownPIDKp
            // 
            this.numericUpDownPIDKp.DecimalPlaces = 2;
            this.numericUpDownPIDKp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownPIDKp.Location = new System.Drawing.Point(46, 4);
            this.numericUpDownPIDKp.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            131072});
            this.numericUpDownPIDKp.Name = "numericUpDownPIDKp";
            this.numericUpDownPIDKp.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownPIDKp.TabIndex = 77;
            this.toolTip1.SetToolTip(this.numericUpDownPIDKp, "Proportional gain of the PID loop for cooling.\r\nDO NOT CHANGE UNLESS YOU KNOW WHA" +
        "T YOU ARE DOING");
            this.numericUpDownPIDKp.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownPIDKp.ValueChanged += new System.EventHandler(this.numericUpDownPIDKp_ValueChanged);
            // 
            // numericUpDownPIDKd
            // 
            this.numericUpDownPIDKd.DecimalPlaces = 2;
            this.numericUpDownPIDKd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownPIDKd.Location = new System.Drawing.Point(46, 46);
            this.numericUpDownPIDKd.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            131072});
            this.numericUpDownPIDKd.Name = "numericUpDownPIDKd";
            this.numericUpDownPIDKd.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownPIDKd.TabIndex = 81;
            this.toolTip1.SetToolTip(this.numericUpDownPIDKd, "Derivative gain of the PID loop for cooling.\r\nDO NOT CHANGE UNLESS YOU KNOW WHAT " +
        "YOU ARE DOING");
            this.numericUpDownPIDKd.ValueChanged += new System.EventHandler(this.numericUpDownPIDKd_ValueChanged);
            // 
            // numericUpDownPIDKi
            // 
            this.numericUpDownPIDKi.DecimalPlaces = 2;
            this.numericUpDownPIDKi.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownPIDKi.Location = new System.Drawing.Point(46, 25);
            this.numericUpDownPIDKi.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            131072});
            this.numericUpDownPIDKi.Name = "numericUpDownPIDKi";
            this.numericUpDownPIDKi.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownPIDKi.TabIndex = 82;
            this.toolTip1.SetToolTip(this.numericUpDownPIDKi, "Integral gain of the PID loop for cooling.\r\nDO NOT CHANGE UNLESS YOU KNOW WHAT YO" +
        "U ARE DOING");
            this.numericUpDownPIDKi.ValueChanged += new System.EventHandler(this.numericUpDownPIDKi_ValueChanged);
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(73, 5);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(33, 13);
            this.labelTemperature.TabIndex = 69;
            this.labelTemperature.Text = "T=0C";
            this.toolTip1.SetToolTip(this.labelTemperature, "Measured sensor temperature / set sensor temperature.\r\nDouble-click to manually s" +
        "et the temperature. \r\nNOTE: Your imaging application can override the manual set" +
        "ting.");
            this.labelTemperature.DoubleClick += new System.EventHandler(this.labelTemperature_DoubleClick);
            // 
            // panelImageInfo
            // 
            this.panelImageInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImageInfo.Controls.Add(this.buttonHideSettings);
            this.panelImageInfo.Controls.Add(this.labelTemperature);
            this.panelImageInfo.Controls.Add(this.labelDHTinfo);
            this.panelImageInfo.Controls.Add(this.labelStdDev);
            this.panelImageInfo.Controls.Add(this.labelMinMaxIntensities);
            this.panelImageInfo.Controls.Add(this.labelExposureDuration);
            this.panelImageInfo.Location = new System.Drawing.Point(8, 26);
            this.panelImageInfo.Name = "panelImageInfo";
            this.panelImageInfo.Size = new System.Drawing.Size(212, 82);
            this.panelImageInfo.TabIndex = 70;
            // 
            // buttonHideSettings
            // 
            this.buttonHideSettings.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHideSettings.Location = new System.Drawing.Point(6, 59);
            this.buttonHideSettings.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHideSettings.Name = "buttonHideSettings";
            this.buttonHideSettings.Size = new System.Drawing.Size(32, 20);
            this.buttonHideSettings.TabIndex = 80;
            this.buttonHideSettings.Text = "▼";
            this.buttonHideSettings.UseVisualStyleBackColor = true;
            this.buttonHideSettings.Click += new System.EventHandler(this.buttonHideSettings_Click);
            // 
            // labelDHTinfo
            // 
            this.labelDHTinfo.AutoSize = true;
            this.labelDHTinfo.Location = new System.Drawing.Point(44, 59);
            this.labelDHTinfo.Name = "labelDHTinfo";
            this.labelDHTinfo.Size = new System.Drawing.Size(115, 13);
            this.labelDHTinfo.TabIndex = 68;
            this.labelDHTinfo.Text = "Hum/Temp/DP: 0/0/0";
            // 
            // labelStdDev
            // 
            this.labelStdDev.AutoSize = true;
            this.labelStdDev.Location = new System.Drawing.Point(4, 42);
            this.labelStdDev.Name = "labelStdDev";
            this.labelStdDev.Size = new System.Drawing.Size(52, 13);
            this.labelStdDev.TabIndex = 67;
            this.labelStdDev.Text = "StdDev:0";
            // 
            // labelMinMaxIntensities
            // 
            this.labelMinMaxIntensities.AutoSize = true;
            this.labelMinMaxIntensities.Location = new System.Drawing.Point(4, 24);
            this.labelMinMaxIntensities.Name = "labelMinMaxIntensities";
            this.labelMinMaxIntensities.Size = new System.Drawing.Size(112, 13);
            this.labelMinMaxIntensities.TabIndex = 64;
            this.labelMinMaxIntensities.Text = "Min/Max/Mean:0/0/0";
            // 
            // labelExposureDuration
            // 
            this.labelExposureDuration.AutoSize = true;
            this.labelExposureDuration.Location = new System.Drawing.Point(3, 5);
            this.labelExposureDuration.Name = "labelExposureDuration";
            this.labelExposureDuration.Size = new System.Drawing.Size(44, 13);
            this.labelExposureDuration.TabIndex = 63;
            this.labelExposureDuration.Text = "Time:0s";
            // 
            // panelCooling
            // 
            this.panelCooling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCooling.Controls.Add(this.numericUpDownPIDKi);
            this.panelCooling.Controls.Add(this.numericUpDownPIDKd);
            this.panelCooling.Controls.Add(this.label8);
            this.panelCooling.Controls.Add(this.label7);
            this.panelCooling.Controls.Add(this.label6);
            this.panelCooling.Controls.Add(this.numericUpDownPIDKp);
            this.panelCooling.Controls.Add(this.numericUpDownTECmaximumPowerPercent);
            this.panelCooling.Controls.Add(this.slowCoolingLabel);
            this.panelCooling.Controls.Add(this.slowCoolingNumUpDown);
            this.panelCooling.Controls.Add(this.label3);
            this.panelCooling.Controls.Add(this.slowCoolingCheckBox);
            this.panelCooling.Controls.Add(this.numericUpDownTECstartupPowerPercent);
            this.panelCooling.Controls.Add(this.label2);
            this.panelCooling.Location = new System.Drawing.Point(8, 284);
            this.panelCooling.Name = "panelCooling";
            this.panelCooling.Size = new System.Drawing.Size(212, 94);
            this.panelCooling.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "PID Ki";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "PID Kd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "PID Kp";
            // 
            // buttonCloudsOffAprilFoolsDay
            // 
            this.buttonCloudsOffAprilFoolsDay.Location = new System.Drawing.Point(156, 4);
            this.buttonCloudsOffAprilFoolsDay.Name = "buttonCloudsOffAprilFoolsDay";
            this.buttonCloudsOffAprilFoolsDay.Size = new System.Drawing.Size(64, 23);
            this.buttonCloudsOffAprilFoolsDay.TabIndex = 81;
            this.buttonCloudsOffAprilFoolsDay.Text = "Clouds off";
            this.buttonCloudsOffAprilFoolsDay.UseVisualStyleBackColor = true;
            this.buttonCloudsOffAprilFoolsDay.Click += new System.EventHandler(this.buttonCloudsOffAprilFoolsDay_Click);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 408);
            this.Controls.Add(this.buttonCloudsOffAprilFoolsDay);
            this.Controls.Add(this.panelCooling);
            this.Controls.Add(this.panelImageInfo);
            this.Controls.Add(this.panelAscom);
            this.Controls.Add(this.labelVersionInformation);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelGainOffset);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SetupDialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASCOM cam86 driver setup";
            this.Shown += new System.EventHandler(this.SetupDialogForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.SetupDialogForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.panelGainOffset.ResumeLayout(false);
            this.panelGainOffset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadingTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNumUpDown)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCondensationWarningTemperatureDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSensorClearTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTECmaximumPowerPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTECstartupPowerPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slowCoolingNumUpDown)).EndInit();
            this.panelAscom.ResumeLayout(false);
            this.panelAscom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPIDKp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPIDKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPIDKi)).EndInit();
            this.panelImageInfo.ResumeLayout(false);
            this.panelImageInfo.PerformLayout();
            this.panelCooling.ResumeLayout(false);
            this.panelCooling.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.ListBox AvailableDevicesListBox;
        private System.Windows.Forms.Panel panelGainOffset;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.Label minMaxGainLabel;
        private System.Windows.Forms.Label minMaxOffsetLabel;
        private System.Windows.Forms.NumericUpDown numericUpDownReadingTime;
        private System.Windows.Forms.NumericUpDown gainNumUpDown;
        private System.Windows.Forms.Label labelMinMaxReadingTime;
        private System.Windows.Forms.NumericUpDown offsetNumUpDown;
        private System.Windows.Forms.Label labelReadingTime;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelSensorClear;
        private System.Windows.Forms.CheckBox checkBoxMono;
        private System.Windows.Forms.Label labelSensorClearSeconds;
        private System.Windows.Forms.CheckBox slowCoolingCheckBox;
        private System.Windows.Forms.CheckBox checkBoxNightMode;
        private System.Windows.Forms.CheckBox checkBoxTEConDuringRead;
        private System.Windows.Forms.NumericUpDown slowCoolingNumUpDown;
        private System.Windows.Forms.Label slowCoolingLabel;
        private System.Windows.Forms.Label labelGainReal;
        private System.Windows.Forms.Label labelRealOffset;
        private System.Windows.Forms.Label labelVersionInformation;
        private System.Windows.Forms.Panel panelAscom;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxOnTop;
        private System.Windows.Forms.Panel panelImageInfo;
        private System.Windows.Forms.Label labelStdDev;
        private System.Windows.Forms.Label labelMinMaxIntensities;
        private System.Windows.Forms.Label labelExposureDuration;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Label labelDHTinfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTECstartupPowerPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownTECmaximumPowerPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownSensorClearTime;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownCondensationWarningTemperatureDifference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxOpenSettingsOnConnect;
        private System.Windows.Forms.Panel panelCooling;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownPIDKp;
        private System.Windows.Forms.CheckBox checkBoxDHT22;
        private System.Windows.Forms.Button buttonHideSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownPIDKi;
        private System.Windows.Forms.NumericUpDown numericUpDownPIDKd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonCloudsOffAprilFoolsDay;
    }
}