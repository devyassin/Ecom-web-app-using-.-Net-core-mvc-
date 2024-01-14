using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Category;
using Models.Todo;
using System.Collections;

namespace SiteWeb.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            TodoService todoService = new TodoService();
            List<ListTodoVM> todos = todoService.GetListTodos();
            return View(todos);
        }

        public IActionResult Create()
        {
            CategoryService categoryService = new CategoryService();
            List<ListCategoryMV> categoriesObj = categoryService.GetListCategory();
            List<string> categoryNames = categoriesObj.Select(category => category.Name).ToList();
            ViewBag.DropDownList = new SelectList(categoryNames);
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateTodoVM obj)
        {
                TodoService TodoService = new TodoService();
                TodoService.AjouterTodo(obj);
                TempData["success"] = "Todo created successfully";
                return RedirectToAction("Index", "Todo");
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            TodoService todoService = new TodoService();
            UpdateTodoMV? todoFromDb = todoService.TrouverTodo((int)id);
            if (todoFromDb == null)
            {
                return NotFound();
            }
            CategoryService categoryService = new CategoryService();
            List<ListCategoryMV> categoriesObj = categoryService.GetListCategory();
            List<string> categoryNames = categoriesObj.Select(category => category.Name).ToList();
            ViewBag.DropDownList = new SelectList(categoryNames);
            return View(todoFromDb);
        }
        [HttpPost]
        public IActionResult Edit(UpdateTodoMV obj)
        {

            
            
                TodoService todoService = new TodoService();
                todoService.ModifierTodo(obj);
                TempData["success"] = "Todo updated successfully";
                return RedirectToAction("Index", "Todo");
            
           
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();
            }
            TodoService todoService = new TodoService();
            UpdateTodoMV? todoDeletedFromDb = todoService.TrouverTodo((int)id);

            if (todoDeletedFromDb == null)
            {
                return NotFound();
            }
            return View(todoDeletedFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();
            }

            TodoService todoService = new TodoService();
            UpdateTodoMV? todoDeletedFromDb = todoService.TrouverTodo((int)id);

            if (todoDeletedFromDb == null)
            {
                return NotFound();
            }

            todoService.SupprimerTodo(todoDeletedFromDb);
            TempData["success"] = "Todo deleted successfully";
            return RedirectToAction("Index", "Todo"); ;
        }
    }
}
