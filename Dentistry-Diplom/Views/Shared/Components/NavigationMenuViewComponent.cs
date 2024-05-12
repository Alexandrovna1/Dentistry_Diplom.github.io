using Dentistry_Diplom.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Views.Shared.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        DensContext db;
        public NavigationMenuViewComponent(DensContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(db.CategoryTable.OrderBy(c=>c.categoryName));
        }
    }
}
