namespace AmbilKtm
{
    partial class Device2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bRs232Discon = new System.Windows.Forms.Button();
            this.bRs232Con = new System.Windows.Forms.Button();
            this.cBaudrate = new System.Windows.Forms.ComboBox();
            this.cCommPort = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tEpcData = new System.Windows.Forms.TextBox();
            this.cEpcWordcnt = new System.Windows.Forms.ComboBox();
            this.cEpcWordptr = new System.Windows.Forms.ComboBox();
            this.cEpcMembank = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tEpcSpeed = new System.Windows.Forms.TrackBar();
            this.cEpcTimes = new System.Windows.Forms.ComboBox();
            this.bEpcWrite = new System.Windows.Forms.Button();
            this.bEpcRead = new System.Windows.Forms.Button();
            this.bEpcId = new System.Windows.Forms.Button();
            this.lInfo = new System.Windows.Forms.ListBox();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.clhNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTagData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTimes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.bClear = new System.Windows.Forms.Button();
            this.btHome = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.timerScanISO = new System.Windows.Forms.Timer(this.components);
            this.timerScanEPC = new System.Windows.Forms.Timer(this.components);
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEpcSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bRs232Discon);
            this.groupBox1.Controls.Add(this.bRs232Con);
            this.groupBox1.Controls.Add(this.cBaudrate);
            this.groupBox1.Controls.Add(this.cCommPort);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(356, 191);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RS232";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(48, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "BAUDRATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(48, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "COMM PORT";
            // 
            // bRs232Discon
            // 
            this.bRs232Discon.BackColor = System.Drawing.Color.SlateGray;
            this.bRs232Discon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRs232Discon.ForeColor = System.Drawing.Color.Black;
            this.bRs232Discon.Location = new System.Drawing.Point(199, 134);
            this.bRs232Discon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bRs232Discon.Name = "bRs232Discon";
            this.bRs232Discon.Size = new System.Drawing.Size(116, 49);
            this.bRs232Discon.TabIndex = 5;
            this.bRs232Discon.Text = "Discon";
            this.bRs232Discon.UseVisualStyleBackColor = false;
            this.bRs232Discon.Click += new System.EventHandler(this.bRs232Discon_Click);
            // 
            // bRs232Con
            // 
            this.bRs232Con.BackColor = System.Drawing.Color.SlateGray;
            this.bRs232Con.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRs232Con.ForeColor = System.Drawing.Color.Black;
            this.bRs232Con.Location = new System.Drawing.Point(53, 134);
            this.bRs232Con.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bRs232Con.Name = "bRs232Con";
            this.bRs232Con.Size = new System.Drawing.Size(116, 49);
            this.bRs232Con.TabIndex = 4;
            this.bRs232Con.Text = "Connect";
            this.bRs232Con.UseVisualStyleBackColor = false;
            this.bRs232Con.Click += new System.EventHandler(this.bRs232Con_Click);
            // 
            // cBaudrate
            // 
            this.cBaudrate.FormattingEnabled = true;
            this.cBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cBaudrate.Location = new System.Drawing.Point(184, 85);
            this.cBaudrate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cBaudrate.Name = "cBaudrate";
            this.cBaudrate.Size = new System.Drawing.Size(129, 29);
            this.cBaudrate.TabIndex = 3;
            // 
            // cCommPort
            // 
            this.cCommPort.FormattingEnabled = true;
            this.cCommPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cCommPort.Location = new System.Drawing.Point(184, 36);
            this.cCommPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cCommPort.Name = "cCommPort";
            this.cCommPort.Size = new System.Drawing.Size(129, 29);
            this.cCommPort.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.tEpcData);
            this.groupBox6.Controls.Add(this.cEpcWordcnt);
            this.groupBox6.Controls.Add(this.cEpcWordptr);
            this.groupBox6.Controls.Add(this.cEpcMembank);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.tEpcSpeed);
            this.groupBox6.Controls.Add(this.cEpcTimes);
            this.groupBox6.Controls.Add(this.bEpcWrite);
            this.groupBox6.Controls.Add(this.bEpcRead);
            this.groupBox6.Controls.Add(this.bEpcId);
            this.groupBox6.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox6.Location = new System.Drawing.Point(13, 215);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(537, 419);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ISO18000-6C(EPC G2)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(15, 369);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 24);
            this.label17.TabIndex = 26;
            this.label17.Text = "Data(Hex)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(12, 209);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 24);
            this.label16.TabIndex = 25;
            this.label16.Text = "MemBank";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(15, 325);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 24);
            this.label15.TabIndex = 24;
            this.label15.Text = "WordCnt";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(12, 266);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 24);
            this.label14.TabIndex = 22;
            this.label14.Text = "WordPtr";
            // 
            // tEpcData
            // 
            this.tEpcData.Location = new System.Drawing.Point(145, 369);
            this.tEpcData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tEpcData.Name = "tEpcData";
            this.tEpcData.Size = new System.Drawing.Size(185, 35);
            this.tEpcData.TabIndex = 21;
            // 
            // cEpcWordcnt
            // 
            this.cEpcWordcnt.FormattingEnabled = true;
            this.cEpcWordcnt.Location = new System.Drawing.Point(145, 319);
            this.cEpcWordcnt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cEpcWordcnt.Name = "cEpcWordcnt";
            this.cEpcWordcnt.Size = new System.Drawing.Size(129, 32);
            this.cEpcWordcnt.TabIndex = 20;
            // 
            // cEpcWordptr
            // 
            this.cEpcWordptr.FormattingEnabled = true;
            this.cEpcWordptr.Location = new System.Drawing.Point(145, 261);
            this.cEpcWordptr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cEpcWordptr.Name = "cEpcWordptr";
            this.cEpcWordptr.Size = new System.Drawing.Size(129, 32);
            this.cEpcWordptr.TabIndex = 19;
            // 
            // cEpcMembank
            // 
            this.cEpcMembank.FormattingEnabled = true;
            this.cEpcMembank.Items.AddRange(new object[] {
            "RESERVE",
            "EPC",
            "TID",
            "USER"});
            this.cEpcMembank.Location = new System.Drawing.Point(145, 209);
            this.cEpcMembank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cEpcMembank.Name = "cEpcMembank";
            this.cEpcMembank.Size = new System.Drawing.Size(129, 32);
            this.cEpcMembank.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(27, 146);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "Times";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(24, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "Speed";
            // 
            // tEpcSpeed
            // 
            this.tEpcSpeed.Location = new System.Drawing.Point(107, 66);
            this.tEpcSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tEpcSpeed.Name = "tEpcSpeed";
            this.tEpcSpeed.Size = new System.Drawing.Size(233, 69);
            this.tEpcSpeed.TabIndex = 15;
            // 
            // cEpcTimes
            // 
            this.cEpcTimes.FormattingEnabled = true;
            this.cEpcTimes.Items.AddRange(new object[] {
            "Continours",
            "1",
            "10",
            "100",
            "1000",
            "5000"});
            this.cEpcTimes.Location = new System.Drawing.Point(145, 144);
            this.cEpcTimes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cEpcTimes.Name = "cEpcTimes";
            this.cEpcTimes.Size = new System.Drawing.Size(129, 32);
            this.cEpcTimes.TabIndex = 14;
            // 
            // bEpcWrite
            // 
            this.bEpcWrite.BackColor = System.Drawing.Color.SlateGray;
            this.bEpcWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bEpcWrite.ForeColor = System.Drawing.Color.Black;
            this.bEpcWrite.Location = new System.Drawing.Point(375, 206);
            this.bEpcWrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bEpcWrite.Name = "bEpcWrite";
            this.bEpcWrite.Size = new System.Drawing.Size(135, 44);
            this.bEpcWrite.TabIndex = 7;
            this.bEpcWrite.Text = "Write";
            this.bEpcWrite.UseVisualStyleBackColor = false;
            this.bEpcWrite.Click += new System.EventHandler(this.bEpcWrite_Click);
            // 
            // bEpcRead
            // 
            this.bEpcRead.BackColor = System.Drawing.Color.SlateGray;
            this.bEpcRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bEpcRead.ForeColor = System.Drawing.Color.Black;
            this.bEpcRead.Location = new System.Drawing.Point(375, 146);
            this.bEpcRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bEpcRead.Name = "bEpcRead";
            this.bEpcRead.Size = new System.Drawing.Size(135, 44);
            this.bEpcRead.TabIndex = 6;
            this.bEpcRead.Text = "Read";
            this.bEpcRead.UseVisualStyleBackColor = false;
            this.bEpcRead.Click += new System.EventHandler(this.bEpcRead_Click);
            // 
            // bEpcId
            // 
            this.bEpcId.BackColor = System.Drawing.Color.SlateGray;
            this.bEpcId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bEpcId.ForeColor = System.Drawing.Color.Black;
            this.bEpcId.Location = new System.Drawing.Point(375, 41);
            this.bEpcId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bEpcId.Name = "bEpcId";
            this.bEpcId.Size = new System.Drawing.Size(135, 85);
            this.bEpcId.TabIndex = 5;
            this.bEpcId.Text = "Identify";
            this.bEpcId.UseVisualStyleBackColor = false;
            this.bEpcId.Click += new System.EventHandler(this.bEpcId_Click);
            // 
            // lInfo
            // 
            this.lInfo.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lInfo.FormattingEnabled = true;
            this.lInfo.HorizontalScrollbar = true;
            this.lInfo.ItemHeight = 18;
            this.lInfo.Location = new System.Drawing.Point(388, 14);
            this.lInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lInfo.Name = "lInfo";
            this.lInfo.ScrollAlwaysVisible = true;
            this.lInfo.Size = new System.Drawing.Size(713, 202);
            this.lInfo.TabIndex = 30;
            // 
            // lvTagList
            // 
            this.lvTagList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhNo,
            this.clhTagData,
            this.clhTimes});
            this.lvTagList.HideSelection = false;
            this.lvTagList.Location = new System.Drawing.Point(558, 226);
            this.lvTagList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(548, 408);
            this.lvTagList.TabIndex = 35;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            // 
            // clhNo
            // 
            this.clhNo.Text = "NO.";
            this.clhNo.Width = 40;
            // 
            // clhTagData
            // 
            this.clhTagData.Text = "Tag Data";
            this.clhTagData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhTagData.Width = 240;
            // 
            // clhTimes
            // 
            this.clhTimes.Text = "Times";
            this.clhTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhTimes.Width = 50;
            // 
            // chkFilter
            // 
            this.chkFilter.AutoSize = true;
            this.chkFilter.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkFilter.ForeColor = System.Drawing.Color.Black;
            this.chkFilter.Location = new System.Drawing.Point(566, 666);
            this.chkFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(179, 28);
            this.chkFilter.TabIndex = 36;
            this.chkFilter.Text = "Filter Same";
            this.chkFilter.UseVisualStyleBackColor = true;
            // 
            // bClear
            // 
            this.bClear.BackColor = System.Drawing.Color.SlateGray;
            this.bClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bClear.ForeColor = System.Drawing.Color.Black;
            this.bClear.Location = new System.Drawing.Point(860, 644);
            this.bClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(235, 61);
            this.bClear.TabIndex = 37;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = false;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // btHome
            // 
            this.btHome.BackColor = System.Drawing.Color.SlateGray;
            this.btHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btHome.ForeColor = System.Drawing.Color.Black;
            this.btHome.Location = new System.Drawing.Point(388, 646);
            this.btHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(165, 71);
            this.btHome.TabIndex = 40;
            this.btHome.Text = "Home";
            this.btHome.UseVisualStyleBackColor = false;
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // bReset
            // 
            this.bReset.BackColor = System.Drawing.Color.SlateGray;
            this.bReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bReset.ForeColor = System.Drawing.Color.Black;
            this.bReset.Location = new System.Drawing.Point(13, 646);
            this.bReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(184, 71);
            this.bReset.TabIndex = 39;
            this.bReset.Text = "Reset Reader";
            this.bReset.UseVisualStyleBackColor = false;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.SlateGray;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(214, 646);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(165, 71);
            this.btnExit.TabIndex = 38;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timerScanISO
            // 
            this.timerScanISO.Tick += new System.EventHandler(this.timerScanISO_Tick_1);
            // 
            // timerScanEPC
            // 
            this.timerScanEPC.Tick += new System.EventHandler(this.timerScanEPC_Tick_1);
            // 
            // timerPing
            // 
            this.timerPing.Interval = 3000;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick_1);
            // 
            // Device2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 731);
            this.Controls.Add(this.btHome);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.chkFilter);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Name = "Device2";
            this.Text = "Device2";
            this.Load += new System.EventHandler(this.Device2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEpcSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bRs232Discon;
        private System.Windows.Forms.Button bRs232Con;
        private System.Windows.Forms.ComboBox cBaudrate;
        private System.Windows.Forms.ComboBox cCommPort;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tEpcData;
        private System.Windows.Forms.ComboBox cEpcWordcnt;
        private System.Windows.Forms.ComboBox cEpcWordptr;
        private System.Windows.Forms.ComboBox cEpcMembank;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar tEpcSpeed;
        private System.Windows.Forms.ComboBox cEpcTimes;
        private System.Windows.Forms.Button bEpcWrite;
        private System.Windows.Forms.Button bEpcRead;
        private System.Windows.Forms.Button bEpcId;
        private System.Windows.Forms.ListBox lInfo;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.ColumnHeader clhNo;
        private System.Windows.Forms.ColumnHeader clhTagData;
        private System.Windows.Forms.ColumnHeader clhTimes;
        private System.Windows.Forms.CheckBox chkFilter;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button btHome;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timerScanISO;
        private System.Windows.Forms.Timer timerScanEPC;
        private System.Windows.Forms.Timer timerPing;
    }
}