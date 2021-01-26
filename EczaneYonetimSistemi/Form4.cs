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
    public partial class SatisForm : Form
    {
        public SatisForm()
        {
            InitializeComponent();
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }

        public static int quantity1;
        public static int quantity2;
        public static int quantity3;
        // girilen barkodun kontrolü ve bilgilerinin ürün grubunda sağ kısma getirilmesini sağlayan fonksiyon
        public void KontrolEt()
        {
            checkBox1.Checked = false;
            string Birim = "";
            string UrunAdi = "";
            string ServisBirim = "";
            string ServisMiktar = "";
            string Fiyat = "";
            string KDVOran = "";
            string urunid = "";

            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con001 = new SQLiteConnection(myBuilder.ConnectionString);
            con001.Open();

            string query2 = "SELECT * from URUN where Barkod_No=@barkodd";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con001);
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
                con001.Close();
            }
            else if (textBoxBarkod.Text == "")
            {
                buttonEkle.Enabled = true;
                buttonTemizle.Enabled = false;
                buttonUrunSil.Enabled = false;
                buttonSifirla.Enabled = false;
                MessageBox.Show("Barkod alanı boş bırakılamaz.");
                con001.Close();
            }
            else
            {
                buttonEkle.Enabled = true;
                buttonTemizle.Enabled = false;
                buttonUrunSil.Enabled = false;
                buttonSifirla.Enabled = false;
                MessageBox.Show("Girdiğiniz barkod numarasıyla eşleşen bir ürün yok.");
                con001.Close();
            }

            string dbconstring2 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con002 = new SQLiteConnection(myBuilder2.ConnectionString);
            con002.Open();

            string query = "SELECT * from URUN where Barkod_No=@barkod";
            SQLiteCommand cmd = new SQLiteCommand(query, con002);
            cmd.Parameters.AddWithValue("@barkod", textBoxBarkod.Text);

            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                urunid = dr[0].ToString();
                UrunAdi = dr[1].ToString();
                Birim = dr[6].ToString();
                ServisBirim = dr[7].ToString();
                ServisMiktar = dr[9].ToString();
                Fiyat = dr[14].ToString();
                KDVOran = dr[11].ToString();
            }
            dr.Close();
            cmd.Dispose();
            con002.Close();

            labelBirim.Visible = true;
            labelUrunAdi.Visible = true;
            labelServisMiktari.Visible = true;
            labelServisBirim.Visible = true;
            labelKDVOran.Visible = true;
            labelFiyat.Visible = true;
            labelUrunid.Visible = true;

            labelUrunAdi.Text = UrunAdi;
            labelBirim.Text = Birim;
            labelServisBirim.Text = ServisBirim;
            labelServisMiktari.Text = ServisMiktar;
            labelKDVOran.Text = KDVOran;
            labelFiyat.Text = Fiyat;
            labelUrunid.Text = urunid;
        }

        // temizle fonksiyonu
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
            textBoxTCNo.Text = "99999999999";
            comboBoxOdemeYontemi.Text = "Nakit";
            labeltcno.Text = "";
            labelOdemeYontemi.Text = "";
            labelMusteriIsim.Text = "";
            labelMusteriTel.Text = "";
            labelMusteriId.Text = "";
            textBoxMusteriIsim.Text = "";
            textBoxMusteriTel.Text = "";
            textBoxMusteriTC.Text = "";
            comboBoxOdemeYontemi2.Text = "Nakit";
            MusteriEkleme.Visible = false;
            FaturaOnizleme.Items.Clear();
            labelBirim.Text = "";
            labelServisBirim.Text = "";
            labelServisMiktari.Text = "";
            buttonFaturaOlustur.Enabled = false;
            textBoxFiyatDegis.Text = "";
            checkBox1.Checked = false;
        }
        private void buttonUrunKontrol_Click(object sender, EventArgs e)
        {
            KontrolEt();
        }
        //barkodu girilen ürünü satış listesine ekleyen butonun yapacağı işlemler
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            KontrolEt();

            if (labelMusteriIsim.Text == "" || labelMusteriTel.Text == "" || labeltcno.Text == "" || labelOdemeYontemi.Text == "" || comboBoxOdemeYontemi.Text == "")
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
            textBoxBarkod.Text = "";
            checkBox1.Checked = false;
        }
        //listeyi sıfırla butonu
        private void buttonSifirla_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            buttonEkle.Enabled = true;
            buttonTemizle.Enabled = false;
            buttonSifirla.Enabled = false;
            buttonUrunSil.Enabled = false;
            labelBirim.Text = "";
            labelUrunAdi.Text = "";
            labelServisBirim.Text = "";
            labelServisMiktari.Text = "";
            textBoxBarkod.Text = "";
            numericUpDownAdet.Value = 1; ;
            labelKDVOran.Text = "";
            labelFiyat.Text = "";
            labelUrunid.Text = "";
            buttonFaturaOnizle.Enabled = false;
            textBoxFiyatDegis.Text = "";
            checkBox1.Checked = false;
        }
        //ürünler grubundaki temizle butonu
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            labelBirim.Text = "";
            labelUrunAdi.Text = "";
            labelServisBirim.Text = "";
            labelServisMiktari.Text = "";
            textBoxBarkod.Text = "";
            numericUpDownAdet.Value = 1; ;
            labelKDVOran.Text = "";
            labelFiyat.Text = "";
            buttonEkle.Enabled = true;
            labelUrunid.Text = "";
            textBoxFiyatDegis.Text = "";
            checkBox1.Checked = false;
        }
        //seçili ürünü sil butonu
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
                labelBirim.Text = "";
                labelUrunAdi.Text = "";
                labelServisBirim.Text = "";
                labelServisMiktari.Text = "";
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
        //tc no girilen müşterinin diğer bilgilerini alt kısma getirir
        private void buttonMusteriOnayla_Click(object sender, EventArgs e)
        {
            string isim = "";
            string telefon = "";
            string odemeyontemi = "";
            string tcno = "";
            string musteriId = "";


            string dbconstring3 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con003 = new SQLiteConnection(myBuilder3.ConnectionString);
            con003.Open();

            string query2 = "SELECT * from CARI_TABLO where TC_No=@tcno";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con003);
            cmd2.Parameters.AddWithValue("@tcno", textBoxTCNo.Text);



            List<string> liste = new List<string>();
            SQLiteDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                liste.Add(dr2[3].ToString());
                isim = dr2[1].ToString();
                telefon = dr2[7].ToString();
                tcno = dr2[3].ToString();
                odemeyontemi = comboBoxOdemeYontemi.Text;
                musteriId = dr2[0].ToString();
            }
            dr2.Close();
            cmd2.Dispose();

            if (liste.Contains(textBoxTCNo.Text))
            {
                con003.Close();

                labelMusteriIsim.Visible = true;
                labelMusteriTel.Visible = true;
                labeltcno.Visible = true;
                labelOdemeYontemi.Visible = true;

                labelMusteriTel.Text = telefon;
                labelMusteriIsim.Text = isim;
                labeltcno.Text = tcno;
                labelOdemeYontemi.Text = odemeyontemi;
                labelMusteriId.Text = musteriId;
            }
            else if (textBoxTCNo.Text == "" || comboBoxOdemeYontemi.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
            else
            {
                MessageBox.Show("Böyle bir müşteri kaydı bulunmuyor, lütfen yeni kayıt oluşturun.");
                MusteriEkleme.Visible = true;
                con003.Close();
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
        //tcsi girilen müşteri kayıtlarda yoksa açılan ekrandaki müşteri ekleme işlemleri
        private void buttonMusteriEkle_Click(object sender, EventArgs e)
        {
            if (textBoxMusteriIsim.Text=="" || textBoxMusteriTC.Text=="" || textBoxMusteriTel.Text=="" || comboBoxOdemeYontemi2.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız");
            }
            else
            {
                textBoxTCNo.Text = textBoxMusteriTC.Text;

                string dbconstring4 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con3 = new SQLiteConnection(myBuilder4.ConnectionString);
                con3.Open();
                SQLiteCommand cmd3 = new SQLiteCommand(con3);
                cmd3.CommandText = "INSERT INTO CARI_TABLO(Cari_Adi, TC_No, Cari_Tip, Telefon) VALUES(@isim, @tcno, 'Müşteri', @telefon) ";
                cmd3.Parameters.AddWithValue("@isim", textBoxMusteriIsim.Text);
                cmd3.Parameters.AddWithValue("@tcno", textBoxMusteriTC.Text);
                cmd3.Parameters.AddWithValue("@telefon", textBoxMusteriTel.Text);
                cmd3.Prepare();
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Müşteri eklendi ve bilgileri müşteri ekranına aktarıldı.");
                textBoxTCNo.Text = textBoxMusteriTC.Text;
                textBoxMusteriIsim.Text = labelMusteriIsim.Text;
                textBoxMusteriTel.Text = labelMusteriTel.Text;
                comboBoxOdemeYontemi2.Text = comboBoxOdemeYontemi.Text;
                MusteriEkleme.Visible = false;
                labelMusteriIsim.Visible = true;
                labelMusteriTel.Visible = true;
            }
            
        }
        //seçilen müşteri ve ürünlerin önizlemesini sağlar
        private void buttonFaturaOnizle_Click(object sender, EventArgs e)
        {
            FaturaOnizleme.Items.Clear();
            buttonFaturaOlustur.Enabled = true;
            FaturaOnizleme.Items.Clear();
            FaturaOnizleme.Items.Add(labelMusteriIsim.Text + "---" + textBoxTCNo.Text + "---" + labelMusteriTel.Text + "---" + comboBoxOdemeYontemi.Text);
            string yazi = "";
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
        //önizlenen faturada yanlışlık yoksa fatura oluşturur.
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
            int cariId =Convert.ToInt32(labelMusteriId.Text);
            string faturaTip = "Satış";
            double KDV_Toplam1 = 0;
            string odemeyontemi = labelOdemeYontemi.Text;

            for (int a = 0; a <= dataGridView1.RowCount - 1; a++)
            {
                KDV_Toplam1 += Convert.ToDouble(dataGridView1.Rows[a].Cells[5].Value.ToString());
            }

            string KDV_Toplam2 = KDV_Toplam1.ToString("0.##");

            double net_Toplam1 = 0;

            for (int b = 0; b <= dataGridView1.RowCount - 1; b++)
            {
                net_Toplam1 += Convert.ToDouble(dataGridView1.Rows[b].Cells[4].Value.ToString());
            }

            string net_Toplam2 = net_Toplam1.ToString("0.##");

            string genel_Toplam = (net_Toplam1 + KDV_Toplam1).ToString("0.##");
            // oluşturulan faturanın veritabanına eklenmesi
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
                MessageBox.Show("Fatura oluşturuldu");
            }
            else MessageBox.Show("Fatura Oluşturma Başarısız");*/
            cmd5.ExecuteNonQuery();

            string query6 = "SELECT Fatura_id from FATURA where Fatura_No=@faturano";
            SQLiteCommand cmd6 = new SQLiteCommand(query6, con5);
            cmd6.Parameters.AddWithValue("@faturano", faturaNo);

            var result6 = cmd6.ExecuteScalar();
            int sonuc6 = Convert.ToInt32(result6);
            con5.Close();

            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                int urunId =Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
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

                string query0 = "SELECT Stok_Bilgisi from URUN where Urun_id = @urunid";
                SQLiteCommand cmd0 = new SQLiteCommand(query0, con4);
                cmd0.Parameters.AddWithValue("@urunid", urunId);

                var result0 = cmd0.ExecuteScalar();
                int sonuc0 = Convert.ToInt32(result0);

                sonuc0 -= adet;
                //satılan ürünün yeterli stoğu var mı kontrolü
                if(sonuc0 > 0)
                {
                    SQLiteCommand cmd10 = new SQLiteCommand(con4);
                    cmd10.CommandText = ("Update URUN SET Stok_Bilgisi = @yenistok WHERE Urun_id = @urunid");
                    cmd10.Parameters.AddWithValue("@yenistok", sonuc0);
                    cmd10.Parameters.AddWithValue("@urunid", urunId);

                    /*int b = cmd10.ExecuteNonQuery();

                    if (b == 1)
                    {
                        MessageBox.Show("Kalem " + (i + 1) + " stoktan düşüldü");
                    }
                    else MessageBox.Show((i + 1) + " no'lu stoktan düşülemedi");*/

                    cmd10.ExecuteNonQuery();
                }

                else
                {
                    MessageBox.Show("Kalem " + (i+1) +" Yetersiz Stok");
                    SQLiteCommand cmd11 = new SQLiteCommand(con4);
                    cmd11.CommandText = ("DELETE FROM FATURA WHERE Fatura_id = @faturaid");
                    cmd11.Parameters.AddWithValue("@faturaid", sonuc6);
                    int c = cmd11.ExecuteNonQuery();

                    /*if (c == 1)
                    {
                        MessageBox.Show("Oluşturulan Fatura silindi");
                    }
                    else MessageBox.Show("Oluşturulan Fatura silinemedi"); */
                    return;
                }
                //faturanın kalemlerinin veritabanına kaydedilmesi
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
                cmd4.ExecuteNonQuery();

                /*int a = cmd4.ExecuteNonQuery();

                /*if (a == 1)
                {
                    MessageBox.Show("Kalem " + (i+1) + " faturaya eklendi");
                }
                else MessageBox.Show((i+1) + " no'lu kalem faturaya eklenemedi");*/
                con4.Close();
            }
            labelYolla1.Text = cariId.ToString();
            labelYolla2.Text = faturaNo.ToString();

            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con15 = new SQLiteConnection(myBuilder.ConnectionString);
            con15.Open();
            string query15 = "SELECT Fatura_id from FATURA where Fatura_No = @faturano";
            SQLiteCommand cmd15 = new SQLiteCommand(query15, con15);
            cmd15.Parameters.AddWithValue("@faturano", labelYolla2.Text);

            var result15 = cmd15.ExecuteScalar();
            string sonuc15 = result15.ToString();

            con15.Close();
            labelYolla3.Text = sonuc15;

            quantity1 = Convert.ToInt32(labelYolla1.Text);
            quantity2 = Convert.ToInt32(labelYolla2.Text);
            quantity3 = Convert.ToInt32(labelYolla3.Text);

            faturaForm f14 = new faturaForm();
            f14.ShowDialog();

            Temizle();
        }
        private void SatisForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            comboBoxOdemeYontemi.SelectedIndex = 1;
            comboBoxOdemeYontemi2.SelectedIndex = 1;
            timer1.Start();
            labelMusteriIsim.Text = "";
            textBoxMusteriTC.MaxLength = 11;
            textBoxTCNo.MaxLength = 11;
            textBoxFiyatDegis.Visible = false;
            buttonFiyatOnayla.Visible = false;

            if (dataGridView1.Rows.Count == 0 || labelMusteriIsim.Text == "" || labelMusteriTel.Text == "" || labeltcno.Text == "" || labelOdemeYontemi.Text == "")
            {
                buttonFaturaOnizle.Enabled = false;
            }
            else
            {
                buttonFaturaOnizle.Enabled = true;
            }

            labelBirim.Visible = false;
            labelUrunAdi.Visible = false;
            labelUrunid.Visible = false;
            labelServisMiktari.Visible = false;
            labelServisBirim.Visible = false;
            labelKDVOran.Visible = false;
            labelFiyat.Visible = false;
            buttonEkle.Enabled = true;
            buttonTemizle.Enabled = false;
            buttonSifirla.Enabled = false;
            buttonUrunSil.Enabled = false;
            MusteriEkleme.Visible = false;
            labelMusteriIsim.Visible = false;
            labelMusteriTel.Visible = false;
            labeltcno.Visible = false;
            labelOdemeYontemi.Visible = false;
            labelMusteriId.Visible = false;
            buttonFaturaOlustur.Enabled = false;
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
                buttonEkle.Enabled = false;
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
            if (labelMusteriIsim.Text == "" || labelMusteriTel.Text == "" || labeltcno.Text == "" || labelOdemeYontemi.Text == "" || comboBoxOdemeYontemi.Text == "")
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
        private void textBoxFiyatDegis_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongDateString();
            label10.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTCNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxMusteriTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxMusteriIsim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar));
        }

        private void textBoxMusteriTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
