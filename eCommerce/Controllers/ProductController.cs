using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace eCommerce.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string? searchTerm , decimal? minPrice, decimal? maxPrice = null, int page = 1)
        {
            // Change this value to adjust how many products are shown per page
            const int productsPerPage = 3;
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Title.Contains(searchTerm));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            if (page < 1) page = 1;

            int totalProducts = await query.CountAsync();
            int totalPagesNeeded = (int)Math.Ceiling(totalProducts / (double)productsPerPage);

            // If user tries to navigate beyond last page, send them to the last page
            if (totalPagesNeeded > 0 && page > totalPagesNeeded) page = totalPagesNeeded;
            
            var products = await query
                .OrderBy(p => p.Title)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            ProductListViewModel productListViewModel = new()
            {
                Products = products,
                CurrentPage = page,
                TotalPages = totalPagesNeeded,
                PageSize = productsPerPage,
                TotalItems = totalProducts,
                SearchTerm = searchTerm,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
            };


            return View(productListViewModel);
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

                // TempData is used to pass data and will persist over a redirect
                TempData["Message"] = $"{p.Title} was created successfully!";
                
                return RedirectToAction(nameof(Index));
            }
            return View(p);// if model state is invalid, return the view with the product model to display validation errors
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            Product? product = await _context.Products.FindAsync(id);
                
            if (product == null) 
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{product.Title} was updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        { 
           
            Product? product = 
               await _context.Products.FindAsync(id);
                

            if (product == null) 
                {
                return NotFound();
                }
            return View(product);
        }
        [ActionName(nameof(Delete))]
        [HttpPost]
      public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Product? product = _context.Products
                .Where(p => p.ProductId ==id)
                .FirstOrDefault();

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _context.Remove(product);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{product.Title} was successfull";
            return RedirectToAction(nameof(Index));
        }
        
    }
}
