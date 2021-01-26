
namespace EczaneYonetimSistemi
{
    partial class KullaniciForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciForm));
            this.groupBoxKullaniciEkle = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEczaneAdi = new System.Windows.Forms.TextBox();
            this.buttonKullaniciEkle = new System.Windows.Forms.Button();
            this.textBoxSifre2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.textBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.buttonKapat = new System.Windows.Forms.Button();
            this.buttonSil = new System.Windows.Forms.Button();
            this.dataGridViewKullanici = new System.Windows.Forms.DataGridView();
            this.labelClicked = new System.Windows.Forms.Label();
            this.groupBoxKullaniciEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanici)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxKullaniciEkle
            // 
            this.groupBoxKullaniciEkle.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxKullaniciEkle.Controls.Add(this.label4);
            this.groupBoxKullaniciEkle.Controls.Add(this.textBoxEczaneAdi);
            this.groupBoxKullaniciEkle.Controls.Add(this.buttonKullaniciEkle);
            this.groupBoxKullaniciEkle.Controls.Add(this.textBoxSifre2);
            this.groupBoxKullaniciEkle.Controls.Add(this.label3);
            this.groupBoxKullaniciEkle.Controls.Add(this.label2);
            this.groupBoxKullaniciEkle.Controls.Add(this.label1);
            this.groupBoxKullaniciEkle.Controls.Add(this.textBoxSifre);
            this.groupBoxKullaniciEkle.Controls.Add(this.textBoxKullaniciAdi);
            this.groupBoxKullaniciEkle.Location = new System.Drawing.Point(12, 12);
            this.groupBoxKullaniciEkle.Name = "groupBoxKullaniciEkle";
            this.groupBoxKullaniciEkle.Size = new System.Drawing.Size(254, 234);
            this.groupBoxKullaniciEkle.TabIndex = 11;
            this.groupBoxKullaniciEkle.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(17, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Eczane Adı";
            // 
            // textBoxEczaneAdi
            // 
            this.textBoxEczaneAdi.Location = new System.Drawing.Point(113, 80);
            this.textBoxEczaneAdi.Name = "textBoxEczaneAdi";
            this.textBoxEczaneAdi.Size = new System.Drawing.Size(100, 20);
            this.textBoxEczaneAdi.TabIndex = 1;
            // 
            // buttonKullaniciEkle
            // 
            this.buttonKullaniciEkle.Location = new System.Drawing.Point(138, 181);
            this.buttonKullaniciEkle.Name = "buttonKullaniciEkle";
            this.buttonKullaniciEkle.Size = new System.Drawing.Size(75, 23);
            this.buttonKullaniciEkle.TabIndex = 4;
            this.buttonKullaniciEkle.Text = "Kaydet";
            this.buttonKullaniciEkle.UseVisualStyleBackColor = true;
            this.buttonKullaniciEkle.Click += new System.EventHandler(this.buttonKullaniciEkle_Click);
            // 
            // textBoxSifre2
            // 
            this.textBoxSifre2.Location = new System.Drawing.Point(113, 148);
            this.textBoxSifre2.Name = "textBoxSifre2";
            this.textBoxSifre2.Size = new System.Drawing.Size(100, 20);
            this.textBoxSifre2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(3, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Şifre (Tekrar)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(63, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Location = new System.Drawing.Point(113, 114);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(100, 20);
            this.textBoxSifre.TabIndex = 2;
            // 
            // textBoxKullaniciAdi
            // 
            this.textBoxKullaniciAdi.Location = new System.Drawing.Point(113, 46);
            this.textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            this.textBoxKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.textBoxKullaniciAdi.TabIndex = 0;
            // 
            // buttonKapat
            // 
            this.buttonKapat.Location = new System.Drawing.Point(406, 252);
            this.buttonKapat.Name = "buttonKapat";
            this.buttonKapat.Size = new System.Drawing.Size(75, 25);
            this.buttonKapat.TabIndex = 1;
            this.buttonKapat.Text = "Kapat";
            this.buttonKapat.UseVisualStyleBackColor = true;
            this.buttonKapat.Click += new System.EventHandler(this.buttonKapat_Click);
            // 
            // buttonSil
            // 
            this.buttonSil.Location = new System.Drawing.Point(272, 252);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.Size = new System.Drawing.Size(110, 25);
            this.buttonSil.TabIndex = 0;
            this.buttonSil.Text = "Seçili Kullanıcıyı Sil";
            this.buttonSil.UseVisualStyleBackColor = true;
            this.buttonSil.Click += new System.EventHandler(this.buttonSil_Click);
            // 
            // dataGridViewKullanici
            // 
            this.dataGridViewKullanici.AllowUserToAddRows = false;
            this.dataGridViewKullanici.AllowUserToDeleteRows = false;
            this.dataGridViewKullanici.AllowUserToResizeColumns = false;
            this.dataGridViewKullanici.AllowUserToResizeRows = false;
            this.dataGridViewKullanici.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewKullanici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKullanici.ColumnHeadersVisible = false;
            this.dataGridViewKullanici.Location = new System.Drawing.Point(272, 12);
            this.dataGridViewKullanici.Name = "dataGridViewKullanici";
            this.dataGridViewKullanici.ReadOnly = true;
            this.dataGridViewKullanici.RowHeadersVisible = false;
            this.dataGridViewKullanici.Size = new System.Drawing.Size(270, 234);
            this.dataGridViewKullanici.TabIndex = 2;
            this.dataGridViewKullanici.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKullanici_CellClick_1);
            // 
            // labelClicked
            // 
            this.labelClicked.AutoSize = true;
            this.labelClicked.Location = new System.Drawing.Point(343, 307);
            this.labelClicked.Name = "labelClicked";
            this.labelClicked.Size = new System.Drawing.Size(0, 13);
            this.labelClicked.TabIndex = 15;
            this.labelClicked.Visible = false;
            // 
            // KullaniciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::EczaneYonetimSistemi.Properties.Resources.employees_bg;
            this.ClientSize = new System.Drawing.Size(565, 291);
            this.Controls.Add(this.labelClicked);
            this.Controls.Add(this.groupBoxKullaniciEkle);
            this.Controls.Add(this.buttonKapat);
            this.Controls.Add(this.buttonSil);
            this.Controls.Add(this.dataGridViewKullanici);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KullaniciForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EYS 2021© KULLANICI YÖNETİM EKRANI";
            this.Load += new System.EventHandler(this.KullaniciForm_Load);
            this.groupBoxKullaniciEkle.ResumeLayout(false);
            this.groupBoxKullaniciEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxKullaniciEkle;
        private System.Windows.Forms.Button buttonKullaniciEkle;
        private System.Windows.Forms.TextBox textBoxSifre2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi;
        private System.Windows.Forms.Button buttonKapat;
        private System.Windows.Forms.Button buttonSil;
        private System.Windows.Forms.DataGridView dataGridViewKullanici;
        private System.Windows.Forms.Label labelClicked;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEczaneAdi;
    }
}