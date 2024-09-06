using Microsoft.AspNetCore.Mvc;
using TechTask.Data;
using TechTask.Models;

namespace TechTask.Controllers
{
    public class UrlTableController : Controller
    {
        private TechTaskDBContext dBContext;
        public UrlTableController(TechTaskDBContext dBContext)
        {
                this.dBContext = dBContext;
        }
        public IActionResult UrlTableView()
        {
            var urls = dBContext.Urls.ToList();
            return View(urls);
        }
    }
}
