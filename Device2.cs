using RfidApiLib;
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
    //card reader device 2
    public partial class Device2 : Form
    {
        private bool fAppClosed; 
        private int ferrorcode;
        private bool fIsInventoryScan;
        private int fCmdRet = 30;
        private byte fComAdr = 0; 
        private int frmcomportindex = 6000; 
        private string fInventory_EPC_List;
        private byte[] fPassWord = new byte[4];
        private bool clearGrid = false;
        private string lama;
        public Device2()
        {
            InitializeComponent();
        }

        RfidApi Reader1 = new RfidApi();
        public byte IsoReading = 0;
        public byte EpcReading = 0;
        public int TagCnt = 0;
        public int ScanTimes = 0;

        private void bRs232Con_Click(object sender, EventArgs e)
        {
            int status;
            byte v1 = 0;
            byte v2 = 0;
            string s = "";
            status = Reader1.OpenCommPort(cCommPort.Text);
            if (status != 0)
            {
                MessageBox.Show("Open Comm Port Failed!");
                //lInfo.Items.Add("Open Comm Port Failed!");
                return;
            }
            status = Reader1.GetFirmwareVersion(ref v1, ref v2);
            if (status != 0)
            {
                MessageBox.Show("Can not connect with the reader!");
                //lInfo.Items.Add("Can not connect with the reader!");
                Reader1.CloseCommPort();
                return;
            }
            MessageBox.Show("Connect the reader success!");
            //lInfo.Items.Add("Connect the reader success!");
            s = string.Format("The reader's firmware version is:V{0:d2}.{1:d2}", v1, v2);
           // lInfo.Items.Add(s);
            //bAntQuery_Click(sender, e);


            
            status = Reader1.SetBaudRate((byte)cBaudrate.SelectedIndex);
            if (status != 0)
            {
                MessageBox.Show("Set baudrate failed!");
               // lInfo.Items.Add("Set baudrate failed!");
                Reader1.CloseCommPort();
                return;
            }
           // MessageBox.Show("Set baudrate success!");
           // lInfo.Items.Add("Set baudrate success!");



            bRs232Con.Enabled = false;
            bRs232Discon.Enabled = true;



            
            bEpcRead.Enabled = true;
            bEpcWrite.Enabled = true;
            

            //bRfQuery_Click(null, null);
        }

        private void bEpcId_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int status;
            int i, j;
            byte[,] IsoBuf = new byte[100, 12];
            byte tag_cnt = 0;
            string s = "";
            string s1 = "";
            byte tag_flag = 0;
            int listIn = 0;

            // Filter same tag
            
            status = Reader1.EpcMultiTagIdentify(ref IsoBuf, ref tag_cnt, ref tag_flag);
            if (tag_cnt > 0)
            {
                for (i = 0; i < tag_cnt; i++)
                {
                    s1 = "";
                    for (j = 0; j < Convert.ToInt16(cEpcWordcnt.Text) * 2; j++)
                    {
                        s = string.Format("{0:X2} ", IsoBuf[i, j]);
                        s1 += s;
                    }
                    //lInfo.Items.Add(s1);
                    ListViewItem lviList = new ListViewItem();
                    if (lvTagList.Items.Count <= 0)
                    {
                        lviList.SubItems[0].Text = "1";
                        lviList.SubItems.Add("");
                        lviList.SubItems.Add("");
                        lvTagList.Items.Add(lviList);
                        listIn = 0;
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        lvTagList.Items[listIn].SubItems[2].Text = "1";
                    }
                    else
                    {
                        listIn = -1;
                        for (i = 0; i < lvTagList.Items.Count; i++)
                        {
                            if (lvTagList.Items[i].SubItems[1].Text == s1)
                            {
                                listIn = i;
                                break;
                            }
                        }
                        if (listIn < 0)
                        {
                            listIn = lvTagList.Items.Count;
                            lviList.SubItems[0].Text = Convert.ToString(listIn + 1);
                            lviList.SubItems.Add("");
                            lviList.SubItems.Add("");
                            lvTagList.Items.Add(lviList);
                        }
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        if (lvTagList.Items[listIn].SubItems[2].Text == "")
                            lvTagList.Items[listIn].SubItems[2].Text = "0";
                        Int64 intTimes = Convert.ToInt64(lvTagList.Items[listIn].SubItems[2].Text);
                        lvTagList.Items[listIn].SubItems[2].Text = Convert.ToString(intTimes + 1);
                    }
                }
            }
            if (ScanTimes <= 0)
            {
                bEpcId_Click(sender, e);
            }
        }



        private void bEpcRead_Click(object sender, EventArgs e)
        {
            int membank;
            int wordptr;
            int wordcnt;
            int status = 0;
            byte[] value = new byte[16];

            string s = "The data is:";
            string s1 = "";

            membank = cEpcMembank.SelectedIndex;
            wordptr = cEpcWordptr.SelectedIndex;
            wordcnt = cEpcWordcnt.SelectedIndex;

            status = Reader1.EpcRead((byte)membank, (byte)wordptr, (byte)wordcnt, ref value);

            if (status != 0)
            {
                MessageBox.Show("Read failed!");
               // lInfo.Items.Add("Read failed!");
                return;
            }
            else
            {
                for (int i = 0; i < wordcnt * 2; i++)
                {
                    s1 = string.Format("{0:X2}", value[i]);
                    s += s1;
                }
                
                //lInfo.Items.Add(s);
                if (EpcReading == 0)
                {
                    MessageBox.Show("Read success!");
                    //lInfo.Items.Add("Read success!");
                    Reader1.ClearIdBuf();
                    //lInfo.Items.Clear();
                    //lInfo.Items.Add("Start multiply tags identify!");
                    TagCnt = 0;
                    if (cEpcTimes.SelectedIndex > 0)
                        ScanTimes = Convert.ToInt16(cEpcTimes.Text);
                    else
                        ScanTimes = 9999;
                    timerScanEPC.Enabled = true;
                    bEpcRead.Text = "Stop";
                    EpcReading = 1;
                }
                else
                {
                    timerScanEPC.Enabled = false;
                    EpcReading = 0;
                    bEpcRead.Text = "Read";

                }
            }
        }

        private void bEpcWrite_Click(object sender, EventArgs e)
        {
            ushort[] value = new ushort[16];

            int i = 0;
            byte membank;
            byte wordptr;
            byte wordcnt;
            int status;
            string hexValues;

            membank = (byte)(cEpcMembank.SelectedIndex);
            wordptr = (byte)(cEpcWordptr.SelectedIndex);
            wordcnt = (byte)(cEpcWordcnt.SelectedIndex);

            hexValues = tEpcData.Text;
            string[] hexValuesSplit = hexValues.Split(' ');
            try
            {
                foreach (String hex in hexValuesSplit)
                {
                    // Convert the number expressed in base-16 to an integer.
                    if (hex.Length >= 2)
                    {
                        int x = Convert.ToInt32(hex, 16);
                        value[i++] = (ushort)x;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please input data needed");
                //lInfo.Items.Add("Please input data needed");
                return;
            }
            if (i != wordcnt)
            {
                MessageBox.Show("Please input data needed");
                //lInfo.Items.Add("Please input data needed");
                return;
            }
            for (byte j = 0; j < wordcnt; j++)
            {
                status = Reader1.EpcWrite(membank, (byte)(wordptr + j), value[j]);
                if (status != 0)
                {
                    MessageBox.Show("Write failed!");
                    //lInfo.Items.Add("Write failed!");
                    return;
                }
            }
            MessageBox.Show("Write success!");
            //lInfo.Items.Add("Write success!");
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            Reader1.ResetReader();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            Reader1.SetBaudRate(0);
            Reader1.CloseCommPort();
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            //lInfo.Items.Clear();
            lvTagList.Items.Clear();

        }

        private void Device2_Load(object sender, EventArgs e)
        {
            cCommPort.SelectedIndex = 0;
            cBaudrate.SelectedIndex = 0;
            bRs232Con.Enabled = true;
            bRs232Discon.Enabled = false;
        
            bEpcRead.Enabled = false;
            bEpcWrite.Enabled = false;

            cEpcTimes.SelectedIndex = 0;

            cEpcMembank.SelectedIndex = 1;
            int nLoop = 0;
            for (nLoop = 0; nLoop < 256; nLoop++)
                cEpcWordptr.Items.Add(Convert.ToString(nLoop));
            cEpcWordptr.SelectedIndex = 2;
            for (nLoop = 0; nLoop < 3; nLoop++)
                cEpcWordcnt.Items.Add(Convert.ToString(nLoop));
            cEpcWordcnt.SelectedIndex = 2;
        }

        private void bRs232Discon_Click(object sender, EventArgs e)
        {
            Reader1.SetBaudRate(0);
            Reader1.CloseCommPort();
            bRs232Con.Enabled = true;
            bRs232Discon.Enabled = false;

            bEpcRead.Enabled = false;
            bEpcWrite.Enabled = false;
            
        }

        private void timerScanISO_Tick_1(object sender, EventArgs e)
        {
            int status;
            int i, j;
            byte[,] IsoBuf = new byte[100, 12];
            byte tag_cnt = 0;
            string s = "";
            string s1 = "";
            int listIn = 0;
            // Filter same tag
            
            status = Reader1.IsoMultiTagIdentify(ref IsoBuf, ref tag_cnt);
            if (tag_cnt > 0)
            {
                for (i = 0; i < tag_cnt; i++)
                {
                    s1 = "";
                    for (j = 0; j < 8; j++)
                    {
                        s = string.Format("{0:X2} ", IsoBuf[i, j]);
                        s1 += s;
                    }
                    //lInfo.Items.Add(s1);
                    ListViewItem lviList = new ListViewItem();
                    if (lvTagList.Items.Count <= 0)
                    {
                        lviList.SubItems[0].Text = "1";
                        for (i = 0; i <= 2; i++)
                            lviList.SubItems.Add("");
                        lvTagList.Items.Add(lviList);
                        listIn = 0;
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        lvTagList.Items[listIn].SubItems[2].Text = "1";
                    }
                    else
                    {
                        listIn = -1;
                        for (i = 0; i < lvTagList.Items.Count; i++)
                        {
                            if (lvTagList.Items[i].SubItems[1].Text == s1)
                            {
                                listIn = i;
                                break;
                            }
                        }
                        if (listIn < 0)
                        {
                            listIn = lvTagList.Items.Count;
                            lviList.SubItems[0].Text = Convert.ToString(listIn + 1);
                            for (i = 0; i <= 2; i++)
                                lviList.SubItems.Add("");
                            lvTagList.Items.Add(lviList);
                        }
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        if (lvTagList.Items[listIn].SubItems[2].Text == "")
                            lvTagList.Items[listIn].SubItems[2].Text = "0";
                        Int64 intTimes = Convert.ToInt64(lvTagList.Items[listIn].SubItems[2].Text);
                        lvTagList.Items[listIn].SubItems[2].Text = Convert.ToString(intTimes + 1);
                    }
                    TagCnt++;

                }
            }
            if (ScanTimes <= 0)
            {
                //bIsoId_Click(sender, e);
            }
        }

        private void timerScanEPC_Tick_1(object sender, EventArgs e)
        {
            int status;
            int i, j;
            byte[,] IsoBuf = new byte[100, 12];
            byte tag_cnt = 0;
            string s = "";
            string s1 = "";
            byte tag_flag = 0;
            int listIn = 0;

            // Filter same tag
            
            status = Reader1.EpcMultiTagIdentify(ref IsoBuf, ref tag_cnt, ref tag_flag);
            if (tag_cnt > 0)
            {
                for (i = 0; i < tag_cnt; i++)
                {
                    s1 = "";
                    for (j = 0; j < Convert.ToInt16(cEpcWordcnt.Text) * 2; j++)
                    {
                        s = string.Format("{0:X2} ", IsoBuf[i, j]);
                        s1 += s;
                    }
                    //lInfo.Items.Add(s1);
                    ListViewItem lviList = new ListViewItem();
                    if (lvTagList.Items.Count <= 0)
                    {
                        lviList.SubItems[0].Text = "1";
                        lviList.SubItems.Add("");
                        lviList.SubItems.Add("");
                        lvTagList.Items.Add(lviList);
                        listIn = 0;
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        lvTagList.Items[listIn].SubItems[2].Text = "1";
                    }
                    else
                    {
                        listIn = -1;
                        for (i = 0; i < lvTagList.Items.Count; i++)
                        {
                            if (lvTagList.Items[i].SubItems[1].Text == s1)
                            {
                                listIn = i;
                                break;
                            }
                        }
                        if (listIn < 0)
                        {
                            listIn = lvTagList.Items.Count;
                            lviList.SubItems[0].Text = Convert.ToString(listIn + 1);
                            lviList.SubItems.Add("");
                            lviList.SubItems.Add("");
                            lvTagList.Items.Add(lviList);
                        }
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        if (lvTagList.Items[listIn].SubItems[2].Text == "")
                            lvTagList.Items[listIn].SubItems[2].Text = "0";
                        Int64 intTimes = Convert.ToInt64(lvTagList.Items[listIn].SubItems[2].Text);
                        lvTagList.Items[listIn].SubItems[2].Text = Convert.ToString(intTimes + 1);
                    }
                }
            }
            if (ScanTimes <= 0)
            {
                bEpcId_Click(sender, e);
            }
        }

        private void timerPing_Tick_1(object sender, EventArgs e)
        {
            if (Reader1.CheckPing() > 0)
            {
                MessageBox.Show("Reader already dropped");
               // lInfo.Items.Add("Reader already dropped");
                // If you are identifying label,can immediately stop.
                if (1 == EpcReading)
                {
                    bEpcId_Click(sender, e);
                }
            }
        }

        private void GbSumberData_Enter(object sender, EventArgs e)
        {

        }

        private void btnGenerateRfid_Click(object sender, EventArgs e)
        {
            if (txt_nik.Text == string.Empty)
            {
                MessageBox.Show("Pilih NIM/NIK terlebih dahulu !", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtRfid.Text != string.Empty)
            {
                MessageBox.Show("Kode Rfid Sudah ada!", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbMahasiswa.Checked == true)
            {
                generateRfidMhs();
            }
            else if (rbPegawai.Checked == true)
            {
                generateRfidPegawai();
            }

            
        }
        private void generateRfidPegawai()
        {
            string idPegawai = lbIdPegawai.Text.Replace("'", "''");

            DataTable dtRfid = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dtRfid = db.selectData(qr.qSelectRfidByIdPeg(idPegawai), '4');
            if (dtRfid.Rows.Count != 0)
            {
                string cekRfid = string.Empty;
                foreach (DataRow rowProdi in dtRfid.Rows)
                {
                    cekRfid = rowProdi["rfid"].ToString();
                }

                //jika ternyata sudah ada rfidnya, proses stop
                if (cekRfid != string.Empty)
                {
                    clearTampilan();
                    tampilPeg(idPegawai);

                    //txt_cari_nama.Text = string.Empty;
                    //txt_cari_nik.Text = string.Empty;

                    return;
                }

                //cek dari tabel pegawai
                DataTable lastHeksa = selectRfidPegTerakir(); //ambil heksa terakir dari pegawai
                string heksa = string.Empty;
                if (lastHeksa.Rows.Count != 0)
                {
                    foreach (DataRow rowHeksa in lastHeksa.Rows)
                    {
                        heksa = rowHeksa["heksa"].ToString();
                    }
                }

                //cek dari tabel history_rfid
                DataTable lastHeksaHis = selectHistoryRfidTerakirPegawai(); //ambil heksa terakir pegawai dari history
                string heksaHis = string.Empty;
                if (lastHeksaHis.Rows.Count != 0)
                {
                    foreach (DataRow rowHeksaHis in lastHeksaHis.Rows)
                    {
                        heksaHis = rowHeksaHis["heksa"].ToString();
                    }
                }

                string heksaUse = string.Empty;//heksa yang akan dipakai

                if (heksa != string.Empty && heksaHis != string.Empty) //jika di kedua tabel ditemukan heksa sebelumnya
                {
                    //bandingkan heksa dari tabel mhs dan history, nilainya paling tinggi yang dipakai
                    Int32 iheksa = Int32.Parse(heksa, System.Globalization.NumberStyles.HexNumber);//dari heksa terakir convert ke int
                    Int32 iheksaHis = Int32.Parse(heksaHis, System.Globalization.NumberStyles.HexNumber);//dari heksa terakir convert ke int

                    if (iheksa > iheksaHis)
                    {
                        heksaUse = heksa;
                    }
                    else if (iheksaHis > iheksa)
                    {
                        heksaUse = heksaHis;
                    }

                }
                else if (heksa != string.Empty && heksaHis == string.Empty) //jika hanya ditemukan dari tabel pegawai
                {
                    heksaUse = heksa;
                }
                else if (heksa == string.Empty && heksaHis != string.Empty) //jika hanya ditemukan dari tabel history_rfid
                {
                    heksaUse = heksaHis;
                }

                //=======================================================================
                if (heksaUse != string.Empty)//jika sudah ditemukan kode rfid terakir, lanjutkan sequence-nya
                {
                    UpdateRfidPegawai(idPegawai, heksaUse);
                }
                else
                { //jika belum ditemukan kode rfid sebelumnya, generate dari awal

                    UpdateRfidPegawai(idPegawai, "0000");
                }

                lastHeksa.Clear();
                lastHeksa.Dispose();
                lastHeksaHis.Clear();
                lastHeksaHis.Dispose();
            }

            clearTampilan();

            //txt_cari_nama.Text = string.Empty;
            //txt_cari_nik.Text = string.Empty;
            //DGList.Rows.Clear();
            //jmlRow.Text = string.Empty;

            tampilPeg(idPegawai);
        }
        private DataTable selectRfidPegTerakir()
        {
            DataTable dt = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dt = db.selectData(qr.qSelectLastRfidPegawai(), '4'); //4 = konek ke payroll_web
            return dt;
        }
        private void UpdateRfidPegawai(string idPegawai, string lastHeksa)
        {

            Int32 sequence = Int32.Parse(lastHeksa, System.Globalization.NumberStyles.HexNumber);//dari heksa terakir convert ke int

            sequence++;
            string heksa = String.Format("{0:X7}", sequence); //heksa selanjutnya => utk pegawai heksa ada 7 digit

            DataTable dt = null;
            cKoneksi koneksi = new cKoneksi();
            SqlConnection conn = new SqlConnection(koneksi.konekMsSql('4'));
            conn.Open();

            try
            {
                string RFID = "2" + heksa + "";

                SqlCommand cmd = null;
                cQuery qr = new cQuery();

                cmd = new SqlCommand(qr.qSelectIdPegawaiByRfid(RFID), conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Proses Generate Gagal");
                    return;
                }

                cmd = new SqlCommand(qr.qUpdateRfidPegByID(), conn);
                cmd.Parameters.AddWithValue("@rfid", RFID);
                cmd.Parameters.AddWithValue("@id_pegawai", idPegawai);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
                conn.Dispose();
                dt.Clear();
                dt.Dispose();
            }
        }
        private DataTable selectHistoryRfidTerakirPegawai()
        {
            DataTable dt = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dt = db.selectData(qr.qSelectLastHistoryRfidPegawai(), '3');//konek ke tabel history_rfid
            return dt;
        }
        private void tampilPeg(string ID_PEG)
        {
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();

            DataTable dt = db.selectData(qr.qSelectNamaRfidPegByIdPeg(ID_PEG), '4');//4 = konek ke 10.0.1.64 db payroll_web
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow rowMhs in dt.Rows)
                {
                    txt_nik.Text = rowMhs["nik"].ToString();
                    txt_nama.Text = rowMhs["nama"].ToString();
                    txtRfid.Text = rowMhs["rfid"].ToString();
                    lbIdPegawai.Text = rowMhs["id_pegawai"].ToString();
                }
            }
            dt.Clear();
            dt.Dispose();
        }
        private void generateRfidMhs()
        {
            string NIM = txt_nik.Text.Replace("'", "''");

            string prodi = string.Empty;

            DataTable dtProdi = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dtProdi = db.selectData(qr.qSelectKodeProdiByNim(NIM), '2');
            if (dtProdi.Rows.Count != 0)
            {
                string cekRfid = string.Empty;
                foreach (DataRow rowProdi in dtProdi.Rows)//ambil kode prodi sesuai nim
                {
                    cekRfid = rowProdi["RFID"].ToString();
                    prodi = rowProdi["prodi"].ToString();
                }

                //jika ternyata sudah ada rfidnya, proses stop
                if (cekRfid != string.Empty)
                {
                    clearTampilan();

                    tampilMhs(NIM);

                    //txt_cari_nama.Text = string.Empty;
                    //txt_cari_nik.Text = string.Empty;

                    return;
                }

                //cek dari tabel mahasiswa
                DataTable lastHeksa = selectRfidMhsTerakirByProdi(prodi); //ambil heksa terakir dari mahasiswa, sesuai prodinya
                string heksa = string.Empty;
                if (lastHeksa.Rows.Count != 0)
                {
                    foreach (DataRow rowHeksa in lastHeksa.Rows)
                    {
                        heksa = rowHeksa["heksa"].ToString();
                    }
                }

                //cek dari tabel history_rfid
                DataTable lastHeksaHis = selectFrHistoryRfidMhsTerakirbyProdi(prodi); //ambil heksa terakir dari history, sesuai prodinya
                string heksaHis = string.Empty;
                if (lastHeksaHis.Rows.Count != 0)
                {
                    foreach (DataRow rowHeksaHis in lastHeksaHis.Rows)
                    {
                        heksaHis = rowHeksaHis["heksa"].ToString();
                    }
                }

                string heksaUse = string.Empty;//heksa yang akan dipakai

                if (heksa != string.Empty && heksaHis != string.Empty) //jika di kedua tabel ditemukan heksa sebelumnya
                {
                    //bandingkan heksa dari tabel mhs dan history, nilainya paling tinggi yang dipakai
                    Int32 iheksa = Int32.Parse(heksa, System.Globalization.NumberStyles.HexNumber);//dari heksa terakir convert ke int
                    Int32 iheksaHis = Int32.Parse(heksaHis, System.Globalization.NumberStyles.HexNumber);//dari heksa terakir convert ke int

                    if (iheksa > iheksaHis)
                    {
                        heksaUse = heksa;
                    }
                    else if (iheksaHis > iheksa)
                    {
                        heksaUse = heksaHis;
                    }

                }
                else if (heksa != string.Empty && heksaHis == string.Empty) //jika hanya ditemukan dari tabel mahasiswa
                {
                    heksaUse = heksa;
                }
                else if (heksa == string.Empty && heksaHis != string.Empty) //jika hanya ditemukan dari tabel history_rfid
                {
                    heksaUse = heksaHis;
                }

                //=======================================================================
                if (heksaUse != string.Empty)//jika sudah ditemukan kode rfid terakir, lanjutkan sequence-nya
                {
                    UpdateRfidMhs(NIM, prodi, heksaUse);
                }
                else
                { //jika belum ditemukan kode rfid sebelumnya, generate dari awal

                    UpdateRfidMhs(NIM, prodi, "0000");
                }

                lastHeksa.Clear();
                lastHeksa.Dispose();
                lastHeksaHis.Clear();
                lastHeksaHis.Dispose();
            }

            clearTampilan();

            //txt_cari_nama.Text = string.Empty;
            //txt_cari_nik.Text = string.Empty;
            //DGList.Rows.Clear();
            //jmlRow.Text = string.Empty;

            tampilMhs(NIM);
        }
        private DataTable selectRfidMhsTerakirByProdi(string prodi)
        {
            DataTable dt = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dt = db.selectData(qr.qSelectLastRfidMhsByProdi(prodi), '2');
            return dt;
        }
        private DataTable selectFrHistoryRfidMhsTerakirbyProdi(string prodi)
        {
            DataTable dt = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dt = db.selectData(qr.qSelectLastHistoryRfidByProdi(prodi), '3');//konek ke tabel history_rfid
            return dt;
        }

        private void tampilMhs(string NIM)
        {
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();

            DataTable dt = db.selectData(qr.qSelectNamaRfidMhsByNim(NIM), '2');
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow rowMhs in dt.Rows)
                {
                    txt_nik.Text = rowMhs["STUDENTID"].ToString();
                    txt_nama.Text = rowMhs["FULLNAME"].ToString();
                    txtRfid.Text = rowMhs["RFID"].ToString();
                }
            }
            dt.Clear();
            dt.Dispose();
        }
        private void rbMahasiswa_CheckedChanged(object sender, EventArgs e)
        {
            clearTampilan();
        }
        private void clearTampilan()
        {
            //hasil
            txt_nama.Text = string.Empty;
            txt_nik.Text = string.Empty;
            txtRfid.Text = string.Empty;
            lbIdPegawai.Text = string.Empty;

            //form search
            txt_cari_nama.Text = string.Empty;
            txt_cari_nik.Text = string.Empty;

            clearGrid = true;
            DGList.Rows.Clear();
            jmlRow.Text = string.Empty;
        }
        private void UpdateRfidMhs(string NIM, string prodi, string lastHeksa)
        {

            Int32 sequence = Int32.Parse(lastHeksa, System.Globalization.NumberStyles.HexNumber);//dari heksa terakir convert ke int

            sequence++;
            string heksa = String.Format("{0:X4}", sequence); //heksa selanjutnya

            DataTable dt = null;
            cKoneksi koneksi = new cKoneksi();
            SqlConnection conn = new SqlConnection(koneksi.konekMsSql('2'));
            conn.Open();

            try
            {
                string RFID = "1" + prodi + "" + heksa + "";

                SqlCommand cmd = null;
                cQuery qr = new cQuery();

                cmd = new SqlCommand(qr.qSelectNimByRfid(RFID), conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Proses Generate Gagal");
                    return;
                }

                cmd = new SqlCommand(qr.qUpdateRfidMhsByNim(), conn);
                cmd.Parameters.AddWithValue("@RFID", RFID);
                cmd.Parameters.AddWithValue("@STUDENTID", NIM);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
                conn.Dispose();
                dt.Clear();
                dt.Dispose();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            DGList.Rows.Clear();
            clearGrid = false;
            jmlRow.Text = string.Empty;
            //validasi
            if (txt_cari_nama.Text.Trim() == string.Empty && txt_cari_nik.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Nama atau Nim/Nik harus diisi!", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchAmbilKtm();

            autoWithColom();
            jmlRow.Text = "Jumlah baris: " + DGList.RowCount;

            if (DGList.RowCount == 0)
            {
                //IdMhs = string.Empty;
                MessageBox.Show("Data tidak ditemukan", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SearchAmbilKtm()
        {
            cQuery qr = new cQuery();
            cDatabase db = new cDatabase();

            DataTable dtSearch = null;

            if (rbMahasiswa.Checked == true)
            {
                dtSearch = db.selectData(qr.qSearchMhsByNImNama(txt_cari_nik.Text, txt_cari_nama.Text), '2');
            }
            else
            {
                dtSearch = db.selectData(qr.qSearchPegByNikNama(txt_cari_nik.Text, txt_cari_nama.Text), '4');
            }

            cControl cnt = new cControl();

            foreach (DataRow rowSearch in dtSearch.Rows)
            {
                string[] row = null;

                if (rbMahasiswa.Checked == true)
                {
                    row = new string[] { rowSearch["STUDENTID"].ToString(), rowSearch["STUDENTID"].ToString(), rowSearch["FULLNAME"].ToString(), rowSearch["RFID"].ToString() };
                }
                else
                {
                    row = new string[] { rowSearch["id_pegawai"].ToString(), rowSearch["nik"].ToString(), rowSearch["nama"].ToString(), rowSearch["rfid"].ToString() };
                }

                DGList.Rows.Add(row);
            }

            dtSearch.Clear();
            dtSearch.Dispose();
        }
        private void autoWithColom()
        {
            ////NIM   
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
            int widthCol = DGList.Columns[3].Width;
            DGList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGList.Columns[3].Width = widthCol;
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

        private void DGList_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DGList.CurrentCell == null)
            {
                return;
            }

            if (clearGrid == true)
            {
                return;
            }

            int row = DGList.CurrentCell.RowIndex;
            string nimOrId = DGList.Rows[row].Cells[0].Value.ToString();
            //txtRfid.Text = DgListCari.Rows[row].Cells["RFID"].Value.ToString();
            //txt_nama.Text = DgListCari.Rows[row].Cells["FULLNAME"].Value.ToString();

            if (rbMahasiswa.Checked == true)
            {
                tampilMhs(nimOrId);
            }
            else
            {
                tampilPeg(nimOrId);
            }
        }

        private void txtRfid_TextChanged(object sender, EventArgs e)
        {
            tEpcData.Text = txtRfid.Text;
            if (tEpcData.Text.Length == 8)
            {
                tEpcData.Text = tEpcData.Text.Insert(tEpcData.Text.Length - 4, " ");
            }
        }
    }
}
