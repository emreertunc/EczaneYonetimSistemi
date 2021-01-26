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

namespace EczaneYonetimSistemi
{
    public partial class HakkindaForm : Form
    {
        public HakkindaForm()
        {
            InitializeComponent();
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.DeselectAll();
        }

        private void HakkindaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           // OtoMesageBoxKapa.Show("Fatura kaydedildi.", "Bilgi", 2000);
        }

        private void HakkindaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //OtoMesageBoxKapa.Show("Fatura kaydedildi.", "Bilgi", 2000);
        }

        private void HakkindaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
