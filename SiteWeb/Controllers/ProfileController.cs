using DAL.Entity;
using DAL.Repo;
using Microsoft.AspNetCore.Mvc;

namespace SiteWeb.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            UserRepos userRepos = new UserRepos();
            User user=userRepos.GetUserById(1);
            return View(user);
        }
    }
}
