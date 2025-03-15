using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
	public class DeneyimController : Controller
	{
		// GET: Deneyim
		DeneyimRepository repo = new DeneyimRepository();
		public ActionResult Index()
		{
			var deneyimler = repo.List();
			return View(deneyimler);
		}
		[HttpGet]
		public ActionResult DeneyimEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult DeneyimEkle(TBL_Deneyimler p)
		{
			repo.TAdd(p);
			return RedirectToAction("Index");
		}
		public ActionResult DeneyimSil(int id)
		{
			TBL_Deneyimler t = repo.Find(x => x.ID == id);
			repo.TDelete(t);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult DeneyimGetir(int id)
		{
			TBL_Deneyimler t = repo.Find(x => x.ID == id);
			return View(t);
		}
		[HttpPost]
		public ActionResult DeneyimGetir(TBL_Deneyimler p)
		{
			TBL_Deneyimler t = repo.Find(x => x.ID == p.ID);
			t.Baslik=p.Baslik;
			t.AltBaslik=p.AltBaslik;
			t.Tarih=p.Tarih;
			t.Aciklama=p.Aciklama;
			repo.TUpdate(t);
			return RedirectToAction("Index");
			return View(t);
		}
	}
}