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
    public partial class UrunYonetimForm : Form
    {
        public UrunYonetimForm()
        {
            InitializeComponent();
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            servisAdediCB.Items.AddRange(Enumerable.Range(1, 1000).Select(i => (object)i).ToArray());
            servisMiktarıCB.Items.AddRange(Enumerable.Range(1, 1000).Select(i => (object)i).ToArray());
            stokBilgisiCB.Items.AddRange(Enumerable.Range(1, 1000).Select(i => (object)i).ToArray());
            textBoxBarkod2.Text = UrunAramaForm.barkod;
        }
        //barkodu girilen ve güncellenmek istenen alanları seçilen ürünü ekranın sağ tarafındaki kısma getirmeyi sağlayan kod dizesi.
        private void urungetirbuton6_Click(object sender, EventArgs e)
        {
            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);
            con.Open();
            string query = "SELECT * from URUN where Barkod_No=@barkod";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@barkod", textBoxBarkod2.Text);

            List<string> liste3 = new List<string>();
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                liste3.Add(dr[2].ToString());
            }
            dr.Close();
            cmd.Dispose();

            if (liste3.Contains(textBoxBarkod2.Text))
            {
                GuncelleButon3.Enabled = true;

                urunAdiTB.Enabled = checkBox1.Checked ? true : false;
                birimCB.Enabled = checkBox2.Checked ? true : false;
                servisBirimCB.Enabled = checkBox3.Checked ? true : false;
                servisAdediCB.Enabled = checkBox4.Checked ? true : false;
                servisMiktarıCB.Enabled = checkBox5.Checked ? true : false;
                satisFiyatiTB.Enabled = checkBox6.Checked ? true : false;
                stokBilgisiCB.Enabled = checkBox7.Checked ? true : false;

                string dbconstring2 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con2 = new SQLiteConnection(myBuilder2.ConnectionString);
                con2.Open();

                string query2 = "SELECT Urun_id from URUN where Barkod_No=@barkod";
                SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@barkod", textBoxBarkod2.Text);

                var result2 = cmd2.ExecuteScalar();
                int sonuc2 = Convert.ToInt32(result2);

                string query3 = "SELECT Urun_Adi from URUN where Urun_id=@urun_id";
                SQLiteCommand cmd3 = new SQLiteCommand(query3, con2);
                cmd3.Parameters.AddWithValue("@urun_id", sonuc2);

                var result3 = cmd3.ExecuteScalar();
                string sonuc3 = result3.ToString();

                urunAdiTB.Text = sonuc3;

                string query4 = "SELECT Birim from URUN where Urun_id=@urun_id";
                SQLiteCommand cmd4 = new SQLiteCommand(query4, con2);
                cmd4.Parameters.AddWithValue("@urun_id", sonuc2);

                var result4 = cmd4.ExecuteScalar();
                string sonuc4 = result4.ToString();

                birimCB.Text = sonuc4;

                string query5 = "SELECT Servis_Birim from URUN where Urun_id=@urun_id";
                SQLiteCommand cmd5 = new SQLiteCommand(query5, con2);
                cmd5.Parameters.AddWithValue("@urun_id", sonuc2);

                var result5 = cmd5.ExecuteScalar();
                string sonuc5 = result5.ToString();

                servisBirimCB.Text = sonuc5;

                string query6 = "SELECT Servis_Adedi from URUN where Urun_id=@urun_id";
                SQLiteCommand cmd6 = new SQLiteCommand(query6, con2);
                cmd6.Parameters.AddWithValue("@urun_id", sonuc2);

                var result6 = cmd6.ExecuteScalar();
                int sonuc6 = Convert.ToInt32(result6);

                servisAdediCB.Text = sonuc6.ToString();

                string query7 = "SELECT Servis_Miktari from URUN where Urun_id=@urun_id";
                SQLiteCommand cmd7 = new SQLiteCommand(query7, con2);
                cmd7.Parameters.AddWithValue("@urun_id", sonuc2);

                var result7 = cmd7.ExecuteScalar();
                int sonuc7 = Convert.ToInt32(result7);

                servisMiktarıCB.Text = sonuc7.ToString();

                string query8 = "SELECT Satis_Fiyati from URUN where Urun_id=@urun_id";
                SQLiteCommand cmd8 = new SQLiteCommand(query8, con2);
                cmd8.Parameters.AddWithValue("@urun_id", sonuc2);

                var result8 = cmd8.ExecuteScalar();
                string sonuc8 = result8.ToString();

                satisFiyatiTB.Text = sonuc8;

                string query9 = "SELECT Stok_Bilgisi from URUN where Urun_id=@urun_id";
                SQLiteCommand cmd9 = new SQLiteCommand(query9, con2);
                cmd9.Parameters.AddWithValue("@urun_id", sonuc2);

                var result9 = cmd9.ExecuteScalar();
                int sonuc9 = Convert.ToInt32(result9);

                stokBilgisiCB.Text = sonuc9.ToString();

                con2.Close();
            }
            else if (textBoxBarkod2.Text == "")
            {
                MessageBox.Show("Lütfen alanları boş bırakmayınız.");
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir barkod giriniz.");
            }

        }
        //tümünü seç seçeneğinin yapacağı işlemler
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }
        //ÜRÜN GÜNCELLE BUTONUNUN YAPACAĞI İŞLEMLER
        private void GuncelleButon3_Click(object sender, EventArgs e)
        {
            if (birimCB.Text=="" || servisBirimCB.Text=="" || servisMiktarıCB.Text=="" || servisAdediCB.Text=="" || stokBilgisiCB.Text=="" || satisFiyatiTB.Text=="" || urunAdiTB.Text=="" )
            {
                MessageBox.Show("Lütfen boş alan bırakmayın.");
            }
            else
            {
                string dbconstring3 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con11 = new SQLiteConnection(myBuilder3.ConnectionString);
                con11.Open();
                string query11 = "SELECT Satis_Fiyati from URUN";
                SQLiteCommand cmd11 = new SQLiteCommand(query11, con11);
                List<double> liste11 = new List<double>();
                SQLiteDataReader dr11 = cmd11.ExecuteReader();
                while (dr11.Read())
                {
                    liste11.Add(Convert.ToDouble(dr11[0].ToString()));
                }
                dr11.Close();
                cmd11.Dispose();
                con11.Close();

                if (liste11.Contains(Convert.ToDouble(satisFiyatiTB.Text)))
                {
                    //fiyat değişikliği yapılmadı;
                }
                else
                {
                    string tarih = DateTime.Now.ToString();
                    string urunadi = urunAdiTB.Text;
                    string yenifiyat = satisFiyatiTB.Text;

                    string dbconstring4 = GetExecutingDirectoryName();
                    SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
                    { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

                    SQLiteConnection con12 = new SQLiteConnection(myBuilder4.ConnectionString);
                    con12.Open();
                    string query12 = "SELECT Satis_Fiyati from URUN where Barkod_No = @barkod";
                    SQLiteCommand cmd12 = new SQLiteCommand(query12, con12);
                    cmd12.Parameters.AddWithValue("barkod", textBoxBarkod2.Text);
                    var result = cmd12.ExecuteScalar();
                    double deger = Convert.ToDouble(result);
                    string eskifiyat = Convert.ToString(deger);

                    SQLiteCommand cmd13 = new SQLiteCommand(con12);
                    cmd13.CommandText = "INSERT INTO FIYAT_DEGISIKLIK(Urun_Adi, Tarih, Eski_Fiyat, Yeni_Fiyat) VALUES(@urunadi, @tarih, @eskifiyat, @yenifiyat)";
                    cmd13.Parameters.AddWithValue("@tarih", tarih);
                    cmd13.Parameters.AddWithValue("@urunadi", urunadi);
                    cmd13.Parameters.AddWithValue("@yenifiyat", yenifiyat);
                    cmd13.Parameters.AddWithValue("@eskifiyat", eskifiyat);

                    cmd13.ExecuteNonQuery();
                    cmd13.Dispose();
                    con12.Close();

                    MessageBox.Show("Yaptığınız fiyat değişikliği, ilgili tabloya eklendi.");
                }

                string dbconstring5 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder5 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring5 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con3 = new SQLiteConnection(myBuilder5.ConnectionString);
                con3.Open();

                string query0 = "SELECT Urun_id from URUN where Barkod_No=@barkod";
                SQLiteCommand cmd0 = new SQLiteCommand(query0, con3);
                cmd0.Parameters.AddWithValue("@barkod", textBoxBarkod2.Text);

                var result0 = cmd0.ExecuteScalar();
                int sonuc0 = Convert.ToInt32(result0);

                string yeniItem1 = urunAdiTB.Text;
                string yeniItem2 = birimCB.Text;
                string yeniItem3 = servisBirimCB.Text;
                int yeniItem4 = Convert.ToInt32(servisAdediCB.Text);
                int yeniItem5 = Convert.ToInt32(servisMiktarıCB.Text);
                string yeniItem6 = satisFiyatiTB.Text;
                int yeniItem7 = Convert.ToInt32(stokBilgisiCB.Text);

                SQLiteCommand cmd10 = new SQLiteCommand(con3);
                cmd10.CommandText = ("Update URUN Set Urun_Adi = @urun_isim, Birim = @birim, Servis_Birim = @servis_birim, Servis_Adedi = @servis_adedi, Servis_Miktari = @servis_miktari, Satis_Fiyati = @satis_fiyati, Stok_Bilgisi = @stok_bilgisi  WHERE Urun_id = @urun_id");
                cmd10.Parameters.AddWithValue("@urun_isim", yeniItem1);
                cmd10.Parameters.AddWithValue("@birim", yeniItem2);
                cmd10.Parameters.AddWithValue("@servis_birim", yeniItem3);
                cmd10.Parameters.AddWithValue("@servis_adedi", yeniItem4);
                cmd10.Parameters.AddWithValue("@servis_miktari", yeniItem5);
                cmd10.Parameters.AddWithValue("@satis_fiyati", yeniItem6);
                cmd10.Parameters.AddWithValue("@stok_bilgisi", yeniItem7);
                cmd10.Parameters.AddWithValue("@urun_id", sonuc0);

                int a = cmd10.ExecuteNonQuery();

                if (a == 1)
                {
                    
                    Temizle();
                }
                else MessageBox.Show("Güncelleme Başarısız");
                cmd10.ExecuteNonQuery();
                con3.Close();
            }
        }
        //TEMİZLE FONKSİYONU
        private void Temizle()
        {
            textBoxBarkod2.Text = "";
            urunAdiTB.Text = "";
            birimCB.Text = "";
            servisBirimCB.Text = "";
            servisAdediCB.Text = "";
            servisMiktarıCB.Text = "";
            satisFiyatiTB.Text = "";
            stokBilgisiCB.Text = "";

            urunAdiTB.Enabled = false;
            birimCB.Enabled = false;
            servisBirimCB.Enabled = false;
            servisAdediCB.Enabled = false;
            servisMiktarıCB.Enabled = false;
            satisFiyatiTB.Enabled = false;
            stokBilgisiCB.Enabled = false;

            GuncelleButon3.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }
        private void temizleButon_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void satisFiyatiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongDateString();
            label11.Text = DateTime.Now.ToLongTimeString();
        }

        //klavyeden giriş yapılan bölümlerde gerekli klavye giriş denetimleri.
        private void textBoxBarkod2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void servisBirimCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar));
        }
        private void servisAdediCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void servisMiktarıCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void stokBilgisiCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void birimCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar));
        }
    }
}
