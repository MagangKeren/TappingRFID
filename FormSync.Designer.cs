namespace AmbilKtm
{
    partial class FormSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSync));
            this.LbUpload = new System.Windows.Forms.Label();
            this.LbDownload = new System.Windows.Forms.Label();
            this.PbUpload = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.ProgressBarSinkron = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LbUpload
            // 
            this.LbUpload.AutoSize = true;
            this.LbUpload.Location = new System.Drawing.Point(3, 13);
            this.LbUpload.Name = "LbUpload";
            this.LbUpload.Size = new System.Drawing.Size(0, 13);
            this.LbUpload.TabIndex = 13;
            // 
            // LbDownload
            // 
            this.LbDownload.AutoSize = true;
            this.LbDownload.Location = new System.Drawing.Point(3, 91);
            this.LbDownload.Name = "LbDownload";
            this.LbDownload.Size = new System.Drawing.Size(0, 13);
            this.LbDownload.TabIndex = 12;
            // 
            // PbUpload
            // 
            this.PbUpload.Location = new System.Drawing.Point(3, 29);
            this.PbUpload.Name = "PbUpload";
            this.PbUpload.Size = new System.Drawing.Size(546, 48);
            this.PbUpload.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(217, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 44);
            this.button1.TabIndex = 10;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProgressBarSinkron
            // 
            this.ProgressBarSinkron.Location = new System.Drawing.Point(3, 107);
            this.ProgressBarSinkron.Name = "ProgressBarSinkron";
            this.ProgressBarSinkron.Size = new System.Drawing.Size(546, 48);
            this.ProgressBarSinkron.TabIndex = 9;
            // 
            // FormSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 229);
            this.Controls.Add(this.LbUpload);
            this.Controls.Add(this.LbDownload);
            this.Controls.Add(this.PbUpload);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ProgressBarSinkron);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSync";
            this.Text = "FormSync";
            this.Load += new System.EventHandler(this.FormSync_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbUpload;
        private System.Windows.Forms.Label LbDownload;
        private System.Windows.Forms.ProgressBar PbUpload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar ProgressBarSinkron;
    }
}