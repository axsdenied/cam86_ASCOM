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
            this.panelImageInfo = new System.Windows.Forms.Panel();
            this.buttonHideSettings = new System.Windows.Forms.Button();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelDHTinfo = new System.Windows.Forms.Label();
            this.labelStdDev = new System.Windows.Forms.Label();
            this.labelMinMaxIntensities = new System.Windows.Forms.Label();
            this.labelExposureDuration = new System.Windows.Forms.Label();
            this.panelCooling = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.cmdOK.Location = new System.Drawing.Point(9, 601);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(94, 37);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(235, 601);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(94, 37);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available devices";
            // 
            // picASCOM
            // 
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.cam86.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(202, -2);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.chkTrace.Location = new System.Drawing.Point(88, 11);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(97, 24);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Trace on";
            this.toolTip1.SetToolTip(this.chkTrace, "Used for debugging (log files can be found in Documents/ASCOM)");
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // AvailableDevicesListBox
            // 
            this.AvailableDevicesListBox.FormattingEnabled = true;
            this.AvailableDevicesListBox.ItemHeight = 20;
            this.AvailableDevicesListBox.Location = new System.Drawing.Point(7, 94);
            this.AvailableDevicesListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvailableDevicesListBox.Name = "AvailableDevicesListBox";
            this.AvailableDevicesListBox.Size = new System.Drawing.Size(268, 444);
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
            this.panelGainOffset.Location = new System.Drawing.Point(12, 319);
            this.panelGainOffset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelGainOffset.Name = "panelGainOffset";
            this.panelGainOffset.Size = new System.Drawing.Size(317, 131);
            this.panelGainOffset.TabIndex = 67;
            // 
            // labelRealOffset
            // 
            this.labelRealOffset.AutoSize = true;
            this.labelRealOffset.Location = new System.Drawing.Point(236, 52);
            this.labelRealOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRealOffset.Name = "labelRealOffset";
            this.labelRealOffset.Size = new System.Drawing.Size(63, 20);
            this.labelRealOffset.TabIndex = 58;
            this.labelRealOffset.Text = "O=0mV";
            // 
            // labelGainReal
            // 
            this.labelGainReal.AutoSize = true;
            this.labelGainReal.Location = new System.Drawing.Point(236, 17);
            this.labelGainReal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGainReal.Name = "labelGainReal";
            this.labelGainReal.Size = new System.Drawing.Size(60, 20);
            this.labelGainReal.TabIndex = 57;
            this.labelGainReal.Text = "G=0.0x";
            // 
            // gainLabel
            // 
            this.gainLabel.AutoSize = true;
            this.gainLabel.Location = new System.Drawing.Point(4, 14);
            this.gainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(43, 20);
            this.gainLabel.TabIndex = 29;
            this.gainLabel.Text = "Gain";
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(4, 54);
            this.offsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(53, 20);
            this.offsetLabel.TabIndex = 32;
            this.offsetLabel.Text = "Offset";
            // 
            // minMaxGainLabel
            // 
            this.minMaxGainLabel.AutoSize = true;
            this.minMaxGainLabel.Location = new System.Drawing.Point(66, 14);
            this.minMaxGainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minMaxGainLabel.Name = "minMaxGainLabel";
            this.minMaxGainLabel.Size = new System.Drawing.Size(44, 20);
            this.minMaxGainLabel.TabIndex = 33;
            this.minMaxGainLabel.Text = "0..63";
            // 
            // minMaxOffsetLabel
            // 
            this.minMaxOffsetLabel.AutoSize = true;
            this.minMaxOffsetLabel.Location = new System.Drawing.Point(66, 54);
            this.minMaxOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minMaxOffsetLabel.Name = "minMaxOffsetLabel";
            this.minMaxOffsetLabel.Size = new System.Drawing.Size(76, 20);
            this.minMaxOffsetLabel.TabIndex = 34;
            this.minMaxOffsetLabel.Text = "-127..127";
            // 
            // numericUpDownReadingTime
            // 
            this.numericUpDownReadingTime.Location = new System.Drawing.Point(150, 89);
            this.numericUpDownReadingTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownReadingTime.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownReadingTime.Name = "numericUpDownReadingTime";
            this.numericUpDownReadingTime.Size = new System.Drawing.Size(76, 26);
            this.numericUpDownReadingTime.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numericUpDownReadingTime, "Delay after reading each line - increase value if you have image corruptions");
            this.numericUpDownReadingTime.ValueChanged += new System.EventHandler(this.numericUpDownReadingTime_ValueChanged);
            // 
            // gainNumUpDown
            // 
            this.gainNumUpDown.Location = new System.Drawing.Point(150, 9);
            this.gainNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gainNumUpDown.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.gainNumUpDown.Name = "gainNumUpDown";
            this.gainNumUpDown.Size = new System.Drawing.Size(76, 26);
            this.gainNumUpDown.TabIndex = 0;
            this.toolTip1.SetToolTip(this.gainNumUpDown, "Gain of the camera");
            this.gainNumUpDown.ValueChanged += new System.EventHandler(this.gainNumUpDown_ValueChanged);
            // 
            // labelMinMaxReadingTime
            // 
            this.labelMinMaxReadingTime.AutoSize = true;
            this.labelMinMaxReadingTime.Location = new System.Drawing.Point(94, 92);
            this.labelMinMaxReadingTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinMaxReadingTime.Name = "labelMinMaxReadingTime";
            this.labelMinMaxReadingTime.Size = new System.Drawing.Size(44, 20);
            this.labelMinMaxReadingTime.TabIndex = 54;
            this.labelMinMaxReadingTime.Text = "0..20";
            // 
            // offsetNumUpDown
            // 
            this.offsetNumUpDown.Location = new System.Drawing.Point(150, 49);
            this.offsetNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.offsetNumUpDown.Size = new System.Drawing.Size(76, 26);
            this.offsetNumUpDown.TabIndex = 1;
            this.toolTip1.SetToolTip(this.offsetNumUpDown, "Offset of the camera");
            this.offsetNumUpDown.ValueChanged += new System.EventHandler(this.offsetNumUpDown_ValueChanged);
            // 
            // labelReadingTime
            // 
            this.labelReadingTime.AutoSize = true;
            this.labelReadingTime.Location = new System.Drawing.Point(4, 92);
            this.labelReadingTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReadingTime.Name = "labelReadingTime";
            this.labelReadingTime.Size = new System.Drawing.Size(86, 20);
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
            this.panelSettings.Location = new System.Drawing.Point(12, 167);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(317, 150);
            this.panelSettings.TabIndex = 68;
            // 
            // checkBoxDHT22
            // 
            this.checkBoxDHT22.AutoSize = true;
            this.checkBoxDHT22.Location = new System.Drawing.Point(4, 71);
            this.checkBoxDHT22.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxDHT22.Name = "checkBoxDHT22";
            this.checkBoxDHT22.Size = new System.Drawing.Size(86, 24);
            this.checkBoxDHT22.TabIndex = 79;
            this.checkBoxDHT22.Text = "DHT22";
            this.toolTip1.SetToolTip(this.checkBoxDHT22, "If DHT22 humidity/temperature sensor is present");
            this.checkBoxDHT22.UseVisualStyleBackColor = true;
            this.checkBoxDHT22.CheckedChanged += new System.EventHandler(this.checkBoxDHT22_CheckedChanged);
            // 
            // checkBoxOpenSettingsOnConnect
            // 
            this.checkBoxOpenSettingsOnConnect.AutoSize = true;
            this.checkBoxOpenSettingsOnConnect.Location = new System.Drawing.Point(180, 35);
            this.checkBoxOpenSettingsOnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOpenSettingsOnConnect.Name = "checkBoxOpenSettingsOnConnect";
            this.checkBoxOpenSettingsOnConnect.Size = new System.Drawing.Size(132, 24);
            this.checkBoxOpenSettingsOnConnect.TabIndex = 78;
            this.checkBoxOpenSettingsOnConnect.Text = "Open on start";
            this.toolTip1.SetToolTip(this.checkBoxOpenSettingsOnConnect, "If settings window will automatically open when the camera is connected");
            this.checkBoxOpenSettingsOnConnect.UseVisualStyleBackColor = true;
            this.checkBoxOpenSettingsOnConnect.CheckedChanged += new System.EventHandler(this.checkBoxOpenSettingsOnConnect_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 77;
            this.label5.Text = "C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 76;
            this.label4.Text = "Condens warning";
            // 
            // numericUpDownCondensationWarningTemperatureDifference
            // 
            this.numericUpDownCondensationWarningTemperatureDifference.Location = new System.Drawing.Point(237, 69);
            this.numericUpDownCondensationWarningTemperatureDifference.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.numericUpDownCondensationWarningTemperatureDifference.Size = new System.Drawing.Size(52, 26);
            this.numericUpDownCondensationWarningTemperatureDifference.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numericUpDownCondensationWarningTemperatureDifference, "A warning will be given if the difference between the sensor temperature and the " +
        "condensation temperature is less than this value");
            this.numericUpDownCondensationWarningTemperatureDifference.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownSensorClearTime
            // 
            this.numericUpDownSensorClearTime.Location = new System.Drawing.Point(194, 109);
            this.numericUpDownSensorClearTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownSensorClearTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownSensorClearTime.Name = "numericUpDownSensorClearTime";
            this.numericUpDownSensorClearTime.Size = new System.Drawing.Size(96, 26);
            this.numericUpDownSensorClearTime.TabIndex = 5;
            this.numericUpDownSensorClearTime.Tag = "";
            this.toolTip1.SetToolTip(this.numericUpDownSensorClearTime, "If exposure is longer than this value a bias frame will be taken (and discarded) " +
        "before the real exposure. This may help if you have charge accumulation problems" +
        ".");
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
            this.checkBoxOnTop.Location = new System.Drawing.Point(218, 5);
            this.checkBoxOnTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOnTop.Name = "checkBoxOnTop";
            this.checkBoxOnTop.Size = new System.Drawing.Size(87, 24);
            this.checkBoxOnTop.TabIndex = 1;
            this.checkBoxOnTop.Text = "On Top";
            this.toolTip1.SetToolTip(this.checkBoxOnTop, "If window always stays on top");
            this.checkBoxOnTop.UseVisualStyleBackColor = true;
            this.checkBoxOnTop.CheckedChanged += new System.EventHandler(this.onTopCheckBox_CheckedChanged);
            // 
            // labelSensorClear
            // 
            this.labelSensorClear.AutoSize = true;
            this.labelSensorClear.Location = new System.Drawing.Point(6, 112);
            this.labelSensorClear.Name = "labelSensorClear";
            this.labelSensorClear.Size = new System.Drawing.Size(174, 20);
            this.labelSensorClear.TabIndex = 69;
            this.labelSensorClear.Text = "Sensor clr if exposure >";
            // 
            // checkBoxMono
            // 
            this.checkBoxMono.AutoSize = true;
            this.checkBoxMono.Location = new System.Drawing.Point(135, 5);
            this.checkBoxMono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxMono.Name = "checkBoxMono";
            this.checkBoxMono.Size = new System.Drawing.Size(75, 24);
            this.checkBoxMono.TabIndex = 3;
            this.checkBoxMono.Text = "Mono";
            this.toolTip1.SetToolTip(this.checkBoxMono, "Mono (de-Bayered) or colour sensor. Restart software after changing.");
            this.checkBoxMono.UseVisualStyleBackColor = true;
            this.checkBoxMono.CheckedChanged += new System.EventHandler(this.checkBoxMono_CheckedChanged);
            // 
            // labelSensorClearSeconds
            // 
            this.labelSensorClearSeconds.AutoSize = true;
            this.labelSensorClearSeconds.Location = new System.Drawing.Point(194, 73);
            this.labelSensorClearSeconds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSensorClearSeconds.Name = "labelSensorClearSeconds";
            this.labelSensorClearSeconds.Size = new System.Drawing.Size(17, 20);
            this.labelSensorClearSeconds.TabIndex = 68;
            this.labelSensorClearSeconds.Text = "s";
            // 
            // checkBoxNightMode
            // 
            this.checkBoxNightMode.AutoSize = true;
            this.checkBoxNightMode.Location = new System.Drawing.Point(3, 3);
            this.checkBoxNightMode.Name = "checkBoxNightMode";
            this.checkBoxNightMode.Size = new System.Drawing.Size(116, 24);
            this.checkBoxNightMode.TabIndex = 0;
            this.checkBoxNightMode.Text = "Night Mode";
            this.toolTip1.SetToolTip(this.checkBoxNightMode, "Red/black or regular colours");
            this.checkBoxNightMode.UseVisualStyleBackColor = true;
            this.checkBoxNightMode.CheckedChanged += new System.EventHandler(this.checkBoxNightMode_CheckedChanged);
            // 
            // checkBoxTEConDuringRead
            // 
            this.checkBoxTEConDuringRead.AutoSize = true;
            this.checkBoxTEConDuringRead.Location = new System.Drawing.Point(4, 35);
            this.checkBoxTEConDuringRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxTEConDuringRead.Name = "checkBoxTEConDuringRead";
            this.checkBoxTEConDuringRead.Size = new System.Drawing.Size(172, 24);
            this.checkBoxTEConDuringRead.TabIndex = 2;
            this.checkBoxTEConDuringRead.Text = "Cooling during read";
            this.toolTip1.SetToolTip(this.checkBoxTEConDuringRead, "If cooling  will be on during frame reading/data transfer.");
            this.checkBoxTEConDuringRead.UseVisualStyleBackColor = true;
            this.checkBoxTEConDuringRead.CheckedChanged += new System.EventHandler(this.checkBoxTEConDuringRead_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 75;
            this.label3.Text = "max";
            // 
            // numericUpDownTECmaximumPowerPercent
            // 
            this.numericUpDownTECmaximumPowerPercent.Location = new System.Drawing.Point(242, 103);
            this.numericUpDownTECmaximumPowerPercent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownTECmaximumPowerPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTECmaximumPowerPercent.Name = "numericUpDownTECmaximumPowerPercent";
            this.numericUpDownTECmaximumPowerPercent.Size = new System.Drawing.Size(70, 26);
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
            this.label2.Location = new System.Drawing.Point(2, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "Cool pwr % start";
            // 
            // numericUpDownTECstartupPowerPercent
            // 
            this.numericUpDownTECstartupPowerPercent.Location = new System.Drawing.Point(134, 102);
            this.numericUpDownTECstartupPowerPercent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownTECstartupPowerPercent.Name = "numericUpDownTECstartupPowerPercent";
            this.numericUpDownTECstartupPowerPercent.Size = new System.Drawing.Size(60, 26);
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
            this.slowCoolingCheckBox.Location = new System.Drawing.Point(179, 11);
            this.slowCoolingCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.slowCoolingCheckBox.Name = "slowCoolingCheckBox";
            this.slowCoolingCheckBox.Size = new System.Drawing.Size(126, 24);
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
            this.slowCoolingNumUpDown.Location = new System.Drawing.Point(179, 45);
            this.slowCoolingNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.slowCoolingNumUpDown.Size = new System.Drawing.Size(76, 26);
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
            this.slowCoolingLabel.Location = new System.Drawing.Point(259, 51);
            this.slowCoolingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.slowCoolingLabel.Name = "slowCoolingLabel";
            this.slowCoolingLabel.Size = new System.Drawing.Size(49, 20);
            this.slowCoolingLabel.TabIndex = 51;
            this.slowCoolingLabel.Text = "C/min";
            // 
            // labelVersionInformation
            // 
            this.labelVersionInformation.AutoSize = true;
            this.labelVersionInformation.Location = new System.Drawing.Point(8, 14);
            this.labelVersionInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVersionInformation.Name = "labelVersionInformation";
            this.labelVersionInformation.Size = new System.Drawing.Size(60, 20);
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
            this.panelAscom.Location = new System.Drawing.Point(351, 40);
            this.panelAscom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelAscom.Name = "panelAscom";
            this.panelAscom.Size = new System.Drawing.Size(282, 551);
            this.panelAscom.TabIndex = 2;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(9, 5);
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(70, 35);
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
            this.numericUpDownPIDKp.Location = new System.Drawing.Point(69, 6);
            this.numericUpDownPIDKp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPIDKp.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            131072});
            this.numericUpDownPIDKp.Name = "numericUpDownPIDKp";
            this.numericUpDownPIDKp.Size = new System.Drawing.Size(90, 26);
            this.numericUpDownPIDKp.TabIndex = 77;
            this.toolTip1.SetToolTip(this.numericUpDownPIDKp, "Proportional gain of the PID loop for cooling (DO NOT CHANGE UNLESS YOU KNOW WHAT" +
        " YOU ARE DOING)");
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
            this.numericUpDownPIDKd.Location = new System.Drawing.Point(69, 65);
            this.numericUpDownPIDKd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPIDKd.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            131072});
            this.numericUpDownPIDKd.Name = "numericUpDownPIDKd";
            this.numericUpDownPIDKd.Size = new System.Drawing.Size(90, 26);
            this.numericUpDownPIDKd.TabIndex = 81;
            this.toolTip1.SetToolTip(this.numericUpDownPIDKd, "Derivative gain of the PID loop for cooling (DO NOT CHANGE UNLESS YOU KNOW WHAT Y" +
        "OU ARE DOING)");
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
            this.numericUpDownPIDKi.Location = new System.Drawing.Point(69, 35);
            this.numericUpDownPIDKi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPIDKi.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            131072});
            this.numericUpDownPIDKi.Name = "numericUpDownPIDKi";
            this.numericUpDownPIDKi.Size = new System.Drawing.Size(90, 26);
            this.numericUpDownPIDKi.TabIndex = 82;
            this.toolTip1.SetToolTip(this.numericUpDownPIDKi, "Integral gain of the PID loop for cooling (DO NOT CHANGE UNLESS YOU KNOW WHAT YOU" +
        " ARE DOING)");
            this.numericUpDownPIDKi.ValueChanged += new System.EventHandler(this.numericUpDownPIDKi_ValueChanged);
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
            this.panelImageInfo.Location = new System.Drawing.Point(12, 40);
            this.panelImageInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelImageInfo.Name = "panelImageInfo";
            this.panelImageInfo.Size = new System.Drawing.Size(317, 125);
            this.panelImageInfo.TabIndex = 70;
            // 
            // buttonHideSettings
            // 
            this.buttonHideSettings.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHideSettings.Location = new System.Drawing.Point(117, 91);
            this.buttonHideSettings.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHideSettings.Name = "buttonHideSettings";
            this.buttonHideSettings.Size = new System.Drawing.Size(64, 31);
            this.buttonHideSettings.TabIndex = 80;
            this.buttonHideSettings.Text = "▼";
            this.buttonHideSettings.UseVisualStyleBackColor = true;
            this.buttonHideSettings.Click += new System.EventHandler(this.buttonHideSettings_Click);
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(216, 37);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(47, 20);
            this.labelTemperature.TabIndex = 69;
            this.labelTemperature.Text = "T=0C";
            // 
            // labelDHTinfo
            // 
            this.labelDHTinfo.AutoSize = true;
            this.labelDHTinfo.Location = new System.Drawing.Point(6, 71);
            this.labelDHTinfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDHTinfo.Name = "labelDHTinfo";
            this.labelDHTinfo.Size = new System.Drawing.Size(156, 20);
            this.labelDHTinfo.TabIndex = 68;
            this.labelDHTinfo.Text = "Hum/Temp/DP: 0/0/0";
            // 
            // labelStdDev
            // 
            this.labelStdDev.AutoSize = true;
            this.labelStdDev.Location = new System.Drawing.Point(102, 8);
            this.labelStdDev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStdDev.Name = "labelStdDev";
            this.labelStdDev.Size = new System.Drawing.Size(75, 20);
            this.labelStdDev.TabIndex = 67;
            this.labelStdDev.Text = "StdDev:0";
            // 
            // labelMinMaxIntensities
            // 
            this.labelMinMaxIntensities.AutoSize = true;
            this.labelMinMaxIntensities.Location = new System.Drawing.Point(4, 37);
            this.labelMinMaxIntensities.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinMaxIntensities.Name = "labelMinMaxIntensities";
            this.labelMinMaxIntensities.Size = new System.Drawing.Size(93, 20);
            this.labelMinMaxIntensities.TabIndex = 64;
            this.labelMinMaxIntensities.Text = "Min/Max:0/0";
            // 
            // labelExposureDuration
            // 
            this.labelExposureDuration.AutoSize = true;
            this.labelExposureDuration.Location = new System.Drawing.Point(6, 8);
            this.labelExposureDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExposureDuration.Name = "labelExposureDuration";
            this.labelExposureDuration.Size = new System.Drawing.Size(64, 20);
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
            this.panelCooling.Location = new System.Drawing.Point(12, 452);
            this.panelCooling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelCooling.Name = "panelCooling";
            this.panelCooling.Size = new System.Drawing.Size(317, 139);
            this.panelCooling.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 80;
            this.label8.Text = "PID Ki";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 67);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 79;
            this.label7.Text = "PID Kd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 78;
            this.label6.Text = "PID Kp";
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(651, 655);
            this.Controls.Add(this.panelCooling);
            this.Controls.Add(this.panelImageInfo);
            this.Controls.Add(this.panelAscom);
            this.Controls.Add(this.labelVersionInformation);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelGainOffset);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}