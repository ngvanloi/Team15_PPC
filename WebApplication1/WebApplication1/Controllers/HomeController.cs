using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        PPCDBEntities1 model = new PPCDBEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            var p = model.Properties.ToList();
            return View(p);
        }

        [HttpPost]
        public ActionResult Index(string keyword)
        {
            var p = model.Properties.Where(x => x.Property_Name.Contains(keyword)).ToList();

            return View(p);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Search(string search)
        {
            var p = model.Properties.Where(x => x.Property_Name.Contains(search)).ToList();
            return View(p);
        }
       

        
    }
}