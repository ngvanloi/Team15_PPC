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
        PPCDBEntities model = new PPCDBEntities();
        public ActionResult Index()
        {
            var p = model.Properties.ToList();
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