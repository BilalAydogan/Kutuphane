using Kutuphane.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository
{
    public class YazarRepository : RepositoryBase<Yazar>
    {
        public YazarRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
