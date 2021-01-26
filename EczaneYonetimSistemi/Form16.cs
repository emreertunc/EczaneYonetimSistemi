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
    public partial class iadeFormFatura : Form
    {
        public iadeFormFatura()
        {
            InitializeComponent();
        }
        db dblayer2 = new db();
        private void Form16_Load(object sender, EventArgs e)
        {
            List<FATURA> liste1 = new List<FATURA>();
            DataSet ds3 = dblayer2.FATURA(IadeForm.quantity5);

            foreach (DataRow dr in ds3.Tables[0].Rows)
            {
                liste1.Add(new FATURA
                {
                    Fatura_id = Convert.ToInt32(dr["Fatura_id"]),
                    Fatura_No = Convert.ToInt32(dr["Fatura_No"]),
                    Fatura_Tarih = dr["Fatura_Tarih"].ToString(),
                    Cari_id = Convert.ToInt32(dr["Cari_id"]),
                    Fatura_Tipi = dr["Fatura_Tipi"].ToString(),
                    KDV_Toplami = dr["KDV_Toplami"].ToString(),
                    Net_Fiyat = dr["Net_Fiyat"].ToString(),
                    Toplam = dr["Toplam"].ToString(),
                    Odeme_Yontemi = dr["Odeme_Yontemi"].ToString()
                });
            }

            List<FATURA_KALEM> liste2 = new List<FATURA_KALEM>();
            DataSet ds = dblayer2.FATURA_KALEM(IadeForm.quantity6);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                liste2.Add(new FATURA_KALEM
                {
                    Faturakalem_id = Convert.ToInt32(dr["Faturakalem_id"]),
                    Fatura_id = Convert.ToInt32(dr["Fatura_id"]),
                    Urun_id = Convert.ToInt32(dr["Urun_id"]),
                    Urun_Adi = dr["Urun_Adi"].ToString(),
                    NetFiyat = dr["NetFiyat"].ToString(),
                    KDV_Orani = dr["KDV_Orani"].ToString(),
                    KDV_Fiyati = dr["KDV_Fiyati"].ToString(),
                    Brut_Fiyat = dr["Brut_Fiyat"].ToString(),
                    Miktar = Convert.ToInt32(dr["Miktar"])
                });
            }
            fatura31.SetDataSource(liste2);
            crystalReportViewer1.ReportSource = fatura31;

            DataSet ds2 = dblayer2.CARI_TABLO(IadeForm.quantity4);
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                fatura31.SetParameterValue("pCustomer", dr["Cari_Adi"].ToString());
                fatura31.SetParameterValue("pCustomerTc", dr["TC_No"].ToString());
                fatura31.SetParameterValue("pCustomerTel", dr["Telefon"].ToString());
            }

            DataSet ds4 = dblayer2.FATURA(IadeForm.quantity5);
            foreach (DataRow dr in ds4.Tables[0].Rows)
            {
                fatura31.SetParameterValue("pNetToplam", dr["Net_Fiyat"].ToString());
                fatura31.SetParameterValue("pKdvToplam", dr["KDV_Toplami"].ToString());
                fatura31.SetParameterValue("pGenelToplam", dr["Toplam"].ToString());
                fatura31.SetParameterValue("pOdemeYontemi", dr["Odeme_Yontemi"].ToString());
                fatura31.SetParameterValue("pFaturaNo", dr["Fatura_No"].ToString());
                fatura31.SetParameterValue("pFaturaTarih", dr["Fatura_Tarih"].ToString());
                fatura31.SetParameterValue("pFaturaTip", dr["Fatura_Tipi"].ToString());
            }
        }

        private void iadeFormFatura_FormClosed(object sender, FormClosedEventArgs e)
        {
          //OtoMesageBoxKapa.Show("Fatura kaydedildi.", "Bilgi", 2000);
        }

        private void iadeFormFatura_FormClosing(object sender, FormClosingEventArgs e)
        {
            OtoMesageBoxKapa.Show("Fatura kaydedildi.", "Bilgi", 2000);  
        }
    }
}
