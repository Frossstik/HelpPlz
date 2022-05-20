using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Models;

namespace WebStore.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public string CurrCategory { get; set; }
    }
}
