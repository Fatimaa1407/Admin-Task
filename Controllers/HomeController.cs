using AdminTask.DAL;
using AdminTask.Models;
using AdminTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products
                .Where<Product> (p => !p.IsDeleted)
                .ToList();
            return View(products);
        }
    }
}
