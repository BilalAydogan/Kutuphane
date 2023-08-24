using Kutuphane.Model;
using Kutuphane.Model.Views;
using Microsoft.EntityFrameworkCore;
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
        public void KitapSil(int kitapId)
        {
            RepositoryContext.Kitaplar.Where(r => r.Id == kitapId).ExecuteDelete();
        }
        public List<V_Kitap> KitapOzet() => RepositoryContext.KitapOzet.ToList<V_Kitap>();

    }
}
