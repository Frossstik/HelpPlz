using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly AppDBContent appDBContent;
        public ProductRepository(AppDBContent appDBContent) => this.appDBContent = appDBContent;

        public IEnumerable<Product> Products => appDBContent.product.Include(c => c.Category);

        //public IEnumerable<Product> getFavProduct => appDBContent.product.Where(p => p.isFavourite).Include(c => c.Category);

        public Product getObjectProduct(int productID) => appDBContent.product.FirstOrDefault(p => p.id == productID);

    }
}
