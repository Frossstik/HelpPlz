using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Data.Repository
{
    public class CategoryRepository : IProductCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent) => this.appDBContent = appDBContent;
        public IEnumerable<Category> AllCategories => appDBContent.category;
    }
}
