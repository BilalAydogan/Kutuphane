using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model
{
    [Table("tblKiralama")]
    public class Kiralama
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public int KullaniciId { get; set; }
        public DateTime KiralamaTarih { get; set; }
        public DateTime BitiTarih { get; set; }
        public DateTime? GeriVerisTarih { get; set; }
    }
}
