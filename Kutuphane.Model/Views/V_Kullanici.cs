using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model.Views
{
    public class V_Kullanici
    {
        public int Id { get; set; } 
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string TelNo { get; set; }
        public bool Aktif { get; set; }
        public DateTime KayitTarih { get; set; }
        public string Adres { get; set; }
        public string Foto { get; set; }
        public int RolId { get; set; }
        public string RolAd { get; set; }
    }
}
