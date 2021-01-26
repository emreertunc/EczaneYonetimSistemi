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
    public partial class MusteriBilgiForm : Form
    {
        public MusteriBilgiForm()
        {
            InitializeComponent();

            try
            {
                ListBoxGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        //GÜNCELLEME FONKSİYONU
        private void ListBoxGuncelle()
        {
            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);
            con.Open();
            string sorgu1 = "SELECT Cari_Adi from CARI_TABLO";
            SQLiteCommand komut1 = new SQLiteCommand(sorgu1, con);

            DataTable vt1 = new DataTable();
            SQLiteDataAdapter adapt1 = new SQLiteDataAdapter(komut1);
            adapt1.Fill(vt1);

            CariListBox.DisplayMember = "Cari_Adi";
            CariListBox.DataSource = vt1;

            con.Close();
        }
        //SEÇİLEN MÜŞTERİNİN BİLGİLERİNİ GETİREN BUTONUN YAPACAĞI İŞLEMLER
        private void bilgiGetirButon_Click(object sender, EventArgs e)
        {
            CariTipcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //CariTipcomboBox.DropDownStyle = ComboBoxStyle.DropDown;

            string dbconstring2 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con2 = new SQLiteConnection(myBuilder2.ConnectionString);
            con2.Open();

            string secilmisItem = CariListBox.GetItemText(CariListBox.SelectedItem);
            CariAdtextBox.Text = secilmisItem;

            string query0 = "SELECT Cari_Tip from CARI_TABLO where Cari_Adi=@cari_isim";
            SQLiteCommand cmd0 = new SQLiteCommand(query0, con2);
            cmd0.Parameters.AddWithValue("@cari_isim", secilmisItem);

            var result0 = cmd0.ExecuteScalar();
            string sonuc0 = result0.ToString();

            if (sonuc0 == "Müşteri")
            {
                CariAdtextBox.ReadOnly = false;
                TcNotextBox.ReadOnly = false;
                TelNotextBox.ReadOnly = false;

                string query2 = "SELECT TC_No from CARI_TABLO where Cari_Adi=@cari_isim";
                SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@cari_isim", secilmisItem);

                var result2 = cmd2.ExecuteScalar();
                string sonuc2 = result2.ToString();
                TcNotextBox.Text = sonuc2;
            }

            else if (sonuc0 == "Satıcı")
            {
                CariAdtextBox.ReadOnly = false;
                VergiNotextBox.ReadOnly = false;
                VergiDairesitextBox.ReadOnly = false;
                KurumAditextBox.ReadOnly = false;
                TelNotextBox.ReadOnly = false;

                string query1 = "SELECT Vergi_No from CARI_TABLO where Cari_Adi=@cari_isim";
                SQLiteCommand cmd1 = new SQLiteCommand(query1, con2);
                cmd1.Parameters.AddWithValue("@cari_isim", secilmisItem);

                var result1 = cmd1.ExecuteScalar();
                string sonuc1 = result1.ToString();
                VergiNotextBox.Text = sonuc1;

                string query3 = "SELECT Vergi_Dairesi from CARI_TABLO where Cari_Adi=@cari_isim";
                SQLiteCommand cmd3 = new SQLiteCommand(query3, con2);
                cmd3.Parameters.AddWithValue("@cari_isim", secilmisItem);

                var result3 = cmd3.ExecuteScalar();
                string sonuc3 = result3.ToString();
                VergiDairesitextBox.Text = sonuc3;

                string query4 = "SELECT Kurum_Adi from CARI_TABLO where Cari_Adi=@cari_isim";
                SQLiteCommand cmd4 = new SQLiteCommand(query4, con2);
                cmd4.Parameters.AddWithValue("@cari_isim", secilmisItem);

                var result4 = cmd4.ExecuteScalar();
                string sonuc4 = result4.ToString();
                KurumAditextBox.Text = sonuc4;
            }

            else MessageBox.Show("Hata");

            string query5 = "SELECT Cari_Tip from CARI_TABLO where Cari_Adi=@cari_isim";
            SQLiteCommand cmd5 = new SQLiteCommand(query5, con2);
            cmd5.Parameters.AddWithValue("@cari_isim", secilmisItem);

            var result5 = cmd5.ExecuteScalar();
            string sonuc5 = result5.ToString();
            CariTipcomboBox.Text = sonuc5;

            string query6 = "SELECT Telefon from CARI_TABLO where Cari_Adi=@cari_isim";
            SQLiteCommand cmd6 = new SQLiteCommand(query6, con2);
            cmd6.Parameters.AddWithValue("@cari_isim", secilmisItem);

            var result6 = cmd6.ExecuteScalar();
            string sonuc6 = result6.ToString();
            TelNotextBox.Text = sonuc6;

            string query7 = "SELECT Cari_id from CARI_TABLO where Cari_Adi=@cari_isim";
            SQLiteCommand cmd7 = new SQLiteCommand(query7, con2);
            cmd7.Parameters.AddWithValue("@cari_isim", secilmisItem);

            var result7 = cmd7.ExecuteScalar();
            string sonuc7 = result7.ToString();
            CariIDtextBox.Text = sonuc7;

            CariListBox.Enabled = false;
            GuncelleButon.Enabled = true;
            TemizleButon.Enabled = true;

            con2.Close();
        }
        //MÜŞTERİ BİLGİLERİNİ GÜNCELLEYECEK BUTONUN YAPACAĞI İŞLEMLER
        private void GuncelleButon_Click(object sender, EventArgs e)
        {
            try
            {
                string dbconstring3 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con3 = new SQLiteConnection(myBuilder3.ConnectionString);
                con3.Open();

                string secilmisItem = CariIDtextBox.Text;

                if (CariTipcomboBox.Text == "Müşteri")
                {
                    if (CariAdtextBox.Text == "" || TcNotextBox.Text=="" || TelNotextBox.Text=="")
                    {
                        MessageBox.Show("Lütfen gerekli alanları doldurunuz");
                    }
                    else
                    {
                        SQLiteCommand cmd8 = new SQLiteCommand(con3);
                        cmd8.CommandText = ("Update CARI_TABLO Set Cari_Adi = @cari_isim, TC_No = @cari_tc, Telefon = @cari_tel WHERE Cari_id = @c_id");
                        cmd8.Parameters.AddWithValue("@cari_isim", CariAdtextBox.Text);
                        cmd8.Parameters.AddWithValue("@cari_tc", TcNotextBox.Text);
                        cmd8.Parameters.AddWithValue("@cari_tel", TelNotextBox.Text);
                        cmd8.Parameters.AddWithValue("@c_id", secilmisItem);

                        int a = cmd8.ExecuteNonQuery();

                        if (a == 1)
                        {
                         
                        }
                        else MessageBox.Show("Güncelleme Başarısız");
                    }
                    
                }

                if (CariTipcomboBox.Text == "Satıcı")
                {
                    if (CariAdtextBox.Text == "" || VergiNotextBox.Text == "" || TelNotextBox.Text == "" || VergiDairesitextBox.Text=="" || KurumAditextBox.Text=="")
                    {
                        MessageBox.Show("Lütfen gerekli alanları doldurunuz");
                    }
                    else
                    {
                        SQLiteCommand cmd9 = new SQLiteCommand(con3);
                        cmd9.CommandText = ("Update CARI_TABLO Set Cari_Adi = @cari_isim, Vergi_No = @cari_vkno, Vergi_Dairesi = @cari_vdairesi, Kurum_Adi=@cari_kurumadi, Telefon = @cari_tel WHERE Cari_id = @c_id");
                        cmd9.Parameters.AddWithValue("@cari_isim", CariAdtextBox.Text);
                        cmd9.Parameters.AddWithValue("@cari_vkno", VergiNotextBox.Text);
                        cmd9.Parameters.AddWithValue("@cari_vdairesi", VergiDairesitextBox.Text);
                        cmd9.Parameters.AddWithValue("@cari_kurumadi", KurumAditextBox.Text);
                        cmd9.Parameters.AddWithValue("@cari_tel", TelNotextBox.Text);
                        cmd9.Parameters.AddWithValue("@c_id", secilmisItem);


                        int i = cmd9.ExecuteNonQuery();

                        if (i == 1)
                        {
                            
                        }
                        else MessageBox.Show("Güncelleme Başarısız");
                    }
                    
                }

                ListBoxGuncelle();
                Temizle();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        //TEMİZLE FONKSİYONU
        private void Temizle()
        {
            CariAdtextBox.ReadOnly = true;
            TcNotextBox.ReadOnly = true;
            TelNotextBox.ReadOnly = true;
            VergiNotextBox.ReadOnly = true;
            VergiDairesitextBox.ReadOnly = true;
            KurumAditextBox.ReadOnly = true;

            CariAdtextBox.Text = ""; // SORUN ÇIKARSA BU SATIRI KALDIR ******************
            TcNotextBox.Text = "";
            VergiNotextBox.Text = "";
            VergiDairesitextBox.Text = "";
            KurumAditextBox.Text = "";
            CariTipcomboBox.Text = "";
            TelNotextBox.Text = "";
            CariIDtextBox.Text = "";

            CariListBox.Enabled = true;
            GuncelleButon.Enabled = false;
            TemizleButon.Enabled = false;
        }
        private void TemizleButon_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        //SEÇİLEN MÜŞTERİNİN SATIŞLARINI GETİRECEK BUTONUN YAPACAĞI İŞLEMLER
        private void SatisGetirButon_Click(object sender, EventArgs e)
        {
            List<string> liste111 = new List<string>();
            List<int> liste222 = new List<int>();
            string dbconstring4 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con3 = new SQLiteConnection(myBuilder4.ConnectionString);
            con3.Open();

            string secilenkisi = CariListBox2.GetItemText(CariListBox2.SelectedItem);

            string query9 = "SELECT Cari_id from CARI_TABLO where Cari_Adi=@cari_isim";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con3);
            cmd9.Parameters.AddWithValue("@cari_isim", secilenkisi);

            var result9 = cmd9.ExecuteScalar();
            int sonuc9 = Convert.ToInt32(result9);

            string query10 = "SELECT Fatura_id FROM FATURA WHERE Cari_id = @cari_id";
            SQLiteCommand cmd10 = new SQLiteCommand(query10, con3);
            cmd10.Parameters.AddWithValue("@cari_id", sonuc9);

            List<string> liste = new List<string>();
            SQLiteDataReader dr2 = cmd10.ExecuteReader();
            while (dr2.Read())
            {
                liste.Add(dr2[0].ToString());
            }
            foreach(string fatura in liste)
            {
                string query11 = "SELECT Urun_id FROM FATURA_KALEM WHERE Fatura_id = @fatura_id";
                SQLiteCommand cmd11 = new SQLiteCommand(query11, con3);
                cmd11.Parameters.AddWithValue("@fatura_id", fatura);

                DataTable vt2 = new DataTable();
                SQLiteDataAdapter adaptdeneme = new SQLiteDataAdapter(cmd11);
                adaptdeneme.Fill(vt2);

                List<int> listeid2 = new List<int>();
                int i = 0;
                int sutun = vt2.Rows.Count;
                do
                {
                    listeid2.Add(Convert.ToInt32(vt2.Rows[i]["Urun_id"]));
                    i++;
                }
                while (i < sutun);
                liste222.AddRange(listeid2);
            }
            for (int x = 0; x < liste222.Count; x++)
            {
                string query12 = "SELECT Urun_Adi FROM URUN WHERE Urun_id = @urun_id";
                SQLiteCommand cmd12 = new SQLiteCommand(query12, con3);
                cmd12.Parameters.AddWithValue("@urun_id", liste222[x]);

                List<string> liste11 = new List<string>();
                SQLiteDataReader dr21 = cmd12.ExecuteReader();
                while (dr21.Read())
                {
                    liste11.Add(dr21[0].ToString());
                    liste111.AddRange(liste11);
                }

            }
            EskiSatislarlistBox.DisplayMember = "Urun_Adi";
            EskiSatislarlistBox.DataSource = liste111;
        }
        private void CariListBox2_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void modDegistirButon1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;

            groupBox2.Visible = !groupBox2.Visible;
        }
        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MusteriBilgiForm_Load(object sender, EventArgs e)
        {
            TcNotextBox.MaxLength = 11;
            timer1.Start();
            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);
            con.Open();
            string sorgu1 = "SELECT Cari_Adi from CARI_TABLO WHERE Cari_Tip = 'Müşteri'";
            SQLiteCommand komut1 = new SQLiteCommand(sorgu1, con);

            DataTable vt1 = new DataTable();
            SQLiteDataAdapter adapt1 = new SQLiteDataAdapter(komut1);
            adapt1.Fill(vt1);
            DataTable vt2 = new DataTable();
            SQLiteDataAdapter adapt2 = new SQLiteDataAdapter(komut1);
            adapt2.Fill(vt2);

            CariListBox2.DisplayMember = "Cari_Adi";
            CariListBox2.DataSource = vt2;

            con.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();
            label10.Text = DateTime.Now.ToLongTimeString();
        }

        private void CariAdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar));
        }

        private void VergiNotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TcNotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void VergiDairesitextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar));
        }

        private void TelNotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}