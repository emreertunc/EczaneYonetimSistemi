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
    public partial class AnaMenuForm : Form
    {
        public AnaMenuForm()
        {
            InitializeComponent();
        }
        //Veritabanı için dosya yolu alınan fonksiyon.
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //Diğer formları açmak için kullanılan kod dizesi.
        private void urunYonetimButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunYonetimForm f2 = new UrunYonetimForm();
            f2.ShowDialog();
            this.Show();
        }

        private void musteriBilgiButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MusteriBilgiForm f3 = new MusteriBilgiForm();
            f3.ShowDialog();
            this.Show();
        }

        private void satisEkranButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SatisForm f4 = new SatisForm();
            f4.ShowDialog();
            this.Show();
        }

        private void alisEkranButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AlisForm f5 = new AlisForm();
            f5.ShowDialog();
            this.Show();
        }

        private void urunAramaButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunAramaForm f6 = new UrunAramaForm();
            f6.ShowDialog();
            this.Show();
        }

        private void raporEkranButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RaporForm f9 = new RaporForm();
            f9.ShowDialog();
            this.Show();
        }

        private void hakkindaButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            HakkindaForm f13 = new HakkindaForm();
            f13.ShowDialog();
            this.Show();
        }

        private void oturumuKapatButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm f7 = new LoginForm();
            f7.ShowDialog();
        }

        private void programiKapatButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menüGizleGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuStrip2.Visible)
            {
                menuStrip2.Visible = false;
            }
            else menuStrip2.Visible = true;
        }
        // Ana sayfa ekranı kulllanıcı giriş sayfasının ardından yüklenirken yapılması gereken işlemler.
        private void AnaMenuForm_Load(object sender, EventArgs e)
        {
            timer1.Start();

            // Ana sayfa ekranındaki haftalık rapor için gerekli kod dizesi.
            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };
            SQLiteConnection con2 = new SQLiteConnection(myBuilder.ConnectionString);
            con2.Open();
            label5.Text = LoginForm.quantity;
            string query2 = "SELECT Fatura_Tarih as 'Fatura Tarihi', Toplam from FATURA where Fatura_Tarih >= date('now','-7 day') AND Fatura_Tarih <= date('now') AND Fatura_Tipi = 'Satış' ORDER BY Fatura_Tarih DESC";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);
            DataTable dt2 = new DataTable();
            SQLiteDataAdapter adapt2 = new SQLiteDataAdapter(cmd2);
            adapt2.Fill(dt2);
            dataGridViewHaftalikSatislar.DataSource = dt2;
            dataGridViewHaftalikSatislar.AutoResizeColumns();
            dataGridViewHaftalikSatislar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            double haftalikhasilat = 0;

            for (int i = 0; i <= dataGridViewHaftalikSatislar.RowCount - 1; i++)
            {
                double x;
                x = Convert.ToDouble(dataGridViewHaftalikSatislar.Rows[i].Cells[1].Value);
                haftalikhasilat += x;
            }
            string haftalikhasilat2 = haftalikhasilat.ToString();
            label9.Text = haftalikhasilat2 + " TL";

            // Ana sayfa ekranındaki haftalık rapor için gerekli kod dizesi.
            string query3 = "SELECT Fatura_Tarih as 'Fatura Tarihi', Toplam from FATURA where Fatura_Tarih >= date('now','-1 month') AND Fatura_Tarih <= date('now') AND Fatura_Tipi = 'Satış' ORDER BY Fatura_Tarih DESC";
            SQLiteCommand cmd3 = new SQLiteCommand(query3, con2);
            DataTable dt3 = new DataTable();
            SQLiteDataAdapter adapt3 = new SQLiteDataAdapter(cmd3);
            adapt3.Fill(dt3);
            dataGridViewAylikSatislar.DataSource = dt3;
            dataGridViewAylikSatislar.AutoResizeColumns();
            dataGridViewAylikSatislar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            double aylikhasilat = 0;
            for (int i = 0; i <= dataGridViewAylikSatislar.RowCount - 1; i++)
            {
                double y;
                y = Convert.ToDouble(dataGridViewAylikSatislar.Rows[i].Cells[1].Value);
                aylikhasilat += y;
            }
            string aylikhasilat2 = aylikhasilat.ToString();

            label10.Text = aylikhasilat2 + " TL";

            // Ana sayfa ekranındaki haftalık rapor için gerekli kod dizesi.
            string query4 = "SELECT Fatura_Tarih as 'Fatura Tarihi', Toplam from FATURA where Fatura_Tarih >= date('now','-1 year') AND Fatura_Tarih <= date('now') AND Fatura_Tipi = 'Satış' ORDER BY Fatura_Tarih DESC"; 
            SQLiteCommand cmd4 = new SQLiteCommand(query4, con2);

            DataTable dt4 = new DataTable();
            SQLiteDataAdapter adapt4 = new SQLiteDataAdapter(cmd4);
            adapt4.Fill(dt4);

            dataGridViewYillikSatislar.DataSource = dt4;
            dataGridViewYillikSatislar.AutoResizeColumns();
            dataGridViewYillikSatislar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            double yillikhasilat = 0;

            for (int i = 0; i <= dataGridViewYillikSatislar.RowCount - 1; i++)
            {
                double z;
                z = Convert.ToDouble(dataGridViewYillikSatislar.Rows[i].Cells[1].Value);
                yillikhasilat += z;
            }
            string yillikhasilat2 = yillikhasilat.ToString();

            label11.Text = yillikhasilat2 + " TL";

            con2.Close();
        }
        private void kullanıcıYönetimEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciForm f10 = new KullaniciForm();
            f10.ShowDialog();
            this.Show();
        }
        private void IadeEkranButon_Click(object sender, EventArgs e)
        {
            this.Hide();
            IadeForm f11 = new IadeForm();
            f11.ShowDialog();
            this.Show();
        }
        //Ekranlardaki saat ve tarih görünümleri için gerekli kod dizesi.
        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToLongDateString();
            label13.Text = DateTime.Now.ToLongTimeString();
        }      
    }
}
