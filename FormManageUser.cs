using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbilKtm
{
    public partial class FormManageUser : Form
    {
        public FormManageUser()
        {
            InitializeComponent();
        }

        private void FormManageUser_Load(object sender, EventArgs e)
        {
            cekHakAkases();
            isiListBox();
            combo_role.Text = "---Select Role---";
        }

        private void cekHakAkases()
        {
            if (cVarGlobal.isAplication == "Akademik")
            {
                rbAkademik.Checked = true;
                rbBiroUmum.Enabled = false;

                lbLokasi.Visible = false;
                rbGate.Visible = false;
                rbKantor.Visible = false;
            }
            else if (cVarGlobal.isAplication == "Biro Umum")
            {
                rbBiroUmum.Checked = true;
                rbAkademik.Enabled = false;
            }
        }

        private void isiListBox()
        {
            LbxUsername.Items.Clear();

            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();

            string queryUse = string.Empty;
            if (rbBiroUmum.Checked == true)
            {
                queryUse = qr.qSelectUserOpBu();
            }
            else if (rbAkademik.Checked == true)
            {
                queryUse = qr.qSelectUserOpAkademik();
            }

            DataTable dtUser = db.selectData(queryUse, '1');


            if (dtUser.Rows.Count != 0)
            {
                foreach (DataRow row in dtUser.Rows)
                {
                    LbxUsername.Items.Add(row["username"]);
                }
            }
            dtUser.Clear();
            dtUser.Dispose();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LbxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbxUsername.SelectedItem.ToString() != null)
            {
                string username = LbxUsername.SelectedItem.ToString();

                cDatabase db = new cDatabase();
                cQuery qr = new cQuery();

                DataTable dtUser = db.selectData(qr.qSelectUserWhereUsername(username), '1');

                if (dtUser.Rows.Count != 0)
                {
                    foreach (DataRow row in dtUser.Rows)
                    {
                        txt_username.Text = row["username"].ToString();
                        txt_fullname.Text = row["fullname"].ToString();
                        txt_password.Text = row["password"].ToString();
                        combo_role.SelectedItem = row["role"].ToString();

                        if (row["aplication"].ToString() == "Biro Umum")
                        {
                            rbKantor.Checked = true;
                        }
                        else if (row["aplication"].ToString() == "Gate")
                        {
                            rbGate.Checked = true;
                        }
                    }
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txt_fullname.Text = null;
            txt_password.Text = null;
            txt_username.Text = null;
            combo_role.Text = "---Select Role---";
            label_message.Text = "";
        }

        private void BtCreate_Click(object sender, EventArgs e)
        {
            //validasi
            if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_fullname.Text) || string.IsNullOrEmpty(txt_password.Text) || combo_role.Text == "---Select Role---")
            {
                label_message.Text = "Mohon Periksa Kembali Form";
                return;
            }
            createUser();

            isiListBox();
        }

        private void createUser()
        {
            string errInsert = string.Empty;
            cKoneksi koneksi = new cKoneksi();
            SqlConnection conn = new SqlConnection(koneksi.konekMsSql('1'));//koneksi ke 64 db parkir

            cQuery qr = new cQuery();
            SqlCommand cmd = null;

            string aplication = string.Empty;
            if (rbAkademik.Checked == true)
            {
                aplication = "Akademik";
            }
            else if (rbBiroUmum.Checked == true)
            {
                if (rbGate.Checked == true)
                {
                    aplication = "Gate";
                }
                else if (rbKantor.Checked == true)
                {
                    aplication = "Biro Umum";
                }
            }

            try
            {
                conn.Open();

                cmd = new SqlCommand(qr.qInsertUser(), conn);

                cmd.Parameters.AddWithValue("@username", txt_username.Text);
                cmd.Parameters.AddWithValue("@fullname", txt_fullname.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                cmd.Parameters.AddWithValue("@role", combo_role.Text);
                cmd.Parameters.AddWithValue("@aplication", aplication);

                cmd.ExecuteNonQuery();//insert ke sql
            }
            catch (Exception ex)
            {
                errInsert = ex.Message;
                MessageBox.Show(errInsert, "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            if (errInsert == string.Empty)
            {
                label_message.Text = "Registrasi User Berhasil Disimpan";
            }

            //cKoneksi koneksi = new cKoneksi();
            //cQuery qr = new cQuery();
            //using (var conn = new SqlConnection(koneksi.konekMsSql('1')))//koneksi ke 64 db parkir
            //{
            //    try
            //    {

            //        conn.Open();//buka koneksi
            //        using (var cmd = new SqlCommand(conn))
            //        {
            //            using (var transaction = conn.BeginTransaction())
            //            {
            //                cmd.CommandText = qr.qInsertUser(); // " INSERT INTO user (username ,fullname ,password ,role) VALUES (@username,@fullname,@password,@role)";
            //                    cmd.Parameters.Clear();
            //                    cmd.Prepare();
            //                    cmd.Parameters.AddWithValue("@username", txt_username.Text);
            //                    cmd.Parameters.AddWithValue("@fullname", txt_fullname.Text);
            //                    cmd.Parameters.AddWithValue("@password", txt_password.Text);
            //                    cmd.Parameters.AddWithValue("@role", combo_role.Text);
            //                    cmd.ExecuteNonQuery();

            //                transaction.Commit();
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Username sudah dipakai, coba yang lain");
            //    }
            //    finally
            //    {
            //        conn.Close(); //tutup koneksi
            //        conn.Dispose();
            //    }

            //}
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            deleteUser();
            Reset();
            isiListBox();
        }

        private void deleteUser()
        {
            string errInsert = string.Empty;
            cKoneksi koneksi = new cKoneksi();
            SqlConnection conn = new SqlConnection(koneksi.konekMsSql('1'));//koneksi ke 64 db parkir

            cQuery qr = new cQuery();
            SqlCommand cmd = null;

            try
            {
                conn.Open();

                cmd = new SqlCommand(qr.qDeleteUserWhereUsernameAndPass(), conn);
                cmd.Parameters.AddWithValue("@username", txt_username.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);

                cmd.ExecuteNonQuery();//insert ke sql
            }
            catch (Exception ex)
            {
                errInsert = ex.Message;
                MessageBox.Show(errInsert, "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            if (errInsert == string.Empty)
            {
                label_message.Text = "User Berahasil dihapus";
            }

            //string err = string.Empty;
            //cQuery qr = new cQuery();
            //cKoneksi koneksi = new cKoneksi();
            //using (var conn = new SQLiteConnection(koneksi.LokasiSqlite()))//koneksi ke sqlite
            //{
            //    try
            //    {
            //        conn.Open();//buka koneksi
            //        using (var cmd = new SQLiteCommand(conn))
            //        {
            //            using (var transaction = conn.BeginTransaction())
            //            {
            //                cmd.CommandText = qr.qDeleteUserWhereUsernameAndPass();//" Delete from user where username = @username and password = @password ";
            //                cmd.Parameters.Clear();
            //                cmd.Prepare();
            //                cmd.Parameters.AddWithValue("@username", txt_username.Text);
            //                cmd.Parameters.AddWithValue("@password", txt_password.Text);
            //                cmd.ExecuteNonQuery();

            //                transaction.Commit();
            //            }
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        conn.Close(); //tutup koneksi
            //        conn.Dispose();
            //    }
            //}
            //if (err == string.Empty)
            //{
            //    MessageBox.Show("Username berhasil dihapus");
            //}

        }
    }
}
