using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Model
{
    [Table("tblRol")]
    public class Rol
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
}
