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
        /*public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<KategoriAnaSayfa> AnaSayfaKategoriler { get; set; }
        public DbSet<KategoriOzellikGrup> KategoriOzelliklerGrup { get; set; }
        public DbSet<Ozellik> Ozellikler { get; set; }
        public DbSet<OzellikGrup> OzellikGrup { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunFoto> UrunFotolar { get; set; }
        public DbSet<UrunKategori> UrunKategorileri { get; set; }
        public DbSet<UrunOzellik> UrunOzellikleri { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }*/
    }
}
