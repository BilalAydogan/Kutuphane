using Kutuphane.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository
{
    public class KitapRepository : RepositoryBase<Kitap>
    {
        public KitapRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
