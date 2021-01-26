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
    public partial class AlisForm : Form
    {
        public AlisForm()
        {
            InitializeComponent();
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        public void KontrolEt()
        {
            //numericUpDownAdet.Value = 0;
            checkBox1.Checked = false;
            labelUrunAdi.Text = "";
            labelKDVOran.Text = "";
            labelFiyat.Text = "";

            string UrunAdi = "";
            string Fiyat = "";
            string KDVOran = "";
            string urunid = "";

            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con2 = new SQLiteConnection(myBuilder.ConnectionString);
            con2.Open();

            string query2 = "SELECT * from URUN where Barkod_No=@barkodd";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@barkodd", textBoxBarkod.Text);

            List<string> liste = new List<string>();
            SQLiteDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                liste.Add(dr2[2].ToString());
            }
            dr2.Close();
            cmd2.Dispose();

            if (liste.Contains(textBoxBarkod.Text))
            {
                buttonEkle.Enabled = true;
                buttonTemizle.Enabled = true;
                con2.Close();
            }
            else if (textBoxBarkod.Text == "")
            {
                buttonEkle.Enabled = true;
                buttonTemizle.Enabled = false;
                buttonUrunSil.Enabled = false;
                buttonSifirla.Enabled = false;
                con2.Close();
            }
            else
            {
                buttonEkle.Enabled = true;
                buttonTemizle.Enabled = false;
                buttonUrunSil.Enabled = false;
                buttonSifirla.Enabled = false;
                con2.Close();
            }

            string dbconstring2 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder2.ConnectionString);
            con.Open();

            string query = "SELECT * from URUN where Barkod_No=@barkod";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@barkod", textBoxBarkod.Text);

            List<string> liste3 = new List<string>();

            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                liste3.Add(dr[2].ToString());
                urunid = dr[0].ToString();
                UrunAdi = dr[1].ToString();
                Fiyat = dr[12].ToString();
                KDVOran = dr[11].ToString();

            }
            dr.Close();
            cmd.Dispose();

            if (liste3.Contains(textBoxBarkod.Text))
            {
                con.Close();
                labelUrunAdi.Visible = true;
                labelKDVOran.Visible = true;
                labelFiyat.Visible = true;
                labelUrunid.Visible = true;
                labelUrunAdi.Text = UrunAdi;
                labelKDVOran.Text = KDVOran;
                labelFiyat.Text = Fiyat;
                labelUrunid.Text = urunid;
                buttonEkle.Enabled = true;
                buttonTemizle.Enabled = true;
            }
            else
            {
                MessageBox.Show("Böyle bir ürün bulunamadı , yeni ürün girişi sayfasına yönlendiriliyorsunuz...");
                Form8 f8 = new Form8();
                f8.ShowDialog();
                con.Close();
            }
        }
        public void Temizle()
        {
            buttonUrunKontrol.Enabled = true;
            textBoxBarkod.Text = "";
            numericUpDownAdet.Value = 1;
            labelUrunid.Text = "";
            labelAdet.Text = "";
            labelUrunAdi.Text = "";
            labelKDVOran.Text = "";
            labelFiyat.Text = "";
            buttonEkle.Enabled = true;
            buttonTemizle.Enabled = false;
            buttonSifirla.Enabled = false;
            buttonUrunSil.Enabled = false;
            dataGridView1.Rows.Clear();
            buttonFaturaOnizle.Enabled = false;
            textBoxVergiNo.Text = "";
            comboBoxOdemeYontemi.Text = "Nakit";
            labelVergiNo.Text = "";
            labelOdemeTuru.Text = "";
            labelSaticiIsim.Text = "";
            labelSaticiTel.Text = "";
            labelSaticiKurumadi.Text = "";
            labelSaticiVergidairesi.Text = "";
            labelSaticiId.Text = "";
            textSaticiIsim.Text = "";
            textSaticiKurumAdi.Text = "";
            textSaticiTel.Text = "";
            textSaticiVergiDairesi.Text = "";
            textSaticiVergiNo.Text = "";
            comboBoxOdemeYontemi2.Text = "Nakit";
            SaticiEkleme.Visible = false;
            FaturaOnizleme.Items.Clear();
            buttonFaturaOlustur.Enabled = false;
            textBoxFiyatDegis.Text = "";
            checkBox1.Checked = false;
        }
        private void buttonUrunKontrol_Click(object sender, EventArgs e)
        {
            KontrolEt();
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            KontrolEt();

            if (labelSaticiIsim.Text == "" || labelSaticiTel.Text == "" || labelVergiNo.Text == "" || labelOdemeTuru.Text == "" || labelSaticiVergidairesi.Text == "" || labelSaticiKurumadi.Text == "" || comboBoxOdemeYontemi.Text == "")
            {
                buttonFaturaOnizle.Enabled = false;
            }
            else
            {
                buttonFaturaOnizle.Enabled = true;
            }
            if (labelKDVOran.Text == "" || numericUpDownAdet.Value==0)
            {
                MessageBox.Show("Ürün girişi yapılmadı");
            }
            else
            {
                labelAdet.Text = Convert.ToString(numericUpDownAdet.Value);
                double adet1 = Convert.ToDouble(labelAdet.Text);
                double kdvoran1 = Convert.ToDouble(labelKDVOran.Text);
                double netfiyat1 = Convert.ToDouble(labelFiyat.Text) * adet1;
                double kdvfiyat1 = kdvoran1 * netfiyat1;
                double brutfiyat1 = netfiyat1 + kdvfiyat1;

                string brut = brutfiyat1.ToString("0.##");
                string kdvfiyat = kdvfiyat1.ToString("0.##");
                string netfiyat = netfiyat1.ToString("0.##");

                dataGridView1.Rows.Add(labelUrunid.Text, labelUrunAdi.Text, labelAdet.Text, labelKDVOran.Text, netfiyat, kdvfiyat, brut);
                buttonSifirla.Enabled = true;
                buttonUrunSil.Enabled = true;
            }
            numericUpDownAdet.Value = 1;
            checkBox1.Checked = false;
            textBoxBarkod.Text = "";
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            labelUrunAdi.Text = "";
            textBoxBarkod.Text = "";
            numericUpDownAdet.Value = 1; ;
            labelKDVOran.Text = "";
            labelFiyat.Text = "";
            buttonEkle.Enabled = true;
            labelUrunid.Text = "";
            textBoxFiyatDegis.Text = "";
            checkBox1.Checked = false;
        }
        private void buttonSifirla_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            buttonEkle.Enabled = true ;
            buttonTemizle.Enabled = false;
            buttonSifirla.Enabled = false;
            buttonUrunSil.Enabled = false;
            labelUrunAdi.Text = "";
            textBoxBarkod.Text = "";
            numericUpDownAdet.Value = 1; ;
            labelKDVOran.Text = "";
            labelFiyat.Text = "";
            labelUrunid.Text = "";
            buttonFaturaOnizle.Enabled = false;
            textBoxFiyatDegis.Text = "";
            checkBox1.Checked = false;
        }
        private void buttonUrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int selectedIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selectedIndex);
                dataGridView1.Refresh();
                checkBox1.Checked = false;
                //buttonUrunSil.Enabled = false;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                labelUrunAdi.Text = "";
                textBoxBarkod.Text = "";
                numericUpDownAdet.Value = 1; ;
                labelKDVOran.Text = "";
                labelFiyat.Text = "";
                buttonEkle.Enabled = true;
                labelUrunid.Text = "";
                buttonTemizle.Enabled = false;
                buttonSifirla.Enabled = false;
                textBoxFiyatDegis.Text = "";
                checkBox1.Checked = false;
            }
        }
        private void buttonFaturaOnizle_Click(object sender, EventArgs e)
        {
            FaturaOnizleme.Items.Clear();
            buttonFaturaOlustur.Enabled = true;
            FaturaOnizleme.Items.Clear();
            FaturaOnizleme.Items.Add(labelSaticiIsim.Text + "---" + labelVergiNo.Text + "---" + labelSaticiTel.Text + "---" + labelOdemeTuru.Text + "---" + labelSaticiVergidairesi.Text);

            string yazi;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                yazi = "";
                for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    if (j == 0)
                    {
                        yazi = yazi + dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        yazi = yazi + "---" + dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                FaturaOnizleme.Items.Add(yazi);
            }
        }
        private void buttonSaticiOnayla_Click(object sender, EventArgs e)
        {
            string isim = "";
            string telefon = "";
            string vergidairesi = "";
            string kurumadi = "";
            string vergino = "";
            string odemeyontemi = "";
            string saticiId = "";

            string dbconstring3 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con4 = new SQLiteConnection(myBuilder3.ConnectionString);
            con4.Open();

            string query4 = "SELECT * from CARI_TABLO where Vergi_No=@vergino";
            SQLiteCommand cmd4 = new SQLiteCommand(query4, con4);
            cmd4.Parameters.AddWithValue("@vergino", textBoxVergiNo.Text);

            List<string> liste2 = new List<string>();
            SQLiteDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                liste2.Add(dr4[2].ToString());
                isim = dr4[1].ToString();
                telefon = dr4[7].ToString();
                kurumadi = dr4[5].ToString();
                vergidairesi = dr4[4].ToString();
                vergino = dr4[2].ToString();
                odemeyontemi = comboBoxOdemeYontemi.Text;
                saticiId = dr4[0].ToString();
            }
            dr4.Close();
            cmd4.Dispose();

            if (liste2.Contains(textBoxVergiNo.Text))
            {con4.Close();

                labelSaticiIsim.Visible = true;
                labelSaticiTel.Visible = true;
                labelSaticiVergidairesi.Visible = true;
                labelSaticiKurumadi.Visible = true;
                labelOdemeTuru.Visible = true;
                labelVergiNo.Visible = true;

                labelSaticiTel.Text = telefon;
                labelSaticiIsim.Text = isim;
                labelSaticiKurumadi.Text = kurumadi;
                labelSaticiVergidairesi.Text = vergidairesi;
                labelVergiNo.Text = vergino;
                labelOdemeTuru.Text = odemeyontemi;
                labelSaticiId.Text = saticiId;
            }
            else if(textBoxVergiNo.Text=="" || comboBoxOdemeYontemi.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
            else
            {
                MessageBox.Show("Böyle bir satıcı kaydı bulunmuyor, lütfen yeni kayıt oluşturun.");
                SaticiEkleme.Visible = true;
                con4.Close();
                textBoxVergiNo.Text = "";
                comboBoxOdemeYontemi.SelectedIndex = -1;
                labelSaticiIsim.Text = "";
                labelSaticiTel.Text = "";
                labelSaticiVergidairesi.Text = "";
                labelSaticiKurumadi.Text = "";
                labelOdemeTuru.Text = "";
                labelVergiNo.Text = "";
            }

            if (dataGridView1.Rows.Count == 0)
            {
                buttonFaturaOnizle.Enabled = false;
            }
            else
            {
                buttonFaturaOnizle.Enabled = true;
            }
        }
        private void buttonSaticiEkle_Click(object sender, EventArgs e)
        {
            if (textSaticiIsim.Text==""|| textSaticiVergiNo.Text == "" || textSaticiVergiDairesi.Text == "" || textSaticiTel.Text == "" || textSaticiKurumAdi.Text == "" || comboBoxOdemeYontemi2.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else
            {
                textBoxVergiNo.Text = textSaticiVergiNo.Text;

                string dbconstring4 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con3 = new SQLiteConnection(myBuilder4.ConnectionString);
                con3.Open();
                SQLiteCommand cmd3 = new SQLiteCommand(con3);
                cmd3.CommandText = "INSERT INTO CARI_TABLO(Cari_Adi, Vergi_No, Cari_Tip, Telefon, Vergi_Dairesi, Kurum_Adi) VALUES(@isim, @vergino, 'Satıcı', @telefon, @kurumadi, @vergidairesi) ";
                cmd3.Parameters.AddWithValue("@isim", textSaticiIsim.Text);
                cmd3.Parameters.AddWithValue("@vergino", textSaticiVergiNo.Text);
                cmd3.Parameters.AddWithValue("@telefon", textSaticiTel.Text);
                cmd3.Parameters.AddWithValue("@vergidairesi", textSaticiVergiDairesi.Text);
                cmd3.Parameters.AddWithValue("@kurumadi", textSaticiKurumAdi.Text);
                cmd3.Prepare();
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Müşteri eklendi ve bilgileri müşteri ekranına aktarıldı.");
                textSaticiVergiNo.Text = textBoxVergiNo.Text;
                textSaticiIsim.Text = labelSaticiIsim.Text;
                textSaticiTel.Text = labelSaticiTel.Text;
                textSaticiKurumAdi.Text = labelSaticiKurumadi.Text;
                textSaticiVergiDairesi.Text = labelSaticiVergidairesi.Text;
                comboBoxOdemeYontemi2.Text = comboBoxOdemeYontemi.Text;
                SaticiEkleme.Visible = false;
                labelSaticiIsim.Visible = true;
                labelSaticiTel.Visible = true;
                labelSaticiKurumadi.Visible = true;
                labelSaticiVergidairesi.Visible = true;
                labelOdemeTuru.Visible = true;
                labelVergiNo.Visible = true;
            }
            
        }
        private void buttonFaturaOlustur_Click(object sender, EventArgs e)
        {
            string dbconstring5 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder5 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring5 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con5 = new SQLiteConnection(myBuilder5.ConnectionString);
            con5.Open();

            Random r = new Random();
            int faturaNo = r.Next(1000000, 9999999);
            string faturaTarih = DateTime.Now.ToString("yyyy-MM-dd");
            int cariId = Convert.ToInt32(labelSaticiId.Text);
            string faturaTip = "Alış";
            double KDV_Toplam1 = 0;
            string odemeyontemi = labelOdemeTuru.Text;

            for (int a = 0; a <= dataGridView1.RowCount - 1; a++)
            {
                KDV_Toplam1 += Convert.ToDouble(dataGridView1.Rows[a].Cells[5].Value.ToString());
            }

            string KDV_Toplam2 = KDV_Toplam1.ToString();

            double net_Toplam1 = 0;

            for (int b = 0; b <= dataGridView1.RowCount - 1; b++)
            {
                net_Toplam1 += Convert.ToDouble(dataGridView1.Rows[b].Cells[4].Value.ToString());
            }

            string net_Toplam2 = net_Toplam1.ToString();

            string genel_Toplam = (net_Toplam1 + KDV_Toplam1).ToString();

            SQLiteCommand cmd5 = new SQLiteCommand(con5);
            cmd5.CommandText = ("INSERT INTO FATURA (Fatura_No, Fatura_Tarih, Cari_id, Fatura_Tipi, KDV_Toplami, Net_Fiyat, Toplam, Odeme_Yontemi) VALUES (@faturano, @faturatarih, @cariid, @faturatip, @kdvtoplam2, @nettoplam2, @geneltoplam, @odemeyontemi);");
            cmd5.Parameters.AddWithValue("@faturano", faturaNo);
            cmd5.Parameters.AddWithValue("@faturatarih", faturaTarih);
            cmd5.Parameters.AddWithValue("@cariid", cariId);
            cmd5.Parameters.AddWithValue("@faturatip", faturaTip);
            cmd5.Parameters.AddWithValue("@kdvtoplam2", KDV_Toplam2);
            cmd5.Parameters.AddWithValue("@nettoplam2", net_Toplam2);
            cmd5.Parameters.AddWithValue("@geneltoplam", genel_Toplam);
            cmd5.Parameters.AddWithValue("@odemeyontemi", odemeyontemi);

            /*int x = cmd5.ExecuteNonQuery();

            if (x == 1)
            {
                MessageBox.Show("Güncelleme tamamlandı");
            }
            else MessageBox.Show("Güncelleme Başarısız");*/
            cmd5.ExecuteNonQuery();

            string query6 = "SELECT Fatura_id from FATURA where Fatura_No=@faturano";
            SQLiteCommand cmd6 = new SQLiteCommand(query6, con5);
            cmd6.Parameters.AddWithValue("@faturano", faturaNo);

            var result6 = cmd6.ExecuteScalar();
            int sonuc6 = Convert.ToInt32(result6);

            con5.Close();

            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                int urunId = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                string urunAdi = dataGridView1.Rows[i].Cells[1].Value.ToString();
                int adet = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
                string kdvOrani = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string netFiyat = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string kdvFiyat = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string brutFiyat = dataGridView1.Rows[i].Cells[6].Value.ToString();

                string dbconstring6 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder6 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring6 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con4 = new SQLiteConnection(myBuilder6.ConnectionString);
                con4.Open();

                SQLiteCommand cmd4 = new SQLiteCommand(con4);
                cmd4.CommandText = ("INSERT INTO FATURA_KALEM (Fatura_id, Urun_id, Urun_Adi, NetFiyat, KDV_Orani, KDV_Fiyati, Brut_Fiyat, Miktar) VALUES (@faturaid, @urunid, @urunadi, @netfiyat, @kdvorani, @kdvfiyati, @brutfiyati, @adet);");
                cmd4.Parameters.AddWithValue("@urunid", urunId);
                cmd4.Parameters.AddWithValue("@netfiyat", netFiyat);
                cmd4.Parameters.AddWithValue("@kdvorani", kdvOrani);
                cmd4.Parameters.AddWithValue("@kdvfiyati", kdvFiyat);
                cmd4.Parameters.AddWithValue("@brutfiyati", brutFiyat);
                cmd4.Parameters.AddWithValue("@adet", adet);
                cmd4.Parameters.AddWithValue("@faturaid", sonuc6);
                cmd4.Parameters.AddWithValue("@urunadi", urunAdi);

                /*int a = cmd4.ExecuteNonQuery();

                if (a == 1)
                {
                    MessageBox.Show("Kalem " + (i + 1) + " faturaya eklendi");
                }
                else MessageBox.Show((i + 1) + " no'lu kalem faturaya eklenemedi"); */
                cmd4.ExecuteNonQuery();

                string query0 = "SELECT Stok_Bilgisi from URUN where Urun_id = @urunid";
                SQLiteCommand cmd0 = new SQLiteCommand(query0, con4);
                cmd0.Parameters.AddWithValue("@urunid", urunId);

                var result0 = cmd0.ExecuteScalar();
                int sonuc0 = Convert.ToInt32(result0);

                sonuc0 += adet;

                SQLiteCommand cmd10 = new SQLiteCommand(con4);
                cmd10.CommandText = ("Update URUN SET Stok_Bilgisi = @yenistok WHERE Urun_id = @urunid");
                cmd10.Parameters.AddWithValue("@yenistok", sonuc0);
                cmd10.Parameters.AddWithValue("@urunid", urunId);

                /*int b = cmd10.ExecuteNonQuery();

                if (b == 1)
                {
                    MessageBox.Show("Kalem " + (i + 1) + " stoğa eklendi");
                }
                else MessageBox.Show((i + 1) + " no'lu kalem stoğa eklenemedi");*/
                cmd10.ExecuteNonQuery();
                con4.Close();
                Temizle();
            }
        }
        private void AlisForm_Load(object sender, EventArgs e)
        {
            comboBoxOdemeYontemi.SelectedIndex = 1;
            comboBoxOdemeYontemi2.SelectedIndex = 1;
            timer1.Start();
            labelSaticiIsim.Text = "";
            textBoxFiyatDegis.Visible = false;
            buttonFiyatOnayla.Visible = false;
            if (dataGridView1.Rows.Count == 0 || labelSaticiIsim.Text == "" || labelSaticiTel.Text == "" || labelVergiNo.Text == "" || labelOdemeTuru.Text == "" || labelSaticiVergidairesi.Text == "" || labelSaticiKurumadi.Text == "")
            {
                buttonFaturaOnizle.Enabled = false;
            }
            else
            {
                buttonFaturaOnizle.Enabled = true;
            }

            labelUrunAdi.Visible = false;
            labelKDVOran.Visible = false;
            labelFiyat.Visible = false;
            buttonEkle.Enabled = true;
            buttonTemizle.Enabled = false;
            buttonSifirla.Enabled = false;
            buttonUrunSil.Enabled = false;
            SaticiEkleme.Visible = false;
            labelSaticiIsim.Visible = false;
            labelSaticiTel.Visible = false;
            labelSaticiVergidairesi.Visible = false;
            labelSaticiKurumadi.Visible = false;
            labelUrunid.Visible = false;
            labelOdemeTuru.Visible = false;
            labelVergiNo.Visible = false;
            buttonFaturaOlustur.Enabled = false;
            checkBox1.Checked = false;
        }
        private void FullTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxFiyatDegis.Visible = true;
                buttonFiyatOnayla.Visible = true;
                buttonEkle.Enabled=false; 
            }
            else
            {
                textBoxFiyatDegis.Visible = false;
                buttonFiyatOnayla.Visible = false;
                buttonEkle.Enabled = true;
            }
        }
        private void buttonFiyatOnayla_Click(object sender, EventArgs e)
        {
            KontrolEt();
            labelFiyat.Text = textBoxFiyatDegis.Text;
            buttonEkle.Enabled = false;
            checkBox1.Checked = true;
            if (labelSaticiIsim.Text == "" || labelSaticiTel.Text == "" || labelVergiNo.Text == "" || labelOdemeTuru.Text == "" || labelSaticiVergidairesi.Text == "" || labelSaticiKurumadi.Text == "" || comboBoxOdemeYontemi.Text == "")
            {
                buttonFaturaOnizle.Enabled = false;
            }
            else
            {
                buttonFaturaOnizle.Enabled = true;
            }
            if (labelKDVOran.Text == "" || numericUpDownAdet.Value == 0)
            {
                MessageBox.Show("Ürün girişi yapılmadı");
            }
            else
            {
                labelAdet.Text = Convert.ToString(numericUpDownAdet.Value);
                double adet1 = Convert.ToDouble(labelAdet.Text);
                double kdvoran1 = Convert.ToDouble(labelKDVOran.Text);
                double netfiyat1 = Convert.ToDouble(labelFiyat.Text) * adet1;
                double kdvfiyat1 = kdvoran1 * netfiyat1;
                double brutfiyat1 = netfiyat1 + kdvfiyat1;

                string brut = brutfiyat1.ToString("0.##");
                string kdvfiyat = kdvfiyat1.ToString("0.##");
                string netfiyat = netfiyat1.ToString("0.##");

                dataGridView1.Rows.Add(labelUrunid.Text, labelUrunAdi.Text, labelAdet.Text, labelKDVOran.Text, netfiyat, kdvfiyat, brut);
                buttonSifirla.Enabled = true;
                buttonUrunSil.Enabled = true;
            }
            numericUpDownAdet.Value = 1;
            textBoxFiyatDegis.Text = "";
            textBoxBarkod.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();
            label12.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxVergiNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textSaticiVergiNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textSaticiTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textSaticiIsim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar));
        }

        private void textBoxFiyatDegis_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
    }
}
