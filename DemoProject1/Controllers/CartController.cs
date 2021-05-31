using DemoProject1.Data;
using DemoProject1.Models;
using DemoProject1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public CartController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        public IActionResult GetCartItems()
        {
            List<CartItems> items = _db.CartItems.ToList();
            foreach(var item in items)
            {
                var product = _db.Products.Find(item.ProductId);
                item.Product.Id = product.Id;
            }

            return View(items);
        }


        public IActionResult AddInShoppingCart(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);

            var existingProduct = _db.CartItems.FirstOrDefault(x => x.ProductId == product.Id);

            if(existingProduct == null)
            {
                CartItems cart = new CartItems()
                {
                    ProductId = product.Id,
                    Product = product,
                    Count = 1
                };

                _db.CartItems.Add(cart);
            }
            else
            {
                existingProduct.Count++;
            }

            _db.SaveChanges();

           

            var x = RedirectToAction("GetCartItems");
            return x;
        }


        public IActionResult RemoveCartItem(int id)
        {
            var obj = _db.CartItems.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.CartItems.Remove(obj);
            _db.SaveChanges();
            

            return this.RedirectToAction("GetCartItems");
        }

        //public ActionResult CartIcon()
        //{
        //    var temp = _db.CartItems.ToList().Count;
        //    BaseViewModel obj = new BaseViewModel()
        //    {
        //        ShoppingItemsCount = temp
        //    };
        //    return PartialView("_Layout", obj);
        //}

        public IActionResult PlaceOrder()
        {
            List<CartItems> items = _db.CartItems.ToList();

            List<OrderViewModel> orderList = new List<OrderViewModel>();

            foreach (var item in items)
            {
                var i = 1;
                var product = _db.Products.Find(item.ProductId);
                OrderViewModel obj = new OrderViewModel()
                {
                    SNo = i,
                    ProductName = product.Name,
                    Quantity = item.Count,
                    Price = product.Price,
                    Total = item.Count * product.Price
                };
                i++;
                orderList.Add(obj);
            }

            return View(orderList);
        }

    }
}
