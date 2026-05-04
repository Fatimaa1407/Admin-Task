using AdminTask.DAL;
using AdminTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            product.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Restore(int id)
        {
            Product product = _context.Products.Find(id);
            product.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int id)
        {
            Product product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product oldProduct = _context.Products.Find(product.Id);
            oldProduct.Title = product.Title;
            oldProduct.Major = product.Major;
            oldProduct.ImageUrl = product.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
