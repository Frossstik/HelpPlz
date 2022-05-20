using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /*
        public ActionResult Admin()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
        */
    }
}
