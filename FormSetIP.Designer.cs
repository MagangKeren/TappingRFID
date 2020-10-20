namespace AmbilKtm
{
    partial class FormSetIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetIP));
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.txtNewPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_IP4 = new System.Windows.Forms.TextBox();
            this.textBox_IP3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_IP2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastIp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLastPort = new System.Windows.Forms.TextBox();
            this.textBox_IP1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSetIp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GbSetIp = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GbSetIp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(282, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port :";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHome});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(502, 25);
            this.toolStrip1.TabIndex = 62;
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
            // txtNewPort
            // 
            this.txtNewPort.Location = new System.Drawing.Point(340, 74);
            this.txtNewPort.Name = "txtNewPort";
            this.txtNewPort.Size = new System.Drawing.Size(132, 20);
            this.txtNewPort.TabIndex = 1;
            this.txtNewPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPort_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(110, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = ".";
            // 
            // textBox_IP4
            // 
            this.textBox_IP4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_IP4.Location = new System.Drawing.Point(129, 1);
            this.textBox_IP4.MaxLength = 3;
            this.textBox_IP4.Name = "textBox_IP4";
            this.textBox_IP4.Size = new System.Drawing.Size(41, 13);
            this.textBox_IP4.TabIndex = 7;
            this.textBox_IP4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_IP4_KeyPress);
            // 
            // textBox_IP3
            // 
            this.textBox_IP3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_IP3.Location = new System.Drawing.Point(80, 1);
            this.textBox_IP3.MaxLength = 3;
            this.textBox_IP3.Name = "textBox_IP3";
            this.textBox_IP3.Size = new System.Drawing.Size(41, 13);
            this.textBox_IP3.TabIndex = 6;
            this.textBox_IP3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_IP3_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(75, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = ".";
            // 
            // textBox_IP2
            // 
            this.textBox_IP2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_IP2.Location = new System.Drawing.Point(39, 1);
            this.textBox_IP2.MaxLength = 3;
            this.textBox_IP2.Name = "textBox_IP2";
            this.textBox_IP2.Size = new System.Drawing.Size(41, 13);
            this.textBox_IP2.TabIndex = 4;
            this.textBox_IP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_IP2_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "New Port :";
            // 
            // txtLastIp
            // 
            this.txtLastIp.Location = new System.Drawing.Point(104, 47);
            this.txtLastIp.Name = "txtLastIp";
            this.txtLastIp.Size = new System.Drawing.Size(162, 20);
            this.txtLastIp.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(33, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = ".";
            // 
            // txtLastPort
            // 
            this.txtLastPort.Location = new System.Drawing.Point(340, 48);
            this.txtLastPort.Name = "txtLastPort";
            this.txtLastPort.Size = new System.Drawing.Size(132, 20);
            this.txtLastPort.TabIndex = 5;
            // 
            // textBox_IP1
            // 
            this.textBox_IP1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_IP1.Location = new System.Drawing.Point(3, 1);
            this.textBox_IP1.MaxLength = 3;
            this.textBox_IP1.Name = "textBox_IP1";
            this.textBox_IP1.Size = new System.Drawing.Size(41, 13);
            this.textBox_IP1.TabIndex = 2;
            this.textBox_IP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_IP1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_IP4);
            this.panel1.Controls.Add(this.textBox_IP3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_IP2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox_IP1);
            this.panel1.Location = new System.Drawing.Point(104, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 21);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "New IP Address :";
            // 
            // BtnSetIp
            // 
            this.BtnSetIp.Location = new System.Drawing.Point(104, 118);
            this.BtnSetIp.Name = "BtnSetIp";
            this.BtnSetIp.Size = new System.Drawing.Size(132, 30);
            this.BtnSetIp.TabIndex = 2;
            this.BtnSetIp.Text = "Save";
            this.BtnSetIp.UseVisualStyleBackColor = true;
            this.BtnSetIp.Click += new System.EventHandler(this.BtnSetIp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP Address :";
            // 
            // GbSetIp
            // 
            this.GbSetIp.BackColor = System.Drawing.SystemColors.Window;
            this.GbSetIp.Controls.Add(this.btnCancel);
            this.GbSetIp.Controls.Add(this.panel1);
            this.GbSetIp.Controls.Add(this.label4);
            this.GbSetIp.Controls.Add(this.txtNewPort);
            this.GbSetIp.Controls.Add(this.label3);
            this.GbSetIp.Controls.Add(this.txtLastPort);
            this.GbSetIp.Controls.Add(this.label2);
            this.GbSetIp.Controls.Add(this.txtLastIp);
            this.GbSetIp.Controls.Add(this.label1);
            this.GbSetIp.Controls.Add(this.BtnSetIp);
            this.GbSetIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbSetIp.Location = new System.Drawing.Point(0, 0);
            this.GbSetIp.Name = "GbSetIp";
            this.GbSetIp.Size = new System.Drawing.Size(502, 176);
            this.GbSetIp.TabIndex = 61;
            this.GbSetIp.TabStop = false;
            this.GbSetIp.Text = "Set IP Address";
            // 
            // FormSetIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 176);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GbSetIp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSetIP";
            this.Text = "FormSetIP";
            this.Load += new System.EventHandler(this.FormSetIP_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GbSetIp.ResumeLayout(false);
            this.GbSetIp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHome;
        private System.Windows.Forms.TextBox txtNewPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_IP4;
        private System.Windows.Forms.TextBox textBox_IP3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_IP2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastIp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLastPort;
        private System.Windows.Forms.TextBox textBox_IP1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSetIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GbSetIp;
    }
}