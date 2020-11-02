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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Device2));
            this.GbDataPegOrMhs = new System.Windows.Forms.GroupBox();
            this.lbIdPegawai = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateRfid = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_NIK = new System.Windows.Forms.Label();
            this.lbl_nama = new System.Windows.Forms.Label();
            this.txt_nik = new System.Windows.Forms.TextBox();
            this.txt_nama = new System.Windows.Forms.TextBox();
            this.txtRfid = new System.Windows.Forms.TextBox();
            this.GbPencarian = new System.Windows.Forms.GroupBox();
            this.DGList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCari = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_cari_nik = new System.Windows.Forms.TextBox();
            this.txt_cari_nama = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.jmlRow = new System.Windows.Forms.Label();
            this.rbMahasiswa = new System.Windows.Forms.RadioButton();
            this.timerScanISO = new System.Windows.Forms.Timer(this.components);
            this.rbPegawai = new System.Windows.Forms.RadioButton();
            this.GbSumberData = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btHome = new System.Windows.Forms.Button();
            this.bRs232Discon = new System.Windows.Forms.Button();
            this.bRs232Con = new System.Windows.Forms.Button();
            this.cBaudrate = new System.Windows.Forms.ComboBox();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.clhNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTagData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTimes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCommPort = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cEpcMembank = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tEpcData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bEpcRead = new System.Windows.Forms.Button();
            this.bEpcWrite = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cEpcTimes = new System.Windows.Forms.ComboBox();
            this.timerScanEPC = new System.Windows.Forms.Timer(this.components);
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.cEpcWordcnt = new System.Windows.Forms.ComboBox();
            this.cEpcWordptr = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bEpcId = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.GbDataPegOrMhs.SuspendLayout();
            this.GbPencarian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGList)).BeginInit();
            this.panel2.SuspendLayout();
            this.GbSumberData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbDataPegOrMhs
            // 
            this.GbDataPegOrMhs.Controls.Add(this.lbIdPegawai);
            this.GbDataPegOrMhs.Controls.Add(this.label3);
            this.GbDataPegOrMhs.Controls.Add(this.label4);
            this.GbDataPegOrMhs.Controls.Add(this.label5);
            this.GbDataPegOrMhs.Controls.Add(this.btnGenerateRfid);
            this.GbDataPegOrMhs.Controls.Add(this.label6);
            this.GbDataPegOrMhs.Controls.Add(this.lbl_NIK);
            this.GbDataPegOrMhs.Controls.Add(this.lbl_nama);
            this.GbDataPegOrMhs.Controls.Add(this.txt_nik);
            this.GbDataPegOrMhs.Controls.Add(this.txt_nama);
            this.GbDataPegOrMhs.Controls.Add(this.txtRfid);
            this.GbDataPegOrMhs.Location = new System.Drawing.Point(7, 81);
            this.GbDataPegOrMhs.Margin = new System.Windows.Forms.Padding(4);
            this.GbDataPegOrMhs.Name = "GbDataPegOrMhs";
            this.GbDataPegOrMhs.Padding = new System.Windows.Forms.Padding(4);
            this.GbDataPegOrMhs.Size = new System.Drawing.Size(890, 237);
            this.GbDataPegOrMhs.TabIndex = 73;
            this.GbDataPegOrMhs.TabStop = false;
            this.GbDataPegOrMhs.Text = "Data Pegawai / Mahasiswa";
            // 
            // lbIdPegawai
            // 
            this.lbIdPegawai.AutoSize = true;
            this.lbIdPegawai.Location = new System.Drawing.Point(188, 218);
            this.lbIdPegawai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIdPegawai.Name = "lbIdPegawai";
            this.lbIdPegawai.Size = new System.Drawing.Size(0, 17);
            this.lbIdPegawai.TabIndex = 32;
            this.lbIdPegawai.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 31);
            this.label3.TabIndex = 31;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 31);
            this.label4.TabIndex = 30;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(119, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 31);
            this.label5.TabIndex = 29;
            this.label5.Text = ":";
            // 
            // btnGenerateRfid
            // 
            this.btnGenerateRfid.Location = new System.Drawing.Point(709, 173);
            this.btnGenerateRfid.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateRfid.Name = "btnGenerateRfid";
            this.btnGenerateRfid.Size = new System.Drawing.Size(131, 33);
            this.btnGenerateRfid.TabIndex = 28;
            this.btnGenerateRfid.Text = "Generate Rfid";
            this.btnGenerateRfid.UseVisualStyleBackColor = true;
            this.btnGenerateRfid.Click += new System.EventHandler(this.btnGenerateRfid_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "RFID";
            // 
            // lbl_NIK
            // 
            this.lbl_NIK.AutoSize = true;
            this.lbl_NIK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NIK.Location = new System.Drawing.Point(29, 116);
            this.lbl_NIK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NIK.Name = "lbl_NIK";
            this.lbl_NIK.Size = new System.Drawing.Size(87, 25);
            this.lbl_NIK.TabIndex = 25;
            this.lbl_NIK.Text = "NIM/NIK";
            // 
            // lbl_nama
            // 
            this.lbl_nama.AutoSize = true;
            this.lbl_nama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nama.Location = new System.Drawing.Point(29, 49);
            this.lbl_nama.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_nama.Name = "lbl_nama";
            this.lbl_nama.Size = new System.Drawing.Size(71, 25);
            this.lbl_nama.TabIndex = 24;
            this.lbl_nama.Text = "NAMA";
            // 
            // txt_nik
            // 
            this.txt_nik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nik.Location = new System.Drawing.Point(188, 112);
            this.txt_nik.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nik.Name = "txt_nik";
            this.txt_nik.ReadOnly = true;
            this.txt_nik.Size = new System.Drawing.Size(496, 27);
            this.txt_nik.TabIndex = 23;
            // 
            // txt_nama
            // 
            this.txt_nama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nama.Location = new System.Drawing.Point(188, 46);
            this.txt_nama.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nama.Name = "txt_nama";
            this.txt_nama.ReadOnly = true;
            this.txt_nama.Size = new System.Drawing.Size(496, 27);
            this.txt_nama.TabIndex = 22;
            // 
            // txtRfid
            // 
            this.txtRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRfid.Location = new System.Drawing.Point(188, 177);
            this.txtRfid.Margin = new System.Windows.Forms.Padding(4);
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.ReadOnly = true;
            this.txtRfid.Size = new System.Drawing.Size(496, 27);
            this.txtRfid.TabIndex = 10;
            this.txtRfid.TextChanged += new System.EventHandler(this.txtRfid_TextChanged);
            // 
            // GbPencarian
            // 
            this.GbPencarian.Controls.Add(this.DGList);
            this.GbPencarian.Controls.Add(this.panel1);
            this.GbPencarian.Controls.Add(this.btnCari);
            this.GbPencarian.Controls.Add(this.label7);
            this.GbPencarian.Controls.Add(this.label8);
            this.GbPencarian.Controls.Add(this.txt_cari_nik);
            this.GbPencarian.Controls.Add(this.txt_cari_nama);
            this.GbPencarian.Controls.Add(this.label9);
            this.GbPencarian.Controls.Add(this.label11);
            this.GbPencarian.Controls.Add(this.panel2);
            this.GbPencarian.Location = new System.Drawing.Point(7, 335);
            this.GbPencarian.Margin = new System.Windows.Forms.Padding(4);
            this.GbPencarian.Name = "GbPencarian";
            this.GbPencarian.Padding = new System.Windows.Forms.Padding(4);
            this.GbPencarian.Size = new System.Drawing.Size(890, 347);
            this.GbPencarian.TabIndex = 74;
            this.GbPencarian.TabStop = false;
            this.GbPencarian.Text = "Pencarian";
            // 
            // DGList
            // 
            this.DGList.AllowUserToAddRows = false;
            this.DGList.AllowUserToDeleteRows = false;
            this.DGList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nim,
            this.fullname,
            this.rfid});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGList.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGList.Location = new System.Drawing.Point(4, 142);
            this.DGList.Margin = new System.Windows.Forms.Padding(4);
            this.DGList.Name = "DGList";
            this.DGList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGList.Size = new System.Drawing.Size(882, 201);
            this.DGList.TabIndex = 61;
            this.DGList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DGList_RowStateChanged);
            this.DGList.SelectionChanged += new System.EventHandler(this.DGList_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // nim
            // 
            this.nim.HeaderText = "NIM/NIK";
            this.nim.Name = "nim";
            this.nim.ReadOnly = true;
            // 
            // fullname
            // 
            this.fullname.HeaderText = "Nama";
            this.fullname.Name = "fullname";
            this.fullname.ReadOnly = true;
            // 
            // rfid
            // 
            this.rfid.HeaderText = "Rfid";
            this.rfid.Name = "rfid";
            this.rfid.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 142);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 201);
            this.panel1.TabIndex = 62;
            // 
            // btnCari
            // 
            this.btnCari.Image = ((System.Drawing.Image)(resources.GetObject("btnCari.Image")));
            this.btnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCari.Location = new System.Drawing.Point(611, 47);
            this.btnCari.Margin = new System.Windows.Forms.Padding(4);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(136, 46);
            this.btnCari.TabIndex = 59;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(247, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 25);
            this.label8.TabIndex = 34;
            this.label8.Text = ":";
            // 
            // txt_cari_nik
            // 
            this.txt_cari_nik.Location = new System.Drawing.Point(272, 85);
            this.txt_cari_nik.Margin = new System.Windows.Forms.Padding(4);
            this.txt_cari_nik.Name = "txt_cari_nik";
            this.txt_cari_nik.Size = new System.Drawing.Size(297, 22);
            this.txt_cari_nik.TabIndex = 30;
            // 
            // txt_cari_nama
            // 
            this.txt_cari_nama.Location = new System.Drawing.Point(272, 47);
            this.txt_cari_nama.Margin = new System.Windows.Forms.Padding(4);
            this.txt_cari_nama.Name = "txt_cari_nama";
            this.txt_cari_nama.Size = new System.Drawing.Size(297, 22);
            this.txt_cari_nama.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 82);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 25);
            this.label9.TabIndex = 28;
            this.label9.Text = "Berdasarkan NIK/NIM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 25);
            this.label11.TabIndex = 27;
            this.label11.Text = "Berdasarkan Nama";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.jmlRow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 19);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(882, 123);
            this.panel2.TabIndex = 63;
            // 
            // jmlRow
            // 
            this.jmlRow.AutoSize = true;
            this.jmlRow.Location = new System.Drawing.Point(603, 91);
            this.jmlRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.jmlRow.Name = "jmlRow";
            this.jmlRow.Size = new System.Drawing.Size(0, 17);
            this.jmlRow.TabIndex = 60;
            // 
            // rbMahasiswa
            // 
            this.rbMahasiswa.AutoSize = true;
            this.rbMahasiswa.Location = new System.Drawing.Point(129, 23);
            this.rbMahasiswa.Margin = new System.Windows.Forms.Padding(4);
            this.rbMahasiswa.Name = "rbMahasiswa";
            this.rbMahasiswa.Size = new System.Drawing.Size(98, 21);
            this.rbMahasiswa.TabIndex = 1;
            this.rbMahasiswa.TabStop = true;
            this.rbMahasiswa.Text = "Mahasiswa";
            this.rbMahasiswa.UseVisualStyleBackColor = true;
            this.rbMahasiswa.CheckedChanged += new System.EventHandler(this.rbMahasiswa_CheckedChanged_1);
            // 
            // rbPegawai
            // 
            this.rbPegawai.AutoSize = true;
            this.rbPegawai.Location = new System.Drawing.Point(21, 23);
            this.rbPegawai.Margin = new System.Windows.Forms.Padding(4);
            this.rbPegawai.Name = "rbPegawai";
            this.rbPegawai.Size = new System.Drawing.Size(82, 21);
            this.rbPegawai.TabIndex = 0;
            this.rbPegawai.TabStop = true;
            this.rbPegawai.Text = "Pegawai";
            this.rbPegawai.UseVisualStyleBackColor = true;
            // 
            // GbSumberData
            // 
            this.GbSumberData.Controls.Add(this.rbMahasiswa);
            this.GbSumberData.Controls.Add(this.rbPegawai);
            this.GbSumberData.Location = new System.Drawing.Point(13, 13);
            this.GbSumberData.Margin = new System.Windows.Forms.Padding(4);
            this.GbSumberData.Name = "GbSumberData";
            this.GbSumberData.Padding = new System.Windows.Forms.Padding(4);
            this.GbSumberData.Size = new System.Drawing.Size(264, 62);
            this.GbSumberData.TabIndex = 71;
            this.GbSumberData.TabStop = false;
            this.GbSumberData.Text = "Sumber data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(43, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "BAUDRATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "COMM PORT";
            // 
            // btHome
            // 
            this.btHome.BackColor = System.Drawing.Color.SlateGray;
            this.btHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btHome.ForeColor = System.Drawing.Color.Black;
            this.btHome.Location = new System.Drawing.Point(794, 686);
            this.btHome.Margin = new System.Windows.Forms.Padding(4);
            this.btHome.Name = "btHome";
            this.btHome.Size = new System.Drawing.Size(95, 33);
            this.btHome.TabIndex = 72;
            this.btHome.Text = "Home";
            this.btHome.UseVisualStyleBackColor = false;
            this.btHome.Click += new System.EventHandler(this.btHome_Click_1);
            // 
            // bRs232Discon
            // 
            this.bRs232Discon.BackColor = System.Drawing.Color.SlateGray;
            this.bRs232Discon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bRs232Discon.ForeColor = System.Drawing.Color.Black;
            this.bRs232Discon.Location = new System.Drawing.Point(177, 107);
            this.bRs232Discon.Margin = new System.Windows.Forms.Padding(4);
            this.bRs232Discon.Name = "bRs232Discon";
            this.bRs232Discon.Size = new System.Drawing.Size(103, 39);
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
            this.bRs232Con.Location = new System.Drawing.Point(47, 107);
            this.bRs232Con.Margin = new System.Windows.Forms.Padding(4);
            this.bRs232Con.Name = "bRs232Con";
            this.bRs232Con.Size = new System.Drawing.Size(103, 39);
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
            this.cBaudrate.Location = new System.Drawing.Point(164, 68);
            this.cBaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cBaudrate.Name = "cBaudrate";
            this.cBaudrate.Size = new System.Drawing.Size(115, 25);
            this.cBaudrate.TabIndex = 3;
            // 
            // lvTagList
            // 
            this.lvTagList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhNo,
            this.clhTagData,
            this.clhTimes});
            this.lvTagList.HideSelection = false;
            this.lvTagList.Location = new System.Drawing.Point(931, 365);
            this.lvTagList.Margin = new System.Windows.Forms.Padding(4);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(376, 327);
            this.lvTagList.TabIndex = 70;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            // 
            // clhNo
            // 
            this.clhNo.Text = "NO.";
            this.clhNo.Width = 37;
            // 
            // clhTagData
            // 
            this.clhTagData.Text = "Tag Data";
            this.clhTagData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhTagData.Width = 71;
            // 
            // clhTimes
            // 
            this.clhTimes.Text = "Times";
            this.clhTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhTimes.Width = 56;
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
            this.cCommPort.Location = new System.Drawing.Point(164, 29);
            this.cCommPort.Margin = new System.Windows.Forms.Padding(4);
            this.cCommPort.Name = "cCommPort";
            this.cCommPort.Size = new System.Drawing.Size(115, 25);
            this.cCommPort.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(986, 183);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 65;
            this.label14.Text = "WordPtr";
            this.label14.Visible = false;
            // 
            // cEpcMembank
            // 
            this.cEpcMembank.FormattingEnabled = true;
            this.cEpcMembank.Items.AddRange(new object[] {
            "RESERVE",
            "EPC",
            "TID",
            "USER"});
            this.cEpcMembank.Location = new System.Drawing.Point(1104, 180);
            this.cEpcMembank.Margin = new System.Windows.Forms.Padding(4);
            this.cEpcMembank.Name = "cEpcMembank";
            this.cEpcMembank.Size = new System.Drawing.Size(115, 24);
            this.cEpcMembank.TabIndex = 61;
            this.cEpcMembank.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(1230, 214);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 68;
            this.label17.Text = "Data(Hex)";
            this.label17.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(984, 183);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 67;
            this.label16.Text = "MemBank";
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(986, 219);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 66;
            this.label15.Text = "WordCnt";
            // 
            // tEpcData
            // 
            this.tEpcData.Location = new System.Drawing.Point(1234, 183);
            this.tEpcData.Margin = new System.Windows.Forms.Padding(4);
            this.tEpcData.Name = "tEpcData";
            this.tEpcData.Size = new System.Drawing.Size(44, 22);
            this.tEpcData.TabIndex = 64;
            this.tEpcData.Visible = false;
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
            this.groupBox1.Location = new System.Drawing.Point(962, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(316, 153);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RS232";
            // 
            // bEpcRead
            // 
            this.bEpcRead.BackColor = System.Drawing.Color.SlateGray;
            this.bEpcRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bEpcRead.ForeColor = System.Drawing.Color.Black;
            this.bEpcRead.Location = new System.Drawing.Point(1071, 322);
            this.bEpcRead.Margin = new System.Windows.Forms.Padding(4);
            this.bEpcRead.Name = "bEpcRead";
            this.bEpcRead.Size = new System.Drawing.Size(86, 35);
            this.bEpcRead.TabIndex = 57;
            this.bEpcRead.Text = "Read";
            this.bEpcRead.UseVisualStyleBackColor = false;
            this.bEpcRead.Click += new System.EventHandler(this.bEpcRead_Click);
            // 
            // bEpcWrite
            // 
            this.bEpcWrite.BackColor = System.Drawing.Color.SlateGray;
            this.bEpcWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bEpcWrite.ForeColor = System.Drawing.Color.Black;
            this.bEpcWrite.Location = new System.Drawing.Point(1176, 322);
            this.bEpcWrite.Margin = new System.Windows.Forms.Padding(4);
            this.bEpcWrite.Name = "bEpcWrite";
            this.bEpcWrite.Size = new System.Drawing.Size(89, 35);
            this.bEpcWrite.TabIndex = 58;
            this.bEpcWrite.Text = "Write";
            this.bEpcWrite.UseVisualStyleBackColor = false;
            this.bEpcWrite.Click += new System.EventHandler(this.bEpcWrite_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(986, 183);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 60;
            this.label10.Text = "Times";
            this.label10.Visible = false;
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
            this.cEpcTimes.Location = new System.Drawing.Point(1102, 182);
            this.cEpcTimes.Margin = new System.Windows.Forms.Padding(4);
            this.cEpcTimes.Name = "cEpcTimes";
            this.cEpcTimes.Size = new System.Drawing.Size(115, 24);
            this.cEpcTimes.TabIndex = 59;
            this.cEpcTimes.Visible = false;
            // 
            // timerScanEPC
            // 
            this.timerScanEPC.Tick += new System.EventHandler(this.timerScanEPC_Tick);
            // 
            // timerPing
            // 
            this.timerPing.Interval = 3000;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // cEpcWordcnt
            // 
            this.cEpcWordcnt.FormattingEnabled = true;
            this.cEpcWordcnt.Location = new System.Drawing.Point(1102, 214);
            this.cEpcWordcnt.Margin = new System.Windows.Forms.Padding(4);
            this.cEpcWordcnt.Name = "cEpcWordcnt";
            this.cEpcWordcnt.Size = new System.Drawing.Size(115, 24);
            this.cEpcWordcnt.TabIndex = 63;
            // 
            // cEpcWordptr
            // 
            this.cEpcWordptr.FormattingEnabled = true;
            this.cEpcWordptr.Location = new System.Drawing.Point(1102, 182);
            this.cEpcWordptr.Margin = new System.Windows.Forms.Padding(4);
            this.cEpcWordptr.Name = "cEpcWordptr";
            this.cEpcWordptr.Size = new System.Drawing.Size(115, 24);
            this.cEpcWordptr.TabIndex = 62;
            this.cEpcWordptr.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1102, 283);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 24);
            this.comboBox1.TabIndex = 75;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bEpcId
            // 
            this.bEpcId.BackColor = System.Drawing.Color.SlateGray;
            this.bEpcId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bEpcId.ForeColor = System.Drawing.Color.Black;
            this.bEpcId.Location = new System.Drawing.Point(977, 322);
            this.bEpcId.Margin = new System.Windows.Forms.Padding(4);
            this.bEpcId.Name = "bEpcId";
            this.bEpcId.Size = new System.Drawing.Size(86, 35);
            this.bEpcId.TabIndex = 76;
            this.bEpcId.Text = "Query tag";
            this.bEpcId.UseVisualStyleBackColor = false;
            this.bEpcId.Click += new System.EventHandler(this.bEpcId_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1112, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 18);
            this.label12.TabIndex = 77;
            // 
            // Device2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 720);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bEpcId);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.GbDataPegOrMhs);
            this.Controls.Add(this.GbPencarian);
            this.Controls.Add(this.GbSumberData);
            this.Controls.Add(this.btHome);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cEpcMembank);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tEpcData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bEpcRead);
            this.Controls.Add(this.bEpcWrite);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cEpcTimes);
            this.Controls.Add(this.cEpcWordcnt);
            this.Controls.Add(this.cEpcWordptr);
            this.Name = "Device2";
            this.Text = "Device2";
            this.Load += new System.EventHandler(this.Device2_Load);
            this.GbDataPegOrMhs.ResumeLayout(false);
            this.GbDataPegOrMhs.PerformLayout();
            this.GbPencarian.ResumeLayout(false);
            this.GbPencarian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.GbSumberData.ResumeLayout(false);
            this.GbSumberData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GbDataPegOrMhs;
        private System.Windows.Forms.Label lbIdPegawai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerateRfid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_NIK;
        private System.Windows.Forms.Label lbl_nama;
        private System.Windows.Forms.TextBox txt_nik;
        private System.Windows.Forms.TextBox txt_nama;
        private System.Windows.Forms.TextBox txtRfid;
        private System.Windows.Forms.GroupBox GbPencarian;
        private System.Windows.Forms.DataGridView DGList;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nim;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_cari_nik;
        private System.Windows.Forms.TextBox txt_cari_nama;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label jmlRow;
        private System.Windows.Forms.RadioButton rbMahasiswa;
        private System.Windows.Forms.Timer timerScanISO;
        private System.Windows.Forms.RadioButton rbPegawai;
        private System.Windows.Forms.GroupBox GbSumberData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btHome;
        private System.Windows.Forms.Button bRs232Discon;
        private System.Windows.Forms.Button bRs232Con;
        private System.Windows.Forms.ComboBox cBaudrate;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.ColumnHeader clhNo;
        private System.Windows.Forms.ColumnHeader clhTagData;
        private System.Windows.Forms.ColumnHeader clhTimes;
        private System.Windows.Forms.ComboBox cCommPort;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cEpcMembank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tEpcData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bEpcRead;
        private System.Windows.Forms.Button bEpcWrite;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cEpcTimes;
        private System.Windows.Forms.Timer timerScanEPC;
        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.ComboBox cEpcWordcnt;
        private System.Windows.Forms.ComboBox cEpcWordptr;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bEpcId;
        private System.Windows.Forms.Label label12;
    }
}