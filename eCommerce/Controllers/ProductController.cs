using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create ( Product p)

        {
            if (ModelState.IsValid)
            {
                
                _context.Products.Add(p);// add the product to the context
                await _context.SaveChangesAsync();// save changes to the database
                
                return RedirectToAction(nameof(Index));
            }
            return View(p);// if model state is invalid, return the view with the product model to display validation errors
        }
    }
}
