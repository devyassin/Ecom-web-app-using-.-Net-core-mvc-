using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepos
    {
        public void Create(User entity)
        {
            MyDbContext db = new MyDbContext();
            db.users.Add(entity);
            db.SaveChanges();
        }

        public User GetUser(string email, string password)
        {
            MyDbContext db = new MyDbContext();
            var user = db.users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
            
        }

        public User GetUserById(int id)
        {
            MyDbContext db = new MyDbContext();
            return db.users.Find(id);
        }

        public int getUserIdByEmail(string email)
        {
            MyDbContext db = new MyDbContext();
            var user = db.users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                return user.UserId;
            }
            return -1;
        }
    }
}
