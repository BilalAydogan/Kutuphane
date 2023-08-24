using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model.Views
{
    [Table("V_Kitap")]
    public class V_Kitap
    {
        public int Kategori_id { get; set; }
        public string Kategori_Ad { get; set; }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public int YayinYili { get; set; }
        public string ISBN { get; set; }
        public int KategoriId{ get; set; }
    }
}
