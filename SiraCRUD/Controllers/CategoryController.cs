using Microsoft.AspNetCore.Mvc;
using SiraCRUD.Data;
using SiraCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiraCRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        //DI
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //INDEX
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //CREATE - GET
        public IActionResult Create()
        {            
            return View();
        }

        //CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //EDIT - GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.Category.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }                
            }                        
        }

        //EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE - GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var obj = _db.Category.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }
            }
        }

        //DELETE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
