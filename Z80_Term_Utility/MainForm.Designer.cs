namespace Z80_Term_Utility
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonCRLF = new System.Windows.Forms.RadioButton();
            this.radioButtonCR = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxImmediateSend = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbData3 = new System.Windows.Forms.TextBox();
            this.textBoxStartAt = new System.Windows.Forms.TextBox();
            this.buttonStartAt = new System.Windows.Forms.Button();
            this.buttonEsc = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDoFirstCommand = new System.Windows.Forms.Button();
            this.textBoxFirstCommand = new System.Windows.Forms.TextBox();
            this.buttonStartOnDevice = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCompareResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEndAddressRead = new System.Windows.Forms.TextBox();
            this.buttonCompareWriteAndRead = new System.Windows.Forms.Button();
            this.buttonReadFromDevice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStartAddressRead = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbData2 = new System.Windows.Forms.TextBox();
            this.groupBoxWriteToDevice = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonSC_MP = new System.Windows.Forms.RadioButton();
            this.radioButton_S_EMUF = new System.Windows.Forms.RadioButton();
            this.radioButton_Term_1 = new System.Windows.Forms.RadioButton();
            this.buttonWriteToDevice = new System.Windows.Forms.Button();
            this.buttonGetData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStartAddress = new System.Windows.Forms.TextBox();
            this.textBoxSelectedFile = new System.Windows.Forms.TextBox();
            this.buttonSelectReadFile = new System.Windows.Forms.Button();
            this.buttonClearScreen = new System.Windows.Forms.Button();
            this.buttonSetTextMode = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonSetGraphMode = new System.Windows.Forms.Button();
            this.buttonCR = new System.Windows.Forms.Button();
            this.buttonCRLF = new System.Windows.Forms.Button();
            this.textBoxSendSerial = new System.Windows.Forms.TextBox();
            this.textBoxSaveMessage = new System.Windows.Forms.TextBox();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.tbData1 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSaveParameters = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSerialDatName = new System.Windows.Forms.TextBox();
            this.textBoxSerialDatsFolderName = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.dataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.portNameComboBox = new System.Windows.Forms.ComboBox();
            this.timer01 = new System.Windows.Forms.Timer(this.components);
            this.serialSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timerSaveMessage = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerRestoreColor = new System.Windows.Forms.Timer(this.components);
            this.textBoxSelectWriteFile = new System.Windows.Forms.TextBox();
            this.buttonSelectWriteFile = new System.Windows.Forms.Button();
            this.buttonWriteToFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonClearWrite = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxWriteToDevice.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialSettingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 564);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonClearWrite);
            this.tabPage1.Controls.Add(this.buttonWriteToFile);
            this.tabPage1.Controls.Add(this.buttonSelectWriteFile);
            this.tabPage1.Controls.Add(this.textBoxSelectWriteFile);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.textBoxImmediateSend);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.tbData3);
            this.tabPage1.Controls.Add(this.textBoxStartAt);
            this.tabPage1.Controls.Add(this.buttonStartAt);
            this.tabPage1.Controls.Add(this.buttonEsc);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbData2);
            this.tabPage1.Controls.Add(this.groupBoxWriteToDevice);
            this.tabPage1.Controls.Add(this.buttonClearScreen);
            this.tabPage1.Controls.Add(this.buttonSetTextMode);
            this.tabPage1.Controls.Add(this.buttonSend);
            this.tabPage1.Controls.Add(this.buttonSetGraphMode);
            this.tabPage1.Controls.Add(this.buttonCR);
            this.tabPage1.Controls.Add(this.buttonCRLF);
            this.tabPage1.Controls.Add(this.textBoxSendSerial);
            this.tabPage1.Controls.Add(this.textBoxSaveMessage);
            this.tabPage1.Controls.Add(this.dataGridViewData);
            this.tabPage1.Controls.Add(this.tbData1);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.btnStop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Operation";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.SizeChanged += new System.EventHandler(this.tabPage1_SizeChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(582, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Only for Term1:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(427, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "Term 1 Commands";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonCRLF);
            this.groupBox5.Controls.Add(this.radioButtonCR);
            this.groupBox5.Location = new System.Drawing.Point(317, 382);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(119, 65);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            // 
            // radioButtonCRLF
            // 
            this.radioButtonCRLF.AutoSize = true;
            this.radioButtonCRLF.Location = new System.Drawing.Point(7, 42);
            this.radioButtonCRLF.Name = "radioButtonCRLF";
            this.radioButtonCRLF.Size = new System.Drawing.Size(52, 17);
            this.radioButtonCRLF.TabIndex = 1;
            this.radioButtonCRLF.TabStop = true;
            this.radioButtonCRLF.Text = "CRLF";
            this.radioButtonCRLF.UseVisualStyleBackColor = true;
            // 
            // radioButtonCR
            // 
            this.radioButtonCR.AutoSize = true;
            this.radioButtonCR.Location = new System.Drawing.Point(6, 14);
            this.radioButtonCR.Name = "radioButtonCR";
            this.radioButtonCR.Size = new System.Drawing.Size(40, 17);
            this.radioButtonCR.TabIndex = 0;
            this.radioButtonCR.TabStop = true;
            this.radioButtonCR.Text = "CR";
            this.radioButtonCR.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(60, 310);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "Send after CR or Cmd Button Click";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(60, 358);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Immediate Send";
            // 
            // textBoxImmediateSend
            // 
            this.textBoxImmediateSend.Location = new System.Drawing.Point(63, 376);
            this.textBoxImmediateSend.Multiline = true;
            this.textBoxImmediateSend.Name = "textBoxImmediateSend";
            this.textBoxImmediateSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxImmediateSend.Size = new System.Drawing.Size(239, 85);
            this.textBoxImmediateSend.TabIndex = 29;
            this.textBoxImmediateSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxImmediateSend_KeyUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(60, 215);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Char Return Window";
            // 
            // tbData3
            // 
            this.tbData3.Location = new System.Drawing.Point(63, 234);
            this.tbData3.Multiline = true;
            this.tbData3.Name = "tbData3";
            this.tbData3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbData3.Size = new System.Drawing.Size(165, 73);
            this.tbData3.TabIndex = 27;
            // 
            // textBoxStartAt
            // 
            this.textBoxStartAt.Location = new System.Drawing.Point(415, 155);
            this.textBoxStartAt.Name = "textBoxStartAt";
            this.textBoxStartAt.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartAt.TabIndex = 26;
            this.textBoxStartAt.Text = "0000";
            this.textBoxStartAt.TextChanged += new System.EventHandler(this.textBoxStartAt_TextChanged);
            this.textBoxStartAt.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxStartAt_Validating);
            // 
            // buttonStartAt
            // 
            this.buttonStartAt.Location = new System.Drawing.Point(417, 181);
            this.buttonStartAt.Name = "buttonStartAt";
            this.buttonStartAt.Size = new System.Drawing.Size(105, 47);
            this.buttonStartAt.TabIndex = 25;
            this.buttonStartAt.Text = "Start at Location  WE $xxxx";
            this.buttonStartAt.UseVisualStyleBackColor = true;
            this.buttonStartAt.Click += new System.EventHandler(this.buttonStartAt_Click);
            // 
            // buttonEsc
            // 
            this.buttonEsc.Location = new System.Drawing.Point(308, 353);
            this.buttonEsc.Name = "buttonEsc";
            this.buttonEsc.Size = new System.Drawing.Size(91, 23);
            this.buttonEsc.TabIndex = 24;
            this.buttonEsc.Text = "Send Esc (0x1B)";
            this.buttonEsc.UseVisualStyleBackColor = true;
            this.buttonEsc.Click += new System.EventHandler(this.buttonEsc_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(582, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(282, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "If compare is \"Euqal\" you can start the Program on Term 1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(582, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Click \'Compare\'";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(582, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(250, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Click \'Read from Device\' --> Read back to compare";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(582, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Click \'Deploy to Device\' (Select target before)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(582, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(260, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Click \'Get-File-Data\' to load the bytes into this program";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(582, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "How to: Select a file with binary data (Code for Z80)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDoFirstCommand);
            this.groupBox3.Controls.Add(this.textBoxFirstCommand);
            this.groupBox3.Controls.Add(this.buttonStartOnDevice);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxCompareResult);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxEndAddressRead);
            this.groupBox3.Controls.Add(this.buttonCompareWriteAndRead);
            this.groupBox3.Controls.Add(this.buttonReadFromDevice);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxStartAddressRead);
            this.groupBox3.Location = new System.Drawing.Point(582, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 250);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Read back from Device, compare and start (Only for Term 1)";
            // 
            // buttonDoFirstCommand
            // 
            this.buttonDoFirstCommand.Location = new System.Drawing.Point(116, 131);
            this.buttonDoFirstCommand.Name = "buttonDoFirstCommand";
            this.buttonDoFirstCommand.Size = new System.Drawing.Size(34, 23);
            this.buttonDoFirstCommand.TabIndex = 16;
            this.buttonDoFirstCommand.Text = "Do";
            this.buttonDoFirstCommand.UseVisualStyleBackColor = true;
            this.buttonDoFirstCommand.Visible = false;
            this.buttonDoFirstCommand.Click += new System.EventHandler(this.buttonDoFirstCommand_Click);
            // 
            // textBoxFirstCommand
            // 
            this.textBoxFirstCommand.Location = new System.Drawing.Point(7, 131);
            this.textBoxFirstCommand.Name = "textBoxFirstCommand";
            this.textBoxFirstCommand.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstCommand.TabIndex = 15;
            this.textBoxFirstCommand.Visible = false;
            // 
            // buttonStartOnDevice
            // 
            this.buttonStartOnDevice.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonStartOnDevice.Location = new System.Drawing.Point(101, 192);
            this.buttonStartOnDevice.Name = "buttonStartOnDevice";
            this.buttonStartOnDevice.Size = new System.Drawing.Size(152, 43);
            this.buttonStartOnDevice.TabIndex = 14;
            this.buttonStartOnDevice.Text = "Start Program on Term 1";
            this.buttonStartOnDevice.UseVisualStyleBackColor = false;
            this.buttonStartOnDevice.Click += new System.EventHandler(this.buttonStartOnDevice_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "CompareResult";
            // 
            // textBoxCompareResult
            // 
            this.textBoxCompareResult.Location = new System.Drawing.Point(168, 131);
            this.textBoxCompareResult.Name = "textBoxCompareResult";
            this.textBoxCompareResult.Size = new System.Drawing.Size(143, 20);
            this.textBoxCompareResult.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Endaddress in hex";
            // 
            // textBoxEndAddressRead
            // 
            this.textBoxEndAddressRead.Location = new System.Drawing.Point(6, 48);
            this.textBoxEndAddressRead.Name = "textBoxEndAddressRead";
            this.textBoxEndAddressRead.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndAddressRead.TabIndex = 6;
            this.textBoxEndAddressRead.Text = "0000";
            this.textBoxEndAddressRead.TextChanged += new System.EventHandler(this.textBoxEndAddressRead_TextChanged);
            this.textBoxEndAddressRead.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEndAddressRead_Validating);
            // 
            // buttonCompareWriteAndRead
            // 
            this.buttonCompareWriteAndRead.Location = new System.Drawing.Point(168, 84);
            this.buttonCompareWriteAndRead.Name = "buttonCompareWriteAndRead";
            this.buttonCompareWriteAndRead.Size = new System.Drawing.Size(143, 23);
            this.buttonCompareWriteAndRead.TabIndex = 5;
            this.buttonCompareWriteAndRead.Text = "Compare";
            this.buttonCompareWriteAndRead.UseVisualStyleBackColor = true;
            this.buttonCompareWriteAndRead.Click += new System.EventHandler(this.buttonCompareWriteAndRead_Click);
            // 
            // buttonReadFromDevice
            // 
            this.buttonReadFromDevice.Location = new System.Drawing.Point(7, 84);
            this.buttonReadFromDevice.Name = "buttonReadFromDevice";
            this.buttonReadFromDevice.Size = new System.Drawing.Size(143, 23);
            this.buttonReadFromDevice.TabIndex = 4;
            this.buttonReadFromDevice.Text = "Read back from Term 1";
            this.buttonReadFromDevice.UseVisualStyleBackColor = true;
            this.buttonReadFromDevice.Click += new System.EventHandler(this.buttonReadFromDevice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Startaddress in hex";
            // 
            // textBoxStartAddressRead
            // 
            this.textBoxStartAddressRead.Location = new System.Drawing.Point(7, 19);
            this.textBoxStartAddressRead.Name = "textBoxStartAddressRead";
            this.textBoxStartAddressRead.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartAddressRead.TabIndex = 2;
            this.textBoxStartAddressRead.Text = "0000";
            this.textBoxStartAddressRead.TextChanged += new System.EventHandler(this.textBoxStartAddressRead_TextChanged);
            this.textBoxStartAddressRead.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxStartAddressRead_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Window: Write to Device (hex)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Window: Read from Device (hex)";
            // 
            // tbData2
            // 
            this.tbData2.Location = new System.Drawing.Point(244, 52);
            this.tbData2.Multiline = true;
            this.tbData2.Name = "tbData2";
            this.tbData2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbData2.Size = new System.Drawing.Size(165, 123);
            this.tbData2.TabIndex = 13;
            // 
            // groupBoxWriteToDevice
            // 
            this.groupBoxWriteToDevice.Controls.Add(this.groupBox4);
            this.groupBoxWriteToDevice.Controls.Add(this.buttonWriteToDevice);
            this.groupBoxWriteToDevice.Controls.Add(this.buttonGetData);
            this.groupBoxWriteToDevice.Controls.Add(this.label1);
            this.groupBoxWriteToDevice.Controls.Add(this.textBoxStartAddress);
            this.groupBoxWriteToDevice.Controls.Add(this.textBoxSelectedFile);
            this.groupBoxWriteToDevice.Controls.Add(this.buttonSelectReadFile);
            this.groupBoxWriteToDevice.Location = new System.Drawing.Point(582, 123);
            this.groupBoxWriteToDevice.Name = "groupBoxWriteToDevice";
            this.groupBoxWriteToDevice.Size = new System.Drawing.Size(369, 153);
            this.groupBoxWriteToDevice.TabIndex = 12;
            this.groupBoxWriteToDevice.TabStop = false;
            this.groupBoxWriteToDevice.Text = "Write binary Data from File to Device";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonSC_MP);
            this.groupBox4.Controls.Add(this.radioButton_S_EMUF);
            this.groupBox4.Controls.Add(this.radioButton_Term_1);
            this.groupBox4.Location = new System.Drawing.Point(116, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 83);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Device Select";
            // 
            // radioButtonSC_MP
            // 
            this.radioButtonSC_MP.AutoSize = true;
            this.radioButtonSC_MP.Location = new System.Drawing.Point(7, 63);
            this.radioButtonSC_MP.Name = "radioButtonSC_MP";
            this.radioButtonSC_MP.Size = new System.Drawing.Size(115, 17);
            this.radioButtonSC_MP.TabIndex = 2;
            this.radioButtonSC_MP.TabStop = true;
            this.radioButtonSC_MP.Text = "SC/MP (600 Baud)";
            this.radioButtonSC_MP.UseVisualStyleBackColor = true;
            this.radioButtonSC_MP.CheckedChanged += new System.EventHandler(this.radioButtonSC_MP_CheckedChanged);
            // 
            // radioButton_S_EMUF
            // 
            this.radioButton_S_EMUF.AutoSize = true;
            this.radioButton_S_EMUF.Location = new System.Drawing.Point(6, 39);
            this.radioButton_S_EMUF.Name = "radioButton_S_EMUF";
            this.radioButton_S_EMUF.Size = new System.Drawing.Size(126, 17);
            this.radioButton_S_EMUF.TabIndex = 1;
            this.radioButton_S_EMUF.TabStop = true;
            this.radioButton_S_EMUF.Text = "S-EMUF (9600 Baud)";
            this.radioButton_S_EMUF.UseVisualStyleBackColor = true;
            this.radioButton_S_EMUF.CheckedChanged += new System.EventHandler(this.radioButton_S_EMUF_CheckedChanged);
            // 
            // radioButton_Term_1
            // 
            this.radioButton_Term_1.AutoSize = true;
            this.radioButton_Term_1.Location = new System.Drawing.Point(6, 16);
            this.radioButton_Term_1.Name = "radioButton_Term_1";
            this.radioButton_Term_1.Size = new System.Drawing.Size(119, 17);
            this.radioButton_Term_1.TabIndex = 0;
            this.radioButton_Term_1.TabStop = true;
            this.radioButton_Term_1.Text = "Term 1 (9600 Baud)";
            this.radioButton_Term_1.UseVisualStyleBackColor = true;
            this.radioButton_Term_1.CheckedChanged += new System.EventHandler(this.radioButton_Term_1_CheckedChanged);
            // 
            // buttonWriteToDevice
            // 
            this.buttonWriteToDevice.Location = new System.Drawing.Point(269, 80);
            this.buttonWriteToDevice.Name = "buttonWriteToDevice";
            this.buttonWriteToDevice.Size = new System.Drawing.Size(100, 48);
            this.buttonWriteToDevice.TabIndex = 5;
            this.buttonWriteToDevice.Text = "Deploy to Device";
            this.buttonWriteToDevice.UseVisualStyleBackColor = true;
            this.buttonWriteToDevice.Click += new System.EventHandler(this.buttonWriteToDevice_Click);
            // 
            // buttonGetData
            // 
            this.buttonGetData.Location = new System.Drawing.Point(7, 71);
            this.buttonGetData.Name = "buttonGetData";
            this.buttonGetData.Size = new System.Drawing.Size(100, 23);
            this.buttonGetData.TabIndex = 4;
            this.buttonGetData.Text = "Get File-Data";
            this.buttonGetData.UseVisualStyleBackColor = true;
            this.buttonGetData.Click += new System.EventHandler(this.buttonGetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Startaddress in hex";
            // 
            // textBoxStartAddress
            // 
            this.textBoxStartAddress.Location = new System.Drawing.Point(7, 45);
            this.textBoxStartAddress.Name = "textBoxStartAddress";
            this.textBoxStartAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartAddress.TabIndex = 2;
            this.textBoxStartAddress.Text = "0000";
            this.textBoxStartAddress.TextChanged += new System.EventHandler(this.textBoxStartAddress_TextChanged);
            this.textBoxStartAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxStartAddress_Validating);
            // 
            // textBoxSelectedFile
            // 
            this.textBoxSelectedFile.Location = new System.Drawing.Point(6, 22);
            this.textBoxSelectedFile.Name = "textBoxSelectedFile";
            this.textBoxSelectedFile.Size = new System.Drawing.Size(234, 20);
            this.textBoxSelectedFile.TabIndex = 1;
            // 
            // buttonSelectReadFile
            // 
            this.buttonSelectReadFile.Location = new System.Drawing.Point(262, 20);
            this.buttonSelectReadFile.Name = "buttonSelectReadFile";
            this.buttonSelectReadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectReadFile.TabIndex = 0;
            this.buttonSelectReadFile.Text = "Select File";
            this.buttonSelectReadFile.UseVisualStyleBackColor = true;
            this.buttonSelectReadFile.Click += new System.EventHandler(this.buttonSelectReadFile_Click);
            // 
            // buttonClearScreen
            // 
            this.buttonClearScreen.Location = new System.Drawing.Point(422, 110);
            this.buttonClearScreen.Name = "buttonClearScreen";
            this.buttonClearScreen.Size = new System.Drawing.Size(105, 23);
            this.buttonClearScreen.TabIndex = 11;
            this.buttonClearScreen.Text = "Clear Screen";
            this.buttonClearScreen.UseVisualStyleBackColor = true;
            this.buttonClearScreen.Click += new System.EventHandler(this.buttonClearScreen_Click);
            // 
            // buttonSetTextMode
            // 
            this.buttonSetTextMode.Location = new System.Drawing.Point(422, 81);
            this.buttonSetTextMode.Name = "buttonSetTextMode";
            this.buttonSetTextMode.Size = new System.Drawing.Size(105, 23);
            this.buttonSetTextMode.TabIndex = 10;
            this.buttonSetTextMode.Text = "Set Text Mode";
            this.buttonSetTextMode.UseVisualStyleBackColor = true;
            this.buttonSetTextMode.Click += new System.EventHandler(this.buttonSetTextMode_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(415, 323);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(41, 23);
            this.buttonSend.TabIndex = 9;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonSetGraphMode
            // 
            this.buttonSetGraphMode.Location = new System.Drawing.Point(422, 52);
            this.buttonSetGraphMode.Name = "buttonSetGraphMode";
            this.buttonSetGraphMode.Size = new System.Drawing.Size(105, 23);
            this.buttonSetGraphMode.TabIndex = 8;
            this.buttonSetGraphMode.Text = "Set Graph Mode";
            this.buttonSetGraphMode.UseVisualStyleBackColor = true;
            this.buttonSetGraphMode.Click += new System.EventHandler(this.buttonSetGraphMode_Click);
            // 
            // buttonCR
            // 
            this.buttonCR.Location = new System.Drawing.Point(363, 324);
            this.buttonCR.Name = "buttonCR";
            this.buttonCR.Size = new System.Drawing.Size(46, 23);
            this.buttonCR.TabIndex = 7;
            this.buttonCR.Text = "CR";
            this.buttonCR.UseVisualStyleBackColor = true;
            this.buttonCR.Click += new System.EventHandler(this.buttonCR_Click);
            // 
            // buttonCRLF
            // 
            this.buttonCRLF.Location = new System.Drawing.Point(308, 324);
            this.buttonCRLF.Name = "buttonCRLF";
            this.buttonCRLF.Size = new System.Drawing.Size(49, 23);
            this.buttonCRLF.TabIndex = 6;
            this.buttonCRLF.Text = "CRLF";
            this.buttonCRLF.UseVisualStyleBackColor = true;
            this.buttonCRLF.Click += new System.EventHandler(this.buttonCRLF_Click);
            // 
            // textBoxSendSerial
            // 
            this.textBoxSendSerial.Location = new System.Drawing.Point(63, 326);
            this.textBoxSendSerial.Name = "textBoxSendSerial";
            this.textBoxSendSerial.Size = new System.Drawing.Size(239, 20);
            this.textBoxSendSerial.TabIndex = 5;
            this.textBoxSendSerial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSendSerial_KeyUp);
            // 
            // textBoxSaveMessage
            // 
            this.textBoxSaveMessage.Location = new System.Drawing.Point(204, 474);
            this.textBoxSaveMessage.Name = "textBoxSaveMessage";
            this.textBoxSaveMessage.Size = new System.Drawing.Size(114, 20);
            this.textBoxSaveMessage.TabIndex = 4;
            this.textBoxSaveMessage.Visible = false;
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(49, 511);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.Size = new System.Drawing.Size(466, 21);
            this.dataGridViewData.TabIndex = 3;
            this.dataGridViewData.Visible = false;
            // 
            // tbData1
            // 
            this.tbData1.Location = new System.Drawing.Point(63, 52);
            this.tbData1.Multiline = true;
            this.tbData1.Name = "tbData1";
            this.tbData1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbData1.Size = new System.Drawing.Size(165, 123);
            this.tbData1.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(91, 474);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(415, 471);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSaveParameters);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(970, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSaveParameters
            // 
            this.buttonSaveParameters.Location = new System.Drawing.Point(377, 455);
            this.buttonSaveParameters.Name = "buttonSaveParameters";
            this.buttonSaveParameters.Size = new System.Drawing.Size(117, 23);
            this.buttonSaveParameters.TabIndex = 2;
            this.buttonSaveParameters.Text = "Save Settings";
            this.buttonSaveParameters.UseVisualStyleBackColor = true;
            this.buttonSaveParameters.Click += new System.EventHandler(this.buttonSaveParameters_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSerialDatName);
            this.groupBox2.Controls.Add(this.textBoxSerialDatsFolderName);
            this.groupBox2.Controls.Add(this.buttonBrowse);
            this.groupBox2.Location = new System.Drawing.Point(43, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // textBoxSerialDatName
            // 
            this.textBoxSerialDatName.Location = new System.Drawing.Point(93, 60);
            this.textBoxSerialDatName.Name = "textBoxSerialDatName";
            this.textBoxSerialDatName.Size = new System.Drawing.Size(233, 20);
            this.textBoxSerialDatName.TabIndex = 2;
            // 
            // textBoxSerialDatsFolderName
            // 
            this.textBoxSerialDatsFolderName.Location = new System.Drawing.Point(93, 20);
            this.textBoxSerialDatsFolderName.Name = "textBoxSerialDatsFolderName";
            this.textBoxSerialDatsFolderName.Size = new System.Drawing.Size(233, 20);
            this.textBoxSerialDatsFolderName.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(425, 34);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(58, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopBitsComboBox);
            this.groupBox1.Controls.Add(this.parityComboBox);
            this.groupBox1.Controls.Add(this.dataBitsComboBox);
            this.groupBox1.Controls.Add(this.baudRateComboBox);
            this.groupBox1.Controls.Add(this.portNameComboBox);
            this.groupBox1.Location = new System.Drawing.Point(76, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Settings";
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.FormattingEnabled = true;
            this.stopBitsComboBox.Location = new System.Drawing.Point(40, 201);
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.stopBitsComboBox.TabIndex = 4;
            // 
            // parityComboBox
            // 
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Location = new System.Drawing.Point(40, 160);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(121, 21);
            this.parityComboBox.TabIndex = 3;
            // 
            // dataBitsComboBox
            // 
            this.dataBitsComboBox.FormattingEnabled = true;
            this.dataBitsComboBox.Location = new System.Drawing.Point(40, 118);
            this.dataBitsComboBox.Name = "dataBitsComboBox";
            this.dataBitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.dataBitsComboBox.TabIndex = 2;
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Location = new System.Drawing.Point(40, 79);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.baudRateComboBox.TabIndex = 1;
            // 
            // portNameComboBox
            // 
            this.portNameComboBox.FormattingEnabled = true;
            this.portNameComboBox.Location = new System.Drawing.Point(40, 43);
            this.portNameComboBox.Name = "portNameComboBox";
            this.portNameComboBox.Size = new System.Drawing.Size(121, 21);
            this.portNameComboBox.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textBoxSelectWriteFile
            // 
            this.textBoxSelectWriteFile.Location = new System.Drawing.Point(63, 181);
            this.textBoxSelectWriteFile.Name = "textBoxSelectWriteFile";
            this.textBoxSelectWriteFile.Size = new System.Drawing.Size(152, 20);
            this.textBoxSelectWriteFile.TabIndex = 35;
            // 
            // buttonSelectWriteFile
            // 
            this.buttonSelectWriteFile.Location = new System.Drawing.Point(221, 178);
            this.buttonSelectWriteFile.Name = "buttonSelectWriteFile";
            this.buttonSelectWriteFile.Size = new System.Drawing.Size(113, 23);
            this.buttonSelectWriteFile.TabIndex = 36;
            this.buttonSelectWriteFile.Text = "Select File to write";
            this.buttonSelectWriteFile.UseVisualStyleBackColor = true;
            this.buttonSelectWriteFile.Click += new System.EventHandler(this.buttonSelectWriteFile_Click);
            // 
            // buttonWriteToFile
            // 
            this.buttonWriteToFile.Location = new System.Drawing.Point(221, 203);
            this.buttonWriteToFile.Name = "buttonWriteToFile";
            this.buttonWriteToFile.Size = new System.Drawing.Size(113, 23);
            this.buttonWriteToFile.TabIndex = 37;
            this.buttonWriteToFile.Text = "Write to File";
            this.buttonWriteToFile.UseVisualStyleBackColor = true;
            this.buttonWriteToFile.Click += new System.EventHandler(this.buttonWriteToFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // buttonClearWrite
            // 
            this.buttonClearWrite.Location = new System.Drawing.Point(63, 23);
            this.buttonClearWrite.Name = "buttonClearWrite";
            this.buttonClearWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonClearWrite.TabIndex = 38;
            this.buttonClearWrite.Text = "Clear";
            this.buttonClearWrite.UseVisualStyleBackColor = true;
            this.buttonClearWrite.Click += new System.EventHandler(this.buttonClearWrite_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 579);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Z80_Term_Utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxWriteToDevice.ResumeLayout(false);
            this.groupBoxWriteToDevice.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serialSettingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox stopBitsComboBox;
        private System.Windows.Forms.ComboBox parityComboBox;
        private System.Windows.Forms.ComboBox dataBitsComboBox;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.ComboBox portNameComboBox;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.TextBox tbData1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox textBoxSaveMessage;
        private System.Windows.Forms.Timer timer01;
        private System.Windows.Forms.BindingSource serialSettingsBindingSource;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timerSaveMessage;
        private System.Windows.Forms.Button buttonSaveParameters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSerialDatName;
        private System.Windows.Forms.TextBox textBoxSerialDatsFolderName;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonCR;
        private System.Windows.Forms.Button buttonCRLF;
        private System.Windows.Forms.TextBox textBoxSendSerial;
        private System.Windows.Forms.Button buttonSetGraphMode;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonSetTextMode;
        private System.Windows.Forms.Button buttonClearScreen;
        private System.Windows.Forms.GroupBox groupBoxWriteToDevice;
        private System.Windows.Forms.Button buttonSelectReadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxSelectedFile;
        private System.Windows.Forms.Button buttonGetData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStartAddress;
        private System.Windows.Forms.Button buttonWriteToDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbData2;
        private System.Windows.Forms.Timer timerRestoreColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEndAddressRead;
        private System.Windows.Forms.Button buttonCompareWriteAndRead;
        private System.Windows.Forms.Button buttonReadFromDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStartAddressRead;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCompareResult;
        private System.Windows.Forms.Button buttonStartOnDevice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonEsc;
        private System.Windows.Forms.TextBox textBoxStartAt;
        private System.Windows.Forms.Button buttonStartAt;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxImmediateSend;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbData3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonSC_MP;
        private System.Windows.Forms.RadioButton radioButton_S_EMUF;
        private System.Windows.Forms.RadioButton radioButton_Term_1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonCRLF;
        private System.Windows.Forms.RadioButton radioButtonCR;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDoFirstCommand;
        private System.Windows.Forms.TextBox textBoxFirstCommand;
        private System.Windows.Forms.Button buttonWriteToFile;
        private System.Windows.Forms.Button buttonSelectWriteFile;
        private System.Windows.Forms.TextBox textBoxSelectWriteFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonClearWrite;
    }
}

