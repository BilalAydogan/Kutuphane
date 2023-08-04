using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model
{
    [Table("tblKitapKategori")]
    public class KitapKategori
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public int KategoriId { get; set; }
    }
}
