using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Models;

namespace WebStore.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.category.Any())
            {
                content.category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.product.Any())
            {
                /*
                content.AddRange(
                    new Product
                    {
                        name = "Гордунни",
                        shortDesc = "За 1000 золотых",
                        longDesc = "",
                        img = "/images/shadowlands.jpg",
                        price = 5.8,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoW"]
                    },
                    new Product
                    {
                        name = "Черный шрам",
                        shortDesc = "За 1000 золотых",
                        longDesc = "",
                        img = "/images/shadowlands.jpg",
                        price = 6.1,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoW"]
                    },
                    new Product
                    {
                        name = "Пламегор",
                        shortDesc = "За 1 золотую",
                        longDesc = "",
                        img = "/images/burning-crusade.jpg",
                        price = 4,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoWClassic"]
                    },
                    new Product
                    {
                        name = "Вестник Рока",
                        shortDesc = "За 1 золотую",
                        longDesc = "",
                        img = "/images/burning-crusade.jpg",
                        price = 6,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoWClassic"]
                    },
                    new Product
                    {
                        name = "Хроми",
                        shortDesc = "За 1 золотую",
                        longDesc = "",
                        img = "/images/burning-crusade.jpg",
                        price = 5.8,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoWClassic"]
                    },
                    new Product
                    {
                        name = "WoWCircle x100",
                        shortDesc = "За 1000 золотых",
                        longDesc = "",
                        img = "/images/lich-king.jpg",
                        price = 1.7,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoWCircle"]
                    },
                    new Product
                    {
                        name = "WoWCircle x5",
                        shortDesc = "За 1000 золотых",
                        longDesc = "",
                        img = "/images/lich-king.jpg",
                        price = 5.9,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoWCircle"]
                    },
                    new Product
                    {
                        name = "WoWCircle x1",
                        shortDesc = "За 1 золотую",
                        longDesc = "",
                        img = "/images/lich-king.jpg",
                        price = 0.04,
                        isFavourite = true,
                        available = true,
                        Category = Categories["WoWCircle"]
                    }
               );
                */
                content.SaveChanges();
            }
        }
        private static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (Category == null)
                {
                    var list = new Category[]
                    {/*
                    new Category {categoryName = "WoW", desc = "Официальные сервера World of Warcraft: Shadowlands" },
                    new Category {categoryName = "WoWClassic", desc = "Официальные сервера World of Warcraft: Burning Crusade Classic" },
                    new Category {categoryName = "WoWCircle", desc = "Пиратские сервера WoWCircle 3.3.5a" }*/
                    };

                    Category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        Category.Add(el.categoryName, el);
                }
                return Category;
            }
        }
    }
}
