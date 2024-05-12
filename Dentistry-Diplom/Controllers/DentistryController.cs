using Dentistry_Diplom.Data.Context;
using Dentistry_Diplom.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Dentistry_Diplom.Controllers
{
    public class DentistryController : Controller
    {
        private DensContext db;
        private IHostingEnvironment env;
        private string imgPath;

        public DentistryController(DensContext context, IHostingEnvironment environment)
        {
            db = context;
            env = environment;
        }

        public IActionResult DentistryList()
        {
            List<DentistryInfo> dens = db.DentistryTable.ToList();
            ViewBag.Title = "Таблица консолей";
            return View(dens);
        }

        [HttpGet]
        public IActionResult EditDentistry(int? _id)
        {
            if (_id == null)
                return RedirectToAction("DentistryList");
            else
            {
                DentistryInfo dens = db.DentistryTable.Find(_id);
                return View(dens);
            }
        }

        [HttpPost]
        public IActionResult EditDentistry(DentistryInfo dens, IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {
                string path = "/img/" + Path.GetFileName(uploadedFile.FileName);
                dens.img = path;
                using( FileStream fileStream = new FileStream(env.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
            }
            db.Entry(dens).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToRoute(new { controller = "Dentistry", action = "DentistryList" });
        }
    }
}
