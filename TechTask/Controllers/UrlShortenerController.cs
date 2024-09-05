using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTask.Data;
using TechTask.Models;
using TechTask.Services;

namespace TechTask.Controllers
{
    public class UrlShortenerController : Controller
    {
        private readonly TechTaskDBContext dbContext;
        private UserModel? logined_user;
        public UrlShortenerController(TechTaskDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public IActionResult UrlShortenerView()
        {
            return View();
        }
        public void ShortenUrl(string longUrl)
        {
            string? userLogin = HttpContext.Session.GetString("UserLogin");
            logined_user = dbContext.Users.FirstOrDefault(o => o.Login == userLogin);
            Shortener sh = new Shortener(dbContext);
            string shortCode = sh.CreateCode(longUrl);
            string shortUrl = $"{Request.Scheme}://{Request.Host}/{shortCode}";

            dbContext.Urls.Add(new UrlModel
            {
                OriginalURL = longUrl,
                ShortURL = shortUrl,
                Code = shortCode,
                CreatedDate = DateTime.Now,
                CreatedBy = logined_user
            });

            dbContext.SaveChangesAsync();

            ViewBag.ShortUrl = shortUrl;
        }
    }
}
