using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTask.Data;
using TechTask.Models;
using TechTask.Services;
using System.Threading.Tasks;

namespace TechTask.Controllers
{
    public class UrlShortenerController : Controller
    {
        private readonly TechTaskDBContext dbContext;

        public UrlShortenerController(TechTaskDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public IActionResult UrlShortenerView()
        {
            return View();
        }

        public async Task<IActionResult> ShortenUrl(string longUrl)
        {
            string? userLogin = HttpContext.Session.GetString("Username");
            UserModel? logined_user = dbContext.Users.FirstOrDefault(o => o.Login == userLogin);
            Shortener sh = new Shortener();
            string shortCode = sh.CreateCode(longUrl);
            string shortUrl = $"{Request.Scheme}://{Request.Host}/{shortCode}";
            var ifexist = dbContext.Urls.Any(o => o.Code == shortCode);
            if (ifexist)
            {
                return RedirectToAction("ErrorView", "UrlShortener");
            }
            dbContext.Urls.Add(new UrlModel
            {
                OriginalURL = longUrl,
                ShortURL = shortUrl,
                Code = shortCode,
                CreatedDate = DateTime.Now,
                CreatedBy = logined_user
            });

            await dbContext.SaveChangesAsync();
            ViewBag.ShortUrl = shortUrl;
            return View("UrlShortenerView");
        }
        public IActionResult ErrorView()
        {
            return View();
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToLongUrl(string shortCode)
        {
            var urlMapping = await dbContext.Urls.FirstOrDefaultAsync(u => u.Code == shortCode);
            if (urlMapping == null)
            {
                return NotFound();
            }

            return Redirect(urlMapping.OriginalURL);
        }
    }
}
