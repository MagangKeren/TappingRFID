using ReaderB;
using System;
using System.Collections;
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
    public partial class Device3 : Form
    {
        private bool fAppClosed; //在测试模式下响应关闭应用程序
        private byte fComAdr = 0xff; //当前操作的ComAdr
        private int ferrorcode;
        private byte fBaud;
        private double fdminfre;
        private double fdmaxfre;
        private byte Maskadr;
        private byte MaskLen;
        private byte MaskFlag;
        private int fCmdRet = 30; //所有执行指令的返回值
        private int fOpenComIndex; //打开的串口索引号
        private bool fIsInventoryScan;
        private bool fisinventoryscan_6B;
        private byte[] fOperEPC = new byte[36];
        private byte[] fPassWord = new byte[4];
        private byte[] fOperID_6B = new byte[8];
        private int CardNum1 = 0;
        ArrayList list = new ArrayList();
        private bool fTimer_6B_ReadWrite;
        private string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）
        private int frmcomportindex;
        private bool ComOpen = false;
        private bool clearGrid = false;
        private string lama;//variable utk menampung kodeRfid hasil scan sebelumnya
        public string dataBaca = "";

        public Device3()
        {
            InitializeComponent();
            Edit_WordPtr.Text = "02";
        }

        private void InitComList()
        {
            int i = 0;
            ComboBox_COM.Items.Clear();
            ComboBox_COM.Items.Add(" AUTO");
            for (i = 1; i < 13; i++)
                ComboBox_COM.Items.Add(" COM" + Convert.ToString(i));
            ComboBox_COM.SelectedIndex = 0;
            RefreshStatus();
        }

        private void ClearLastInfo()
        {
            ComboBox_AlreadyOpenCOM.Refresh();
            RefreshStatus();

            //  PageControl1.TabIndex = 0;
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
            else
            {
                rbMahasiswa.Checked = true;
            }
        }

        private void OpenPort_Click(object sender, EventArgs e)
        {
            int port = 0;
            int openresult, i;
            openresult = 30;
            string temp;
            Cursor = Cursors.WaitCursor;
            if (Edit_CmdComAddr.Text == "")
                Edit_CmdComAddr.Text = "FF";
            fComAdr = Convert.ToByte(Edit_CmdComAddr.Text, 16); // $FF;
            try
            {
                if (ComboBox_COM.SelectedIndex == 0)//Auto
                {
                    fBaud = Convert.ToByte(ComboBox_baud2.SelectedIndex);
                    if (fBaud > 2)
                    {
                        fBaud = Convert.ToByte(fBaud + 2);
                    }
                    openresult = StaticClassReaderB.AutoOpenComPort(ref port, ref fComAdr, fBaud, ref frmcomportindex);
                    fOpenComIndex = frmcomportindex;
                    if (openresult == 0)
                    {
                        ComOpen = true;
                        // Button3_Click(sender, e); //自动执行读取写卡器信息
                        if (fBaud > 3)
                        {

                        }
                        else
                        {

                        }
                        //Button3_Click(sender, e); //自动执行读取写卡器信息
                        if ((fCmdRet == 0x35) | (fCmdRet == 0x30))
                        {
                            MessageBox.Show("Serial Communication Error or Occupied", "Information");
                            StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                            ComOpen = false;
                        }
                    }
                }
                else
                {
                    temp = ComboBox_COM.SelectedItem.ToString();
                    temp = temp.Trim();
                    port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                    for (i = 6; i >= 0; i--)
                    {
                        fBaud = Convert.ToByte(i);
                        if (fBaud == 3)
                            continue;
                        openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                        fOpenComIndex = frmcomportindex;
                        if (openresult == 0x35)
                        {
                            MessageBox.Show("COM Opened", "Information");
                            return;
                        }
                        if (openresult == 0)
                        {
                            ComOpen = true;
                            //Button3_Click(sender, e); //自动执行读取写卡器信息
                            if (fBaud > 3)
                            {

                            }
                            else
                            {

                            }
                            if ((fCmdRet == 0x35) || (fCmdRet == 0x30))
                            {
                                ComOpen = false;
                                MessageBox.Show("Serial Communication Error or Occupied", "Information");
                                StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                                return;
                            }
                            RefreshStatus();
                            break;
                        }

                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if ((fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30))
            {
                ComboBox_AlreadyOpenCOM.Items.Add("COM" + Convert.ToString(fOpenComIndex));
                ComboBox_AlreadyOpenCOM.SelectedIndex = ComboBox_AlreadyOpenCOM.SelectedIndex + 1;

                button2.Enabled = true;

                //SpeedButton_Query_6B.Enabled = true;

                ComOpen = true;
            }
            if ((fOpenComIndex == -1) && (openresult == 0x30))
                MessageBox.Show("Serial Communication Error", "Information");

            if ((ComboBox_AlreadyOpenCOM.Items.Count != 0) & (fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30) & (fCmdRet == 0))
            {
                temp = ComboBox_AlreadyOpenCOM.SelectedItem.ToString();
                frmcomportindex = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
            }
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            if (!(ComboBox_AlreadyOpenCOM.Items.Count != 0))
                StatusBar1.Panels[1].Text = "COM Closed";
            else
                StatusBar1.Panels[1].Text = " COM" + Convert.ToString(frmcomportindex);
            StatusBar1.Panels[0].Text = "";
            StatusBar1.Panels[2].Text = "";
        }

        private void InitReaderList()
        {
            int i = 0;
            // ComboBox_PowerDbm.SelectedIndex = 0;


            i = 40;
            while (i <= 300)
            {
                ComboBox_IntervalTime.Items.Add(Convert.ToString(i) + "ms");
                i = i + 10;
            }
            ComboBox_IntervalTime.SelectedIndex = 1;
            for (i = 0; i < 7; i++)

                i = 40;
            //while (i <= 300)
            //{
            //ComboBox_IntervalTime_6B.Items.Add(Convert.ToString(i) + "ms");
            //i = i + 10;
            //}
            //ComboBox_IntervalTime_6B.SelectedIndex = 1;


        }

        private void ComboBox_COM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox_baud2.Items.Clear();
            if (ComboBox_COM.SelectedIndex == 0)
            {
                ComboBox_baud2.Items.Add("9600bps");
                ComboBox_baud2.Items.Add("19200bps");
                ComboBox_baud2.Items.Add("38400bps");
                ComboBox_baud2.Items.Add("57600bps");
                ComboBox_baud2.Items.Add("115200bps");
                ComboBox_baud2.SelectedIndex = 3;
            }
            else
            {
                ComboBox_baud2.Items.Add("Auto");
                ComboBox_baud2.SelectedIndex = 0;
            }
        }

        private void Device3_Load(object sender, EventArgs e)
        {
            cekHakAkases();


            fOpenComIndex = -1;
            fComAdr = 0;
            ferrorcode = -1;
            fBaud = 5;
            InitComList();
            InitReaderList();


            //Byone_6B.Checked = true;
            //Different_6B.Checked = true;


            C_EPC.Checked = true;

            fAppClosed = false;
            fIsInventoryScan = false;
            fisinventoryscan_6B = false;
            fTimer_6B_ReadWrite = false;

            Timer_Test_.Enabled = false;
            Timer_G2_Read.Enabled = false;
            Timer_G2_Alarm.Enabled = false;
            timer1.Enabled = false;


            button2.Enabled = false;

            SpeedButton_Read_G2.Enabled = false;
            Button_DataWrite.Enabled = false;
            BlockWrite.Enabled = false;
            Button_BlockErase.Enabled = false;

            //SpeedButton_Query_6B.Enabled = false;
            //SpeedButton_Read_6B.Enabled = false;
            //SpeedButton_Write_6B.Enabled = false;
            //Button14.Enabled = false;
            //Button15.Enabled = false;


            //Same_6B.Enabled = false;
            //Different_6B.Enabled = false;
            //Less_6B.Enabled = false;
            //Greater_6B.Enabled = false;
            ComboBox_baud2.SelectedIndex = 3;
        }

        private void ClosePort_Click(object sender, EventArgs e)
        {
            int port;
            //string SelectCom ;
            string temp;
            ClearLastInfo();
            try
            {
                if (ComboBox_AlreadyOpenCOM.SelectedIndex < 0)
                {
                    MessageBox.Show("Please Choose COM Port to close", "Information");
                }
                else
                {
                    temp = ComboBox_AlreadyOpenCOM.SelectedItem.ToString();
                    port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                    fCmdRet = StaticClassReaderB.CloseSpecComPort(port);
                    if (fCmdRet == 0)
                    {
                        ComboBox_AlreadyOpenCOM.Items.RemoveAt(0);
                        if (ComboBox_AlreadyOpenCOM.Items.Count != 0)
                        {
                            temp = ComboBox_AlreadyOpenCOM.SelectedItem.ToString();
                            port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                            StaticClassReaderB.CloseSpecComPort(port);
                            fComAdr = 0xFF;
                            StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                            fOpenComIndex = frmcomportindex;
                            RefreshStatus();
                            //Button3_Click(sender, e); //自动执行读取写卡器信息
                        }
                    }
                    else
                        MessageBox.Show("Serial Communication Error", "Information");
                }
            }
            finally
            {

            }
            if (ComboBox_AlreadyOpenCOM.Items.Count != 0)
                ComboBox_AlreadyOpenCOM.SelectedIndex = 0;
            else
            {
                fOpenComIndex = -1;
                ComboBox_AlreadyOpenCOM.Items.Clear();
                ComboBox_AlreadyOpenCOM.Refresh();
                RefreshStatus();

                button2.Enabled = false;

                SpeedButton_Read_G2.Enabled = false;
                Button_DataWrite.Enabled = false;
                BlockWrite.Enabled = false;
                Button_BlockErase.Enabled = false;

                //SpeedButton_Query_6B.Enabled = false;
                //SpeedButton_Read_6B.Enabled = false;
                //SpeedButton_Write_6B.Enabled = false;
                //Button14.Enabled = false;
                //Button15.Enabled = false;




                //Same_6B.Enabled = false;
                //Different_6B.Enabled = false;
                //Less_6B.Enabled = false;
                //Greater_6B.Enabled = false;




                SpeedButton_Read_G2.Enabled = false;
                Button_DataWrite.Enabled = false;
                BlockWrite.Enabled = false;
                Button_BlockErase.Enabled = false;

                ListView1_EPC.Items.Clear();

                ComboBox_EPC2.Items.Clear();

                button2.Text = "Stop";
                //checkBox1.Enabled = false;

                //SpeedButton_Read_6B.Enabled = false;
                //SpeedButton_Write_6B.Enabled = false;
                //Button14.Enabled = false;
                //Button15.Enabled = false;

                //ListView_ID_6B.Items.Clear();
                ComOpen = false;
                //timer1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Edit_WordPtr.Text == "")
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Edit_AccessCode2.Text == "")
            {
                MessageBox.Show("(PassWord) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(Edit_WordPtr.Text, 16) + Convert.ToInt32(textBox1.Text) > 120)
                return;
            Timer_G2_Read.Enabled = !Timer_G2_Read.Enabled;
            if (Timer_G2_Read.Enabled)
            {
                //button2.Enabled = false;
                Button_DataWrite.Enabled = false;
                BlockWrite.Enabled = false;
                Button_BlockErase.Enabled = false;

                SpeedButton_Read_G2.Text = "Stop";
            }
            else
            {
                if (ListView1_EPC.Items.Count != 0)
                {

                    button2.Enabled = true;

                    Button_DataWrite.Enabled = true;
                    BlockWrite.Enabled = true;
                    Button_BlockErase.Enabled = true;
                }
                if (ListView1_EPC.Items.Count == 0)
                {

                    button2.Enabled = true;
                    Button_DataWrite.Enabled = false;
                    BlockWrite.Enabled = false;
                    Button_BlockErase.Enabled = false;


                }
                SpeedButton_Read_G2.Text = "Read";
            }

            if (CheckBox_TID.Checked)
            {
                if ((textBox4.Text.Length) != 2 || ((textBox5.Text.Length) != 2))
                {
                    StatusBar1.Panels[0].Text = "TID Parameter Error！";
                    return;
                }
            }
            Timer_Test_.Enabled = !Timer_Test_.Enabled;
            if (!Timer_Test_.Enabled)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                CheckBox_TID.Enabled = true;
                if (ListView1_EPC.Items.Count != 0)
                {

                    SpeedButton_Read_G2.Enabled = true;

                    Button_DataWrite.Enabled = true;
                    BlockWrite.Enabled = true;
                    Button_BlockErase.Enabled = true;
                    checkBox1.Enabled = true;
                }
                if (ListView1_EPC.Items.Count == 0)
                {

                    SpeedButton_Read_G2.Enabled = false;
                    Button_DataWrite.Enabled = false;
                    BlockWrite.Enabled = false;
                    Button_BlockErase.Enabled = false;

                    checkBox1.Enabled = false;

                }
                AddCmdLog("Inventory", "Exit Query", 0);
                button2.Text = "Query Tag";
            }
            else
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                CheckBox_TID.Enabled = false;

                SpeedButton_Read_G2.Enabled = false;
                Button_DataWrite.Enabled = false;
                BlockWrite.Enabled = false;
                Button_BlockErase.Enabled = false;

                ListView1_EPC.Items.Clear();

                ComboBox_EPC2.Items.Clear();

                button2.Text = "Stop";
                checkBox1.Enabled = false;
            }
        }

        private void Inventory()
        {
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            fIsInventoryScan = true;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            if (CheckBox_TID.Checked)
            {
                AdrTID = Convert.ToByte(textBox4.Text, 16);
                LenTID = Convert.ToByte(textBox5.Text, 16);
                TIDFlag = 1;
            }
            else
            {
                AdrTID = 0;
                LenTID = 0;
                TIDFlag = 0;
            }
            ListViewItem aListItem = new ListViewItem();
            fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                fInventory_EPC_List = temps;            //存贮记录
                m = 0;

                /*   while (ListView1_EPC.Items.Count < CardNum)
                  {
                      aListItem = ListView1_EPC.Items.Add((ListView1_EPC.Items.Count + 1).ToString());
                      aListItem.SubItems.Add("");
                      aListItem.SubItems.Add("");
                      aListItem.SubItems.Add("");
                 * 
                  }*/
                if (CardNum == 0)
                {
                    fIsInventoryScan = false;
                    return;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    if (sEPC.Length != EPClen * 2)
                        return;
                    isonlistview = false;
                    for (i = 0; i < ListView1_EPC.Items.Count; i++)     //判断是否在Listview列表内
                    {
                        if (sEPC == ListView1_EPC.Items[i].SubItems[1].Text)
                        {
                            aListItem = ListView1_EPC.Items[i];
                            ChangeSubItem(aListItem, 1, sEPC);
                            isonlistview = true;
                        }
                    }
                    //dataBaca = sEPC;

                    if (!isonlistview)
                    {
                        aListItem = ListView1_EPC.Items.Add((ListView1_EPC.Items.Count + 1).ToString());
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        s = sEPC;
                        ChangeSubItem(aListItem, 1, s);
                        s = (sEPC.Length / 2).ToString().PadLeft(2, '0');
                        ChangeSubItem(aListItem, 2, s);
                        if (!CheckBox_TID.Checked)
                        {
                            if (ComboBox_EPC2.Items.IndexOf(sEPC) == -1)
                            {
                                //ComboBox_EPC1.Items.Add(sEPC);
                                ComboBox_EPC2.Items.Add(sEPC);
                                //ComboBox_EPC3.Items.Add(sEPC);
                                //ComboBox_EPC4.Items.Add(sEPC);
                                //ComboBox_EPC5.Items.Add(sEPC);
                                //ComboBox_EPC6.Items.Add(sEPC);
                            }
                        }

                    }
                }
                
            }
            if (!CheckBox_TID.Checked)
            {
                if ((ComboBox_EPC2.Items.Count != 0))
                {
                    //ComboBox_EPC1.SelectedIndex = 0;
                    ComboBox_EPC2.SelectedIndex = 0;
                    //ComboBox_EPC3.SelectedIndex = 0;
                    //ComboBox_EPC4.SelectedIndex = 0;
                    //ComboBox_EPC5.SelectedIndex = 0;
                    //ComboBox_EPC6.SelectedIndex = 0;
                }
            }
            fIsInventoryScan = false;
            if (fAppClosed)
                Close();
        }

        private void AddCmdLog(string CMD, string cmdStr, int cmdRet)
        {
            try
            {
                StatusBar1.Panels[0].Text = "";
                StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() + " " +
                                            cmdStr + ": " +
                                            GetReturnCodeDesc(cmdRet);
            }
            finally
            {
                ;
            }
        }

        public void ChangeSubItem(ListViewItem ListItem, int subItemIndex, string ItemText)
        {
            if (subItemIndex == 1)
            {
                if (ItemText == "")
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    if (ListItem.SubItems[subItemIndex + 2].Text == "")
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                    }
                    else
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    }
                }
                else
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    ListItem.SubItems[subItemIndex + 2].Text = "1";
                }
                else
                {
                    ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    if ((Convert.ToUInt32(ListItem.SubItems[subItemIndex + 2].Text) > 9999))
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                }

            }
            if (subItemIndex == 2)
            {
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                }
            }

        }

        private void CekKodeRFID(string kodeRfid)
        {
            if (lama != kodeRfid)
            {

                //item = listView1.Items.Add((k + 1).ToString(), k);
                //item.SubItems.Add(str);
                //item.SubItems.Add(TagBuffer[i, 0].ToString("X2"));

                //k++; //no urut di listview

                lama = kodeRfid;

                //cocokkan kode rfid yang ada dengan kode yang ada di listview
                //===============================================================
                //Int32 jmlRow = ListView1_EPC.Items.Count;
                //if (jmlRow > 0)
                //{
                //    string kodeRfid = string.Empty;

                //    ListView1_EPC.Items[jmlRow - 1].Selected = true; //select row terakir
                //    kodeRfid = ListView1_EPC.Items[jmlRow - 1].SubItems[1].Text; //ambil datanya

                //    //bandingkan
                //    if (txtRfid.Text.Trim() != "")
                //    {
                //        if (txtRfid.Text == kodeRfid)
                //        { //jika sama
                //            lblMatch.Text = "Match!";
                //            //lblMatch.BackColor = Color.Blue;
                //            lblMatch.ForeColor = Color.Blue;
                //        }
                //        else { lblMatch.Text = "Not Match!"; lblMatch.ForeColor = Color.Red; }
                //    }
                //    else { lblMatch.Text = "Not Match!"; lblMatch.ForeColor = Color.Red; }
                //}
                //===============================================================

            }
        }


        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }


        private void Timer_Test__Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            Inventory();

            //cocokkan kode rfid yang ada dengan kode yang ada di listview
            //===============================================================
            Int32 jmlRow = ListView1_EPC.Items.Count;
            if (jmlRow > 0)
            {
                string kodeRfid = string.Empty;

                ListView1_EPC.Items[jmlRow - 1].Selected = true; //select row terakir
                kodeRfid = ListView1_EPC.Items[jmlRow - 1].SubItems[1].Text; //ambil datanya

                //bandingkan
                if (txtRfid.Text.Trim() != "")
                {
                    if (txtRfid.Text == kodeRfid)
                    { //jika sama
                        lblMatch.Text = "Match!";
                        //lblMatch.BackColor = Color.Blue;
                        lblMatch.ForeColor = Color.Blue;
                    }
                    else { lblMatch.Text = "Not Match!"; lblMatch.ForeColor = Color.Red; }
                }
                else { lblMatch.Text = "Not Match!"; lblMatch.ForeColor = Color.Red; }
            }
            //===============================================================
        }

        private string GetErrorCodeDesc(int cmdRet)
        {
            switch (cmdRet)
            {
                case 0x00:
                    return "Other error";
                case 0x03:
                    return "Memory out or pc not support";
                case 0x04:
                    return "Memory Locked and unwritable";
                case 0x0b:
                    return "No Power,memory write operation cannot be executed";
                case 0x0f:
                    return "Not Special Error,tag not support special errorcode";
                default:
                    return "";
            }
        }

        private string GetReturnCodeDesc(int cmdRet)
        {
            switch (cmdRet)
            {
                case 0x00:
                    return "Operation Successed";
                case 0x01:
                    return "Return before Inventory finished";
                case 0x02:
                    return "the Inventory-scan-time overflow";
                case 0x03:
                    return "More Data";
                case 0x04:
                    return "Reader module MCU is Full";
                case 0x05:
                    return "Access Password Error";
                case 0x09:
                    return "Destroy Password Error";
                case 0x0a:
                    return "Destroy Password Error Cannot be Zero";
                case 0x0b:
                    return "Tag Not Support the command";
                case 0x0c:
                    return "Use the commmand,Access Password Cannot be Zero";
                case 0x0d:
                    return "Tag is protected,cannot set it again";
                case 0x0e:
                    return "Tag is unprotected,no need to reset it";
                case 0x10:
                    return "There is some locked bytes,write fail";
                case 0x11:
                    return "can not lock it";
                case 0x12:
                    return "is locked,cannot lock it again";
                case 0x13:
                    return "Parameter Save Fail,Can Use Before Power";
                case 0x14:
                    return "Cannot adjust";
                case 0x15:
                    return "Return before Inventory finished";
                case 0x16:
                    return "Inventory-Scan-Time overflow";
                case 0x17:
                    return "More Data";
                case 0x18:
                    return "Reader module MCU is full";
                case 0x19:
                    return "Not Support Command Or AccessPassword Cannot be Zero";
                case 0xFA:
                    return "Get Tag,Poor Communication,Inoperable";
                case 0xFB:
                    return "No Tag Operable";
                case 0xFC:
                    return "Tag Return ErrorCode";
                case 0xFD:
                    return "Command length wrong";
                case 0xFE:
                    return "Illegal command";
                case 0xFF:
                    return "Parameter Error";
                case 0x30:
                    return "Communication error";
                case 0x31:
                    return "CRC checksummat error";
                case 0x32:
                    return "Return data length error";
                case 0x33:
                    return "Communication busy";
                case 0x34:
                    return "Busy,command is being executed";
                case 0x35:
                    return "ComPort Opened";
                case 0x36:
                    return "ComPort Closed";
                case 0x37:
                    return "Invalid Handle";
                case 0x38:
                    return "Invalid Port";
                case 0xEE:
                    return "Return command error";
                default:
                    return "";
            }
        }


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCek_Click(object sender, EventArgs e)
        {
            //if (cControl.connectRfid == false)
            //{
            //    MessageBox.Show("Cek Koneksi Scanner!", "BSI UMY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (btnCek.Text == "Cek")
            //{
            //    ListView1_EPC.Items.Clear();
            //    lblMatch.Text = "";
            //}

            //listBox1.Items.Clear();
            //listBox1.BackColor = Color.White;

            button2_Click(sender, e);//click scan

            //scanRfid();
        }

        private void btnTulis_Click(object sender, EventArgs e)
        {
            Button_DataWrite_Click(sender, e);
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

        private void generateRfidPegawai() //harusnya bukan nik tapi id_pegawai CEK LAGI DARI PROSES SEARCH!!!!!!!!!!!!!!!!!!!!
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

        private DataTable selectRfidPegTerakir()
        {
            DataTable dt = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dt = db.selectData(qr.qSelectLastRfidPegawai(), '4'); //4 = konek ke payroll_web
            return dt;
        }

        private DataTable selectHistoryRfidTerakirPegawai()
        {
            DataTable dt = null;
            cDatabase db = new cDatabase();
            cQuery qr = new cQuery();
            dt = db.selectData(qr.qSelectLastHistoryRfidPegawai(), '3');//konek ke tabel history_rfid
            return dt;
        }





        private void txtRfid_TextChanged(object sender, EventArgs e)
        {
            if (txtRfid.Text == string.Empty)
            {
                btnGenerateRfid.Enabled = true;
            }
            else
            {
                btnGenerateRfid.Enabled = false;
            }
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

        private void btnGenerateRfid_Click(object sender, EventArgs e)
        {
            //validasi
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

        private void SpeedButton_Read_G2_Click(object sender, EventArgs e)
        {
            if (Edit_WordPtr.Text == "")
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Edit_AccessCode2.Text == "")
            {
                MessageBox.Show("(PassWord) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(Edit_WordPtr.Text, 16) + Convert.ToInt32(textBox1.Text) > 120)
                return;
            Timer_G2_Read.Enabled = !Timer_G2_Read.Enabled;
            if (Timer_G2_Read.Enabled)
            {
                button2.Enabled = false;
                Button_DataWrite.Enabled = false;
                BlockWrite.Enabled = false;
                Button_BlockErase.Enabled = false;

                SpeedButton_Read_G2.Text = "Stop";
            }
            else
            {
                if (ListView1_EPC.Items.Count != 0)
                {

                    button2.Enabled = true;

                    Button_DataWrite.Enabled = true;
                    BlockWrite.Enabled = true;
                    Button_BlockErase.Enabled = true;
                }
                if (ListView1_EPC.Items.Count == 0)
                {

                    button2.Enabled = true;
                    Button_DataWrite.Enabled = false;
                    BlockWrite.Enabled = false;
                    Button_BlockErase.Enabled = false;


                }
                SpeedButton_Read_G2.Text = "Read";
            }
        }

        private void Button_DataWrite_Click(object sender, EventArgs e)
        {
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte WNum = 0;
            byte EPClength = 0;
            byte Writedatalen = 0;
            int WrittenDataNum = 0;
            byte WriteEPClen;
            string s2, str;
            byte[] CardData = new byte[320];
            byte[] writedata = new byte[230];
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (ComboBox_EPC2.Items.Count == 0)
                return;
            if (ComboBox_EPC2.SelectedItem == null)
                return;
            str = ComboBox_EPC2.SelectedItem.ToString();
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (Edit_WordPtr.Text == "")
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(Edit_WordPtr.Text) + Convert.ToInt32(textBox1.Text) > 120)
                return;
            if (Edit_AccessCode2.Text == "")
            {
                return;
            }
            WordPtr = Convert.ToByte(Edit_WordPtr.Text, 16);
            Num = Convert.ToByte(textBox1.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode2.Text);
            if (Edit_WriteData.Text == "")
                return;
            s2 = txtRfid.Text;
            if (s2.Length % 4 != 0)
            {
                MessageBox.Show("The Number must be 4 times.", "Write");
                return;
            }
            WriteEPClen = Convert.ToByte(txtRfid.Text.Length / 2);
            WNum = Convert.ToByte(s2.Length / 4);
            byte[] Writedata = new byte[WNum * 2];
            Writedata = HexStringToByteArray(s2);
            Writedatalen = Convert.ToByte(WNum * 2);
            if ((checkBox_pc.Checked) && (C_EPC.Checked))
            {
                WordPtr = 1;
                Writedatalen = Convert.ToByte(Edit_WriteData.Text.Length / 2 + 2);
                Writedata = HexStringToByteArray(textBox_pc.Text + Edit_WriteData.Text);
            }
            fCmdRet = StaticClassReaderB.WriteCard_G2(ref fComAdr, EPC, Mem, WordPtr, Writedatalen, Writedata, fPassWord, Maskadr, MaskLen, MaskFlag, WrittenDataNum, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("WriteEPC_G2", "Write EPC", fCmdRet);
            if (fCmdRet == 0)
            {
                StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() + "'Write'Command Response=0x00" +
                     "(completely write Data successfully)";
            }

        }

        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        private void AddCmdLog(string CMD, string cmdStr, int cmdRet, int errocode)
        {
            try
            {
                StatusBar1.Panels[0].Text = "";
                StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() + " " +
                                            cmdStr + ": " +
                                            GetReturnCodeDesc(cmdRet) + " " + "0x" + Convert.ToString(errocode, 16).PadLeft(2, '0');
            }
            finally
            {
                ;
            }
        }

        private void Inventory_6B()
        {
            //int CardNum = 0;
            //byte[] ID_6B = new byte[2000];
            //byte[] ID2_6B = new byte[5000];
            //bool isonlistview;
            //string temps;
            //string s, ss, sID;
            //ListViewItem aListItem = new ListViewItem();
            //int i, j;
            //byte Condition = 0;
            //byte StartAddress;
            //byte mask = 0;
            //byte[] ConditionContent = new byte[300];
            //byte Contentlen;
            //if (Byone_6B.Checked)
            //{
            //    fCmdRet = StaticClassReaderB.Inventory_6B(ref fComAdr, ID_6B, frmcomportindex);
            //    if (fCmdRet == 0)
            //    {
            //        byte[] daw = new byte[8];
            //        Array.Copy(ID_6B, daw, 8);
            //        temps = ByteArrayToHexString(daw);
            //        if (!list.Contains(temps))
            //        {
            //            CardNum1 = CardNum1 + 1;
            //            list.Add(temps);
            //        }
            //        while (ListView_ID_6B.Items.Count < CardNum1)
            //        {
            //            aListItem = ListView_ID_6B.Items.Add((ListView_ID_6B.Items.Count + 1).ToString());
            //            aListItem.SubItems.Add("");
            //            aListItem.SubItems.Add("");
            //            aListItem.SubItems.Add("");
            //        }
            //        isonlistview = false;
            //        for (i = 0; i < CardNum1; i++)     //判断是否在Listview列表内
            //        {
            //            if (temps == ListView_ID_6B.Items[i].SubItems[1].Text)
            //            {
            //                aListItem = ListView_ID_6B.Items[i];
            //                ChangeSubItem1(aListItem, 1, temps);
            //                isonlistview = true;
            //            }
            //        }
            //        if (!isonlistview)
            //        {
            //            // CardNum1 = Convert.ToByte(ListView_ID_6B.Items.Count+1);
            //            aListItem = ListView_ID_6B.Items[CardNum1 - 1];
            //            s = temps;
            //            ChangeSubItem1(aListItem, 1, s);


            //        }
            //    }

            //    if (ComboBox_ID1_6B.Items.Count != 0)
            //        ComboBox_ID1_6B.SelectedIndex = 0;
            //}
            //if (Bycondition_6B.Checked)
            //{
            //    if (Same_6B.Checked)
            //        Condition = 0;
            //    else if (Different_6B.Checked)
            //        Condition = 1;
            //    else if (Greater_6B.Checked)
            //        Condition = 2;
            //    else if (Less_6B.Checked)
            //        Condition = 3;
            //    if (Edit_ConditionContent_6B.Text == "")
            //        return;
            //    ss = Edit_ConditionContent_6B.Text;
            //    Contentlen = Convert.ToByte((Edit_ConditionContent_6B.Text).Length);
            //    for (i = 0; i < 16 - Contentlen; i++)
            //        ss = ss + "0";
            //    int Nlen = (ss.Length) / 2;
            //    byte[] daw = new byte[Nlen];
            //    daw = HexStringToByteArray(ss);
            //    switch (Contentlen / 2)
            //    {
            //        case 1:
            //            mask = 0x80;
            //            break;
            //        case 2:
            //            mask = 0xC0;
            //            break;
            //        case 3:
            //            mask = 0xE0;
            //            break;
            //        case 4:
            //            mask = 0XF0;
            //            break;
            //        case 5:
            //            mask = 0XF8;
            //            break;
            //        case 6:
            //            mask = 0XFC;
            //            break;
            //        case 7:
            //            mask = 0XFE;
            //            break;
            //        case 8:
            //            mask = 0XFF;
            //            break;
            //    }
            //    if (Edit_Query_StartAddress_6B.Text == "")
            //        return;
            //    StartAddress = Convert.ToByte(Edit_Query_StartAddress_6B.Text);
            //    fCmdRet = StaticClassReaderB.inventory2_6B(ref fComAdr, Condition, StartAddress, mask, daw, ID2_6B, ref CardNum, frmcomportindex);
            //    if ((fCmdRet == 0x15) | (fCmdRet == 0x16) | (fCmdRet == 0x17) | (fCmdRet == 0x18) | (fCmdRet == 0xFB))
            //    {
            //        byte[] daw1 = new byte[CardNum * 8];
            //        Array.Copy(ID2_6B, daw1, CardNum * 8);
            //        temps = ByteArrayToHexString(daw1);
            //        for (i = 0; i < CardNum; i++)
            //        {
            //            sID = temps.Substring(16 * i, 16);
            //            if ((sID.Length) != 16)
            //                return;
            //            if (CardNum == 0)
            //                return;
            //            while (ListView_ID_6B.Items.Count < CardNum)
            //            {
            //                aListItem = ListView_ID_6B.Items.Add((ListView_ID_6B.Items.Count + 1).ToString());
            //                aListItem.SubItems.Add("");
            //                aListItem.SubItems.Add("");
            //                aListItem.SubItems.Add("");
            //            }
            //            isonlistview = false;
            //            for (j = 0; j < ListView_ID_6B.Items.Count; j++)     //判断是否在Listview列表内
            //            {
            //                if (sID == ListView_ID_6B.Items[j].SubItems[1].Text)
            //                {
            //                    aListItem = ListView_ID_6B.Items[j];
            //                    ChangeSubItem1(aListItem, 1, sID);
            //                    isonlistview = true;
            //                }
            //            }
            //            if (!isonlistview)
            //            {
            //                // CardNum1 = Convert.ToByte(ListView_ID_6B.Items.Count+1);
            //                aListItem = ListView_ID_6B.Items[i];
            //                s = sID;
            //                ChangeSubItem1(aListItem, 1, s);

            //            }
            //        }
            //        if (ComboBox_ID1_6B.Items.Count != 0)
            //            ComboBox_ID1_6B.SelectedIndex = 0;
            //    }
            //}
            //if (Timer_Test_6B.Enabled)
            //{
            //    if (Bycondition_6B.Checked)
            //    {
            //        if (fCmdRet != 0)
            //            AddCmdLog("Inventory", "Query tag", fCmdRet);
            //    }
            //    else if (fCmdRet == 0XFB) //说明还未将所有卡读取完
            //    {

            //        StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0xFB" +
            //             "(No Tag Operable)";
            //    }
            //    else if (fCmdRet == 0)
            //        StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0x00" +
            //             "(Find a Tag)";
            //    else
            //        AddCmdLog("Inventory", "Query Tag", fCmdRet);
            //    if (fCmdRet == 0xEE)
            //        StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0xee" +
            //                      "(Response Command Error)";
            //}
            //if (fAppClosed)
            //    Close();
        }

        private void Timer_Test_6B_Tick_1(object sender, EventArgs e)
        {
            if (fisinventoryscan_6B)
                return;
            fisinventoryscan_6B = true;
            Inventory_6B();
            fisinventoryscan_6B = false;
        }

        private void Timer_G2_Read_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Timer_6B_Read_Tick_1(object sender, EventArgs e)
        {
            if (fTimer_6B_ReadWrite)
                return;
            fTimer_6B_ReadWrite = true;
            //Read_6B();
            fTimer_6B_ReadWrite = false;
        }

        private void Timer_G2_Alarm_Tick_1(object sender, EventArgs e)
        {
            if (fTimer_6B_ReadWrite)
                return;
            fTimer_6B_ReadWrite = true;
            //Read_6B();
            fTimer_6B_ReadWrite = false;
        }

        private void Timer_6B_Write_Tick(object sender, EventArgs e)
        {
            if (fTimer_6B_ReadWrite)
                return;
            fTimer_6B_ReadWrite = true;
            //Write_6B();
            fTimer_6B_ReadWrite = false;
        }

        //private void Read_6B()
        //{
        //    string temp, temps;
        //    byte[] CardData = new byte[320];
        //    byte[] ID_6B = new byte[8];
        //    byte Num, StartAddress;
        //    if (ComboBox_ID1_6B.Items.Count == 0)
        //        return;
        //    if (ComboBox_ID1_6B.SelectedItem == null)
        //        return;
        //    temp = ComboBox_ID1_6B.SelectedItem.ToString();
        //    if (temp == "")
        //        return;
        //    ID_6B = HexStringToByteArray(temp);
        //    if (Edit_StartAddress_6B.Text == "")
        //        return;
        //    StartAddress = Convert.ToByte(Edit_StartAddress_6B.Text, 16);
        //    if (Edit_Len_6B.Text == "")
        //        return;
        //    Num = Convert.ToByte(Edit_Len_6B.Text);
        //    fCmdRet = StaticClassReaderB.ReadCard_6B(ref fComAdr, ID_6B, StartAddress, Num, CardData, ref ferrorcode, frmcomportindex);
        //    if (fCmdRet == 0)
        //    {
        //        byte[] data = new byte[Num];
        //        Array.Copy(CardData, data, Num);
        //        temps = ByteArrayToHexString(data);
        //        listBox2.Items.Add(temps);
        //    }
        //    if (fAppClosed)
        //        Close();
        //}

        //private void Write_6B()
        //{
        //    string temp;
        //    byte[] CardData = new byte[320];
        //    byte[] ID_6B = new byte[8];
        //    byte StartAddress;
        //    byte Writedatalen;
        //    int writtenbyte = 0;
        //    if (ComboBox_ID1_6B.Items.Count == 0)
        //        return;
        //    if (ComboBox_ID1_6B.SelectedItem == null)
        //        return;
        //    temp = ComboBox_ID1_6B.SelectedItem.ToString();
        //    if (temp == "")
        //        return;
        //    ID_6B = HexStringToByteArray(temp);
        //    if (Edit_StartAddress_6B.Text == "")
        //        return;
        //    StartAddress = Convert.ToByte(Edit_StartAddress_6B.Text);
        //    if ((Edit_WriteData_6B.Text == "") | (Edit_WriteData_6B.Text.Length % 2) != 0)
        //        return;
        //    Writedatalen = Convert.ToByte(Edit_WriteData_6B.Text.Length / 2);
        //    byte[] Writedata = new byte[Writedatalen];
        //    Writedata = HexStringToByteArray(Edit_WriteData_6B.Text);
        //    fCmdRet = StaticClassReaderB.WriteCard_6B(ref fComAdr, ID_6B, StartAddress, Writedata, Writedatalen, ref writtenbyte, ref ferrorcode, frmcomportindex);
        //    AddCmdLog("WriteCard", "Write", fCmdRet);
        //    if (fAppClosed)
        //        Close();
        //}

        private void Timer_G2_Read_Tick_1(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            fIsInventoryScan = true;
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte EPClength = 0;
            string str;
            byte[] CardData = new byte[320];
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (textBox1.Text == "")
            {
                fIsInventoryScan = false;
                return;
            }
            if (ComboBox_EPC2.Items.Count == 0)
            {
                fIsInventoryScan = false;
                return;
            }
            if (ComboBox_EPC2.SelectedItem == null)
            {
                fIsInventoryScan = false;
                return;
            }
            str = ComboBox_EPC2.SelectedItem.ToString();
            if (str == "")
            {
                // fIsInventoryScan = false;
                //  return;
            }
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (Edit_AccessCode2.Text == "")
            {
                fIsInventoryScan = false;
                return;
            }
            if (Edit_WordPtr.Text == "")
            {
                fIsInventoryScan = false;
                return;
            }
            WordPtr = Convert.ToByte(Edit_WordPtr.Text, 16);
            Num = Convert.ToByte(textBox1.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                fIsInventoryScan = false;
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode2.Text);
            fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, EPC, Mem, WordPtr, Num, fPassWord, Maskadr, MaskLen, MaskFlag, CardData, EPClength, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
            {
                byte[] daw = new byte[Num * 2];
                Array.Copy(CardData, daw, Num * 2);
                listBox1.Items.Add(ByteArrayToHexString(daw));
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                AddCmdLog("ReadData", "Read", fCmdRet);
            }
            if (ferrorcode != -1)
            {
                StatusBar1.Panels[0].Text = DateTime.Now.ToLongTimeString() +
                 " 'Read' Response ErrorCode=0x" + Convert.ToString(ferrorcode, 2) +
                 "(" + GetErrorCodeDesc(ferrorcode) + ")";
                ferrorcode = -1;
            }
            fIsInventoryScan = false;
            if (fAppClosed)
                Close();
        }

    }
}
