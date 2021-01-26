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
    class FATURA_KALEM
    {
        public int Faturakalem_id { get; set; }
        public int Fatura_id { get; set; }
        public int Urun_id { get; set; }
        public string Urun_Adi { get; set; }
        public string NetFiyat { get; set; }
        public string KDV_Orani { get; set; }
        public string KDV_Fiyati { get; set; }
        public string Brut_Fiyat { get; set; }
        public int Miktar { get; set; }
    }
}
