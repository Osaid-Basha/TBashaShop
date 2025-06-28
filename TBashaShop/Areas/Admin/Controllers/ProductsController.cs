using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBashaShop.Data;
using TBashaShop.Models;
using TBashaShop.Services;

namespace TBashaShop.Areas.Admin.Controllers
{   [Area("Admin")]
    public class ProductsController : Controller
    {
        
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var product=_context.Products.ToList();
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
             ViewBag.Categories=_context.Categories.ToList(); 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product request, IFormFile Image)
        {
            if (!ModelState.IsValid) {
                ViewBag.Categories = _context.Categories.ToList();
                return View(request);
            }

            if (Image != null && Image.Length > 0)
            {
              var imageService=new ImageServices();
               string fileName= imageService.UploadImage(Image);
                request.Image = fileName;
            }
            else
            {
                ModelState.AddModelError("Image", "Please upload an image.");
                ViewBag.Categories = _context.Categories.ToList();
                return View(request); 
            }

            _context.Products.Add(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var imageService=new ImageServices();
                var product = _context.Products.SingleOrDefault(p => p.Id == id);
            imageService.DeleteImage(product.Image);
                _context.Products.Remove(product);
                _context.SaveChanges();
            return RedirectToAction("Index");




        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound();

            return View(product); 
        }

        [HttpPost]
        public IActionResult Edit(Product request, IFormFile? Image)
        {
            var oldProduct = _context.Products.AsNoTracking().FirstOrDefault(c => c.Id == request.Id);

            if (oldProduct == null)
            {
                return NotFound(); 
            }

            var imageService = new ImageServices();

            if (Image != null && Image.Length > 0)
            {
             
                imageService.DeleteImage(oldProduct.Image);

            
                string fileName = imageService.UploadImage(Image);
                request.Image = fileName;
            }
            else
            {
              
                request.Image = oldProduct.Image;
            }

            _context.Products.Update(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
