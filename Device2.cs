using RfidApiLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            bReset.Enabled = true;

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
            if (!chkFilter.Checked)
                Reader1.ClearIdBuf();
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
                    timerScanEPC.Interval = (tEpcSpeed.Value + 1) * 20;
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

            bReset.Enabled = false;



           
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

            bReset.Enabled = false;

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
            if (!chkFilter.Checked)
                Reader1.ClearIdBuf();
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
            if (!chkFilter.Checked)
                Reader1.ClearIdBuf();
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
    }
}
