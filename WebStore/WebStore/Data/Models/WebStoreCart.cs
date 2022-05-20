using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebStore.Data.Models
{
    public class WebStoreCart
    {
        public string WebStoreCartId { get; set; }
        public List<WebStoreCartItem> listWebStoreItems { get; set; }
        private readonly AppDBContent appDBContent;

        public WebStoreCart(AppDBContent appDBContent) => this.appDBContent = appDBContent;
        public static WebStoreCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string webStoreCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", webStoreCartId);

            return new WebStoreCart(context) { WebStoreCartId = webStoreCartId };
        }

        public void AddToCart(Product product)
        {
            appDBContent.webStoreCartItem.Add(new WebStoreCartItem
            {
                WebStoreCartId = WebStoreCartId,
                product = product,
                price = product.price
            }) ;

            appDBContent.SaveChanges();
        }

        public List<WebStoreCartItem> getWebStoreItems()
        {
            return appDBContent.webStoreCartItem.Where(c => c.WebStoreCartId == WebStoreCartId).Include(s => s.product).ToList();
        }
    }
}
