using DemoProject1.Data;
using DemoProject1.Models;
using DemoProject1.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        

        public IActionResult PGetList(int? id)
        {
            if(id == null)
            {
                ViewBag.CatId = TempData["CatId"];
                
            }
            else
            {
                ViewBag.CatId = id;
            }
           

            ViewBag.Heading = _db.Category.Where(x => x.Id == id).Select(x => x.CategoryName).FirstOrDefault();
            var items = _db.Products.Where(x => x.CategoryId == id).ToList();
            return View(items);
        }

        // GET create 
        [HttpGet]
        public IActionResult AddProduct(int id)
        {
            ViewBag.CatId = id;
            return View();
        }

        // POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductsViewModel vm, int id)
        {

            if (ModelState.IsValid)
            {
                string stringFileName = UploadFile(vm);

                var product = new Products
                {
                    Name = vm.Name,
                    Price = vm.Price,
                    Description = vm.Description,
                    IsActive = vm.IsActive,
                    CategoryId = id,
                    ProductImg = stringFileName
                };

                _db.Products.Add(product);
                _db.SaveChanges();

                TempData["CatId"] = id;

                return RedirectToAction("PGetList", "Products");
            }
            return View();
        }

        private string UploadFile(ProductsViewModel vm)
        {
            string fileName = null;
            if (vm.ProductImg != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + vm.ProductImg.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.ProductImg.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}













