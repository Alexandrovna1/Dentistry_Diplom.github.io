using Dentistry_Diplom.Data.Context;
using Dentistry_Diplom.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Dentistry_Diplom.Controllers
{
    public class CategoryController : Controller
    {
        private DensContext db;
        public CategoryController(DensContext context)
        {
            db = context;
        }
        public IActionResult PortativeCategory()
        {
            List<DentistryInfo> dens = db.DentistryTable.ToList();
            ViewBag.Title = "Таблица портативных консолей";
            return View(dens);
        }
        public IActionResult StationarCategory()
        {
            List<DentistryInfo> dens = db.DentistryTable.ToList();
            ViewBag.Title = "Таблица стационарных консолей";
            return View(dens);
        }
    }
}
