using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","Name and Display order cannot be the same !");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index","Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null|| id == 0)
            {

            return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb==null) {
                return NotFound();
            }
                return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();
            }

            Category? categoryDeletedFromDb = _db.Categories.Find(id);

            if (categoryDeletedFromDb == null)
            {
                return NotFound();
            }
            return View(categoryDeletedFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
          
            if (id == null || id == 0)
            {

                return NotFound();
            }

            Category? categoryDeletedFromDb = _db.Categories.Find(id);

            if (categoryDeletedFromDb == null)
            {
                return NotFound();
            }

            // Remove the category from the database
            _db.Categories.Remove(categoryDeletedFromDb);
            _db.SaveChanges(); // Save changes to commit the deletion
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category"); ;
        }
    }
}
