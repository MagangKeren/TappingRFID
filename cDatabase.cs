using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbilKtm
{
    class cDatabase
    {
        cKoneksi koneksi = new cKoneksi();//buat koneksi

        public DataTable selectDataSqlite(string query)
        {
            using (SQLiteConnection sqliteCon = new SQLiteConnection(koneksi.LokasiSqlite()))// select data dari sqlite
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    //---------------------------------
                    cmd.CommandText = query;
                    //---------------------------------
                    cmd.Connection = sqliteCon;
                    sqliteCon.Open();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //---------------------
                    sqliteCon.Close();
                    sqliteCon.Dispose();

                    return dt;
                }
            }
        }

        //insert data ke sqlite
        public void insertDataSqlite(string query)
        {
            using (SQLiteConnection sqlCon = new SQLiteConnection(koneksi.LokasiSqlite()))//insert ke local Sqlite
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    //---------------------------------
                    cmd.CommandText = query;
                    //---------------------------------
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //---------------------
                    sqlCon.Close();
                    sqlCon.Dispose();

                    dt.Clear();
                    dt.Dispose();
                }
            }
        }

        //select data ms sql
        public DataTable selectData(string query, char server)
        {
            cKoneksi koneksi = new cKoneksi();
            using (SqlConnection sqlCon = new SqlConnection(koneksi.konekMsSql(server)))// select data dari server
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //---------------------------------
                    cmd.CommandText = query;
                    //---------------------------------
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //---------------------
                    sqlCon.Close();
                    sqlCon.Dispose();

                    return dt;
                }
            }
        }
    }
}
