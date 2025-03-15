using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	public class YetenekController : Controller
	{
		// GET: Yetenek
		GenericRepository<TBL_Yeteneklerim> repo = new GenericRepository<TBL_Yeteneklerim>();
		public ActionResult Index()
		{
			var yetenekler = repo.List();
			return View(yetenekler);
		}
		[HttpGet]
		public ActionResult YeniYetenek()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniYetenek(TBL_Yeteneklerim p)
		{
			repo.TAdd(p);
			return RedirectToAction("Index");
		}
		public ActionResult YetenekSil(int id)
		{
			var yetenek=repo.Find(x=>x.ID==id);
			repo.TDelete(yetenek);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult YetenekDuzenle(int id)
		{
			var yetenek = repo.Find(x => x.ID == id);
			return View(yetenek);
		}
		[HttpPost]
		public ActionResult YetenekDuzenle(TBL_Yeteneklerim t)
		{
			var yetenek = repo.Find(x => x.ID == t.ID);
			yetenek.Yetenek = t.Yetenek;
			yetenek.Oran = t.Oran;
			repo.TUpdate(yetenek);
			return RedirectToAction("Index");
		}
	}
}