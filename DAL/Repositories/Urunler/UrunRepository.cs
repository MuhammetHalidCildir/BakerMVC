using Entities.Urunler;
using System.Linq;

namespace DAL.Repositories.Urunler
{
    //Her veritabanı için genericrepository yapısnı kalıtım alan alt kırılımlar oluşturularak entity yapıları gruplanabilir.
    public sealed class UrunRepository : UrunlerBaseRepository<Urun>
    {
        public void UrunAktiflikDegistir(int Id)
        {
            var urun = ReadOne(Id);
            urun.Active = !urun.Active;
            UpdateOne(Id, urun);
        }

        public void UrunSilGeriAl(int Id)
        {
            var urun = ReadOne(Id);
            urun.Deleted = !urun.Deleted;
            UpdateOne(Id, urun);
        }

    }
}
