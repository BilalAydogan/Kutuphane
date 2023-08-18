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
    public class KullaniciRepository : RepositoryBase<Kullanici>
    {
        public KullaniciRepository(RepositoryContext context) : base(context)
        {

        }
        public void KullaniciSil(int kullaniciId)
        {
            RepositoryContext.Kullanicilar.Where(k => k.Id == kullaniciId).ExecuteDelete();
        }
        public List<V_Kullanici> KullaniciOzet() => RepositoryContext.KullaniciOzet.ToList<V_Kullanici>();
    }
}
