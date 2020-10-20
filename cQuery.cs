using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbilKtm
{
    class cQuery
    {
        //SQLITE
        public string qSelectPenggunaWhereKodeRfid(string kodeRfid)
        {
            string qr = "select p.rfid, p.nik, p.nama, k.no_kendaraan, k.merek, k.jenis , p.id, k.id, p.kategori" +
                        " from Pengguna as p left join kendaraan as k on p.id = k.id_pengguna" +
                        " where p.rfid= '" + kodeRfid + "'";
            return qr;
        }

        public string qSelectUserLoginSqlite()
        {
            string qr = "SELECT username, role, aplication" +
                        " FROM user" +
                        " Where username = @username AND password = @password";
            return qr;
        }

        public string qSelectTransaksiMhsStatus0()
        {
            string qr = "SELECT idTransaksi, nim, lastModified, operator" +
                        " FROM TransaksiKartu " +
                        " where statusUpload = 0" +
                                " and kategori = 1" +
                        " order by lastModified";
            return qr;
        }

        public string qSelectTransaksiMhsStatus0Limit1()
        {
            string qr = "SELECT nim, lastModified, operator" +
                        " FROM TransaksiKartu " +
                        " where statusUpload = 0" +
                                " and kategori = 1" +
                        " order by lastModified" +
                        " limit 1";
            return qr;
        }

        public string qUpdateStatusUpload1()
        {
            string qr = "UPDATE TransaksiKartu SET statusUpload= '1' where idTransaksi = @idTransaksi";
            return qr;
        }

        public string qDeleteKendaraanTmp()
        {
            string qr = "delete from kendaraanTmp";
            return qr;
        }

        public string qInsertKendaraanTmp()
        {
            string qr = " insert into kendaraanTmp (id, id_pengguna,no_kendaraan,nama_pemilik,merek,jenis, last_update) values (@id,@id_pengguna,@no_kendaraan,@pemilik,@merek,@jenis,@last_update)";
            return qr;
        }

        public string qSelectKendaraanTmpLimit1()
        {
            string qr = "SELECT last_update FROM kendaraanTmp order by last_update desc LIMIT 1";
            return qr;
        }

        public string qDeleteKendaraan()
        {
            string qr = "delete from kendaraan";
            return qr;
        }

        public string qCopyTmpToKendaraan()
        {
            string qr = "INSERT INTO kendaraan SELECT * FROM kendaraanTmp";
            return qr;
        }

        public string qDeleteMhsTmp()
        {
            string qr = "delete from penggunaTmp where kategori = 1"; //kategori 1=mahasiwa
            return qr;
        }

        public string qSelectMhsTmpLimit1()
        {
            string qr = "SELECT nik FROM penggunaTmp WHERE kategori = 1 LIMIT 1";
            return qr;
        }

        public string qDeleteMhs()
        {
            string qr = "delete from pengguna where kategori = 1"; //kategori 1=mahasiwa
            return qr;
        }

        public string qCopyTmpToMhs()
        {
            string qr = "INSERT INTO pengguna SELECT * FROM penggunaTmp WHERE kategori = 1";
            return qr;
        }

        public string qInsertPenggunaTmp()
        {
            string qr = "insert into penggunaTmp (id,nik,nama,rfid,kategori) values (@id,@nik,@nama,@rfid,@kategori)";
            return qr;
        }

        public string qDeleteOperatorTmp()
        {
            string query = "delete from userTmp";
            return query;
        }

        public string qInsertUserTmp()
        {
            string qr = "INSERT INTO userTmp (username, fullname, password, role, aplication) values(@username, @fullname, @password, @role, @aplication)";
            return qr;
        }

        public string qSelectUserTmpLimit1()
        {
            string qr = "SELECT username FROM userTmp order by username desc LIMIT 1";
            return qr;
        }

        public string qDeleteOperator()
        {
            string qr = "delete from user";
            return qr;
        }

        public string qCopyTmpToOperator()
        {
            string qr = "INSERT INTO user SELECT * FROM userTmp";
            return qr;
        }

        public string qSelectIdTransaksiByRfid(string kodeRfid)
        {
            string vkodeRfid = kodeRfid.Replace("'", "''");
            string qr = "SELECT idTransaksi FROM TransaksiKartu where kodeRfid = '" + vkodeRfid + "' order by lastModified desc limit 1";
            return qr;
        }

        public string qUpdateTanggalTransaksiById(string idTransaksi)
        {
            string vidTransaksi = idTransaksi.Replace("'", "''");
            string qr = "update transaksiKartu set lastModified = strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime') where idTransaksi = " + vidTransaksi + "";
            return qr;
        }

        public string qInsertTransaksi()
        {
            string qr = " insert into TransaksiKartu (nim, operator, kodeRfid, lastModified, nama, kategori) values (@nim, @operator, @kodeRfid, strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime'), @nama, @kategori)";
            return qr;
        }

        // MS SQL
        public string qSelectTop1StatusMhsWhereStudId(string STUDENTID)
        {
            string qr = "SELECT TOP 1 STUDENTID, TGL_AMBIL_KTM, AMBIL_KTM_KE, PTGS_KTM_AMBIL" +
                        " FROM STATUS_MHS" +
                        " WHERE THAJARANID = '0000' " +
                                " AND TERMID = '0'" +
                                " AND STUDENTID = '" + STUDENTID + "'" +
                        "ORDER BY TGL_AMBIL_KTM desc";
            return qr;
        }

        public string qInsertStatusMhs()
        {
            string qr = "INSERT INTO STATUS_MHS (STUDENTID, TGL_AMBIL_KTM, AMBIL_KTM_KE, PTGS_KTM_AMBIL, THAJARANID, TERMID) " +
                        " VALUES (@STUDENTID, @TGL_AMBIL_KTM, 1, @PTGS_KTM_AMBIL, '0000', '0')";
            return qr;
        }

        public string qUpdateStatusMhs()
        {
            string qr = "UPDATE STATUS_MHS " +
                        " SET AMBIL_KTM_KE = @AMBIL_KTM_KE, TGL_AMBIL_KTM = @TGL_AMBIL_KTM, PTGS_KTM_AMBIL = @PTGS_KTM_AMBIL" +
                        " WHERE STUDENTID = @STUDENTID";
            return qr;
        }

        public string qSelectKendaraan()
        {
            string qr = "select id_kendaraan, pengguna, tnkb, pemilik, merek, id_jenis_kendaraan, last_update from export_kendaraan order by last_update desc";
            return qr;
        }

        public string qSelectMhs()
        {
            string qr = "select StudentID,fullname,rfid from mahasiswa where rfid != 'null'"; //select semua mhs yg punya kode rfid
            return qr;
        }

        //query select Mhs yng punya kode rfid by NIM and fullname
        //parameter: STUDENTID, FULLNAME
        public string qSearchMhsAmbilKtm(string STUDENTID, string FULLNAME)
        {
            string NIM = STUDENTID.Replace("'", "''");
            string Nama = FULLNAME.Replace("'", "''");

            string qr = "SELECT a.STUDENTID AS NIM, b.FULLNAME as Nama, b.RFID as KodeRfid, PTGS_KTM_AMBIL AS Operator," +
                                " CONVERT(varchar, a.TGL_AMBIL_KTM, 103) AS TanggalAmbil, a.AMBIL_KTM_KE" +
                        " FROM STATUS_MHS a" +
                                " inner join MAHASISWA b ON b.STUDENTID = a.STUDENTID" +
                        " WHERE b.RFID != 'null'" +
                                " AND a.THAJARANID = '0000'" +
                                " AND a.TERMID = '0'" +
                                " AND b.STUDENTID LIKE '%" + NIM + "%'" +
                                " AND b.FULLNAME LIKE '%" + Nama + "%'" +
                        " ORDER BY a.STUDENTID";
            return qr;
        }

        public string qSearchAmbilKartuPeg(string nik, string nama)
        {
            string noPeg = nik.Replace("'", "''");
            string namaPeg = nama.Replace("'", "''");

            string qr = "select nik as Nik, nama as Nama," +
                        " case " +
                            " when ambilkartu=1" +
                                " then 'Ya'" +
                                " else 'Belum'" +
                        " end as Sudah_Diambil" +
                        " from pegawai" +
                        " where nik like '%" + noPeg + "%' and nama like '%" + namaPeg + "%'";
            return qr;
        }

        public string qSearchMhsByNImNama(string STUDENTID, string FULLNAME)
        {
            string NIM = STUDENTID.Replace("'", "''");
            string Nama = FULLNAME.Replace("'", "''");

            string qr = "select STUDENTID, FULLNAME, RFID from MAHASISWA" +
                        " where STUDENTID like '%" + NIM + "%' and FULLNAME like '%" + Nama + "%'" +
                        " order by STUDENTID ASC";
            return qr;
        }

        public string qSearchHistoryByIdPenggunaTop1(string IdPengguna)
        {
            string ID = IdPengguna.Replace("'", "''");

            string qr = "SELECT TOP 1 rfid, nama, last_modified " +
                        " FROM history_rfid " +
                        " WHERE id_pengguna = '" + ID + "'" +
                        " ORDER BY last_modified desc";
            return qr;
        }

        public string qInsertHistory()
        {
            string qr = "INSERT INTO history_rfid (id_pengguna, rfid, nama, last_modified)values(@id_pengguna, @rfid, @nama, GETDATE())";
            return qr;
        }

        public string qUpdateRfidNullByNim()
        {
            string qr = "UPDATE MAHASISWA SET RFID = NULL WHERE STUDENTID = @STUDENTID";
            return qr;
        }

        public string qUpdateRfidNullByIdPeg()
        {
            string qr = "UPDATE pegawai SET rfid = NULL WHERE id_pegawai = @id_pegawai";
            return qr;
        }

        public string qSelectKodeProdiByNim(string NIM)
        {
            string STUDENTID = NIM.Replace("'", "''");
            string qr = "select STUDENTID, FULLNAME, RFID," +
                        " case len(AVAILABLE_EDU_ID)" +
                            " when 2 then '0'+AVAILABLE_EDU_ID" +
                            " else AVAILABLE_EDU_ID end" +
                        " as prodi" +
                        " from MAHASISWA" +
                        " where STUDENTID = '" + STUDENTID + "'";
            return qr;
        }

        public string qSelectNamaRfidMhsByNim(string NIM)
        {
            string STUDENTID = NIM.Replace("'", "''");
            string qr = "select STUDENTID, FULLNAME, RFID from MAHASISWA" +
                            " where STUDENTID = '" + STUDENTID + "'";
            return qr;
        }

        public string qSelectLastRfidMhsByProdi(string prodi)
        {
            string kodeProdi = prodi.Replace("'", "''");
            //string qr = "select TOP 1 StudentID, RFID , substring (StudentID,5,3) as id_prodi,"+ //query hanya berlaku utk angkatan th 2000 keatas
            //            " SUBSTRING (RFID, 5,4) AS heksa "+
            //            " from mahasiswa "+
            //            " where len (studentid)=11 "+
            //            " and substring (StudentID, 5,3) ='" + kodeProdi + "' " +
            //            " order by RFID DESC";
            string qr = "select TOP 1 StudentID, RFID ," + //query berlaku utk semua angkatan
                        " case len(AVAILABLE_EDU_ID) " +
                                " when 2 then '0'+AVAILABLE_EDU_ID " +
                                " else AVAILABLE_EDU_ID end  " +
                        " as id_prodi," +
                        " SUBSTRING (RFID, 5,4) AS heksa  " +
                        " from mahasiswa  " +
                        " where left (RFID,4) = '1" + kodeProdi + "'" +
                        " order by RFID DESC";
            return qr;
        }

        public string qSelectLastRfidPegawai()
        {
            string qr = "SELECT TOP 1 id_pegawai, rfid, SUBSTRING (rfid, 2,7) AS heksa " +
                        " FROM pegawai" +
                        " ORDER BY rfid DESC";
            return qr;
        }

        public string qSelectLastHistoryRfidByProdi(string prodi)
        {
            string kodeProdi = prodi.Replace("'", "''");
            //string qr = "select TOP 1 id_pengguna, rfid , substring (id_pengguna,5,3) as id_prodi, SUBSTRING (rfid, 5,4) AS heksa " +
            //            " from history_rfid " +
            //            " where rfid like '1%' AND substring (id_pengguna, 5,3) ='" + kodeProdi + "' " +
            //            " order by rfid DESC";
            string qr = "select TOP 1 id_pengguna, rfid ," +
                        " substring (rfid,2,3) as id_prodi, " +
                        " SUBSTRING (rfid, 5,4) AS heksa  " +
                        " from history_rfid  " +
                        " where LEFT(rfid,4) = '1" + kodeProdi + "' " +
                        " order by rfid DESC";
            return qr;
        }

        public string qSelectLastHistoryRfidPegawai()
        {
            string qr = "select TOP 1 id_pengguna, rfid , SUBSTRING (rfid, 2,7) AS heksa " +
                         " from history_rfid " +
                         " where rfid like '2%'" +
                         " order by rfid DESC";
            return qr;
        }

        public string qSelectNimByRfid(string rfid)
        {
            string kodeRfid = rfid.Replace("'", "''");
            string qr = "select STUDENTID from MAHASISWA where RFID = '" + kodeRfid + "'";
            return qr;
        }

        public string qSelectIdPegawaiByRfid(string rfid)
        {
            string kodeRfid = rfid.Replace("'", "''");
            string qr = " select id_pegawai from pegawai where rfid = '" + kodeRfid + "'";
            return qr;
        }

        public string qUpdateRfidMhsByNim()
        {
            string qr = "update MAHASISWA" +
                        " set RFID = @RFID" + //kode rfid
                        " WHERE STUDENTID = @STUDENTID"; //nim"
            return qr;
        }

        public string qUpdateRfidPegByID()
        {
            string qr = " update pegawai set rfid = @rfid" +
                         " where id_pegawai = @id_pegawai";
            return qr;
        }

        public string qSelectUserOpAkdk()//query untuk mendapatkan data operator akdk, admin akdk, dan super Admin
        {
            string qr = "select username, fullname, password, role, aplication " +
                        " from [user] where aplication in ('All','Akademik')";
            return qr;
        }

        public string qSelectUserLoginMsSql()
        {
            string qr = "select username, role, aplication " +
                        " from [user] " +
                        " where aplication != 'Gate'" +
                        " AND username = @username AND password = @password";
            return qr;
        }

        public string qSearchPegByNikNama(string NIK, string NAMA)
        {
            string nikPeg = NIK.Replace("'", "''");
            string namaPeg = NAMA.Replace("'", "''");

            string qr = "SELECT id_pegawai, nik, nama, rfid " +
                        " FROM pegawai" +
                        " WHERE nik like '%" + nikPeg + "%'" +
                        " AND nama like '%" + namaPeg + "%'" +
                        "ORDER BY nik ASC";
            return qr;
        }

        public string qSelectNamaRfidPegByIdPeg(string ID)
        {
            string id_pegawai = ID.Replace("'", "''");
            string qr = "SELECT id_pegawai, nama, rfid, nik FROM pegawai" +
                        " WHERE id_pegawai = '" + id_pegawai + "'";
            return qr;
        }

        public string qSelectRfidByIdPeg(string ID)
        {
            string id_pegawai = ID.Replace("'", "''");
            string qr = "select rfid from pegawai where id_pegawai = '" + id_pegawai + "'";
            return qr;
        }

        public string qSelectPegawaiWhereRfid(string kodeRfid)
        {
            string qr = "select id_pegawai, nik, nama from pegawai where rfid = '" + kodeRfid + "'";
            return qr;
        }

        public string qSelectKenaraanWhereIdpengguna(string idpengguna)
        {
            string qr = "select tnkb, merek, id_jenis_kendaraan from kendaraan where pengguna = '" + idpengguna + "'";
            return qr;
        }

        public string qUpdateAmbilKartuPegawai()
        {
            string qr = "update pegawai set ambilkartu = 1 where id_pegawai = @id_pegawai";
            return qr;
        }

        public string qSelectUserOpBu()
        {
            string qr = "select username from [user] where aplication in ('Biro Umum','Gate')";
            return qr;
        }

        public string qSelectUserOpAkademik()
        {
            string qr = "select username from [user] where aplication in ('Akademik')";
            return qr;
        }

        public string qSelectUserWhereUsername(string username)
        {
            string vusername = username.Replace("'", "''");
            string qr = "select username, fullname, password, role, aplication from [user] where username = '" + vusername + "'";
            return qr;
        }

        public string qInsertUser()
        {
            string qr = "INSERT INTO [user] (username ,fullname ,password ,role, aplication) VALUES (@username,@fullname,@password,@role,@aplication)";
            return qr;
        }

        public string qDeleteUserWhereUsernameAndPass()
        {
            string qr = "Delete from [user] where username = @username and password = @password";
            return qr;
        }
    }
}
