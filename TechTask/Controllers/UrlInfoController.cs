using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTask.Data;
using TechTask.Models;

namespace TechTask.Controllers
{
    public class UrlInfoController : Controller
    {
        private readonly TechTaskDBContext dBContext;
        public UrlInfoController(TechTaskDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public IActionResult UrlInfoView(int urlId)
        {
            UrlModel url = new UrlModel();
            url = dBContext.Urls
                .Include(u => u.CreatedBy)
                .FirstOrDefault(o => o.Id == urlId);
            return View(url);
        }
    }
}
