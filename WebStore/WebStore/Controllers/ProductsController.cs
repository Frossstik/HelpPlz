using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts allProducts;
        private readonly IProductCategory productCategory;

        public ProductsController(IAllProducts iAllProducts, IProductCategory iProductCategory)
        {
            allProducts = iAllProducts;
            productCategory = iProductCategory;
        }

        [Route("Products/List")]
        [Route("Products/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                products = allProducts.Products.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("category1", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = allProducts.Products.Where(i => i.Category.categoryName.Equals("category1")).OrderBy(i => i.id);
                }
                else if (string.Equals("category2", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = allProducts.Products.Where(i => i.Category.categoryName.Equals("category2")).OrderBy(i => i.id);
                }
                else if (string.Equals("category3", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = allProducts.Products.Where(i => i.Category.categoryName.Equals("category3")).OrderBy(i => i.id);
                }
                currCategory = _category;
            }

            var productObj = new ProductsListViewModel
            {
                AllProducts = products,
                CurrCategory = currCategory
            };

            ViewBag.Title = "Страница с товарами";
            return View(productObj);
        }
    }
}
