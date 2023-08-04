using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model
{
    [Table("tblKullanici")]
    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public int RolId { get; set; }
        public bool Aktif { get; set; }
        public DateTime KayitTarih { get; set; }
        public string Adres { get; set; }
        public string Foto { get; set; }    

    }
}
