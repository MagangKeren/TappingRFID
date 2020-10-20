using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbilKtm
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.AcceptButton = btn_login;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cSyncRun.closingThread = true;
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string role = string.Empty;
            string OP = string.Empty;

            if ((textBox_username.Text.Trim() != "") && (textBox_pass.Text.Trim() != ""))
            {
                //var con = new SQLiteConnection(koneksi.LokasiSqlite());
                //cQuery qr = new cQuery();
                //SQLiteCommand cmd = new SQLiteCommand(qr.qSelectUserLogin(), con);
                //cmd.Parameters.AddWithValue("@username", this.textBox_username.Text);
                //cmd.Parameters.AddWithValue("@password", this.textBox_pass.Text);

                //try
                //{
                //    con.Open();
                //    SQLiteDataReader dr = cmd.ExecuteReader();
                //    while (dr.Read())
                //    {
                //        if (dr.HasRows == true)
                //        {
                //            role = dr.GetString(1);
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    return;
                //}
                //finally
                //{
                //    con.Close();
                //    con.Dispose();
                //}

                //jika terchek akademik proses db local
                if (cbAkademik.Checked == true)
                {
                    role = loginLocal();
                }
                else
                {
                    role = loginMsSql();
                }

                if (role != string.Empty)
                {
                    lbl_message.Text = "";
                    OP = textBox_username.Text;

                    cVarGlobal.opLogin = OP;//masukkan username operator login
                    if (role == "Admin")//hak akses
                    {
                        cVarGlobal.isAdmin = true;
                    }
                    else
                    {
                        cVarGlobal.isAdmin = false;
                    }
                    Form1 fr = new Form1();
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    lbl_message.Text = ("Mohon Maaf, password dan username anda tidak cocok");
                    textBox_username.Text = "";//mengosongkan kolom setelah salah
                    textBox_pass.Text = "";//mengosongkan kolom setelah salah
                }

            }
            else
            {
                lbl_message.Text = ("Masukkan username dan password");
            }
        }

        private string loginLocal()
        {
            cKoneksi koneksi = new cKoneksi();
            string role = string.Empty;

            var con = new SQLiteConnection(koneksi.LokasiSqlite());
            cQuery qr = new cQuery();
            SQLiteCommand cmd = new SQLiteCommand(qr.qSelectUserLoginSqlite(), con);
            cmd.Parameters.AddWithValue("@username", this.textBox_username.Text);
            cmd.Parameters.AddWithValue("@password", this.textBox_pass.Text);

            try
            {
                con.Open();
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        role = dr.GetString(1);
                        cVarGlobal.isAplication = dr.GetString(2);//set hak akses aplikasi
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                role = string.Empty;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return role;
        }

        private string loginMsSql()
        {
            cKoneksi koneksi = new cKoneksi();
            string role = string.Empty;

            var con = new SqlConnection(koneksi.konekMsSql('1'));//// konek ke 10.0.1.64 db parkir
            cQuery qr = new cQuery();
            SqlCommand cmd = new SqlCommand(qr.qSelectUserLoginMsSql(), con);
            cmd.Parameters.AddWithValue("@username", this.textBox_username.Text);
            cmd.Parameters.AddWithValue("@password", this.textBox_pass.Text);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        role = dr.GetString(1);
                        cVarGlobal.isAplication = dr.GetString(2);//set hak akses aplikasi
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                role = string.Empty;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return role;
        }
    }
}
