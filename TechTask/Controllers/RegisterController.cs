using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTask.Data;
using TechTask.Models;

namespace TechTask.Controllers
{
    public class RegisterController : Controller
    {
        private readonly TechTaskDBContext dbcontext;

        public RegisterController(TechTaskDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult RegisterView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(UserModel user)
        {
            if (ModelState.IsValid)
            {
                bool if_exist = dbcontext.Users.Any(u => u.Login == user.Login);
                if (!if_exist)
                {
                    dbcontext.Users.Add(user);
                    dbcontext.SaveChanges();
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
