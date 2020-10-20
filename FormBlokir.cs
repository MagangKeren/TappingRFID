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
    public partial class FormBlokir : Form
    {
        private string IdMhs;
        private string NamaMhs;
        private string Rfid;
        private string nimOrNik;

        private void FormBlokir_Load(object sender, EventArgs e)
        {
            Hak_akses(); //disable ts jika bukan admin
        }

        public FormBlokir()
        {
            InitializeComponent();

        }

        private void Hak_akses()
        {
            if (cVarGlobal.isAdmin == true)
            {
                rbPegawai.Enabled = true; //menu blokir
            }
            else
            {
                rbPegawai.Enabled = false;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            DGList.Rows.Clear();
            jmlRow.Text = string.Empty;
            //validasi
            if (txt_cari_nama.Text.Trim() == string.Empty && txt_cari_nim.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Nim atau Nama harus diisi!", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbMahasiswa.Checked == true)
            {
                cariMhs();
            }
            else if (rbPegawai.Checked == true)
            {
                cariPegawai();
            }

            autoWithColom();
            jmlRow.Text = "Jumlah baris: " + DGList.RowCount;

            if (DGList.RowCount == 0)
            {
                IdMhs = string.Empty;
                MessageBox.Show("Data tidak ditemukan", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cariMhs()
        {
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();
            DataTable dtSearch = db.selectData(qr.qSearchMhsByNImNama(txt_cari_nim.Text, txt_cari_nama.Text), '2');
            cControl cnt = new cControl();

            foreach (DataRow rowSearch in dtSearch.Rows)
            {
                string status = string.Empty;
                String TglBlokir = string.Empty;
                //jika kode rfid kososng, cek dari table history blokir
                if (rowSearch["RFID"].ToString().Trim() == string.Empty)
                {
                    DataTable dtHistory = db.selectData(qr.qSearchHistoryByIdPenggunaTop1(rowSearch["STUDENTID"].ToString()), '3');
                    if (dtHistory.Rows.Count != 0)//jika ada data di dlm history blokir = terblokir
                    {
                        status = "Terblokir";
                    }
                    else
                    {//jika tidak ada data di dlm history blokir = Tidak Aktif
                        status = "Tidak Aktif";
                    }
                }
                else
                {//jika ada data rfidnya = akif
                    status = "Aktif";
                }

                string[] row = new string[] { rowSearch["STUDENTID"].ToString(), rowSearch["STUDENTID"].ToString(), rowSearch["FULLNAME"].ToString(), rowSearch["RFID"].ToString(), status };
                DGList.Rows.Add(row);
            }

            dtSearch.Clear();
            dtSearch.Dispose();
        }

        private void cariPegawai()
        {
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();
            DataTable dtSearch = db.selectData(qr.qSearchPegByNikNama(txt_cari_nim.Text, txt_cari_nama.Text), '4'); //'4' = konek ke db payroll
            cControl cnt = new cControl();

            foreach (DataRow rowSearch in dtSearch.Rows)
            {
                string status = string.Empty;
                String TglBlokir = string.Empty;
                //jika kode rfid kososng, cek dari table history blokir
                if (rowSearch["rfid"].ToString().Trim() == string.Empty)
                {
                    DataTable dtHistory = db.selectData(qr.qSearchHistoryByIdPenggunaTop1(rowSearch["id_pegawai"].ToString()), '3');
                    if (dtHistory.Rows.Count != 0)//jika ada data di dlm history blokir = terblokir
                    {
                        status = "Terblokir";
                    }
                    else
                    {//jika tidak ada data di dlm history blokir = Tidak Aktif
                        status = "Tidak Aktif";
                    }
                }
                else
                {//jika ada data rfidnya = akif
                    status = "Aktif";
                }

                string[] row = new string[] { rowSearch["id_pegawai"].ToString(), rowSearch["nik"].ToString(), rowSearch["nama"].ToString(), rowSearch["rfid"].ToString(), status };
                DGList.Rows.Add(row);
            }

            dtSearch.Clear();
            dtSearch.Dispose();
        }

        private void autoWithColom()
        {
            ////ID
            //DGList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //int widthCol = DGList.Columns[0].Width;
            //DGList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //DGList.Columns[0].Width = widthCol;
            //NIM
            DGList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int widthCol1 = DGList.Columns[1].Width;
            DGList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGList.Columns[1].Width = widthCol1;
            //Nama
            DGList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int widthCol2 = DGList.Columns[2].Width;
            DGList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGList.Columns[2].Width = widthCol2;
            //Kode rfid
            DGList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int widthCol3 = DGList.Columns[3].Width;
            DGList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGList.Columns[3].Width = widthCol2;
            //Status
            DGList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int widthCol4 = DGList.Columns[4].Width;
            DGList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGList.Columns[4].Width = widthCol2;
        }

        private void DGList_SelectionChanged(object sender, EventArgs e)
        {
            int row = DGList.CurrentCell.RowIndex;
            IdMhs = DGList.Rows[row].Cells["ID"].Value.ToString();
            nimOrNik = DGList.Rows[row].Cells["nim"].Value.ToString();
            Rfid = DGList.Rows[row].Cells["kodeRfid"].Value.ToString();
            NamaMhs = DGList.Rows[row].Cells["Nama"].Value.ToString();
        }

        private void DGList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                if (e.Row.Index % 2 == 0)
                {
                    DGList.Rows[e.Row.Index].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
                else
                {
                    DGList.Rows[e.Row.Index].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void tsBlokir_Click(object sender, EventArgs e)
        {
            //validasi
            if (DGList.RowCount < 1)
            {
                MessageBox.Show("List data kosong!", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Rfid.Trim() == string.Empty)
            {
                MessageBox.Show("Hanya status Aktif yang dapat diblokir!", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //konfirmasi
            if (MessageBox.Show("Anda yakin memblokir Kartu" + Environment.NewLine + "NIM/NIK: " + nimOrNik + Environment.NewLine + "Nama: " + NamaMhs, "BSI UMY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            blokir(IdMhs, Rfid, NamaMhs);

            //====refresh========
            jmlRow.Text = string.Empty;
            DGList.Rows.Clear();

            if (rbMahasiswa.Checked == true)
            {
                cariMhs();
            }
            else if (rbPegawai.Checked == true)
            {
                cariPegawai();
            }

            autoWithColom();
            jmlRow.Text = "Jumlah baris: " + DGList.RowCount;
            //===================
        }

        private void blokir(string IdMhsOrPegawai, string rfid, string NamaMhs)
        {
            string errInsert = string.Empty;
            cKoneksi koneksi = new cKoneksi();
            SqlConnection conn = new SqlConnection(koneksi.konekMsSql('3'));//konek ke sql server historyBlokir

            cQuery qr = new cQuery();
            SqlCommand cmd = null;

            try
            {
                conn.Open();

                cmd = new SqlCommand(qr.qInsertHistory(), conn);

                cmd.Parameters.AddWithValue("@id_pengguna", IdMhsOrPegawai);
                cmd.Parameters.AddWithValue("@rfid", rfid);
                cmd.Parameters.AddWithValue("@nama", NamaMhs);

                cmd.ExecuteNonQuery();//insert ke sql
            }
            catch (Exception ex)
            {
                errInsert = ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            //jika insert ke table history sukses, lanjut hapus rfid dari tblMhs
            if (errInsert == string.Empty)
            {
                string konekKe = null;
                string queryUse = null;
                string paramUse = null;
                if (rbMahasiswa.Checked == true)//konek ke simak
                {
                    konekKe = "2";
                    queryUse = qr.qUpdateRfidNullByNim();
                    paramUse = "@STUDENTID";
                }
                else if (rbPegawai.Checked == true)//konek ke payroll
                {
                    konekKe = "4";
                    queryUse = qr.qUpdateRfidNullByIdPeg();
                    paramUse = "@id_pegawai";
                }

                SqlConnection connMhsOrPeg = new SqlConnection(koneksi.konekMsSql(Convert.ToChar(konekKe)));
                SqlCommand cmdDelRfid = null;
                try
                {
                    connMhsOrPeg.Open();

                    cmdDelRfid = new SqlCommand(queryUse, connMhsOrPeg);

                    cmdDelRfid.Parameters.AddWithValue(paramUse, IdMhsOrPegawai);
                    cmdDelRfid.ExecuteNonQuery();//insert ke sql
                }
                finally
                {
                    connMhsOrPeg.Close();
                    connMhsOrPeg.Dispose();
                }
            }
        }

        
    }
}
