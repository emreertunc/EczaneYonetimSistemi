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
using System.Diagnostics;

namespace EczaneYonetimSistemi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txt_Password.UseSystemPasswordChar = true;
        }
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }

        private void Run1()
        {
            if (!Program.IsAdministrator())
            {
                // Restart and run as admin
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                startInfo.Arguments = "restart";
                Process.Start(startInfo);
                Application.Exit();
            }
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Run1();
            this.Cursor = Cursors.Default;
            button1.BackgroundImage = (System.Drawing.Image)Properties.Resources.visibility;
        }
        public static string quantity = "";
        private void LoginButon_Click(object sender, EventArgs e)
        {
            if ((txt_UserName.Text == "Giriş Yapınız.." || txt_Password.Text == "Giriş Yapınız..") || (txt_UserName.Text == "" || txt_Password.Text == ""))
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve/veya Şifre giriniz");
                return;
            }
            try
            {
                string dbconstring = GetExecutingDirectoryName();

                SQLiteConnectionStringBuilder myBuilder = new SQLiteConnectionStringBuilder()
                {
                    DataSource = @"" + dbconstring + @"\\proje_db\\eys_db.db"
                };
                SQLiteConnection con = new SQLiteConnection(myBuilder.ConnectionString);
                
                con.Open();
                
                string query = "SELECT * from KULLANICI where k_adi = @username and k_password = @password";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

                string query0 = "SELECT firmaisim from KULLANICI where k_adi = @username";
                SQLiteCommand cmd0 = new SQLiteCommand(query0, con);
                cmd0.Parameters.AddWithValue("@username", txt_UserName.Text);

                var result = cmd0.ExecuteScalar();
                if(result== null)
                {
                   
                }
                else
                {
                    string sonuc = result.ToString();
                    label1.Text = sonuc;
                }

                if (label1.Text == null)
                {
                    label1.Text = null;
                }
                else
                {
                    quantity = label1.Text;
                }
                

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                con.Close();

                int count = ds.Tables[0].Rows.Count;
                //Eğer count=1 ise Ana Sayfa Formunu göster.
                if (count == 1)
                {
                    this.Hide();
                    AnaMenuForm f1 = new AnaMenuForm();
                    f1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CleanButton1_Click(object sender, EventArgs e)
        {
            txt_UserName.Text = "";
            txt_Password.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = !txt_Password.UseSystemPasswordChar;

            if(txt_Password.UseSystemPasswordChar == true)
            {
                button1.BackgroundImage = (System.Drawing.Image)Properties.Resources.visibility;
            }

            else if(txt_Password.UseSystemPasswordChar == false)
            {
                button1.BackgroundImage = (System.Drawing.Image)Properties.Resources.invisible;
            }
        }
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //this.Run1();
            //this.Cursor = Cursors.Default;
        }
    }
}
