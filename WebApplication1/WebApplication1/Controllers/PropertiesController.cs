using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.IO;
namespace WebApplication1.Controllers
{
    public class PropertiesController : Controller
    {
        private PPCDBEntities model = new PPCDBEntities(); 
        // GET: Properties
        public ActionResult Index()
        {
            var properties = model.Properties.Include(x => x.District).Include(x => x.Property_Status).Include(x => x.Property_Type);
            return View(properties.ToList());
        }
        public void PopularData(object propertyTypeSelected = null,object propertyStatusSelected = null,object citySelected = null,object districtSelected = null)
        {
            ViewBag.Property_Type_ID = new SelectList(model.Property_Type.ToList(), "ID", "Property_Type_Name", propertyTypeSelected);
            ViewBag.Property_Status_ID = new SelectList(model.Property_Status.ToList(), "ID", "Property_Status_Name", propertyStatusSelected);
            ViewBag.City_ID = new SelectList(model.Cities.ToList(), "ID", "City_Name", citySelected);
            ViewBag.District_ID = new SelectList(model.Districts.ToList(), "ID", "District_Name", districtSelected);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var property = model.Properties.Find(id);
            if(property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }
    }
}