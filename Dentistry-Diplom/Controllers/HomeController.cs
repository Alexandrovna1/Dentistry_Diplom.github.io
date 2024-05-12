using Dentistry_Diplom.Data.Context;
using Dentistry_Diplom.Data.Models;
using Dentistry_Diplom.Data.Repository;
using Dentistry_Diplom.Data.ViewModels;
using Dentistry_Diplom.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace Dentistry_Diplom.Controllers
{
    public class HomeController : Controller
    {
        DensContext db;
        private int pageSize = 6;
        private int MaxPage => (int)Math.Ceiling((decimal)db.DentistryTable.Count() / pageSize);
        public HomeController(DensContext context)
        {
            db = context;
        }

        public IActionResult Index(int category = 1, int page = 1)
        {
            PageLinkTagHelper.categoryId = category;
            ViewBag.Title = "Главная страница";
            return View(
                new DentistryPagingModel
                {
                    Dentistrys = db.DentistryTable
                    .Where(c=>c.categoryId == category)
                    .OrderBy(c=>c.id)
                    .Skip((page-1) * pageSize)
                    .Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = db.DentistryTable.Where(c=>c.categoryId==category).Count()
                    }
                    
                });
        }
        public IActionResult AddAllDentistrys()
        {
            MockDentistrys mockDentistrys = new MockDentistrys();
            foreach (DentistryInfo dens in mockDentistrys.Dentistrys)
            {
                db.DentistryTable.Add(dens);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SingleDentistry(int _id)
        {
            DentistryInfo dens = db.DentistryTable.Find(_id);
            ViewBag.Title = $"Просмотр консоли {dens.name}";
            return View(dens);
        }
        public IActionResult DeleteDentistry(int _id)
        {
            DentistryInfo dens = db.DentistryTable.Find(_id);
            db.DentistryTable.Remove(dens);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
