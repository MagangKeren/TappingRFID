using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbilKtm
{
    public partial class FormSync : Form
    {
        string LastUpdate { get; set; }

        public FormSync()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cSyncRun.closingThread = true;
            Application.Exit();
        }

        private void FormSync_Load(object sender, EventArgs e)
        {
            //inisialisasi progressbar
            PbUpload.Style = ProgressBarStyle.Marquee;
            ProgressBarSinkron.Style = ProgressBarStyle.Marquee;

            if (cekTransaksiUploadMhs() == true)//jika masih ada data status 0
            { //diupload dulu
                Thread tUpload = new Thread(new ThreadStart(SyncUploadTransksiMhs));
                tUpload.Start();

                //syncron download
                Thread oThread = new Thread(new ThreadStart(SyncDownload));
                oThread.IsBackground = true;//bikin thread di backgroud, supaya ketika main thread di close, thread yang lain otomatis ke close
                oThread.Start();
            }
            else
            { //progressbar upload langsung di full
                PbUpload.Style = ProgressBarStyle.Blocks;
                PbUpload.Value = PbUpload.Maximum;
                LbUpload.Text = "Complete";

                //syncron download
                Thread oThread = new Thread(new ThreadStart(SyncDownload));
                oThread.IsBackground = true;//bikin thread di backgroud, supaya ketika main thread di close, thread yang lain otomatis ke close
                oThread.Start();
            }
        }

        //true = ada data
        //false = tidak ada data
        private bool cekTransaksiUploadMhs()
        {
            DataTable dt = null;
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();

            dt = db.selectDataSqlite(qr.qSelectTransaksiMhsStatus0Limit1());// ambil data dari sqlite 
            if (dt.Rows.Count != 0) //jika ada data
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SyncUploadTransksiMhs()
        {
            //tandai proses sync
            cSyncRun.isSync = true;
            string err = string.Empty;

            if (LbUpload.InvokeRequired)
            {
                LbUpload.BeginInvoke(
                    new Action(() =>
                    {
                        LbUpload.Text = "Uploading Transaksi...";
                    }
                ));
            }
            err = uploadTransaksiKartuMhs(); //proses upload ada disini
            if (err != string.Empty)
            {
                cSyncRun.isSync = false;

                if (LbUpload.InvokeRequired)
                {
                    LbUpload.BeginInvoke(
                        new Action(() =>
                        {
                            LbUpload.Text = "Upload Transaksi Kartu Mhs Failed, Proses Stoped";
                        }
                    ));
                }

                //MessageBox.Show("Syncronize Transaksi Parkir Failed, Proses Stoped", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (err == string.Empty)
            {
                cSyncRun.isSync = false;

                if (LbUpload.InvokeRequired)
                {
                    LbUpload.BeginInvoke(
                        new Action(() =>
                        {
                            LbUpload.Text = "Upload Kartu Mhs Complete";
                        }
                    ));
                }
                //MessageBox.Show("Syncronize Complete", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //tandai proses sync
            cSyncRun.isSync = false;
        }

        private string uploadTransaksiKartuMhs()
        {
            cSyncRun.isSync = true;//tandai proses sync

            string err = string.Empty;//tampungan error message

            try
            {
                DataTable dt = null;
                cQuery qr = new cQuery();
                cDatabase db = new cDatabase();

                dt = db.selectDataSqlite(qr.qSelectTransaksiMhsStatus0());// ambil data dari sqlite 
                if (dt.Rows.Count != 0) //jika ada data
                {
                    cKoneksi koneksi = new cKoneksi();

                    SqlConnection conn = new SqlConnection(koneksi.konekMsSql('2'));//konek ke sql server user ktm = 2
                    SQLiteConnection connLite = new SQLiteConnection(koneksi.LokasiSqlite());//koneksi ke sqlite
                    try
                    {
                        conn.Open();//open sql server
                        connLite.Open();//open sqlite

                        //===inisialisasi progres bar======
                        if (PbUpload.InvokeRequired)
                        {
                            PbUpload.BeginInvoke(
                                new Action(() =>
                                {
                                    PbUpload.Style = ProgressBarStyle.Blocks;
                                    PbUpload.Value = 0;
                                    PbUpload.Minimum = 0;
                                    PbUpload.Maximum = dt.Rows.Count;
                                }
                            ));
                        }
                        //=================================

                        SQLiteTransaction transactionSqlite = connLite.BeginTransaction();

                        DataTable dtTrMhs = null;
                        foreach (DataRow row in dt.Rows)
                        {
                            SqlCommand myCommand = null;

                            dtTrMhs = cekTransaksiMhs(row["nim"].ToString());//cek data sebelumnya
                            if (dtTrMhs.Rows.Count == 0) //jika tidak ada data sebelumnya langung di insert
                            {
                                myCommand = new SqlCommand(qr.qInsertStatusMhs(), conn);

                                myCommand.Parameters.AddWithValue("@STUDENTID", row["nim"]);
                                myCommand.Parameters.AddWithValue("@TGL_AMBIL_KTM", row["lastModified"]);
                                myCommand.Parameters.AddWithValue("@PTGS_KTM_AMBIL", row["operator"]);
                            }
                            else //hanya di update
                            {
                                //==cek dulu status ktm diambil==
                                Int32 AMBIL_KTM_KE;
                                string tmpAMBIL_KTM_KE = "";
                                foreach (DataRow rowTrMhs in dtTrMhs.Rows)
                                {
                                    tmpAMBIL_KTM_KE = rowTrMhs["AMBIL_KTM_KE"].ToString().Trim();
                                }
                                //===============================

                                myCommand = new SqlCommand(qr.qUpdateStatusMhs(), conn);

                                if (Int32.TryParse(tmpAMBIL_KTM_KE, out AMBIL_KTM_KE))
                                {//jika sudah pernah diambil, urutan pengambilan ditambah 1
                                    myCommand.Parameters.AddWithValue("@AMBIL_KTM_KE", AMBIL_KTM_KE + 1);
                                }
                                else
                                {//jika urutan bukan int, set jadi 0
                                    myCommand.Parameters.AddWithValue("@AMBIL_KTM_KE", 1);
                                }
                                myCommand.Parameters.AddWithValue("@TGL_AMBIL_KTM", row["lastModified"]);
                                myCommand.Parameters.AddWithValue("@STUDENTID", row["nim"]);
                                myCommand.Parameters.AddWithValue("@PTGS_KTM_AMBIL", row["operator"]);
                            }

                            SQLiteCommand cmdSqlite = new SQLiteCommand(qr.qUpdateStatusUpload1(), connLite);
                            cmdSqlite.Parameters.AddWithValue("@idTransaksi", row["idTransaksi"]);

                            ////cek perintah thread close
                            if (cSyncRun.closingThread == true)
                            {
                                transactionSqlite.Commit();//jika ada perintah thread close, maka di sqlite langsung di commit

                                conn.Close(); //tutup koneksi
                                conn.Dispose();
                                connLite.Close();
                                connLite.Dispose();

                                return "Thread Closed By User";
                            }

                            try
                            {
                                myCommand.ExecuteNonQuery();//insert ke sql
                            }
                            catch
                            {
                                transactionSqlite.Commit();//jika proses insert di sql gagal, di sqlite langsung di commit
                            }

                            cmdSqlite.ExecuteNonQuery();//update status ke sqlite

                            //===proses progres bar======
                            if (PbUpload.InvokeRequired)
                            {
                                PbUpload.BeginInvoke(
                                    new Action(() =>
                                    {
                                        PbUpload.Increment(1);
                                    }
                                ));
                            }
                            //===========================

                            dtTrMhs.Clear();
                        }
                        transactionSqlite.Commit();

                    }
                    catch (Exception ex)
                    {
                        err = ex.Message;
                        //MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close(); //tutup koneksi
                        conn.Dispose();
                        connLite.Close();
                        connLite.Dispose();
                    }

                }

                //clear datatable
                dt.Clear();
                dt.Dispose();
                //================
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            cSyncRun.isSync = false;

            return err;
        }

        private DataTable cekTransaksiMhs(string nim)
        {
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();

            DataTable dtStatusMhs = null;
            //Cek dulu data yang mau diUpload apakah sudah ada atau belum
            dtStatusMhs = db.selectData(qr.qSelectTop1StatusMhsWhereStudId(nim), '2'); //2 = user ktm

            return dtStatusMhs;
        }

        private void SyncDownload()
        {
            Thread.Sleep(2000);//sleep dulu 2 detik, agar proses upload jalan duluan
            while (cekProsesSync() == true)
            {
                Thread.Sleep(2000); //2 detik sekali di cek, jika proses upload sudah selesai, lanjut kebawah
            }

            //tandai proses sync
            cSyncRun.isSync = true;

            string err = string.Empty;

            if (LbDownload.InvokeRequired)
            {
                LbDownload.BeginInvoke(
                    new Action(() =>
                    {
                        LbDownload.Text = "Downloading Operator...";
                    }
                ));
            }

            err = SyncOperator(true);
            if (err != string.Empty)//disetiap proses sync, jika terjadi error langsung stop
            {
                cSyncRun.isSync = false;
                if (LbDownload.InvokeRequired)
                {
                    LbDownload.BeginInvoke(
                        new Action(() =>
                        {
                            LbDownload.Text = "Download Operator Failed, Proses Stoped";
                        }
                    ));
                }
                //MessageBox.Show("Syncronize Operator Failed, Proses Stoped", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LbDownload.InvokeRequired)
            {
                LbDownload.BeginInvoke(
                    new Action(() =>
                    {
                        LbDownload.Text = "Downloading Kendaraan...";
                    }
                ));
            }
            err = SyncKendaraan(true);
            if (err != string.Empty)
            {
                cSyncRun.isSync = false;
                if (LbDownload.InvokeRequired)
                {
                    LbDownload.BeginInvoke(
                        new Action(() =>
                        {
                            LbDownload.Text = "Download Kendaraan Failed, Proses Stoped";
                        }
                    ));
                }
                //MessageBox.Show("Syncronize Kendaraan Failed, Proses Stoped", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LbDownload.InvokeRequired)
            {
                LbDownload.BeginInvoke(
                    new Action(() =>
                    {
                        LbDownload.Text = "Downloading Mahasiswa...";
                    }
                ));
            }
            err = SyncMahasiswa(true);
            if (err != string.Empty)
            {
                cSyncRun.isSync = false;
                if (LbDownload.InvokeRequired)
                {
                    LbDownload.BeginInvoke(
                        new Action(() =>
                        {
                            LbDownload.Text = "Download Mahasiswa Failed, Proses Stoped";
                        }
                    ));
                }
                return;
            }

            if (err == string.Empty)
            {
                cSyncRun.isSync = false;
                if (LbDownload.InvokeRequired)
                {
                    LbDownload.BeginInvoke(
                        new Action(() =>
                        {
                            LbDownload.Text = "Download Complete";
                        }
                    ));
                }
                //MessageBox.Show("Syncronize Complete", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //tandai proses sync
            cSyncRun.isSync = false;
        }

        private bool cekProsesSync()
        {
            bool jalan = false;
            if (cSyncRun.isSync == false)
            {
                jalan = false;
            }
            else
            {
                jalan = true;
            }
            return jalan;
        }

        private string SyncOperator(bool firstSync)
        {
            string err = string.Empty;//tampungan error message

            deleteOperatorTmp();//hapus tmp

            err = downloadOperatorTmp();//insert tmp

            //cek fisrtSync
            if (firstSync == true)
            {
                if (err != string.Empty)
                { //jika terjadi error
                    return err;
                }
            }

            cQuery qr = new cQuery();
            if (cekDataSqlLIte(qr.qSelectUserTmpLimit1(), false) == true)//cek tabel tmp
            {  //jika ada datanya
                //pindah tabel tmp ke kendaraan

                deleteOperator();
                copyTmpToOperator();

                if (ProgressBarSinkron.Value == ProgressBarSinkron.Maximum)//jika sudah selesai tampilkan download complete
                {
                    if (LbDownload.InvokeRequired)
                    {
                        LbDownload.BeginInvoke(
                                new Action(() =>
                                {
                                    LbDownload.Text = "Download Complete";
                                }
                        ));
                    }
                }

                //cek firstSync
                if (firstSync == false)
                {
                    MessageBox.Show("" + ProgressBarSinkron.Value + " Data Berhasil di Download", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (LbDownload.InvokeRequired)
                {
                    LbDownload.BeginInvoke(
                            new Action(() =>
                            {
                                LbDownload.Text = string.Empty;
                            }
                    ));
                }

            }
            else
            {
                MessageBox.Show("Synchronize Failed", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return err;
        }

        private void deleteOperatorTmp()
        {
            cQuery qr = new cQuery();

            cDatabase db = new cDatabase();
            db.insertDataSqlite(qr.qDeleteOperatorTmp());
        }

        private string downloadOperatorTmp()
        {
            string err = string.Empty;
            try
            {
                cQuery qr = new cQuery();
                cDatabase db = new cDatabase();
                DataTable dt = null;
                dt = db.selectData(qr.qSelectUserOpAkdk(), '1'); // ambil data dari mssql 
                if (dt.Rows.Count != 0) //jika ada data
                {
                    //===inisialisasi progres bar======
                    if (ProgressBarSinkron.InvokeRequired)
                    {
                        ProgressBarSinkron.BeginInvoke(
                           new Action(() =>
                           {
                               ProgressBarSinkron.Style = ProgressBarStyle.Blocks;
                               ProgressBarSinkron.Value = 0;
                               ProgressBarSinkron.Minimum = 0;
                               ProgressBarSinkron.Maximum = dt.Rows.Count;
                           }
                       ));
                    }

                    //=================================

                    cKoneksi koneksi = new cKoneksi();

                    using (var conn = new SQLiteConnection(koneksi.LokasiSqlite()))//koneksi ke sqlite
                    {
                        try
                        {

                            conn.Open();//buka koneksi
                            using (var cmd = new SQLiteCommand(conn))
                            {
                                using (var transaction = conn.BeginTransaction())
                                {
                                    //looping insert
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        cmd.CommandText = qr.qInsertUserTmp();//" INSERT INTO userTmp (username, fullname, password, role) values(@username, @fullname, @password, @role)";
                                        cmd.Parameters.Clear();
                                        cmd.Prepare();
                                        cmd.Parameters.AddWithValue("@username", row["username"]);
                                        cmd.Parameters.AddWithValue("@fullname", row["fullname"]);
                                        cmd.Parameters.AddWithValue("@password", row["password"]);
                                        cmd.Parameters.AddWithValue("@aplication", row["aplication"]);
                                        cmd.Parameters.AddWithValue("@role", row["role"]);
                                        cmd.ExecuteNonQuery();

                                        //===proses progres bar======
                                        if (ProgressBarSinkron.InvokeRequired)
                                        {
                                            ProgressBarSinkron.BeginInvoke(
                                                new Action(() =>
                                                {
                                                    ProgressBarSinkron.Increment(1);
                                                }
                                            ));
                                        }

                                        //ProgressBarSinkron.Increment(1);
                                        //===========================
                                    }

                                    transaction.Commit();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn.Close(); //tutup koneksi
                            conn.Dispose();
                        }

                    }

                    ////===tutup progres bar======
                    //if (ProgressBarSinkron.Value == ProgressBarSinkron.Maximum)//jika sudah selesai tampilkan download complete
                    //{ LblProgressBar.Text = "Download Complete"; }
                    //MessageBox.Show("" + ProgressBarSinkron.Value + " Data Berhasil di Download");
                    //panelProgressBar.Visible = false;// hiden panel progressbar
                    ////==========================
                }

                //clear datatable
                dt.Clear();
                dt.Dispose();
                //================
            }
            catch (Exception ex)
            {
                err = ex.Message;
                //ProgressBarSinkron.Visible = false;
                MessageBox.Show(ex.Message);
            }
            return err;
        }

        //cek data sql lite
        //lastUpdate, true = pakai lastUpdate, false tidak pakai lastUpdate
        // return true jika ada data
        // return false jika tidak ada
        private bool cekDataSqlLIte(string query, bool lastUpdate)
        {
            if (lastUpdate == true) { this.LastUpdate = string.Empty; }//kosongkan dulu lastUpdate

            bool ada = false;
            cKoneksi koneksi = new cKoneksi();
            SQLiteConnection sqlite = null;
            sqlite = new SQLiteConnection(koneksi.LokasiSqlite());

            SQLiteDataReader rdrCek = null; //fikri 20150202
            SQLiteCommand cek_dataSqlLite = null; //fikri 20150202

            cek_dataSqlLite = new SQLiteCommand(query); // fikri 20150202

            try
            {
                sqlite.Open();
                cek_dataSqlLite.Connection = sqlite;
                rdrCek = cek_dataSqlLite.ExecuteReader();
                if (rdrCek.HasRows)
                {
                    if (lastUpdate == true)
                    {
                        while (rdrCek.Read())
                        { this.LastUpdate = rdrCek.GetDateTime(0).ToString(); } //isi lastUpdate
                    }

                    ada = true;
                }
                else
                {
                    ada = false;
                }
                return ada;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ada;
            }
            finally
            {
                rdrCek.Close();
                sqlite.Close();
                sqlite.Dispose();
            }
        }

        private void deleteOperator()
        {
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();
            db.insertDataSqlite(qr.qDeleteOperator());
        }

        private void copyTmpToOperator()
        {
            cKoneksi koneksi = new cKoneksi();
            using (var conn = new SQLiteConnection(koneksi.LokasiSqlite()))//koneksi ke sqlite
            {
                try
                {
                    conn.Open();//buka koneksi
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        using (var transaction = conn.BeginTransaction())
                        {
                            cQuery qr = new cQuery();
                            cmd.CommandText = qr.qCopyTmpToOperator();//"INSERT INTO user SELECT * FROM userTmp";//query copy table
                            cmd.ExecuteNonQuery();

                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close(); //tutup koneksi
                    conn.Dispose();
                }

            }
        }

        private string SyncKendaraan(bool firstSync)
        {
            string err = string.Empty;//tampungan error message

            deleteKendaraanTmp();//hapus tmp

            err = downloadKendaraanTmp();//insert tmp

            //cek fisrtSync
            if (firstSync == true)
            {
                if (err != string.Empty)
                { //jika terjadi error
                    return err;
                }
            }

            cQuery qr = new cQuery();
            //string qrTmp = "SELECT last_update FROM kendaraanTmp order by last_update desc LIMIT 1";//cek data di tmp
            if (cekDataSqlLIte(qr.qSelectKendaraanTmpLimit1(), false) == true)//cek tabel tmp
            {  //jika ada datanya
                //pindah tabel tmp ke kendaraan

                deleteKendaraan();
                copyTmpToKendaraan();

                if (ProgressBarSinkron.Value == ProgressBarSinkron.Maximum)//jika sudah selesai tampilkan download complete
                {
                    if (LbDownload.InvokeRequired)
                    {
                        LbDownload.BeginInvoke(
                                new Action(() =>
                                {
                                    LbDownload.Text = "Download Complete";
                                }
                        ));
                    }
                }

                //cek firstSync
                if (firstSync == false)
                {
                    MessageBox.Show("" + ProgressBarSinkron.Value + " Data Berhasil di Download", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (LbDownload.InvokeRequired)
                {
                    LbDownload.BeginInvoke(
                            new Action(() =>
                            {
                                LbDownload.Text = string.Empty;
                            }
                    ));
                }

            }
            else
            {
                MessageBox.Show("Synchronize Failed", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return err;
        }

        private void deleteKendaraanTmp()
        {
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();
            db.insertDataSqlite(qr.qDeleteKendaraanTmp());
        }

        private string downloadKendaraanTmp()
        {
            string err = string.Empty;
            try
            {
                cQuery qr = new cQuery();
                cDatabase db = new cDatabase();
                DataTable dt = null;
                dt = db.selectData(qr.qSelectKendaraan(), '1'); // ambil data dari mssql 
                if (dt.Rows.Count != 0) //jika ada data
                {
                    //===inisialisasi progres bar======
                    if (ProgressBarSinkron.InvokeRequired)
                    {
                        ProgressBarSinkron.BeginInvoke(
                                new Action(() =>
                                {
                                    ProgressBarSinkron.Style = ProgressBarStyle.Blocks;
                                    ProgressBarSinkron.Value = 0;
                                    ProgressBarSinkron.Minimum = 0;
                                    ProgressBarSinkron.Maximum = dt.Rows.Count;
                                }
                        ));
                    }
                    //=================================

                    cKoneksi koneksi = new cKoneksi();

                    using (var conn = new SQLiteConnection(koneksi.LokasiSqlite()))//koneksi ke sqlite
                    {
                        try
                        {

                            conn.Open();//buka koneksi
                            using (var cmd = new SQLiteCommand(conn))
                            {
                                using (var transaction = conn.BeginTransaction())
                                {
                                    //looping insert
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        cmd.CommandText = qr.qInsertKendaraanTmp();
                                        cmd.Parameters.Clear();
                                        cmd.Prepare();
                                        cmd.Parameters.AddWithValue("@id", row["id_kendaraan"]);
                                        cmd.Parameters.AddWithValue("@id_pengguna", row["pengguna"]);
                                        cmd.Parameters.AddWithValue("@no_kendaraan", row["tnkb"]);
                                        cmd.Parameters.AddWithValue("@pemilik", row["pemilik"]);
                                        cmd.Parameters.AddWithValue("@merek", row["merek"]);
                                        cmd.Parameters.AddWithValue("@jenis", row["id_jenis_kendaraan"]); //jenis dilangsung aja
                                        cmd.Parameters.AddWithValue("@last_update", row["last_update"]); //last Update
                                        cmd.ExecuteNonQuery();

                                        //===proses progres bar======
                                        if (ProgressBarSinkron.InvokeRequired)
                                        {
                                            ProgressBarSinkron.BeginInvoke(
                                                    new Action(() =>
                                                    {
                                                        ProgressBarSinkron.Increment(1);
                                                    }
                                            ));
                                        }
                                        //===========================
                                    }

                                    transaction.Commit();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn.Close(); //tutup koneksi
                            conn.Dispose();
                        }

                    }

                    ////===tutup progres bar======
                    //if (ProgressBarSinkron.Value == ProgressBarSinkron.Maximum)//jika sudah selesai tampilkan download complete
                    //{ LblProgressBar.Text = "Download Complete"; }
                    //MessageBox.Show("" + ProgressBarSinkron.Value + " Data Berhasil di Download");
                    //panelProgressBar.Visible = false;// hiden panel progressbar
                    ////==========================
                }

                //clear datatable
                dt.Clear();
                dt.Dispose();
                //================
            }
            catch (Exception ex)
            {
                err = ex.Message;
                //ProgressBarSinkron.Visible = false;
                MessageBox.Show(ex.Message);
            }
            return err;
        }

        private void deleteKendaraan()
        {
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();
            db.insertDataSqlite(qr.qDeleteKendaraan());
        }

        private void copyTmpToKendaraan()
        {
            cKoneksi koneksi = new cKoneksi();
            using (var conn = new SQLiteConnection(koneksi.LokasiSqlite()))//koneksi ke sqlite
            {
                try
                {
                    conn.Open();//buka koneksi
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        using (var transaction = conn.BeginTransaction())
                        {
                            cQuery qr = new cQuery();
                            cmd.CommandText = qr.qCopyTmpToKendaraan();//"INSERT INTO kendaraan SELECT * FROM kendaraanTmp";//query copy table
                            cmd.ExecuteNonQuery();

                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close(); //tutup koneksi
                    conn.Dispose();
                }
            }
        }

        private string SyncMahasiswa(bool firstSync)
        {
            string err = string.Empty;//tampungan error message

            deleteMahasiswaTmp();//hapus tmp

            err = downloadMahasiswaTmp();//insert tmp

            //cek fisrtSync
            if (firstSync == true)
            {
                if (err != string.Empty)
                { //jika terjadi error
                    return err;
                }
            }

            cQuery qr = new cQuery();
            //string qrTmp = "SELECT nik FROM penggunaTmp WHERE kategori = 1 LIMIT 1";//cek data mhs di tmp
            if (cekDataSqlLIte(qr.qSelectMhsTmpLimit1(), false) == true)//cek tabel tmp
            {  //jika ada datanya
                //pindah tabel tmp ke kendaraan

                deleteMahasiswa();
                copyTmpToMahasiswa();

                if (ProgressBarSinkron.Value == ProgressBarSinkron.Maximum)//jika sudah selesai tampilkan download complete
                {
                    if (LbDownload.InvokeRequired)
                    {
                        LbDownload.BeginInvoke(
                                new Action(() =>
                                {
                                    LbDownload.Text = "Download Complete";
                                }
                        ));
                    }
                }

                //Cek firstSync
                if (firstSync == false)
                {
                    MessageBox.Show("" + ProgressBarSinkron.Value + " Data Berhasil di Download", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Synchronize Failed", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ProgressBarSinkron.Visible = false;// hiden panel progressbar
            }

            return err;
        }

        private void deleteMahasiswaTmp()
        {
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();
            //string query = "delete from penggunaTmp where kategori = 1"; //kategori 1=mahasiwa
            db.insertDataSqlite(qr.qDeleteMhsTmp());
        }

        private string downloadMahasiswaTmp()
        {
            string err = string.Empty;

            try
            {
                cQuery qr = new cQuery();
                cDatabase db = new cDatabase();
                DataTable dt = null;
                dt = db.selectData(qr.qSelectMhs(), '2'); // '2' = ambil data dari 10.0.1.61 db s1makumyny4
                if (dt.Rows.Count != 0) //jika ada data
                {
                    //===inisialisasi progres bar======
                    if (ProgressBarSinkron.InvokeRequired)
                    {
                        ProgressBarSinkron.BeginInvoke(
                                new Action(() =>
                                {
                                    ProgressBarSinkron.Value = 0;
                                    ProgressBarSinkron.Minimum = 0;
                                    ProgressBarSinkron.Maximum = dt.Rows.Count;
                                }
                        ));
                    }
                    //=================================

                    cKoneksi koneksi = new cKoneksi();
                    using (var conn = new SQLiteConnection(koneksi.LokasiSqlite()))//koneksi ke sqlite
                    {
                        try
                        {

                            conn.Open();//buka koneksi
                            using (var cmd = new SQLiteCommand(conn))
                            {
                                using (var transaction = conn.BeginTransaction())
                                {
                                    //looping insert
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        cmd.CommandText = qr.qInsertPenggunaTmp();//"insert into penggunaTmp (id,nik,nama,rfid,kategori) values (@id,@nik,@nama,@rfid,@kategori)";
                                        cmd.Parameters.Clear();
                                        cmd.Prepare();
                                        cmd.Parameters.AddWithValue("@id", row["StudentID"]); //kenapa ID diisi sama kayak nik??
                                        cmd.Parameters.AddWithValue("@nik", row["StudentID"]); //kenapa ID diisi sama kayak nik??
                                        cmd.Parameters.AddWithValue("@nama", row["fullname"]);
                                        cmd.Parameters.AddWithValue("@rfid", row["rfid"]);
                                        cmd.Parameters.AddWithValue("@kategori", 1); // 1 = kategori mahasiswa
                                        cmd.ExecuteNonQuery();

                                        //===proses progres bar======
                                        if (ProgressBarSinkron.InvokeRequired)
                                        {
                                            ProgressBarSinkron.BeginInvoke(
                                                    new Action(() =>
                                                    {
                                                        ProgressBarSinkron.Increment(1);
                                                    }
                                            ));
                                        }
                                        //===========================
                                    }

                                    transaction.Commit();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn.Close(); //tutup koneksi
                            conn.Dispose();
                        }

                    }

                    ////===tutup progres bar======
                    //if (ProgressBarSinkron.Value == ProgressBarSinkron.Maximum)//jika sudah selesai tampilkan download complete
                    //{ LblProgressBar.Text = "Download Complete"; }
                    //MessageBox.Show("" + ProgressBarSinkron.Value + " Data Berhasil di Download");
                    //panelProgressBar.Visible = false;// hiden panel progressbar
                    ////==========================
                }

                //clear datatable
                dt.Clear();
                dt.Dispose();
                //================
            }
            catch (Exception ex)
            {
                err = ex.Message;
                //ProgressBarSinkron.Visible = false;
                MessageBox.Show(ex.Message);
            }
            return err;
        }

        private void deleteMahasiswa()
        {
            //string query = "delete from pengguna where kategori = 1"; //kategori 1=mahasiwa
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();
            db.insertDataSqlite(qr.qDeleteMhs());
        }

        private void copyTmpToMahasiswa()
        {
            cKoneksi koneksi = new cKoneksi();
            using (var conn = new SQLiteConnection(koneksi.LokasiSqlite()))//koneksi ke sqlite
            {
                try
                {
                    conn.Open();//buka koneksi
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        using (var transaction = conn.BeginTransaction())
                        {
                            cQuery qr = new cQuery();
                            cmd.CommandText = qr.qCopyTmpToMhs();
                            cmd.ExecuteNonQuery();

                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close(); //tutup koneksi
                    conn.Dispose();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadFormLogin();
        }

        private void loadFormLogin()
        {
            FormLogin frmLogin = new FormLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
