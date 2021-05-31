using DemoProject1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCart(ApplicationDbContext db)
        {
            _db = db;
        }

        public string ShoppingCartId { get; set; }
        public List<CartItems> CartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context){ ShoppingCartId = cartId};
        }
    }
}
