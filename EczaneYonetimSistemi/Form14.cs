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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using System.Configuration;

namespace EczaneYonetimSistemi
{
    public partial class faturaForm : Form
    {
        public faturaForm()
        {
            InitializeComponent();
        }

        db dblayer = new db();
        private void faturaForm_Load(object sender, EventArgs e)
        {
            List<FATURA> liste1 = new List<FATURA>();
            DataSet ds3 = dblayer.FATURA(SatisForm.quantity2);

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
            DataSet ds = dblayer.FATURA_KALEM(SatisForm.quantity3);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                liste2.Add(new FATURA_KALEM
                {
                    Faturakalem_id = Convert.ToInt32(dr["Faturakalem_id"]),
                    Fatura_id = Convert.ToInt32(dr["Fatura_id"]),
                    Urun_id = Convert.ToInt32(dr["Urun_id"]),
                    Urun_Adi=dr["Urun_Adi"].ToString(),
                    NetFiyat = dr["NetFiyat"].ToString(),
                    KDV_Orani = dr["KDV_Orani"].ToString(),
                    KDV_Fiyati = dr["KDV_Fiyati"].ToString(),
                    Brut_Fiyat = dr["Brut_Fiyat"].ToString(),
                    Miktar = Convert.ToInt32(dr["Miktar"])
                });
            }
            
            fatura11.SetDataSource(liste2);
            crystalReportViewer1.ReportSource = fatura11;

            DataSet ds2 = dblayer.CARI_TABLO(SatisForm.quantity1);
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                fatura11.SetParameterValue("pCustomer", dr["Cari_Adi"].ToString());
                fatura11.SetParameterValue("pCustomerTc", dr["TC_No"].ToString());
                fatura11.SetParameterValue("pCustomerTel", dr["Telefon"].ToString());
            }

            DataSet ds4 = dblayer.FATURA(SatisForm.quantity2);
            foreach (DataRow dr in ds4.Tables[0].Rows)
            {
                fatura11.SetParameterValue("pNetToplam", dr["Net_Fiyat"].ToString());
                fatura11.SetParameterValue("pKdvToplam", dr["KDV_Toplami"].ToString());
                fatura11.SetParameterValue("pGenelToplam", dr["Toplam"].ToString());
                fatura11.SetParameterValue("pOdemeYontemi", dr["Odeme_Yontemi"].ToString());
                fatura11.SetParameterValue("pFaturaNo", dr["Fatura_No"].ToString());
                fatura11.SetParameterValue("pFaturaTarih", dr["Fatura_Tarih"].ToString());
                fatura11.SetParameterValue("pFaturaTip", dr["Fatura_Tipi"].ToString());
            }
        }

        private void faturaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //OtoMesageBoxKapa.Show("Fatura kaydedildi.", "Bilgi", 2000);
        }

        private void faturaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OtoMesageBoxKapa.Show("Fatura kaydedildi.", "Bilgi", 2000);
        }
    }
}
