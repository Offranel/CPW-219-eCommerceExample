using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
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
        public IActionResult Create ( Product p)

        {
            if (ModelState.IsValid)
            {
                // Add to database
                // Redirect to Product list (Index action
            }
            return View(p);
        }
    }
}
