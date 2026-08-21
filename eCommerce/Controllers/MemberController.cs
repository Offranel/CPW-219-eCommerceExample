using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class MemberController : Controller
{
    private readonly ProductDbContext _context;

    public MemberController(ProductDbContext context)
    {
        _context = context;
    }
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegistractionViewModel red)
    {
        if (ModelState.IsValid)
        { 
            //  Map View model
            Member newmember = new()
            {
                UserName = red.UserName,
                Email = red.Email,
                Password = red.Password,
                DateOfBirth = red.DateOfBirth,
            };

            _context.Members.Add(newmember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(red);
    }
}
