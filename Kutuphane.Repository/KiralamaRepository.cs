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
    public class KiralamaRepository : RepositoryBase<Kiralama>
    {
        public KiralamaRepository(RepositoryContext context) : base(context)
        {
        }
        public void KiralamaSil(int kiralamaId)
        {
            RepositoryContext.Kiralamalar.Where(k => k.Id == kiralamaId).ExecuteDelete();
        }
        public List<V_Kiralama> KiralamaOzet() => RepositoryContext.KiralamaOzet.ToList<V_Kiralama>(); 
    }
}
