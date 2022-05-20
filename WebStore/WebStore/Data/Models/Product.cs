using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Models
{
    public class Product
    {
        public int id { set; get; }
        public string name { set; get; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public string img { set; get; }
        public double price { get; set; }
        public string tradeKey { set; get; }
        public bool available { set; get; }
        public int categoryID { set; get; }
        public virtual Category Category { set; get; }

    }
}
