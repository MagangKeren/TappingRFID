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
    public partial class FormCekAmbil : Form
    {
        private string nik = string.Empty;
        private string nama = string.Empty;

        public FormCekAmbil()
        {
            InitializeComponent();
        }

        private void FormCekAmbil_Load(object sender, EventArgs e)
        {
            cekHakAkases();
        }

        private void cekHakAkases()
        {
            if (cVarGlobal.isAplication == "Akademik")
            {
                rbMahasiswa.Checked = true;
                rbPegawai.Enabled = false;
            }
            else if (cVarGlobal.isAplication == "Biro Umum")
            {
                rbPegawai.Checked = true;
                rbMahasiswa.Enabled = false;
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                if (e.Row.Index % 2 == 0)
                {
                    dataGridView1.Rows[e.Row.Index].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
                else
                {
                    dataGridView1.Rows[e.Row.Index].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void txt_cari_nama_TextChanged(object sender, EventArgs e)
        {
            nama = txt_cari_nama.Text.Replace("'", "''");
            cariDariServer();
        }

        private void cariDariServer()
        {
            SearchAmbilKtm();

            //NIM
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int widthCol = dataGridView1.Columns[0].Width;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = widthCol;
            //Nama
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int widthCol1 = dataGridView1.Columns[1].Width;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].Width = widthCol1;
            //Kode rfid
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int widthCol2 = dataGridView1.Columns[2].Width;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[2].Width = widthCol2;

            if (rbMahasiswa.Checked == true) //jika mhs ada 6 field
            {
                //operator
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int widthCol3 = dataGridView1.Columns[3].Width;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[3].Width = widthCol3;
                //lastModified
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int widthCol4 = dataGridView1.Columns[4].Width;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[4].Width = widthCol4;
                //ambilKtmKe
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int widthCol5 = dataGridView1.Columns[5].Width;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[5].Width = widthCol5;
            }
        }

        private void SearchAmbilKtm() //select dari simak
        {
            SqlConnection conn = null;
            try
            {
                string konekKe = null;
                string queryUse = null;

                cQuery qr = new cQuery();
                cKoneksi koneksi = new cKoneksi();

                if (rbMahasiswa.Checked == true)
                {
                    konekKe = "2";//2 = ke simak
                    queryUse = qr.qSearchMhsAmbilKtm(nik, nama);
                }
                else
                {
                    konekKe = "4";//4 = ke payroll
                    queryUse = qr.qSearchAmbilKartuPeg(nik, nama);
                }

                conn = new SqlConnection(koneksi.konekMsSql(Convert.ToChar(konekKe)));
                SqlCommand cmd = null;
                //---------------------------------
                cmd = new SqlCommand(queryUse, conn);
                //---------------------------------
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Authors_table");
                //---------------------
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Authors_table";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void txt_cari_nik_TextChanged(object sender, EventArgs e)
        {
            nik = txt_cari_nik.Text.Replace("'", "''");
            cariDariServer();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
