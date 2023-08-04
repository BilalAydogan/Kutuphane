using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model
{
    [Table("tblKitap")]
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int YazarId { get; set; }
        public int YayinYili { get; set; }
        public string ISBN { get; set; }    
        public int ToplamKopya { get; set; }
        public int KullanilabilirKopya { get; set; }

    }
}
