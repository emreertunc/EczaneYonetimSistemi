// Copyright © EYS 2021, Emre Ertunç
// Tüm Hakları Saklıdır.
// İzinsiz Kullanılamaz.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Reflection;
using System.IO;

namespace EczaneYonetimSistemi
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);
            con.Open();
            try
            {
                //combo marka 
                string sorgu1 = "SELECT Marka_Adi from MARKA";
                SQLiteCommand komut1 = new SQLiteCommand(sorgu1, con);

                DataTable vt1 = new DataTable();
                SQLiteDataAdapter adapt1 = new SQLiteDataAdapter(komut1);
                adapt1.Fill(vt1);

                comboBoxMarka.DisplayMember = "Marka_Adi";
                comboBoxMarka.DataSource = vt1;

                //combo kategori
                string sorgu2 = "SELECT Kategori_Adi from KATEGORI";
                SQLiteCommand komut2 = new SQLiteCommand(sorgu2, con);

                DataTable vt2 = new DataTable();
                SQLiteDataAdapter adapt2 = new SQLiteDataAdapter(komut2);
                adapt2.Fill(vt2);

                comboBoxKategori.DisplayMember = "Kategori_Adi";
                comboBoxKategori.DataSource = vt2;

                //combo depo
                string sorgu3 = "SELECT Depo_Adi from DEPO";
                SQLiteCommand komut3 = new SQLiteCommand(sorgu3, con);

                DataTable vt3 = new DataTable();
                SQLiteDataAdapter adapt3 = new SQLiteDataAdapter(komut3);
                adapt3.Fill(vt3);

                comboBoxDepo.DisplayMember = "Depo_Adi";
                comboBoxDepo.DataSource = vt3;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonUrunEkle_Click(object sender, EventArgs e)
        {
            if(textBoxUrunAdi.Text=="" || textBoxBarkodNo.Text == "" || textBoxBirim.Text == "" || textBoxServisbirim.Text == "" || textBoxServismiktari.Text == "" || textBoxServisadedi.Text == "" || textBoxKDVOran.Text == "" || textBoxAlisFiyati.Text == "" || textBoxSatisFiyati.Text == "" || textBoxPiyasaFiyati.Text == "" || textBoxYerli.Text == "" || textBoxAsgaristok.Text == "" || textBoxStok.Text == "" || textBoxSKT.Text == "")
            {
                MessageBox.Show("Lütfen hiç bir alanı boş bırakmayınız.");
            }
            else
            {
                //depo id çekme
                string dbconstring2 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con2 = new SQLiteConnection(myBuilder2.ConnectionString);
                con2.Open();
                string query = "SELECT Depo_id from DEPO where Depo_Adi=@depo_isim";
                SQLiteCommand cmd2 = new SQLiteCommand(query, con2);
                cmd2.Parameters.AddWithValue("@depo_isim", comboBoxDepo.Text.ToString());

                var result3 = cmd2.ExecuteScalar();
                int deger3 = Convert.ToInt32(result3);
                con2.Close();

                //marka id çekme
                string dbconstring3 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con3 = new SQLiteConnection(myBuilder3.ConnectionString);
                con3.Open();
                string query3 = "SELECT Marka_id from MARKA where Marka_Adi=@marka_isim";
                SQLiteCommand cmd3 = new SQLiteCommand(query3, con3);
                cmd3.Parameters.AddWithValue("@marka_isim", comboBoxMarka.Text.ToString());

                var result = cmd3.ExecuteScalar();
                int deger = Convert.ToInt32(result);
                con3.Close();

                //kategori id çekme
                string dbconstring4 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con4 = new SQLiteConnection(myBuilder4.ConnectionString);
                con4.Open();
                string query5 = "SELECT Kategori_id from KATEGORI where Kategori_Adi=@kategori_isim";
                SQLiteCommand cmd5 = new SQLiteCommand(query5, con4);
                cmd5.Parameters.AddWithValue("@kategori_isim", comboBoxKategori.Text.ToString());

                var result2 = cmd5.ExecuteScalar();
                int deger2 = Convert.ToInt32(result2);
                con4.Close();

                string dbconstring5 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder5 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring5 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con = new SQLiteConnection(myBuilder5.ConnectionString);
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO URUN(Urun_Adi, Barkod_No, Birim, Servis_Birim, Servis_Adedi, Servis_Miktari, SKT, KDV_Orani, Alis_Fiyati, Piyasa_Fiyati, Satis_Fiyati, Yerli, Asgari_Stok, Stok_Bilgisi, Depo_id, Marka_id, Kategori_id) VALUES(@urun, @barkod, @birim, @servisbirim, @servisadedi, @servismiktari, @skt, @kdvorani, @alisfiyati, @piyasafiyati, @satisfiyati, @yerli, @asgaristok, @stokbilgisi, @d_id, @m_id, @k_id)";
                cmd.Parameters.AddWithValue("@urun", textBoxUrunAdi.Text);
                cmd.Parameters.AddWithValue("@barkod", textBoxBarkodNo.Text);
                cmd.Parameters.AddWithValue("@birim", textBoxBirim.Text);
                cmd.Parameters.AddWithValue("@servisbirim", textBoxServisbirim.Text);
                cmd.Parameters.AddWithValue("@servisadedi", Convert.ToInt32(textBoxServisadedi.Text));
                cmd.Parameters.AddWithValue("@servismiktari", Convert.ToInt32(textBoxServismiktari.Text));
                cmd.Parameters.AddWithValue("@skt", textBoxSKT.Text);
                cmd.Parameters.AddWithValue("@kdvorani", textBoxKDVOran.Text);
                cmd.Parameters.AddWithValue("@alisfiyati", textBoxAlisFiyati.Text);
                cmd.Parameters.AddWithValue("@piyasafiyati", textBoxPiyasaFiyati.Text);
                cmd.Parameters.AddWithValue("@satisfiyati", textBoxSatisFiyati.Text);
                cmd.Parameters.AddWithValue("@yerli", textBoxYerli.Text);
                cmd.Parameters.AddWithValue("@asgaristok", Convert.ToInt32(textBoxAsgaristok.Text));
                cmd.Parameters.AddWithValue("@stokbilgisi", Convert.ToInt32(textBoxStok.Text));
                cmd.Parameters.AddWithValue("@d_id", deger3);
                cmd.Parameters.AddWithValue("@m_id", deger);
                cmd.Parameters.AddWithValue("@k_id", deger2);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Ürün başarıyla eklendi");
                this.Close();
            }
        }
        private void textBoxAlisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        private void textBoxPiyasaFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        private void textBoxSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void textBoxBarkodNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxKDVOran_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void textBoxYerli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxAsgaristok_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxServismiktari_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxServisadedi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
