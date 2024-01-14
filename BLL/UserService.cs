using DAL.Entity;
using DAL.Repo;
using Models.Category;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService
    {
        public void RegisterUser(VMRegister model)
        {
            var userRepos = new UserRepos();
            User user = new User();
            user.UserId = model.UserId;
            user.Username = model.Username;
            user.Password=  model.Password;
            user.Email = model.Email;
            userRepos.Create(user);

        }

        public bool LoginUser(VMLogin model)
        {
            var userRepos = new UserRepos();
            User user = new User();
            user.Email= model.Email;
            user.Password = model.PassWord;
            User auth= userRepos.GetUser(user.Email, user.Password);
            if(auth != null)
            {
                return true;
            }

            return false;
           

        }
    }
}
