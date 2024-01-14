

using Microsoft.AspNetCore.Mvc;


using BLL;
using Models.Category;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;

namespace SiteWeb.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
       

        public CategoryController()
        {
           
        }
        public IActionResult Index()
        {
            CategoryService categoryService = new CategoryService();
            List<ListCategoryMV> categories = categoryService.GetListCategory();
            
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryMV obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order cannot be the same !");
            }
            if (ModelState.IsValid)
            {
                CategoryService categoryService = new CategoryService();
                categoryService.AjouterCategory(obj);
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            CategoryService categoryService=new CategoryService();
            UpdateCategoryMV? categoryFromDb = categoryService.TrouverCategory((int)id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(UpdateCategoryMV obj)
        {

            if (ModelState.IsValid)
            {
                CategoryService categoryService = new CategoryService();
                categoryService.ModifierCategory(obj);
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
            CategoryService categoryService=new CategoryService();
            UpdateCategoryMV? categoryDeletedFromDb = categoryService.TrouverCategory((int)id);

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

            CategoryService categoryService = new CategoryService();
            UpdateCategoryMV? categoryDeletedFromDb = categoryService.TrouverCategory((int)id);

            if (categoryDeletedFromDb == null)
            {
                return NotFound();
            }

            categoryService.SupprimerCategorie(categoryDeletedFromDb);
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category"); ;
        }

    }
}
