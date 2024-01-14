using DAL.Entity;
using DAL.Repo;
using Models.Category;
using Models.Todo;
using System.Security.Claims;

namespace BLL
{
    public class TodoService
    {
        public void AjouterTodo(CreateTodoVM model)
        {
            var todoRepos = new TodoRepos();
            var userRepos=new UserRepos();
           
            Todo todo = new Todo();
            todo.TodoId = model.TodoId;
            //todo.CategoryName = model.CategoryName;
            todo.CategoryName = model.CategoryName;
            todo.Title = model.Title;
            todo.Description = model.Description;
            todo.Date= DateTime.Now;
            todo.UserId = 1;
            todoRepos.Create(todo);

        }

        public List<ListTodoVM> GetListTodos()
        {

            var todosRepos = new TodoRepos();


            List<ListTodoVM> listTodosMVs = new List<ListTodoVM>();

            foreach (var item in todosRepos.GetAll())
            {
                ListTodoVM TodoMV = new ListTodoVM();
                TodoMV.TodoId = item.TodoId;
                TodoMV.Date = item.Date;
                TodoMV.CategoryName = item.CategoryName;
                TodoMV.Title= item.Title;

                listTodosMVs.Add(TodoMV);
            }
            return listTodosMVs;
        }

        public UpdateTodoMV TrouverTodo(int id)
        {
            TodoRepos todoRepos = new TodoRepos();
            UpdateTodoMV todoMV = new UpdateTodoMV();
            Todo todo = todoRepos.Find(id);
            todoMV.TodoId = todo.TodoId;
            todoMV.Title = todo.Title;
            todoMV.CategoryName = todo.CategoryName;
            todoMV.Description = todo.Description;
            return todoMV;

        }

        public void ModifierTodo(UpdateTodoMV model)
        {
            TodoRepos todoRepos = new TodoRepos();
            Todo todo = new Todo();
           
            todo.TodoId = model.TodoId;
            todo.Title= model.Title;
            todo.Description = model.Description;
            todo.CategoryName = model.CategoryName;
            todo.Date=DateTime.Now;
            todo.UserId = 1;
           
            todoRepos.Update(todo);

        }

        public void SupprimerTodo(UpdateTodoMV model)
        {
            TodoRepos todoRepos = new TodoRepos();
            Todo todo = new Todo();
            todo.TodoId = model.TodoId;
            todo.Title = model.Title;
            todo.Description = model.Description;
            todo.CategoryName = model.CategoryName;
            todo.Date = DateTime.Now;
            todo.UserId = 1;
            todoRepos.Delete(todo);

        }
    }
}
