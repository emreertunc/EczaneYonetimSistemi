namespace EczaneYonetimSistemi
{
    partial class MusteriBilgiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusteriBilgiForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TelNotextBox = new System.Windows.Forms.MaskedTextBox();
            this.TemizleButon = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CariIDtextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bilgiGetirButon = new System.Windows.Forms.Button();
            this.KurumAditextBox = new System.Windows.Forms.TextBox();
            this.GuncelleButon = new System.Windows.Forms.Button();
            this.VergiDairesitextBox = new System.Windows.Forms.TextBox();
            this.CariTipcomboBox = new System.Windows.Forms.ComboBox();
            this.TcNotextBox = new System.Windows.Forms.TextBox();
            this.VergiNotextBox = new System.Windows.Forms.TextBox();
            this.CariAdtextBox = new System.Windows.Forms.TextBox();
            this.CariListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SatisGetirButon = new System.Windows.Forms.Button();
            this.EskiSatislarlistBox = new System.Windows.Forms.ListBox();
            this.CariListBox2 = new System.Windows.Forms.ListBox();
            this.modDegistirButon1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anaSayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.groupBox1.Controls.Add(this.TelNotextBox);
            this.groupBox1.Controls.Add(this.TemizleButon);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CariIDtextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bilgiGetirButon);
            this.groupBox1.Controls.Add(this.KurumAditextBox);
            this.groupBox1.Controls.Add(this.GuncelleButon);
            this.groupBox1.Controls.Add(this.VergiDairesitextBox);
            this.groupBox1.Controls.Add(this.CariTipcomboBox);
            this.groupBox1.Controls.Add(this.TcNotextBox);
            this.groupBox1.Controls.Add(this.VergiNotextBox);
            this.groupBox1.Controls.Add(this.CariAdtextBox);
            this.groupBox1.Controls.Add(this.CariListBox);
            this.groupBox1.Location = new System.Drawing.Point(293, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 283);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cari Düzenleme Menüsü";
            // 
            // TelNotextBox
            // 
            this.TelNotextBox.Location = new System.Drawing.Point(564, 178);
            this.TelNotextBox.Mask = "(999) 000-0000";
            this.TelNotextBox.Name = "TelNotextBox";
            this.TelNotextBox.ReadOnly = true;
            this.TelNotextBox.Size = new System.Drawing.Size(180, 20);
            this.TelNotextBox.TabIndex = 7;
            this.TelNotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TelNotextBox_KeyPress);
            // 
            // TemizleButon
            // 
            this.TemizleButon.Enabled = false;
            this.TemizleButon.Location = new System.Drawing.Point(526, 233);
            this.TemizleButon.Name = "TemizleButon";
            this.TemizleButon.Size = new System.Drawing.Size(106, 36);
            this.TemizleButon.TabIndex = 9;
            this.TemizleButon.Text = "Temizle";
            this.TemizleButon.UseVisualStyleBackColor = true;
            this.TemizleButon.Click += new System.EventHandler(this.TemizleButon_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(507, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cari ID";
            // 
            // CariIDtextBox
            // 
            this.CariIDtextBox.Location = new System.Drawing.Point(564, 207);
            this.CariIDtextBox.Name = "CariIDtextBox";
            this.CariIDtextBox.ReadOnly = true;
            this.CariIDtextBox.Size = new System.Drawing.Size(180, 20);
            this.CariIDtextBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(440, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Telefon Numarası";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(497, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cari Tipi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(487, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Kurum Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(469, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Vergi Dairesi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(470, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "T.C. Kimlik No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(454, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Vergi Numarası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(444, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cari İsim-Soyisim";
            // 
            // bilgiGetirButon
            // 
            this.bilgiGetirButon.Location = new System.Drawing.Point(306, 234);
            this.bilgiGetirButon.Name = "bilgiGetirButon";
            this.bilgiGetirButon.Size = new System.Drawing.Size(106, 36);
            this.bilgiGetirButon.TabIndex = 0;
            this.bilgiGetirButon.Text = "Bilgileri Getir";
            this.bilgiGetirButon.UseVisualStyleBackColor = true;
            this.bilgiGetirButon.Click += new System.EventHandler(this.bilgiGetirButon_Click);
            // 
            // KurumAditextBox
            // 
            this.KurumAditextBox.Location = new System.Drawing.Point(564, 125);
            this.KurumAditextBox.Name = "KurumAditextBox";
            this.KurumAditextBox.ReadOnly = true;
            this.KurumAditextBox.Size = new System.Drawing.Size(180, 20);
            this.KurumAditextBox.TabIndex = 5;
            // 
            // GuncelleButon
            // 
            this.GuncelleButon.Enabled = false;
            this.GuncelleButon.Location = new System.Drawing.Point(638, 233);
            this.GuncelleButon.Name = "GuncelleButon";
            this.GuncelleButon.Size = new System.Drawing.Size(106, 36);
            this.GuncelleButon.TabIndex = 10;
            this.GuncelleButon.Text = "Bilgileri Güncelle";
            this.GuncelleButon.UseVisualStyleBackColor = true;
            this.GuncelleButon.Click += new System.EventHandler(this.GuncelleButon_Click);
            // 
            // VergiDairesitextBox
            // 
            this.VergiDairesitextBox.Location = new System.Drawing.Point(564, 99);
            this.VergiDairesitextBox.Name = "VergiDairesitextBox";
            this.VergiDairesitextBox.ReadOnly = true;
            this.VergiDairesitextBox.Size = new System.Drawing.Size(180, 20);
            this.VergiDairesitextBox.TabIndex = 4;
            this.VergiDairesitextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VergiDairesitextBox_KeyPress);
            // 
            // CariTipcomboBox
            // 
            this.CariTipcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CariTipcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CariTipcomboBox.FormattingEnabled = true;
            this.CariTipcomboBox.Items.AddRange(new object[] {
            "Müşteri",
            "Satıcı"});
            this.CariTipcomboBox.Location = new System.Drawing.Point(564, 151);
            this.CariTipcomboBox.Name = "CariTipcomboBox";
            this.CariTipcomboBox.Size = new System.Drawing.Size(180, 21);
            this.CariTipcomboBox.TabIndex = 6;
            // 
            // TcNotextBox
            // 
            this.TcNotextBox.Location = new System.Drawing.Point(564, 73);
            this.TcNotextBox.MaxLength = 11;
            this.TcNotextBox.Name = "TcNotextBox";
            this.TcNotextBox.ReadOnly = true;
            this.TcNotextBox.Size = new System.Drawing.Size(180, 20);
            this.TcNotextBox.TabIndex = 3;
            this.TcNotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TcNotextBox_KeyPress);
            // 
            // VergiNotextBox
            // 
            this.VergiNotextBox.Location = new System.Drawing.Point(564, 47);
            this.VergiNotextBox.Name = "VergiNotextBox";
            this.VergiNotextBox.ReadOnly = true;
            this.VergiNotextBox.Size = new System.Drawing.Size(180, 20);
            this.VergiNotextBox.TabIndex = 2;
            this.VergiNotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VergiNotextBox_KeyPress);
            // 
            // CariAdtextBox
            // 
            this.CariAdtextBox.Location = new System.Drawing.Point(564, 21);
            this.CariAdtextBox.Name = "CariAdtextBox";
            this.CariAdtextBox.ReadOnly = true;
            this.CariAdtextBox.Size = new System.Drawing.Size(180, 20);
            this.CariAdtextBox.TabIndex = 1;
            this.CariAdtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CariAdtextBox_KeyPress);
            // 
            // CariListBox
            // 
            this.CariListBox.FormattingEnabled = true;
            this.CariListBox.Location = new System.Drawing.Point(22, 22);
            this.CariListBox.Name = "CariListBox";
            this.CariListBox.Size = new System.Drawing.Size(278, 251);
            this.CariListBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SeaGreen;
            this.groupBox2.Controls.Add(this.SatisGetirButon);
            this.groupBox2.Controls.Add(this.EskiSatislarlistBox);
            this.groupBox2.Controls.Add(this.CariListBox2);
            this.groupBox2.Location = new System.Drawing.Point(293, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 283);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eski Satışlar Menüsü";
            this.groupBox2.Visible = false;
            // 
            // SatisGetirButon
            // 
            this.SatisGetirButon.Location = new System.Drawing.Point(314, 125);
            this.SatisGetirButon.Name = "SatisGetirButon";
            this.SatisGetirButon.Size = new System.Drawing.Size(139, 36);
            this.SatisGetirButon.TabIndex = 1;
            this.SatisGetirButon.Text = "Müşteriye Ait Satışları Getir";
            this.SatisGetirButon.UseVisualStyleBackColor = true;
            this.SatisGetirButon.Click += new System.EventHandler(this.SatisGetirButon_Click);
            // 
            // EskiSatislarlistBox
            // 
            this.EskiSatislarlistBox.FormattingEnabled = true;
            this.EskiSatislarlistBox.Location = new System.Drawing.Point(466, 19);
            this.EskiSatislarlistBox.Name = "EskiSatislarlistBox";
            this.EskiSatislarlistBox.Size = new System.Drawing.Size(278, 251);
            this.EskiSatislarlistBox.TabIndex = 2;
            // 
            // CariListBox2
            // 
            this.CariListBox2.FormattingEnabled = true;
            this.CariListBox2.Location = new System.Drawing.Point(22, 19);
            this.CariListBox2.Name = "CariListBox2";
            this.CariListBox2.Size = new System.Drawing.Size(278, 251);
            this.CariListBox2.TabIndex = 0;
            this.CariListBox2.Click += new System.EventHandler(this.CariListBox2_Click);
            // 
            // modDegistirButon1
            // 
            this.modDegistirButon1.Location = new System.Drawing.Point(546, 360);
            this.modDegistirButon1.Name = "modDegistirButon1";
            this.modDegistirButon1.Size = new System.Drawing.Size(250, 40);
            this.modDegistirButon1.TabIndex = 0;
            this.modDegistirButon1.Text = "Cari Düzenleme / Eski Satışlar Menüsü";
            this.modDegistirButon1.UseVisualStyleBackColor = true;
            this.modDegistirButon1.Click += new System.EventHandler(this.modDegistirButon1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaSayfaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 696);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1344, 33);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1205, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 16);
            this.label9.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1205, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 16);
            this.label10.TabIndex = 31;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MusteriBilgiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EczaneYonetimSistemi.Properties.Resources.customer_bg;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.modDegistirButon1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MusteriBilgiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EYS 2021© CARİ YÖNETİM EKRANI";
            this.Load += new System.EventHandler(this.MusteriBilgiForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CariTipcomboBox;
        private System.Windows.Forms.TextBox TcNotextBox;
        private System.Windows.Forms.TextBox VergiNotextBox;
        private System.Windows.Forms.TextBox CariAdtextBox;
        private System.Windows.Forms.ListBox CariListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button GuncelleButon;
        private System.Windows.Forms.TextBox VergiDairesitextBox;
        private System.Windows.Forms.TextBox KurumAditextBox;
        private System.Windows.Forms.Button bilgiGetirButon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CariIDtextBox;
        private System.Windows.Forms.Button TemizleButon;
        private System.Windows.Forms.ListBox CariListBox2;
        private System.Windows.Forms.ListBox EskiSatislarlistBox;
        private System.Windows.Forms.Button SatisGetirButon;
        private System.Windows.Forms.Button modDegistirButon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anaSayfaToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox TelNotextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer1;
    }
}