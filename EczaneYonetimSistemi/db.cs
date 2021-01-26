// Copyright © EYS 2021, Emre Ertunç
// Tüm Hakları Saklıdır.
// İzinsiz Kullanılamaz.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace EczaneYonetimSistemi
{
    class db
    {
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        public DataSet FATURA_KALEM(int invid)
        {
            string dbconstring = GetExecutingDirectoryName();

            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);

            string query1 = "SELECT * FROM FATURA_KALEM WHERE Fatura_id = @InvoiceID";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, con);
            cmd1.Parameters.AddWithValue("@InvoiceID", invid);

            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(cmd1);
            DataSet ds = new DataSet();
            adapter1.Fill(ds);
            return ds;
        }
        public DataSet CARI_TABLO(int cust_id)
        {
            string dbconstring = GetExecutingDirectoryName();

            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);

            string query1 = "SELECT * FROM CARI_TABLO WHERE Cari_id = @Cust_id";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, con);
            cmd1.Parameters.AddWithValue("@Cust_id", cust_id);

            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            return ds1;
        }
        public DataSet FATURA(int fat_no)
        {
            string dbconstring = GetExecutingDirectoryName();

            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);

            string query1 = "SELECT * FROM FATURA WHERE Fatura_No = @fat_no";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, con);
            cmd1.Parameters.AddWithValue("@fat_no", fat_no);

            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            return ds1;
        }
    }
}
