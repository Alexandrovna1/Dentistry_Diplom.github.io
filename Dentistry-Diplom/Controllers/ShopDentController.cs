using Dentistry_Diplom.Data.Context;
using Dentistry_Diplom.Data.Models;
using Dentistry_Diplom.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Controllers
{
    public class ShopDentController : Controller
    {
        private ShopDent _shopDent;
        private DensContext db;
        public ShopDentController(DensContext context, ShopDent shopDent)
        {
            _shopDent = shopDent;
            db = context;
        }

        public ViewResult Index()
        {
            var items = _shopDent.GetShopItems();
            _shopDent.shopDentItems = items;
            var obj = new ShopDentViewModel { shopDent = _shopDent };
            return View(obj);
        }

        public RedirectToActionResult AddToDent(int Id)
        {
            DentistryInfo item = db.DentistryTable.Find(Id); 
            if (item != null)
                _shopDent.AddToDent(item); 

            return RedirectToAction("Index"); 
        }
    
    }
}
