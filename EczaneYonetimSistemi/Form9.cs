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
    public partial class RaporForm : Form
    {
        public RaporForm()
        {
            InitializeComponent();
            string dbconstring = GetExecutingDirectoryName();
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Visible = false;
            label2.Visible = false;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;

            dataGridViewTumUrunler.AutoResizeColumns();
            dataGridViewTumUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string dbconstring = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder.ConnectionString);
            con7.Open();

            string query9 = "SELECT Urun_adi as 'Ürün Adı' from URUN";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridViewTumUrunler.DataSource = dt9;
            con7.Close();

            dataGridViewTumUrunler.Visible = true;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string dbconstring5 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder5 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring5 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con = new SQLiteConnection(myBuilder5.ConnectionString);
            con.Open();
            string query = "SELECT Urun_Adi as 'Ürün Adı', Barkod_No as 'Barkod', Asgari_Stok as 'Asgari Stok', Stok_Bilgisi as 'Stok Bilgisi' from URUN where Stok_Bilgisi < 5 ";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd);
            adapt.Fill(dt);


            dataGridViewAsgariStok.DataSource = dt;
            con.Close();

            dataGridViewAsgariStok.Visible = true;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string dbconstring3 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder3.ConnectionString);
            con7.Open();

            string query9 = "SELECT Urun_Adi as 'Ürün Adı', Tarih, Eski_Fiyat as 'Eski Fİyatı', Yeni_Fiyat as 'Yeni Fiyatı' from FIYAT_DEGISIKLIK";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridViewFiyatDegisikligi.AutoResizeColumns();
            dataGridViewFiyatDegisikligi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewFiyatDegisikligi.DataSource = dt9;
            con7.Close();

            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = true;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToLongTimeString();
        }
        private void tümMüşterileriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string dbconstring2 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder2.ConnectionString);
            con7.Open();

            string query9 = "SELECT Cari_Adi as 'İsim Soyisim', TC_No as 'TC Kimlik No', Cari_Tip as 'Tip', Telefon  from CARI_TABLO where Cari_Tip = 'Müşteri'";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridViewTumMusteriler.DataSource = dt9;
            con7.Close();

            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = true;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void tümSatıcılarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string dbconstring9 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder9 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring9 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder9.ConnectionString);
            con7.Open();

            string query9 = "SELECT Cari_Adi as 'İsim', Vergi_No as 'Vergi No', Cari_Tip as 'Tip', Telefon, Vergi_Dairesi as 'Vergi Dairesi', Kurum_Adi as 'Kurum Adı' from CARI_TABLO where Cari_Tip = 'Satıcı'";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridTumSaticilar.DataSource = dt9;
            con7.Close();

            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = true;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void tümSatışlarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string dbconstring3 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder3.ConnectionString);
            con7.Open();

            string query9 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA WHERE Fatura_Tipi = 'Satış' ";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridViewTumSatislar.DataSource = dt9;
            con7.Close();

            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = true;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void haftalıkSatışlarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dbconstring4 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder4 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring4 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con2 = new SQLiteConnection(myBuilder4.ConnectionString);
            con2.Open();
            string query2 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA where Fatura_Tarih >= date('now','-7 day') AND Fatura_Tarih <= date('now') AND Fatura_Tipi = 'Satış' ORDER BY Fatura_Tarih DESC ";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);

            DataTable dt2 = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd2);
            adapt.Fill(dt2);

            dataGridViewHaftalikSatislar.DataSource = dt2;
            con2.Close();

            double haftalikhasilat = 0;

            for (int i = 0; i <= dataGridViewHaftalikSatislar.RowCount - 1; i++)
            {
                double x;
                x = Convert.ToDouble(dataGridViewHaftalikSatislar.Rows[i].Cells[5].Value);
                haftalikhasilat += x;
            }
            string haftalikhasilat2 = haftalikhasilat.ToString();
            label1.Text = "Haftalık Hasılat:";
            label2.Text = haftalikhasilat2 + "TL";

            label1.Visible = true;
            label2.Visible = true;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = true;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void krediKartıİleYapılanSatışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dbconstring6 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder6 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring6 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder6.ConnectionString);
            con7.Open();

            string query9 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA where Odeme_Yontemi = 'Kredi Kartı' AND Fatura_Tipi = 'Satış' ";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridViewKrediKarti.DataSource = dt9;
            con7.Close();

            label1.Visible = false;
            label2.Visible = false;
            dataGridViewKrediKarti.Visible = true;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void nakitYapılanSatışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dbconstring7 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder7 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring7 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder7.ConnectionString);
            con7.Open();

            string query9 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA where Odeme_Yontemi = 'Nakit' AND Fatura_Tipi = 'Satış'";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridViewNakit.DataSource = dt9;
            con7.Close();

            label1.Visible = false;
            label2.Visible = false;
            dataGridViewKrediKarti.Visible = true;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = true;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void havaleEFTİleYapılanSatışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dbconstring8 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder8 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring8 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con7 = new SQLiteConnection(myBuilder8.ConnectionString);
            con7.Open();

            string query9 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA where Odeme_Yontemi = 'Havale/EFT' AND Fatura_Tipi = 'Satış'";
            SQLiteCommand cmd9 = new SQLiteCommand(query9, con7);

            SQLiteDataAdapter adapter9 = new SQLiteDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapter9.Fill(dt9);

            dataGridViewHavale.DataSource = dt9;
            con7.Close();

            label1.Visible = false;
            label2.Visible = false;
            dataGridViewKrediKarti.Visible = true;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewHavale.Visible = true;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void aylıkSatışlarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dbconstring40 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder40 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring40 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con20 = new SQLiteConnection(myBuilder40.ConnectionString);
            con20.Open();
            string query20 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA where Fatura_Tarih >= date('now','-1 month') AND Fatura_Tarih <= date('now') AND Fatura_Tipi = 'Satış' ORDER BY Fatura_Tarih DESC ";
            SQLiteCommand cmd20 = new SQLiteCommand(query20, con20);

            DataTable dt20 = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd20);
            adapt.Fill(dt20);

            dataGridViewAylikSatislar.DataSource = dt20;
            con20.Close();

            double aylikhasilat = 0;

            for (int i = 0; i <= dataGridViewAylikSatislar.RowCount - 1; i++)
            {
                double x;
                x = Convert.ToDouble(dataGridViewAylikSatislar.Rows[i].Cells[5].Value);
                aylikhasilat += x;
            }
            string aylikhasilat2 = aylikhasilat.ToString();
            label1.Text = "Aylık Hasılat:";
            label2.Text = aylikhasilat2 + "TL";

            label1.Visible = true;
            label2.Visible = true;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = true;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void yıllıkSatışlarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dbconstring400 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder400 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring400 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con200 = new SQLiteConnection(myBuilder400.ConnectionString);
            con200.Open();
            string query200 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA where Fatura_Tarih >= date('now','-1 year') AND Fatura_Tarih <= date('now') AND Fatura_Tipi = 'Satış' ORDER BY Fatura_Tarih DESC ";
            SQLiteCommand cmd200 = new SQLiteCommand(query200, con200);

            DataTable dt200 = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd200);
            adapt.Fill(dt200);

            dataGridViewYillikSatislar.DataSource = dt200;
            con200.Close();

            double yillikhasilat = 0;

            for (int i = 0; i <= dataGridViewYillikSatislar.RowCount - 1; i++)
            {
                double x;
                x = Convert.ToDouble(dataGridViewYillikSatislar.Rows[i].Cells[5].Value);
                yillikhasilat += x;
            }
            string yillikhasilat2 = yillikhasilat.ToString();
            label1.Text = "Yıllık Hasılat:";
            label2.Text = yillikhasilat2 + "TL";

            label1.Visible = true;
            label2.Visible = true;
            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = true;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = false;
        }
        private void iadeGirişleriniGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string dbconstring300 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder300 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring300 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con700 = new SQLiteConnection(myBuilder300.ConnectionString);
            con700.Open();

            string query900 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA WHERE Fatura_Tipi = 'İade' ";
            SQLiteCommand cmd900 = new SQLiteCommand(query900, con700);

            SQLiteDataAdapter adapter900 = new SQLiteDataAdapter(cmd900);
            DataTable dt900 = new DataTable();
            adapter900.Fill(dt900);

            dataGridViewİade.DataSource = dt900;
            con700.Close();

            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = true;
            dataGridViewAlislar.Visible = false;
        }
        private void alışKayıtlarınıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            string dbconstring300 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder300 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring300 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con700 = new SQLiteConnection(myBuilder300.ConnectionString);
            con700.Open();

            string query900 = "SELECT Fatura_No as 'Fatura No', Fatura_Tarih as 'Tarih', Fatura_Tipi as 'Fatura Tipi', Net_Fiyat as 'Net Fiyat', KDV_Toplami as 'Toplam KDV', Toplam, Odeme_Yontemi as 'Ödeme Yöntemi' from FATURA WHERE Fatura_Tipi = 'Alış' ";
            SQLiteCommand cmd900 = new SQLiteCommand(query900, con700);

            SQLiteDataAdapter adapter900 = new SQLiteDataAdapter(cmd900);
            DataTable dt900 = new DataTable();
            adapter900.Fill(dt900);

            dataGridViewAlislar.DataSource = dt900;
            con700.Close();

            dataGridViewAsgariStok.Visible = false;
            dataGridViewHaftalikSatislar.Visible = false;
            dataGridViewTumSatislar.Visible = false;
            dataGridViewTumMusteriler.Visible = false;
            dataGridViewTumUrunler.Visible = false;
            dataGridViewKrediKarti.Visible = false;
            dataGridViewHavale.Visible = false;
            dataGridViewNakit.Visible = false;
            dataGridTumSaticilar.Visible = false;
            dataGridViewFiyatDegisikligi.Visible = false;
            dataGridViewAylikSatislar.Visible = false;
            dataGridViewYillikSatislar.Visible = false;
            dataGridViewİade.Visible = false;
            dataGridViewAlislar.Visible = true;
        }
    }
}
