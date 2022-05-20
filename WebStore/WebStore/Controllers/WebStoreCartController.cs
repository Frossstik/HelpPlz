using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;
using WebStore.Repository;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class WebStoreCartController : Controller
    {
        private IAllProducts _productRep;
        private readonly WebStoreCart _webStoreCart;

        public WebStoreCartController(IAllProducts productRep, WebStoreCart webStoreCart)
        {
            _productRep = productRep;
            _webStoreCart = webStoreCart;
        }

        public ViewResult CartIndex()
        {
            var items = _webStoreCart.getWebStoreItems();
            _webStoreCart.listWebStoreItems = items;

            var obj = new WebStoreCartViewModel
            {
                webStoreCart = _webStoreCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _productRep.Products.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _webStoreCart.AddToCart(item);
            }
            return RedirectToAction("CartIndex");
        }
    }
}
