namespace EczaneYonetimSistemi
{
    partial class UrunAramaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrunAramaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBarkod = new System.Windows.Forms.TextBox();
            this.textBoxUrunAd = new System.Windows.Forms.TextBox();
            this.comboBoxKategori = new System.Windows.Forms.ComboBox();
            this.urungetirbuton1 = new System.Windows.Forms.Button();
            this.urungetirbuton2 = new System.Windows.Forms.Button();
            this.urungetirbuton3 = new System.Windows.Forms.Button();
            this.urungetirbuton4 = new System.Windows.Forms.Button();
            this.urungetirbuton5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxMarka = new System.Windows.Forms.ComboBox();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.DataKapatButon = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.anaSayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Markaya Ait Ürün Sorgulama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Kategoriye Ait Ürün Sorgulama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Barkod ile Ürün Sorgulama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ürün Adı İle Sorgulama";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tüm Ürünleri Görüntüle";
            // 
            // textBoxBarkod
            // 
            this.textBoxBarkod.Location = new System.Drawing.Point(271, 98);
            this.textBoxBarkod.Name = "textBoxBarkod";
            this.textBoxBarkod.Size = new System.Drawing.Size(160, 20);
            this.textBoxBarkod.TabIndex = 8;
            this.textBoxBarkod.Text = "Barkod Giriniz..";
            this.textBoxBarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBarkod_KeyPress);
            this.textBoxBarkod.MouseEnter += new System.EventHandler(this.textBoxBarkod_MouseEnter);
            this.textBoxBarkod.MouseLeave += new System.EventHandler(this.textBoxBarkod_MouseLeave);
            // 
            // textBoxUrunAd
            // 
            this.textBoxUrunAd.Location = new System.Drawing.Point(271, 138);
            this.textBoxUrunAd.Name = "textBoxUrunAd";
            this.textBoxUrunAd.Size = new System.Drawing.Size(160, 20);
            this.textBoxUrunAd.TabIndex = 10;
            this.textBoxUrunAd.Text = "Ürün Adı Giriniz..";
            this.textBoxUrunAd.MouseEnter += new System.EventHandler(this.textBoxUrunAd_MouseEnter);
            this.textBoxUrunAd.MouseLeave += new System.EventHandler(this.textBoxUrunAd_MouseLeave);
            // 
            // comboBoxKategori
            // 
            this.comboBoxKategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxKategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxKategori.FormattingEnabled = true;
            this.comboBoxKategori.Location = new System.Drawing.Point(271, 58);
            this.comboBoxKategori.Name = "comboBoxKategori";
            this.comboBoxKategori.Size = new System.Drawing.Size(160, 21);
            this.comboBoxKategori.TabIndex = 6;
            this.comboBoxKategori.Text = "Kategori Seçiniz..";
            // 
            // urungetirbuton1
            // 
            this.urungetirbuton1.Location = new System.Drawing.Point(454, 16);
            this.urungetirbuton1.Name = "urungetirbuton1";
            this.urungetirbuton1.Size = new System.Drawing.Size(142, 23);
            this.urungetirbuton1.TabIndex = 5;
            this.urungetirbuton1.Text = "Ürünleri Getir";
            this.urungetirbuton1.UseVisualStyleBackColor = true;
            this.urungetirbuton1.Click += new System.EventHandler(this.urungetirbuton1_Click);
            // 
            // urungetirbuton2
            // 
            this.urungetirbuton2.Location = new System.Drawing.Point(454, 56);
            this.urungetirbuton2.Name = "urungetirbuton2";
            this.urungetirbuton2.Size = new System.Drawing.Size(142, 23);
            this.urungetirbuton2.TabIndex = 7;
            this.urungetirbuton2.Text = "Ürünleri Getir";
            this.urungetirbuton2.UseVisualStyleBackColor = true;
            this.urungetirbuton2.Click += new System.EventHandler(this.urungetirbuton2_Click);
            // 
            // urungetirbuton3
            // 
            this.urungetirbuton3.Location = new System.Drawing.Point(454, 98);
            this.urungetirbuton3.Name = "urungetirbuton3";
            this.urungetirbuton3.Size = new System.Drawing.Size(142, 23);
            this.urungetirbuton3.TabIndex = 9;
            this.urungetirbuton3.Text = "Ürünü Getir";
            this.urungetirbuton3.UseVisualStyleBackColor = true;
            this.urungetirbuton3.Click += new System.EventHandler(this.urungetirbuton3_Click);
            // 
            // urungetirbuton4
            // 
            this.urungetirbuton4.Location = new System.Drawing.Point(454, 138);
            this.urungetirbuton4.Name = "urungetirbuton4";
            this.urungetirbuton4.Size = new System.Drawing.Size(142, 23);
            this.urungetirbuton4.TabIndex = 11;
            this.urungetirbuton4.Text = "Ürünü Getir";
            this.urungetirbuton4.UseVisualStyleBackColor = true;
            this.urungetirbuton4.Click += new System.EventHandler(this.urungetirbuton4_Click);
            // 
            // urungetirbuton5
            // 
            this.urungetirbuton5.Location = new System.Drawing.Point(454, 176);
            this.urungetirbuton5.Name = "urungetirbuton5";
            this.urungetirbuton5.Size = new System.Drawing.Size(142, 23);
            this.urungetirbuton5.TabIndex = 12;
            this.urungetirbuton5.Text = "Ürün Listesini Görüntüle";
            this.urungetirbuton5.UseVisualStyleBackColor = true;
            this.urungetirbuton5.Click += new System.EventHandler(this.urungetirbuton5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.comboBoxMarka);
            this.groupBox1.Controls.Add(this.urungetirbuton5);
            this.groupBox1.Controls.Add(this.urungetirbuton4);
            this.groupBox1.Controls.Add(this.urungetirbuton3);
            this.groupBox1.Controls.Add(this.urungetirbuton2);
            this.groupBox1.Controls.Add(this.urungetirbuton1);
            this.groupBox1.Controls.Add(this.comboBoxKategori);
            this.groupBox1.Controls.Add(this.textBoxUrunAd);
            this.groupBox1.Controls.Add(this.textBoxBarkod);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(378, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 214);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxMarka
            // 
            this.comboBoxMarka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMarka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMarka.FormattingEnabled = true;
            this.comboBoxMarka.Location = new System.Drawing.Point(271, 18);
            this.comboBoxMarka.Name = "comboBoxMarka";
            this.comboBoxMarka.Size = new System.Drawing.Size(160, 21);
            this.comboBoxMarka.TabIndex = 4;
            this.comboBoxMarka.Text = "Marka Seçiniz..";
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.DataKapatButon);
            this.groupBoxData.Controls.Add(this.dataGridView2);
            this.groupBoxData.Location = new System.Drawing.Point(8, 255);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(1332, 438);
            this.groupBoxData.TabIndex = 34;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Veri Ekranı";
            this.groupBoxData.Visible = false;
            // 
            // DataKapatButon
            // 
            this.DataKapatButon.Location = new System.Drawing.Point(1241, 408);
            this.DataKapatButon.Name = "DataKapatButon";
            this.DataKapatButon.Size = new System.Drawing.Size(83, 26);
            this.DataKapatButon.TabIndex = 0;
            this.DataKapatButon.Text = "Kapat";
            this.DataKapatButon.UseVisualStyleBackColor = true;
            this.DataKapatButon.Click += new System.EventHandler(this.DataKapatButon_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(10, 23);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(1314, 379);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaSayfaToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 696);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1344, 33);
            this.menuStrip2.TabIndex = 36;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // anaSayfaToolStripMenuItem
            // 
            this.anaSayfaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.anaSayfaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anaSayfaToolStripMenuItem.Name = "anaSayfaToolStripMenuItem";
            this.anaSayfaToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.anaSayfaToolStripMenuItem.Text = "Ana Sayfa";
            this.anaSayfaToolStripMenuItem.Click += new System.EventHandler(this.anaSayfaToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(1205, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 16);
            this.label6.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(1205, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 38;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UrunAramaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EczaneYonetimSistemi.Properties.Resources.search_bg;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UrunAramaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EYS 2021© ÜRÜN LİSTELEME EKRANI";
            this.Load += new System.EventHandler(this.UrunAramaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxBarkod;
        private System.Windows.Forms.TextBox textBoxUrunAd;
        private System.Windows.Forms.ComboBox comboBoxKategori;
        private System.Windows.Forms.Button urungetirbuton1;
        private System.Windows.Forms.Button urungetirbuton2;
        private System.Windows.Forms.Button urungetirbuton3;
        private System.Windows.Forms.Button urungetirbuton4;
        private System.Windows.Forms.Button urungetirbuton5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxMarka;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button DataKapatButon;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem anaSayfaToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
    }
}