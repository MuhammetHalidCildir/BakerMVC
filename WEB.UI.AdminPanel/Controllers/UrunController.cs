using BLL.Models;
using BLL.Workers;
using System;
using System.Web.Mvc;

namespace WEB.UI.AdminPanel.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            return View(UrunWorker.UrunListeGetir());
        }

        // GET: Urun/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Urun/Edit/5
        public ActionResult CreateOrEdit(int? id)
        {
            //Html tarafında dropdown (select) etiketini doldurmak için yazılır.
            ViewBag.AltKategoriler = UrunWorker.AltkategorileriGetir();
            if (id != null)
            {
                return View(UrunWorker.UrunDetayGetir((int)id));
            }
            else
            {
                return View();
            }
        }

        // POST: Urun/Edit/5
        [HttpPost]
        public ActionResult CreateOrEdit(int? id, UrunDetail model)
        {

            if (id == null)
            {
                UrunWorker.UrunEkle(model);
            }
            else
            {
                UrunWorker.UrunGuncelle(model);
            }

            return RedirectToAction("Index");
        }

        // GET: Urun/Delete/5
        public ActionResult Delete(int id)
        {
            UrunWorker.UrunSilGeriAl(id);
            return RedirectToAction("Index");
        }

        public ActionResult Activate(int Id)
        {
            UrunWorker.UrunAktiflikDegistir(Id);
            //Belirtilen aksiyona yönlendirir.
            return RedirectToAction("Index");
        }
    }
}
