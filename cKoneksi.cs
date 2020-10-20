using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbilKtm
{
    class cKoneksi
    {
        //server = '0' => konek ke local pakai auth windows
        //server = '1' => konek ke db parkir
        //server = '2' => konek ke db simak 
        public string konekMsSql(char server)
        {
            string conn = string.Empty;

            if (server == '0')
            {// konek ke local pc kantor
                //conn = "Data Source= FIKRI-PC\\SQLEXPRESS; Initial Catalog= parkir; Integrated Security=SSPI; ";
            }
            else if (server == '1')
            { // konek ke db parkir
                conn = "Data Source= 10.0.1.65 ; Initial Catalog= parkir;User id=karturfid; Password=kartu#UMY#yes;";
            }
            else if (server == '2')
            { // konek ke simak 
                conn = "Data Source= 10.0.1.65 ; Initial Catalog= s1makumyny4;User id=karturfid; Password=kartu#UMY#yes;";
            }
            else if (server == '3')
            {// konek ke History blokir sementara masih ada di DB_Parkir
                conn = "Data Source= 10.0.1.65 ; Initial Catalog= parkir;User id=karturfid; Password=kartu#UMY#yes;";
            }
            else if (server == '4')
            { // konek ke db kepegawaian
                conn = "Data Source= 10.0.1.65 ; Initial Catalog= kepegawaian_new;User id=karturfid; Password=kartu#UMY#yes;";
            }

            return conn;
        }

        //loksi Sqlite
        public string LokasiSqlite()
        {
            //const string filename = @"C:\ProgramData\RfidBagiKartu\PMS_UMY.sqlite"; // ubah lokasi filename jika diperlukan
            string filename = Directory.GetCurrentDirectory() + @"\PMS_UMY.sqlite"; // ubah lokasi filename jika diperlukan
            string lokasi = "Data Source=" + filename + ";Version=3;";
            return lokasi;
        }
    }
}
