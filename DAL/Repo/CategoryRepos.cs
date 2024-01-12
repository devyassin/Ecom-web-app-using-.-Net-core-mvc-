

using DAL.Entity;
using DAL.Migrations;

namespace DAL.Repo
{
    public class CategoryRepos
    {

        public List<Category> GetAll()
        {
            MyDbContext myDbContext = new MyDbContext();
            return myDbContext.Categories.ToList();
        }

        public void Create(Category entity)
        {
            MyDbContext db = new MyDbContext();
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public Category Find(int id)
        {
            MyDbContext db = new MyDbContext();
            return db.Categories.Find(id);
            
        }

        public void Update(Category obj)
        {
            MyDbContext db = new MyDbContext();
            db.Categories.Update(obj);
            db.SaveChanges();

        }

        public void Delete(Category obj)
        {
            MyDbContext db = new MyDbContext();
            db.Categories.Remove(obj);
            db.SaveChanges();

        }
    }
}
