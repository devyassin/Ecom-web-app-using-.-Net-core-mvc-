using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class TodoRepos
    {

        public void Create(Todo entity)
        {
            MyDbContext db = new MyDbContext();
            db.todos.Add(entity);
            db.SaveChanges();
        }

        public List<Todo> GetAll()
        {
            MyDbContext myDbContext = new MyDbContext();
            return myDbContext.todos.ToList();
        }

        public Todo Find(int id)
        {
            MyDbContext db = new MyDbContext();
            return db.todos.Find(id);

        }

        public void Update(Todo obj)
        {
            MyDbContext db = new MyDbContext();
            db.todos.Update(obj);
            db.SaveChanges();

        }

        public void Delete(Todo obj)
        {
            MyDbContext db = new MyDbContext();
            db.todos.Remove(obj);
            db.SaveChanges();

        }
    }
}
