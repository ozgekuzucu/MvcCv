using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
	public class EgitimController : Controller
	{
		// GET: Egitim
		GenericRepository<TBL_Egitimlerim> repo = new GenericRepository<TBL_Egitimlerim>();
		public ActionResult Index()
		{
			var egitim = repo.List();
			return View(egitim);
		}
		[HttpGet]
		public ActionResult EgitimEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult EgitimEkle(TBL_Egitimlerim p)
		{
			if (!ModelState.IsValid)
			{
				return View("EgitimEkle");
			}
			repo.TAdd(p);
			return RedirectToAction("Index");
		}
		public ActionResult EgitimSil(int id)
		{
			var egitim = repo.Find(x => x.ID == id);
			repo.TDelete(egitim);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult EgitimDuzenle(int id)
		{
			TBL_Egitimlerim t = repo.Find(x => x.ID == id);
			return View(t);
		}

		[HttpPost]
		public ActionResult EgitimDuzenle(TBL_Egitimlerim p)
		{
			if (!ModelState.IsValid)
			{
				return View("EgitimDuzenle");
			}
			TBL_Egitimlerim t = repo.Find(x => x.ID == p.ID);
			t.Baslik = p.Baslik;
			t.AltBaslik1 = p.AltBaslik1;
			t.AltBaslik2 = p.AltBaslik2;
			t.GNO = p.GNO;
			t.Tarih = p.Tarih;
			repo.TUpdate(t);
			return RedirectToAction("Index");
		}
	}
}