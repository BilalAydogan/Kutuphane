using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model.Views
{
    [Table("V_Kiralama")]
    public class V_Kiralama
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public string KitapAd { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciAd { get; set; }
        public DateTime KiralamaTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public DateTime? GeriVerisTarih { get; set; }

       
    }
}
