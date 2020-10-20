namespace AmbilKtm
{
    partial class FormManageUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageUser));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.GbSumberData = new System.Windows.Forms.GroupBox();
            this.rbAkademik = new System.Windows.Forms.RadioButton();
            this.rbBiroUmum = new System.Windows.Forms.RadioButton();
            this.gbRegistrasi = new System.Windows.Forms.GroupBox();
            this.rbKantor = new System.Windows.Forms.RadioButton();
            this.rbGate = new System.Windows.Forms.RadioButton();
            this.lbLokasi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LbxUsername = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_message = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.BtCancel = new System.Windows.Forms.Button();
            this.txt_fullname = new System.Windows.Forms.TextBox();
            this.BtReset = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.BtCreate = new System.Windows.Forms.Button();
            this.combo_role = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.GbSumberData.SuspendLayout();
            this.gbRegistrasi.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHome});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(504, 25);
            this.toolStrip1.TabIndex = 58;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnHome
            // 
            this.btnHome.Image = global::AmbilKtm.Properties.Resources.Home_5699;
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(60, 22);
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // GbSumberData
            // 
            this.GbSumberData.Controls.Add(this.rbAkademik);
            this.GbSumberData.Controls.Add(this.rbBiroUmum);
            this.GbSumberData.Dock = System.Windows.Forms.DockStyle.Top;
            this.GbSumberData.Location = new System.Drawing.Point(0, 25);
            this.GbSumberData.Name = "GbSumberData";
            this.GbSumberData.Size = new System.Drawing.Size(504, 50);
            this.GbSumberData.TabIndex = 65;
            this.GbSumberData.TabStop = false;
            this.GbSumberData.Text = "Biro";
            // 
            // rbAkademik
            // 
            this.rbAkademik.AutoSize = true;
            this.rbAkademik.Location = new System.Drawing.Point(97, 19);
            this.rbAkademik.Name = "rbAkademik";
            this.rbAkademik.Size = new System.Drawing.Size(72, 17);
            this.rbAkademik.TabIndex = 1;
            this.rbAkademik.Text = "Akademik";
            this.rbAkademik.UseVisualStyleBackColor = true;
            // 
            // rbBiroUmum
            // 
            this.rbBiroUmum.AutoSize = true;
            this.rbBiroUmum.Checked = true;
            this.rbBiroUmum.Location = new System.Drawing.Point(16, 19);
            this.rbBiroUmum.Name = "rbBiroUmum";
            this.rbBiroUmum.Size = new System.Drawing.Size(56, 17);
            this.rbBiroUmum.TabIndex = 0;
            this.rbBiroUmum.TabStop = true;
            this.rbBiroUmum.Text = "BSDM";
            this.rbBiroUmum.UseVisualStyleBackColor = true;
            // 
            // gbRegistrasi
            // 
            this.gbRegistrasi.Controls.Add(this.rbKantor);
            this.gbRegistrasi.Controls.Add(this.rbGate);
            this.gbRegistrasi.Controls.Add(this.lbLokasi);
            this.gbRegistrasi.Controls.Add(this.label5);
            this.gbRegistrasi.Controls.Add(this.label3);
            this.gbRegistrasi.Controls.Add(this.BtDelete);
            this.gbRegistrasi.Controls.Add(this.label1);
            this.gbRegistrasi.Controls.Add(this.LbxUsername);
            this.gbRegistrasi.Controls.Add(this.label2);
            this.gbRegistrasi.Controls.Add(this.label4);
            this.gbRegistrasi.Controls.Add(this.label_message);
            this.gbRegistrasi.Controls.Add(this.txt_username);
            this.gbRegistrasi.Controls.Add(this.BtCancel);
            this.gbRegistrasi.Controls.Add(this.txt_fullname);
            this.gbRegistrasi.Controls.Add(this.BtReset);
            this.gbRegistrasi.Controls.Add(this.txt_password);
            this.gbRegistrasi.Controls.Add(this.BtCreate);
            this.gbRegistrasi.Controls.Add(this.combo_role);
            this.gbRegistrasi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRegistrasi.Location = new System.Drawing.Point(0, 75);
            this.gbRegistrasi.Name = "gbRegistrasi";
            this.gbRegistrasi.Size = new System.Drawing.Size(504, 333);
            this.gbRegistrasi.TabIndex = 66;
            this.gbRegistrasi.TabStop = false;
            this.gbRegistrasi.Text = "Registrasi";
            // 
            // rbKantor
            // 
            this.rbKantor.AutoSize = true;
            this.rbKantor.Location = new System.Drawing.Point(165, 173);
            this.rbKantor.Name = "rbKantor";
            this.rbKantor.Size = new System.Drawing.Size(56, 17);
            this.rbKantor.TabIndex = 59;
            this.rbKantor.Text = "Kantor";
            this.rbKantor.UseVisualStyleBackColor = true;
            // 
            // rbGate
            // 
            this.rbGate.AutoSize = true;
            this.rbGate.Checked = true;
            this.rbGate.Location = new System.Drawing.Point(105, 173);
            this.rbGate.Name = "rbGate";
            this.rbGate.Size = new System.Drawing.Size(48, 17);
            this.rbGate.TabIndex = 58;
            this.rbGate.TabStop = true;
            this.rbGate.Text = "Gate";
            this.rbGate.UseVisualStyleBackColor = true;
            // 
            // lbLokasi
            // 
            this.lbLokasi.AutoSize = true;
            this.lbLokasi.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLokasi.Location = new System.Drawing.Point(12, 171);
            this.lbLokasi.Name = "lbLokasi";
            this.lbLokasi.Size = new System.Drawing.Size(62, 19);
            this.lbLokasi.TabIndex = 57;
            this.lbLokasi.Text = "Lokasi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 22);
            this.label5.TabIndex = 51;
            this.label5.Text = "Form Registrasi User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "Password :";
            // 
            // BtDelete
            // 
            this.BtDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtDelete.Location = new System.Drawing.Point(16, 263);
            this.BtDelete.Name = "BtDelete";
            this.BtDelete.Size = new System.Drawing.Size(142, 32);
            this.BtDelete.TabIndex = 56;
            this.BtDelete.Text = "Delete User";
            this.BtDelete.UseVisualStyleBackColor = true;
            this.BtDelete.Click += new System.EventHandler(this.BtDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 38;
            this.label1.Text = "Username :";
            // 
            // LbxUsername
            // 
            this.LbxUsername.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbxUsername.FormattingEnabled = true;
            this.LbxUsername.ItemHeight = 19;
            this.LbxUsername.Location = new System.Drawing.Point(317, 41);
            this.LbxUsername.Name = "LbxUsername";
            this.LbxUsername.Size = new System.Drawing.Size(178, 251);
            this.LbxUsername.TabIndex = 55;
            this.LbxUsername.SelectedIndexChanged += new System.EventHandler(this.LbxUsername_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 39;
            this.label2.Text = "Full Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "Role :";
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_message.ForeColor = System.Drawing.Color.Red;
            this.label_message.Location = new System.Drawing.Point(14, 309);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(11, 12);
            this.label_message.TabIndex = 50;
            this.label_message.Text = "1";
            // 
            // txt_username
            // 
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(105, 41);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(201, 26);
            this.txt_username.TabIndex = 42;
            // 
            // BtCancel
            // 
            this.BtCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCancel.Location = new System.Drawing.Point(164, 262);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(142, 34);
            this.BtCancel.TabIndex = 48;
            this.BtCancel.Text = "Cancel";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // txt_fullname
            // 
            this.txt_fullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fullname.Location = new System.Drawing.Point(105, 73);
            this.txt_fullname.Name = "txt_fullname";
            this.txt_fullname.Size = new System.Drawing.Size(201, 26);
            this.txt_fullname.TabIndex = 43;
            // 
            // BtReset
            // 
            this.BtReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtReset.Location = new System.Drawing.Point(165, 205);
            this.BtReset.Name = "BtReset";
            this.BtReset.Size = new System.Drawing.Size(142, 33);
            this.BtReset.TabIndex = 47;
            this.BtReset.Text = "Reset";
            this.BtReset.UseVisualStyleBackColor = true;
            this.BtReset.Click += new System.EventHandler(this.BtReset_Click);
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(105, 104);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(201, 26);
            this.txt_password.TabIndex = 44;
            // 
            // BtCreate
            // 
            this.BtCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCreate.Location = new System.Drawing.Point(16, 204);
            this.BtCreate.Name = "BtCreate";
            this.BtCreate.Size = new System.Drawing.Size(143, 34);
            this.BtCreate.TabIndex = 46;
            this.BtCreate.Text = "Create";
            this.BtCreate.UseVisualStyleBackColor = true;
            this.BtCreate.Click += new System.EventHandler(this.BtCreate_Click);
            // 
            // combo_role
            // 
            this.combo_role.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_role.FormattingEnabled = true;
            this.combo_role.Items.AddRange(new object[] {
            "Admin",
            "Operator"});
            this.combo_role.Location = new System.Drawing.Point(105, 136);
            this.combo_role.Name = "combo_role";
            this.combo_role.Size = new System.Drawing.Size(201, 27);
            this.combo_role.TabIndex = 45;
            // 
            // FormManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 408);
            this.Controls.Add(this.gbRegistrasi);
            this.Controls.Add(this.GbSumberData);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormManageUser";
            this.Text = "FormManageUser";
            this.Load += new System.EventHandler(this.FormManageUser_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GbSumberData.ResumeLayout(false);
            this.GbSumberData.PerformLayout();
            this.gbRegistrasi.ResumeLayout(false);
            this.gbRegistrasi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHome;
        private System.Windows.Forms.GroupBox GbSumberData;
        private System.Windows.Forms.RadioButton rbAkademik;
        private System.Windows.Forms.RadioButton rbBiroUmum;
        private System.Windows.Forms.GroupBox gbRegistrasi;
        private System.Windows.Forms.RadioButton rbKantor;
        private System.Windows.Forms.RadioButton rbGate;
        private System.Windows.Forms.Label lbLokasi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LbxUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.TextBox txt_fullname;
        private System.Windows.Forms.Button BtReset;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button BtCreate;
        private System.Windows.Forms.ComboBox combo_role;
    }
}