using DAL.Repositories.Urunler;

namespace BLL
{
    public static class Repositories
    {
        public static readonly UrunRepository UrunRepo = new UrunRepository();
        public static readonly KategoriRepository KategoriRepo = new KategoriRepository();
        public static readonly AltKategoriRepository AltKategoriRepo = new AltKategoriRepository();
    }
}
