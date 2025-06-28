using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBashaShop.Data;
using TBashaShop.Models;
using TBashaShop.Services;

namespace TBashaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category request, IFormFile Image)
        {
            if (ModelState.IsValid)
            {


                var imageService = new ImageServices();
                string fileName = imageService.UploadImage(Image);
                request.Image = fileName;

                _context.Categories.Add(request);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();



        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return RedirectToAction("Index");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = _context.Categories.Find(id);

            return View(category);

        }
        [HttpPost]
        public IActionResult Edit(Category request, IFormFile? Image)
        {
            var oldProduct = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == request.Id);

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

            _context.Categories.Update(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
    }
    
