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
    public partial class KullaniciForm : Form
    {
        public KullaniciForm()
        {
            InitializeComponent();
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
        private void buttonKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (textBoxKullaniciAdi.Text == "" || textBoxSifre.Text == "" || textBoxSifre2.Text == "" || textBoxEczaneAdi.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
            else if (textBoxSifre2.Text != textBoxSifre.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor.");
            }
            else
            {
                string dbconstring = GetExecutingDirectoryName();
                SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
                { DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db" };

                SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO KULLANICI (k_password, k_adi, firmaisim) VALUES(@pass, @id, @firmaad) ";
                cmd.Parameters.AddWithValue("@id", textBoxKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@pass", textBoxSifre.Text);
                cmd.Parameters.AddWithValue("@firmaad", textBoxEczaneAdi.Text);

                int a = cmd.ExecuteNonQuery();

                if (a == 1)
                {
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");
                }
                else MessageBox.Show("Kullanıcı Eklenemedi. ");

                cmd.Prepare();
                cmd.Dispose();
                con.Close();
                string query2 = "SELECT k_adi, firmaisim from KULLANICI";
                SQLiteCommand cmd2 = new SQLiteCommand(query2, con);

                SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                dataGridViewKullanici.DataSource = dt2;

            }
        }
        private void dataGridViewKullanici_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKullanici.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                labelClicked.Text = dataGridViewKullanici.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private void buttonSil_Click(object sender, EventArgs e)
        {
            string dbconstring2 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder2 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring2 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con2 = new SQLiteConnection(myBuilder2.ConnectionString);
            con2.Open();

            string query2 = "SELECT k_adi, firmaisim from KULLANICI";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);

            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            dataGridViewKullanici.DataSource = dt2;

            string secilen ="";
            
            if (labelClicked.Text != "")
            {
                secilen = labelClicked.Text;
            }
            else MessageBox.Show("Seçim yapılmadı");

            string query3 = "DELETE FROM KULLANICI WHERE k_adi = @secilen";
            SQLiteCommand komut = new SQLiteCommand(query3, con2);
            komut.Parameters.AddWithValue("@secilen", secilen);
            komut.ExecuteNonQuery();

            string query4 = "SELECT k_adi, firmaisim from KULLANICI";
            SQLiteCommand cmd4 = new SQLiteCommand(query4, con2);

            SQLiteDataAdapter adapter4 = new SQLiteDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            adapter4.Fill(dt4);
            dataGridViewKullanici.DataSource = dt4;
            con2.Close();
        }
        private void buttonKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            string dbconstring3 = GetExecutingDirectoryName();
            SQLiteConnectionStringBuilder myBuilder3 = new SQLiteConnectionStringBuilder()
            { DataSource = @"" + dbconstring3 + @"\\proje_db\\eys_db.db" };

            SQLiteConnection con2 = new SQLiteConnection(myBuilder3.ConnectionString);
            con2.Open();
            string query2 = "SELECT k_adi as 'Kullanıcı Adı', firmaisim as 'Firma' from KULLANICI";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);

            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            dataGridViewKullanici.DataSource = dt2;
            dataGridViewKullanici.Visible = true;
        }
    }
}
