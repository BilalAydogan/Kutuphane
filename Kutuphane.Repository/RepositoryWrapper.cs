using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;
        private KategoriRepository kategoriRepository;
        private RolRepository rolRepository;
        private KullaniciRepository kullaniciRepository;
        private KiralamaRepository kiralamaRepository;
        private KitapRepository kitapRepository;
        private KitapKategoriRepository kitapkategoriRepository;
        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }

        public KategoriRepository KategoriRepository
        {
            get
            {
                if (kategoriRepository == null)
                    kategoriRepository = new KategoriRepository(context);
                return kategoriRepository;
            }
        }
        public RolRepository RolRepository
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);
                return rolRepository;
            }
        }
        public KullaniciRepository KullaniciRepository
        {
            get
            {
                if (kullaniciRepository == null)
                    kullaniciRepository = new KullaniciRepository(context);
                return kullaniciRepository;

            }
        }
        public KiralamaRepository KiralamaRepository
        {
            get
            {
                if (kiralamaRepository == null)
                    kiralamaRepository = new KiralamaRepository(context);
                return kiralamaRepository;
            }
        }
        public KitapRepository KitapRepository
        {
            get
            {
                if (kitapRepository == null)
                    kitapRepository = new KitapRepository(context);
                return kitapRepository;
            }
        }
        public KitapKategoriRepository KitapKategoriRepository
        {
            get
            {
                if (kitapkategoriRepository == null)
                    kitapkategoriRepository = new KitapKategoriRepository(context);
                return kitapkategoriRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
