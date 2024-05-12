using Dentistry_Diplom.Data.Context;
using Dentistry_Diplom.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Controllers
{
    public class OrderController : Controller
    {
        private DensContext db;
        private ShopDent shopDent;
        public OrderController(DensContext context, ShopDent _shopDent)
        {
            db = context;
            shopDent = _shopDent;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopDent.shopDentItems = shopDent.GetShopItems();
            if(shopDent.shopDentItems.Count == 0)
            {
                ModelState.AddModelError("", "Должны быть товары");
            }
            if (ModelState.IsValid)
            {
                createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ обработан!";
            return View();
        }
        private void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            db.OrderTable.Add(order);
            db.SaveChanges();

            foreach (var el in shopDent.shopDentItems)
            {
                var orderDetail = new OrderDetail
                {
                    gameId = el.dentistry.id,
                    orderId = order.id,
                    price = (short)el.dentistry.price
                };
                db.OrderDetailTable.Add(orderDetail);
                db.SaveChanges();
            }
        }
    }
}
