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
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<KitapKategori> KitapKategorileri { get; set; }
        public DbSet<V_Kiralama> KiralamaOzet { get; set; }
        public DbSet<V_Kullanici> KullaniciOzet { get; set; }
    }
}
