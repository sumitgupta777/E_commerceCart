using DemoProject1.Data;
using DemoProject1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult GetList()
        {
            var items = _db.Category.ToList();
            return View(items);
        }

        // GET create 
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        // POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("GetList");
            }
            return View(obj);
        }


    }
}
