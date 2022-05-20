using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly WebStoreCart webStoreCart;

        public OrderController(IAllOrders allOrders, WebStoreCart webStoreCart)
        {
            this.allOrders = allOrders;
            this.webStoreCart = webStoreCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            webStoreCart.listWebStoreItems = webStoreCart.getWebStoreItems();
            if (webStoreCart.listWebStoreItems.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста!");
            }
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View();
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан!";
            return View();
        }
    }
}
