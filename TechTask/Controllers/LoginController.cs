using Microsoft.AspNetCore.Mvc;
using TechTask.Data;
using TechTask.Models;

namespace TechTask.Controllers
{
    public class LoginController : Controller
    {
        private readonly TechTaskDBContext dbcontext;
        public LoginController(TechTaskDBContext dbcontext)
        {
              this.dbcontext = dbcontext;
        }
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            var user_exist = dbcontext.Users.FirstOrDefault(u => u.Login == user.Login);
            if (user_exist != null)
            {
                HttpContext.Session.SetString("Username", user_exist.Login);
                HttpContext.Session.SetInt32("IsAdmin", user_exist.IsAdmin ? 1 : 0);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Wrong login or password");
                return RedirectToAction("Index", "Home");
            } 
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}
