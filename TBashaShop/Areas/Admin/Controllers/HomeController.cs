using Microsoft.AspNetCore.Mvc;
using TBashaShop.Data;

namespace TBashaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
    }
}
