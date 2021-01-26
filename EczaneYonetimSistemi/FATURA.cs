// Copyright © EYS 2021, Emre Ertunç
// Tüm Hakları Saklıdır.
// İzinsiz Kullanılamaz.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneYonetimSistemi
{
    class FATURA
    {
        public int Fatura_id { get; set; }
        public int Fatura_No { get; set; }
        public string Fatura_Tarih { get; set; }
        public int Cari_id { get; set; }
        public string Fatura_Tipi { get; set; }
        public string KDV_Toplami { get; set; }
        public string Net_Fiyat { get; set; }
        public string Toplam { get; set; }
        public string Odeme_Yontemi { get; set; }
    }
}
