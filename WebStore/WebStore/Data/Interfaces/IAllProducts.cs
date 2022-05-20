using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Models;

namespace WebStore.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        //IEnumerable<Product> getFavProduct { get; }
        Product getObjectProduct(int productID);
    }
}
