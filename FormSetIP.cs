using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbilKtm
{
    public partial class FormSetIP : Form
    {
        public FormSetIP()
        {
            InitializeComponent();
        }

        private void FormSetIP_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            clearIP();
            txtNewPort.Text = string.Empty;

            cControl cnt = new cControl();

            txtLastIp.Text = cnt.getLastIp();
            txtLastIp.ReadOnly = true;

            txtLastPort.Text = cnt.getLastPort();
            txtLastPort.ReadOnly = true;
        }

        private void clearIP()
        {
            textBox_IP1.Text = string.Empty;
            textBox_IP2.Text = string.Empty;
            textBox_IP3.Text = string.Empty;
            textBox_IP4.Text = string.Empty;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNewPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            txtNewPort.MaxLength = 5;
        }

        private void MaskIPAddr(TextBox textBox, KeyPressEventArgs e)
        {
            //pindah fokus ketika klik "." (titik)
            if (e.KeyChar == '.' && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.')
            {
                if (textBox.Name == "textBox_IP1")
                {
                    this.textBox_IP2.Focus();
                    this.textBox_IP2.SelectAll();
                    e.Handled = true;
                    return;
                }
                else if (textBox.Name == "textBox_IP2")
                {
                    this.textBox_IP3.Focus();
                    this.textBox_IP3.SelectAll();
                    e.Handled = true;
                    return;
                }
                else if (textBox.Name == "textBox_IP3")
                {
                    this.textBox_IP4.Focus();
                    this.textBox_IP4.SelectAll();
                    e.Handled = true;
                    return;
                }
                else if (textBox.Name == "textBox_IP4")
                {
                    e.Handled = true;
                    return;
                }
            }

            //validasi IP
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.')
            {
                if (e.KeyChar != 8 && textBox.Text.Length == 2)
                {
                    string tempStr = textBox.Text + e.KeyChar;
                    if (textBox.Name == "textBox_IP1")
                    {
                        if (Int32.Parse(tempStr) > 255)
                        {
                            MessageBox.Show(tempStr + " tidak valid." + Environment.NewLine + "Silakan isi antara 1 dan 255.", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox.Text = "255";
                            textBox.Focus();
                            return;
                        }
                        this.textBox_IP2.Focus();
                        this.textBox_IP2.SelectAll();
                    }
                    else if (textBox.Name == "textBox_IP2")
                    {
                        if (Int32.Parse(tempStr) > 255)
                        {
                            MessageBox.Show(tempStr + " tidak valid." + Environment.NewLine + "Silakan isi antara 1 dan 255.", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox.Text = "255";
                            textBox.Focus();
                            return;
                        }
                        this.textBox_IP3.Focus();
                        this.textBox_IP3.SelectAll();
                    }
                    else if (textBox.Name == "textBox_IP3")
                    {
                        if (Int32.Parse(tempStr) > 255)
                        {
                            MessageBox.Show(tempStr + " tidak valid." + Environment.NewLine + "Silakan isi antara 1 dan 255.", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox.Text = "255";
                            textBox.Focus();
                            return;
                        }
                        this.textBox_IP4.Focus();
                        this.textBox_IP4.SelectAll();
                    }
                    else if (textBox.Name == "textBox_IP4")
                    {
                        if (Int32.Parse(tempStr) > 255)
                        {
                            MessageBox.Show(tempStr + " tidak valid." + Environment.NewLine + "Silakan isi antara 1 dan 255.", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox.Text = "255";
                            textBox.Focus();
                            return;
                        }
                    }
                }
                else if (e.KeyChar == 8)
                {
                    if (textBox.Name == "textBox_IP1" && textBox.Text.Length == 0)
                    {
                        this.textBox_IP2.Focus();
                    }
                    else if (textBox.Name == "textBox_IP2" && textBox.Text.Length == 0)
                    {
                        this.textBox_IP3.Focus();
                    }
                    else if (textBox.Name == "textBox_IP3" && textBox.Text.Length == 0)
                    {
                        this.textBox_IP4.Focus();
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox_IP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIPAddr(this.textBox_IP1, e);
        }

        private void textBox_IP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIPAddr(this.textBox_IP2, e);
        }

        private void textBox_IP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIPAddr(this.textBox_IP3, e);
        }

        private void textBox_IP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIPAddr(this.textBox_IP4, e);
        }

        private void BtnSetIp_Click(object sender, EventArgs e)
        {
            //validasi kosong
            if (IP1 == string.Empty || IP2 == string.Empty || IP3 == string.Empty || IP4 == string.Empty || txtNewPort.Text.ToString().Trim() == string.Empty)
            { return; }
            //jika tidak ada yang dirubah
            if (txtLastPort.Text.ToString().Trim() == txtNewPort.Text.ToString().Trim() && txtLastIp.Text.ToString().Trim() == getIpAdr)
            { return; }

            //konfirmasi
            if (MessageBox.Show("Anda yakin merubah IP: " + getIpAdr + " dan Port: " + txtNewPort.Text + "?", "BSI UMY", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            InsertIP();
        }

        private void InsertIP()
        {
            bool err = false;

            string query = "INSERT INTO IpHistory (IpAddress, LastModified, port) values (@IpAddress, @LastModified, @port)";

            cKoneksi koneksi = new cKoneksi();

            cControl cnt = new cControl();

            using (SQLiteConnection sqlCon = new SQLiteConnection(koneksi.LokasiSqlite()))//insert ke local Sqlite
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    try
                    {
                        //---------------------------------
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@IpAddress", getIpAdr);
                        cmd.Parameters.AddWithValue("@LastModified", cnt.getDateTimeNow());
                        cmd.Parameters.AddWithValue("@port", txtNewPort.Text.ToString().Trim());
                        //---------------------------------
                        cmd.Connection = sqlCon;
                        sqlCon.Open();

                        da.Fill(dt);
                        //---------------------
                    }
                    catch (Exception ex)
                    {
                        err = true;
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();

                        dt.Clear();
                        dt.Dispose();
                    }
                }
            }

            if (err == false)
            {
                refresh(); //jika tidak ada error refresh
            }
        }

        private string IP1
        {
            get
            {
                return this.textBox_IP1.Text.Trim();
            }
        }

        private string IP2
        {
            get
            {
                return this.textBox_IP2.Text.Trim();
            }
        }
        private string IP3
        {
            get
            {
                return this.textBox_IP3.Text.Trim();
            }
        }

        private string IP4
        {
            get
            {
                return this.textBox_IP4.Text.Trim();
            }
        }

        private string getIpAdr
        {
            get
            {
                return IP1 + "." + IP2 + "." + IP3 + "." + IP4;
            }

        }
    }
}
