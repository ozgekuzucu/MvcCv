using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		// GET: Default
		DbCVEntities db = new DbCVEntities();
		public ActionResult Index()
		{
			var degerler = db.TBL_Hakkimda.ToList();
			return View(degerler);
		}
		public PartialViewResult Deneyim()
		{
			var deneyimler = db.TBL_Deneyimler.ToList();
			return PartialView(deneyimler);
		}
		public PartialViewResult SosyalMedya()
		{
			var sosyalmedya = db.TBL_SosyalMedya.Where(x=>x.Durum == true).ToList();
			return PartialView(sosyalmedya);
		}
		public PartialViewResult Egitimlerim()
		{
			var egitimler = db.TBL_Egitimlerim.ToList();
			return PartialView(egitimler);
		}
		public PartialViewResult Yetenekler()
		{
			var yetenekler = db.TBL_Yeteneklerim.ToList();
			return PartialView(yetenekler);
		}
		public PartialViewResult Hobilerim()
		{
			var hobiler = db.TBL_Hobilerim.ToList();
			return PartialView(hobiler);
		}
		public PartialViewResult Sertifikalarim()
		{
			var sertifikalar = db.TBL_Sertifikalarim.ToList();
			return PartialView(sertifikalar);
		}
		[HttpGet]
		public PartialViewResult Iletisim()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult Iletisim(TBL_Iletisim t)
		{
			t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			db.TBL_Iletisim.Add(t);
			db.SaveChanges();
			return PartialView();
		}
	}
}