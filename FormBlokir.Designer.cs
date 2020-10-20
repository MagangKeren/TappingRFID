namespace AmbilKtm
{
    partial class FormBlokir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBlokir));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.tsBlokir = new System.Windows.Forms.ToolStripButton();
            this.GbSumberData = new System.Windows.Forms.GroupBox();
            this.rbMahasiswa = new System.Windows.Forms.RadioButton();
            this.rbPegawai = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.jmlRow = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cari_nama = new System.Windows.Forms.TextBox();
            this.txt_cari_nim = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodeRfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.GbSumberData.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHome,
            this.tsBlokir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(880, 32);
            this.toolStrip1.TabIndex = 59;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(89, 29);
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // tsBlokir
            // 
            this.tsBlokir.Image = ((System.Drawing.Image)(resources.GetObject("tsBlokir.Image")));
            this.tsBlokir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBlokir.Name = "tsBlokir";
            this.tsBlokir.Size = new System.Drawing.Size(130, 29);
            this.tsBlokir.Text = "Blokir Kartu";
            this.tsBlokir.Click += new System.EventHandler(this.tsBlokir_Click);
            // 
            // GbSumberData
            // 
            this.GbSumberData.Controls.Add(this.rbMahasiswa);
            this.GbSumberData.Controls.Add(this.rbPegawai);
            this.GbSumberData.Dock = System.Windows.Forms.DockStyle.Top;
            this.GbSumberData.Location = new System.Drawing.Point(0, 32);
            this.GbSumberData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbSumberData.Name = "GbSumberData";
            this.GbSumberData.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbSumberData.Size = new System.Drawing.Size(880, 77);
            this.GbSumberData.TabIndex = 63;
            this.GbSumberData.TabStop = false;
            this.GbSumberData.Text = "Sumber data";
            // 
            // rbMahasiswa
            // 
            this.rbMahasiswa.AutoSize = true;
            this.rbMahasiswa.Location = new System.Drawing.Point(146, 29);
            this.rbMahasiswa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMahasiswa.Name = "rbMahasiswa";
            this.rbMahasiswa.Size = new System.Drawing.Size(113, 24);
            this.rbMahasiswa.TabIndex = 1;
            this.rbMahasiswa.TabStop = true;
            this.rbMahasiswa.Text = "Mahasiswa";
            this.rbMahasiswa.UseVisualStyleBackColor = true;
            // 
            // rbPegawai
            // 
            this.rbPegawai.AutoSize = true;
            this.rbPegawai.Checked = true;
            this.rbPegawai.Location = new System.Drawing.Point(24, 29);
            this.rbPegawai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbPegawai.Name = "rbPegawai";
            this.rbPegawai.Size = new System.Drawing.Size(94, 24);
            this.rbPegawai.TabIndex = 0;
            this.rbPegawai.TabStop = true;
            this.rbPegawai.Text = "Pegawai";
            this.rbPegawai.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.jmlRow);
            this.groupBox10.Controls.Add(this.btnCari);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.label4);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.txt_cari_nama);
            this.groupBox10.Controls.Add(this.txt_cari_nim);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox10.Location = new System.Drawing.Point(0, 109);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox10.Size = new System.Drawing.Size(880, 131);
            this.groupBox10.TabIndex = 64;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Parameter";
            // 
            // jmlRow
            // 
            this.jmlRow.AutoSize = true;
            this.jmlRow.Location = new System.Drawing.Point(381, 94);
            this.jmlRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.jmlRow.Name = "jmlRow";
            this.jmlRow.Size = new System.Drawing.Size(0, 20);
            this.jmlRow.TabIndex = 59;
            // 
            // btnCari
            // 
            this.btnCari.Image = ((System.Drawing.Image)(resources.GetObject("btnCari.Image")));
            this.btnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCari.Location = new System.Drawing.Point(386, 37);
            this.btnCari.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(186, 52);
            this.btnCari.TabIndex = 58;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 20);
            this.label6.TabIndex = 57;
            this.label6.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 54;
            this.label3.Text = "Nim / Nik";
            // 
            // txt_cari_nama
            // 
            this.txt_cari_nama.Location = new System.Drawing.Point(136, 37);
            this.txt_cari_nama.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_cari_nama.Name = "txt_cari_nama";
            this.txt_cari_nama.Size = new System.Drawing.Size(211, 26);
            this.txt_cari_nama.TabIndex = 30;
            // 
            // txt_cari_nim
            // 
            this.txt_cari_nim.Location = new System.Drawing.Point(136, 77);
            this.txt_cari_nim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_cari_nim.Name = "txt_cari_nim";
            this.txt_cari_nim.Size = new System.Drawing.Size(211, 26);
            this.txt_cari_nim.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 240);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(880, 325);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hasil Pencarian";
            // 
            // DGList
            // 
            this.DGList.AllowUserToAddRows = false;
            this.DGList.AllowUserToDeleteRows = false;
            this.DGList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.nim,
            this.nama,
            this.kodeRfid,
            this.Status});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGList.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGList.Location = new System.Drawing.Point(4, 24);
            this.DGList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGList.Name = "DGList";
            this.DGList.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGList.Size = new System.Drawing.Size(872, 296);
            this.DGList.TabIndex = 33;
            this.DGList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DGList_RowStateChanged);
            this.DGList.SelectionChanged += new System.EventHandler(this.DGList_SelectionChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // nim
            // 
            this.nim.HeaderText = "NIM/NIK";
            this.nim.Name = "nim";
            this.nim.ReadOnly = true;
            // 
            // nama
            // 
            this.nama.HeaderText = "Nama";
            this.nama.Name = "nama";
            this.nama.ReadOnly = true;
            // 
            // kodeRfid
            // 
            this.kodeRfid.HeaderText = "Rfid";
            this.kodeRfid.Name = "kodeRfid";
            this.kodeRfid.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // FormBlokir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 565);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.GbSumberData);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormBlokir";
            this.Text = "FormBlokir";
            this.Load += new System.EventHandler(this.FormBlokir_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GbSumberData.ResumeLayout(false);
            this.GbSumberData.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHome;
        private System.Windows.Forms.ToolStripButton tsBlokir;
        private System.Windows.Forms.GroupBox GbSumberData;
        private System.Windows.Forms.RadioButton rbMahasiswa;
        private System.Windows.Forms.RadioButton rbPegawai;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label jmlRow;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_cari_nama;
        private System.Windows.Forms.TextBox txt_cari_nim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nim;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeRfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}