using Microsoft.AspNetCore.Mvc;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class MemberController : Controller
    {
        private readonly ProductDbContext _context;

        public MemberController(ProductDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel reg)
        {
            if (ModelState.IsValid)
            {
                // Check if username or email is already taken 
                bool usernameTaken = await _context.Members
                                    .AnyAsync(m => m.Username == reg.Username);
                if (usernameTaken)
                {
                    ModelState.AddModelError(nameof(Member.Username), "Username already taken");
                    
                }

                bool emailTaken = await _context.Members
                                 .AnyAsync(m => m.Email == reg.Email);

                if (emailTaken)
                {
                    ModelState.AddModelError(nameof(Member.Email), "Email already taken");
                   
                }

                if (usernameTaken || emailTaken)
                {
                    return View(reg);
                }
                
                // Map ViewModel To Member model tracked by DB       
                Member newMember = new()
                {
                    Username = reg.Username,
                    Email = reg.Email,
                    Password = reg.Password,
                    DateOfBirth = reg.DateOfBirth
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(reg);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
       
    }
}