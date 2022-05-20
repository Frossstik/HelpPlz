using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Models
{
    public class WebStoreCartItem
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public double price { get; set; }
        public string WebStoreCartId { get; set; }
    }
}
