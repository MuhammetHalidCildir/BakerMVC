using BLL.Models;
using Entities.Urunler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Workers
{
    public static class UrunWorker
    {
        public static IQueryable<UrunListItem> UrunListeGetir(Expression<Func<UrunListItem, bool>> expression = null)
        {

            return from u in Repositories.UrunRepo.ReadMany()
                   select new UrunListItem
                   {
                       Id = u.Id,
                       Title = u.Title,
                       Active = u.Active,
                       Deleted = u.Deleted,
                       CreateDate = u.CreateTime,
                       Altkategori = u.AltKategori.Title,
                       Kategori = u.AltKategori.Kategori.Title
                   };
        }

        public static void UrunAktiflikDegistir(int Id)
        {
            Repositories.UrunRepo.UrunAktiflikDegistir(Id);
        }
        public static void UrunSilGeriAl(int Id)
        {
            Repositories.UrunRepo.UrunSilGeriAl(Id);
        }

        public static UrunDetail UrunDetayGetir(int id)
        {
            var u = Repositories.UrunRepo.ReadOne(id);
            return u != null ? new UrunDetail()
            {
                Id = u.Id,
                Title = u.Title,
                Description = u.Description,
                Fiyat = u.Fiyat,
                Kampanya = u.Kampanya,
                KampanyaOrani = u.KampanyaOrani,
                AltkategoriId = u.AltKategoriId
            } : null;
        }
        public static IQueryable<AltKategoriViewModel> AltkategorileriGetir()
        {
            return from a in Repositories.AltKategoriRepo.ReadMany()
                   select new AltKategoriViewModel
                   {
                       Id = a.Id,
                       Active = a.Active,
                       Deleted = a.Deleted,
                       Description = a.Description,
                       Title = a.Title,
                       KategoriId = a.KategoriId
                   };
        }

        public static IQueryable<KategoriViewModel> KategorileriGetir()
        {
            return from a in Repositories.KategoriRepo.ReadMany()
                   select new KategoriViewModel
                   {
                       Id = a.Id,
                       Active = a.Active,
                       Deleted = a.Deleted,
                       Description = a.Description,
                       Title = a.Title
                   };
        }

        public static void UrunEkle(UrunDetail detail)
        {
            var entity = new Urun()
            {
                CreateTime = DateTime.Now,
                Active = true,
                Deleted = false,
                Title = detail.Title,
                Description = detail.Description,
                Kampanya = detail.Kampanya,
                KampanyaOrani = detail.KampanyaOrani,
                AltKategoriId = detail.AltkategoriId,
                Fiyat = detail.Fiyat
            };
            Repositories.UrunRepo.InsertOne(entity);
        }
        public static void UrunGuncelle(UrunDetail detail)
        {
            var orj_entity = Repositories.UrunRepo.ReadOne(detail.Id);
            var entity = new Urun()
            {
                CreateTime = orj_entity.CreateTime,
                Active = orj_entity.Active,
                Deleted = orj_entity.Deleted,
                Title = detail.Title,
                Description = detail.Description,
                Kampanya = detail.Kampanya,
                KampanyaOrani = detail.KampanyaOrani,
                AltKategoriId = detail.AltkategoriId,
                Fiyat = detail.Fiyat,
                Id = detail.Id
            };
            Repositories.UrunRepo.UpdateOne(detail.Id, entity);
        }
    }
}
