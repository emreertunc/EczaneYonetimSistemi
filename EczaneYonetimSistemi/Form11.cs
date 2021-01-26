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
    public partial class IadeForm : Form
    {
        public IadeForm()
        {
            InitializeComponent();
            string dbconstring = GetExecutingDirectoryName();
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }

        public static int quantity4;
        public static int quantity5;
        public static int quantity6;
        public void KontrolEt()
        {
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
                buttonTemizle.Enabled = false;
                buttonUrunSil.Enabled = false;
                buttonSifirla.Enabled = false;
                MessageBox.Show("Barkod alanı boş bırakılamaz.");
                con2.Close();
            }
            else
            {
                buttonTemizle.Enabled = false;
                buttonUrunSil.Enabled = false;
                buttonSifirla.Enabled = false;
                MessageBox.Show("Girdiğiniz barkod numarasıyla eşleşen bir ürün yok.");
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

                MessageBox.Show("Böyle bir ürün bulunamadı.");
            }
        }
        private void buttonUrunKontrol_Click(object sender, EventArgs e)
        {
            KontrolEt();
        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if(textBoxBarkod.Text == "" || numericUpDownAdet.Value == 0)
            {
                MessageBox.Show("Hatalı bir giriş yaptınız.");
            }
            else
            {
                KontrolEt();

                if (labelSaticiIsim.Text == "" || labelSaticiTel.Text == "" || labelVergiNo.Text == "" || labelOdemeTuru.Text == "" || comboBoxOdemeYontemi.Text == "")
                {
                    buttonFaturaOnizle.Enabled = false;
                }
                else
                {
                    buttonFaturaOnizle.Enabled = true;
                }
                if (labelKDVOran.Text == "")
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
            }
            numericUpDownAdet.Value = 1;
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
        }
        private void buttonSifirla_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            buttonEkle.Enabled = true;
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
        }
        private void buttonUrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int selectedIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selectedIndex);
                dataGridView1.Refresh();
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
            }
        }
        private void buttonFaturaOnizle_Click(object sender, EventArgs e)
        {
            FaturaOnizleme.Items.Clear();
            buttonFaturaOlustur.Enabled = true;

            FaturaOnizleme.Items.Add(labelSaticiIsim.Text + "---" + labelVergiNo.Text + "---" + labelSaticiTel.Text + "---" + labelOdemeTuru.Text);

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
        private void FullTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void buttonFaturaOlustur_Click(object sender, EventArgs e)
        {
            string dbconstring4 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con5 = new SQLiteConnection(myBuilder4.ConnectionString);
            con5.Open();

            Random r = new Random();
            int faturaNo = r.Next(1000000, 9999999);
            string faturaTarih = DateTime.Now.ToString("yyyy-MM-dd");
            int cariId = Convert.ToInt32(labelSaticiId.Text);
            string faturaTip = "İade";
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

            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                int urunId = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                string urunAdi = dataGridView1.Rows[i].Cells[1].Value.ToString();
                int adet = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
                string kdvOrani = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string netFiyat = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string kdvFiyat = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string brutFiyat = dataGridView1.Rows[i].Cells[6].Value.ToString();

                string dbconstring5 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder5 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring5 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con4 = new SQLiteConnection(myBuilder5.ConnectionString);
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
                else MessageBox.Show((i + 1) + " no'lu kalem faturaya eklenemedi");*/

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

            quantity4 = Convert.ToInt32(labelYolla1.Text);
            quantity5 = Convert.ToInt32(labelYolla2.Text);
            quantity6 = Convert.ToInt32(labelYolla3.Text);
            iadeFormFatura f16 = new iadeFormFatura();
            f16.ShowDialog();
            Temizle();
        }
        private void IadeForm_Load(object sender, EventArgs e)
        {
            comboBoxOdemeYontemi.SelectedIndex = 1;
            timer1.Start();
            buttonFaturaOlustur.Enabled = false;
            labelSaticiIsim.Text = "";
            if (dataGridView1.Rows.Count == 0 || labelSaticiIsim.Text == "" || labelSaticiTel.Text == "" || labelVergiNo.Text == "" || labelOdemeTuru.Text == "")
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
            
            buttonTemizle.Enabled = false;
            buttonSifirla.Enabled = false;
            buttonUrunSil.Enabled = false;

            labelSaticiIsim.Visible = false;
            labelSaticiTel.Visible = false;
            labelUrunid.Visible = false;
            labelOdemeTuru.Visible = false;
            labelVergiNo.Visible = false;
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
            buttonFaturaOlustur.Enabled = false;
            comboBoxOdemeYontemi.Text = "Nakit";
            labelVergiNo.Text = "";
            labelOdemeTuru.Text = "";
            labelSaticiIsim.Text = "";
            labelSaticiTel.Text = "";
            labelSaticiId.Text = "";
            textBoxFaturaNo.Text = "";
            FaturaOnizleme.Items.Clear();
            dataGridView2.DataSource = null;
            textBoxUrunAdi.Text = "";
        }
        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongDateString();
            label6.Text = DateTime.Now.ToLongTimeString();
        }
        private void buttonFaturaNo_Click(object sender, EventArgs e)
        {
            textBoxBarkod.Text = "";
            numericUpDownAdet.Value = 1;
            DataTable dt444 = new DataTable();
            string cariid = "";
            string isim2 = "";
            string telefon2 = "";
            string odemeyontemi2 = "";
            string tcno2 = "";
            string musteriId2 = "";
            if (textBoxFaturaNo.Text == "" || comboBoxOdemeYontemi.Text == "")
            {
                MessageBox.Show("Alanlar Boş Bırakılamaz.");
            }
            else
            {
                string dbconstring44 = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder44 = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring44 + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con44 = new SQLiteConnection(myBuilder44.ConnectionString);
                con44.Open();
                string query44 = "SELECT Fatura_No, Cari_id from FATURA WHERE Fatura_No = @faturano AND Fatura_Tipi='Satış'";
                SQLiteCommand cmd44 = new SQLiteCommand(query44, con44);
                cmd44.Parameters.AddWithValue("@faturano", Convert.ToInt64(textBoxFaturaNo.Text));

                List<string> liste44 = new List<string>();
                SQLiteDataReader dr44 = cmd44.ExecuteReader();
                while (dr44.Read())
                {
                    liste44.Add(dr44[0].ToString());
                    cariid = dr44[1].ToString();
                }

                if (liste44.Contains(textBoxFaturaNo.Text))
                {
                    string query45 = "SELECT * from CARI_TABLO WHERE Cari_id = @cariid";
                    SQLiteCommand cmd45 = new SQLiteCommand(query45,con44);
                    cmd45.Parameters.AddWithValue("@cariid",cariid);
                    SQLiteDataReader dr45 = cmd45.ExecuteReader();
                    while (dr45.Read())
                    {
                        isim2 = dr45[1].ToString();
                        telefon2 = dr45[7].ToString();
                        tcno2 = dr45[3].ToString();
                        odemeyontemi2 = comboBoxOdemeYontemi.Text;
                        musteriId2 = dr45[0].ToString();


                        labelSaticiIsim.Visible = true;
                        labelSaticiTel.Visible = true;
                        labelOdemeTuru.Visible = true;
                        labelVergiNo.Visible = true;

                        labelSaticiTel.Text = telefon2;
                        labelSaticiIsim.Text = isim2;
                        labelVergiNo.Text = tcno2;
                        labelOdemeTuru.Text = odemeyontemi2;
                        labelSaticiId.Text = musteriId2;

                        if (labelUrunid.Text == "" || labelUrunAdi.Text == "" || labelKDVOran.Text == "" || labelFiyat.Text == "" || labelAdet.Text == "")
                        {
                            buttonFaturaOnizle.Enabled = false;
                        }
                        else
                        {
                            buttonFaturaOnizle.Enabled = true;
                        }

                        if (textBoxFaturaNo.Text == "")
                        {
                        }
                        else
                        {
                            string dbconstring440 = GetExecutingDirectoryName();
                            SQLiteConnectionStringBuilder myBuilder440 = new SQLiteConnectionStringBuilder()
                            { DataSource = @"" + dbconstring440 + @"\\proje_db\\eys_db.db" };
                            SQLiteConnection con440 = new SQLiteConnection(myBuilder440.ConnectionString);
                            con440.Open();
                            string query440 = "SELECT Fatura_id from FATURA WHERE Fatura_No = @faturanoo";
                            SQLiteCommand cmd440 = new SQLiteCommand(query440, con440);
                            cmd440.Parameters.AddWithValue("@faturanoo", Convert.ToInt64(textBoxFaturaNo.Text));
                            var result = cmd440.ExecuteScalar();
                            int deger = Convert.ToInt32(result);

                            string query441 = "SELECT Urun_id from FATURA_KALEM WHERE Fatura_id = @faturaid";
                            SQLiteCommand cmd441 = new SQLiteCommand(query441, con440);
                            cmd441.Parameters.AddWithValue("@faturaid", deger);
                            List<int> liste441 = new List<int>();
                            SQLiteDataReader dr441 = cmd441.ExecuteReader();
                            while (dr441.Read())
                            {
                                liste441.Add(Convert.ToInt32(dr441[0]));
                            }
                            DataTable dt442 = new DataTable();
                            for (int i = 0; i < liste441.Count; i++)
                            {
                                string query442 = "SELECT Urun_id as 'Ürün Id', Urun_Adi as 'Ürün Adı', Barkod_No as 'Barkod' from URUN WHERE Urun_id = @urunid";
                                SQLiteCommand cmd442 = new SQLiteCommand(query442, con440);
                                cmd442.Parameters.AddWithValue("@urunid", liste441[i]);
                                SQLiteDataAdapter adapter442 = new SQLiteDataAdapter(cmd442);
                                adapter442.Fill(dt442);
                            }
                            dataGridView2.DataSource = dt442;
                            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


                        }
                    }
                }
                else
                {
                    MessageBox.Show("Böyle bir satış kaydı bulunmuyor.");
                }
            }
            
        }
        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxFaturaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            numericUpDownAdet.Value = 1;
            string barkod = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            string ad = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBoxBarkod.Text = barkod;
            textBoxUrunAdi.Text = ad;
            labelUrunid.Text = id;
            string dbconstring440 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder440 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring440 + @"\\proje_db\\eys_db.db" };
            SQLiteConnection con440 = new SQLiteConnection(myBuilder440.ConnectionString);
            con440.Open();

            string query440 = "SELECT Fatura_id from FATURA WHERE Fatura_No=@faturanoo";
            SQLiteCommand cmd440 = new SQLiteCommand(query440, con440);
            cmd440.Parameters.AddWithValue("@faturanoo", Convert.ToInt64(textBoxFaturaNo.Text));
            var result = cmd440.ExecuteScalar();
            int deger100 = Convert.ToInt32(result);

            string query443 = "SELECT Miktar from FATURA_KALEM WHERE Fatura_id=@fatid AND Urun_id=@urunid";
            SQLiteCommand cmd443 = new SQLiteCommand(query443, con440);
            cmd443.Parameters.AddWithValue("@fatid", deger100);
            cmd443.Parameters.AddWithValue("@urunid", dataGridView2.CurrentRow.Cells[0].Value.ToString());
            var result440 = cmd443.ExecuteScalar();
            int deger440 = Convert.ToInt32(result440);   
            int maks = deger440;
            numericUpDownAdet.Minimum = 1;
            numericUpDownAdet.Maximum = maks;
        }
    }
}
