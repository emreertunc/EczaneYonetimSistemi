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
    public partial class UrunAramaForm : Form
    {
        public UrunAramaForm()
        {
           InitializeComponent();
            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);
            con.Open();

            try
            {
                string sorgu1 = "SELECT Marka_Adi from MARKA";
                SQLiteCommand komut1 = new SQLiteCommand(sorgu1, con);

                DataTable vt1 = new DataTable();
                SQLiteDataAdapter adapt1 = new SQLiteDataAdapter(komut1);
                adapt1.Fill(vt1);

                comboBoxMarka.DisplayMember = "Marka_Adi";
                comboBoxMarka.DataSource = vt1;

                string sorgu2 = "SELECT Kategori_Adi from KATEGORI";
                SQLiteCommand komut2 = new SQLiteCommand(sorgu2, con);

                DataTable vt2 = new DataTable();
                SQLiteDataAdapter adapt2 = new SQLiteDataAdapter(komut2);
                adapt2.Fill(vt2);

                comboBoxKategori.DisplayMember = "Kategori_Adi";
                comboBoxKategori.DataSource = vt2;
                con.Close();

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
        public static string barkod;
        private void urungetirbuton1_Click(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            string dbconstring2 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con3 = new SQLiteConnection(myBuilder2.ConnectionString);
            con3.Open();
            string query3 = "SELECT Marka_id from MARKA where Marka_Adi=@marka_isim";
            SQLiteCommand cmd3 = new SQLiteCommand(query3, con3);
            cmd3.Parameters.AddWithValue("@marka_isim", comboBoxMarka.Text.ToString());

            var result = cmd3.ExecuteScalar();
            int deger = Convert.ToInt32(result);

            string query4 = "SELECT Urun_Adi as 'Ürün Adı' , Barkod_No as 'Barkod', Birim , Servis_Birim as 'Servis Birimi', Servis_Adedi as 'Servis Adedi', Servis_Miktari as 'Servis Miktarı', SKT , KDV_Orani as 'KDV Oranı', Alis_Fiyati as 'Alış Fiyatı', Satis_Fiyati as 'Satış Fiyatı', Piyasa_Fiyati as 'Piyasa Fiyatı', Yerli , Asgari_Stok as 'Asgari Stok', Stok_Bilgisi as 'Stok', Depo_id as 'Depo ID', Kategori_id as 'Kategori ID', Marka_id as 'Marka ID' from URUN where Marka_id =@m_id";
            SQLiteCommand cmd4 = new SQLiteCommand(query4, con3);
            cmd4.Parameters.AddWithValue("@m_id", deger);

            SQLiteDataAdapter adapter4 = new SQLiteDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            adapter4.Fill(dt4);
            if(dt4.Rows.Count == 0)
            {
                MessageBox.Show("Bu markaya ait bir ürün bulunamadı");
                con3.Close();
            }
            else
            {
                dataGridView2.DataSource = dt4;
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                con3.Close();
                groupBoxData.Visible = true;
            } 
        }
        private void urungetirbuton2_Click(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            string dbconstring3 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con4 = new SQLiteConnection(myBuilder3.ConnectionString);
            con4.Open();

            string query5 = "SELECT Kategori_id from KATEGORI where Kategori_Adi=@kategori_isim";
            SQLiteCommand cmd5 = new SQLiteCommand(query5, con4);
            cmd5.Parameters.AddWithValue("@kategori_isim", comboBoxKategori.Text.ToString());

            var result2 = cmd5.ExecuteScalar();
            int deger2 = Convert.ToInt32(result2);

            string query6 = "SELECT Urun_Adi as 'Ürün Adı' , Barkod_No as 'Barkod', Birim , Servis_Birim as 'Servis Birimi', Servis_Adedi as 'Servis Adedi', Servis_Miktari as 'Servis Miktarı', SKT , KDV_Orani as 'KDV Oranı', Alis_Fiyati as 'Alış Fiyatı', Satis_Fiyati as 'Satış Fiyatı', Piyasa_Fiyati as 'Piyasa Fiyatı', Yerli , Asgari_Stok as 'Asgari Stok', Stok_Bilgisi as 'Stok', Depo_id as 'Depo ID', Kategori_id as 'Kategori ID', Marka_id as 'Marka ID' from URUN where Kategori_id =@k_id";
            SQLiteCommand cmd6 = new SQLiteCommand(query6, con4);
            cmd6.Parameters.AddWithValue("@k_id", deger2);

            SQLiteDataAdapter adapter6 = new SQLiteDataAdapter(cmd6);
            DataTable dt6 = new DataTable();
            adapter6.Fill(dt6);
            if (dt6.Rows.Count == 0)
            {
                MessageBox.Show("Bu kategoriye ait bir ürün bulunamadı");
                con4.Close();
            }
            else
            {
                dataGridView2.DataSource = dt6;
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                con4.Close();
                groupBoxData.Visible = true;
            }    
        }
        private void urungetirbuton3_Click(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            string dbconstring4 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con5 = new SQLiteConnection(myBuilder4.ConnectionString);
            con5.Open();

            string query7 = "SELECT Urun_Adi as 'Ürün Adı' , Barkod_No as 'Barkod', Birim , Servis_Birim as 'Servis Birimi', Servis_Adedi as 'Servis Adedi', Servis_Miktari as 'Servis Miktarı', SKT , KDV_Orani as 'KDV Oranı', Alis_Fiyati as 'Alış Fiyatı', Satis_Fiyati as 'Satış Fiyatı', Piyasa_Fiyati as 'Piyasa Fiyatı', Yerli , Asgari_Stok as 'Asgari Stok', Stok_Bilgisi as 'Stok', Depo_id as 'Depo ID', Kategori_id as 'Kategori ID', Marka_id as 'Marka ID' from URUN where Barkod_No=@barkod";
            SQLiteCommand cmd7 = new SQLiteCommand(query7, con5);
            cmd7.Parameters.AddWithValue("@barkod", textBoxBarkod.Text);

            SQLiteDataAdapter adapter7 = new SQLiteDataAdapter(cmd7);
            DataTable dt7 = new DataTable();
            adapter7.Fill(dt7);
            if (dt7.Rows.Count == 0)
            {
                MessageBox.Show("Böyle bir ürün bulunamadı");
                con5.Close();
            }
            else
            {
                dataGridView2.DataSource = dt7;
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                con5.Close();
                groupBoxData.Visible = true;
            }
        }
        private void urungetirbuton4_Click(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            string dbconstring5 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder5 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring5 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con6 = new SQLiteConnection(myBuilder5.ConnectionString);
            con6.Open();

            string query8 = "SELECT Urun_Adi as 'Ürün Adı' , Barkod_No as 'Barkod', Birim , Servis_Birim as 'Servis Birimi', Servis_Adedi as 'Servis Adedi', Servis_Miktari as 'Servis Miktarı', SKT , KDV_Orani as 'KDV Oranı', Alis_Fiyati as 'Alış Fiyatı', Satis_Fiyati as 'Satış Fiyatı', Piyasa_Fiyati as 'Piyasa Fiyatı', Yerli , Asgari_Stok as 'Asgari Stok', Stok_Bilgisi as 'Stok', Depo_id as 'Depo ID', Kategori_id as 'Kategori ID', Marka_id as 'Marka ID' from URUN where Urun_adi LIKE @urunadi";
            SQLiteCommand cmd8 = new SQLiteCommand(query8, con6);
            cmd8.Parameters.AddWithValue("@urunadi", '%'+textBoxUrunAd.Text+'%');

            SQLiteDataAdapter adapter8 = new SQLiteDataAdapter(cmd8);
            DataTable dt8 = new DataTable();
            adapter8.Fill(dt8);
            if (dt8.Rows.Count == 0)
            {
                MessageBox.Show("Bu isme ait ürün bulunamadı");
                con6.Close();
            }
            else
            {
                
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.DataSource = dt8;
                con6.Close();
                groupBoxData.Visible = true;
            }  
        }
        private void urungetirbuton5_Click(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
            string dbconstring6 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder6 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring6 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder6.ConnectionString);
            con7.Open();

            string query9 = "SELECT Urun_Adi as 'Ürün Adı' , Barkod_No as 'Barkod', Birim , Servis_Birim as 'Servis Birimi', Servis_Adedi as 'Servis Adedi', Servis_Miktari as 'Servis Miktarı', SKT , KDV_Orani as 'KDV Oranı', Alis_Fiyati as 'Alış Fiyatı', Satis_Fiyati as 'Satış Fiyatı', Piyasa_Fiyati as 'Piyasa Fiyatı', Yerli , Asgari_Stok as 'Asgari Stok', Stok_Bilgisi as 'Stok', Depo_id as 'Depo ID', Kategori_id as 'Kategori ID', Marka_id as 'Marka ID' from URUN";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridView2.DataSource = dt9;
            dataGridView2.AutoResizeColumns();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            con7.Close();
            groupBoxData.Visible = true;
        }
        private void DataKapatButon_Click(object sender, EventArgs e)
        {
            groupBoxData.Visible = false;
        }
        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            barkod = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            UrunYonetimForm FORM = new UrunYonetimForm();
            FORM.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToLongDateString();
            label7.Text = DateTime.Now.ToLongTimeString();
        }
        private void UrunAramaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBoxBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxBarkod_MouseEnter(object sender, EventArgs e)
        {
            if (textBoxBarkod.Text == "Barkod Giriniz..")
            {
                textBoxBarkod.Text = "";
            }
            else
            {
                textBoxBarkod.Text = textBoxBarkod.Text;
            }
        }

        private void textBoxBarkod_MouseLeave(object sender, EventArgs e)
        {
            if (textBoxBarkod.Text == "")
            {
                textBoxBarkod.Text = "Barkod Giriniz..";
            }
            else
            {
                textBoxBarkod.Text = textBoxBarkod.Text;
            }
        }

        private void textBoxUrunAd_MouseEnter(object sender, EventArgs e)
        {
            if (textBoxUrunAd.Text == "Ürün Adı Giriniz..")
            {
                textBoxUrunAd.Text = "";
            }
            else
            {
                textBoxUrunAd.Text = textBoxUrunAd.Text;
            }
        }

        private void textBoxUrunAd_MouseLeave(object sender, EventArgs e)
        {
            if (textBoxUrunAd.Text == "")
            {
                textBoxUrunAd.Text = "Ürün Adı Giriniz..";
            }
            else
            {
                textBoxUrunAd.Text = textBoxUrunAd.Text;
            }
        }
    }
}