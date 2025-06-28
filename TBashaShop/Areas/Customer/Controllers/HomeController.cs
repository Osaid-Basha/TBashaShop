using Microsoft.AspNetCore.Mvc;
using TBashaShop.Data;

namespace TBashaShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Index()
        {
            ViewBag.category = _context.Categories.ToList();
            ViewBag.product = _context.Products.ToList();
            return View();
        }

    }
}
