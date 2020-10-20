using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AmbilKtm
{
    class cSyncRun
    {
        private static bool run = false;

        private static bool close = false;

        public static bool isSync
        {
            get { return run; }
            set { run = value; }
        }

        public static bool closingThread
        {
            get { return close; }
            set { close = value; }
        }
    }

    class cVarGlobal
    {
        private static string ipv4 = string.Empty;
        public static string IP
        {
            get { return ipv4; }
            set { ipv4 = value; }
        }

        private static string op = string.Empty;
        public static string opLogin
        {
            get { return op; }
            set { op = value; }
        }

        private static bool admin = false;
        public static bool isAdmin
        {
            get { return admin; }
            set { admin = value; }
        }

        private static string aplication = string.Empty;
        public static string isAplication
        {
            get { return aplication; }
            set { aplication = value; }
        }

    }

    class cControl
    {
        //com open or close
        private static bool CR = false;

        public static bool connectRfid
        {
            get { return CR; }
            set { CR = value; }
        }
        //==========================

        private static string port = "COM1";
        public static string PortCom
        {
            get { return port; }
            set { port = value; }
        }

        public string getDateTimeNow()
        {
            string formatType = "yyyy-MM-dd HH:mm:ss";
            return DateTime.Now.ToString(formatType);
        }

        public string getLastIp()
        {
            string IpAddress = string.Empty;
            string qr = "SELECT IpAddress FROM IpHistory order by LastModified desc limit 1";

            cDatabase db = new cDatabase();
            DataTable dt = db.selectDataSqlite(qr);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    IpAddress = row["IpAddress"].ToString();
                }
            }

            dt.Clear();
            dt.Dispose();

            return IpAddress;
        }

        public string getLastPort()
        {
            string port = string.Empty;
            string qr = "SELECT port FROM IpHistory order by LastModified desc limit 1";

            cDatabase db = new cDatabase();
            DataTable dt = db.selectDataSqlite(qr);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    port = row["port"].ToString();
                }
            }

            dt.Clear();
            dt.Dispose();

            return port;
        }

        public string getipLokalPc() //fungsi mendapatkan IPV4 di PC lokal
        {
            //string strHostName = "";
            //strHostName = System.Net.Dns.GetHostName();
            //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            //IPAddress[] addr = ipEntry.AddressList;
            //return addr[addr.Length - 2].ToString();

            string ipv4 = string.Empty;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipv4 = ip.Address.ToString();
                        }
                    }
                }
            }

            return ipv4;

        }
    }
}
