using DAL.EfContexts;

namespace DAL.Repositories
{
    //Her veritabanı için genericrepository yapısnı kalıtım alan alt kırılımlar oluşturularak entity yapıları gruplanabilir.
    public abstract class UrunlerBaseRepository<T> : GenericRepository<T> where T : class
    {
        protected UrunlerBaseRepository() : base(new Ef_Urunler()) { }
    }

    public abstract class ToptanBaseRepository<T> : GenericRepository<T> where T : class
    {
        protected ToptanBaseRepository() : base(new Ef_Toptan()) { }
    }

    public abstract class PerakendeBaseRepository<T> : GenericRepository<T> where T : class
    {
        protected PerakendeBaseRepository() : base(new Ef_Perakende()) { }
    }
}
