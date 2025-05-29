using System.Security.Claims;
using BusinessCard_Project.Entities;
using BusinessCard_Project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessCard_Project.Controllers;



public class AccountController : Controller
{
    Context _context;
    public AccountController(Context context)
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
    public IActionResult Register(RegistrationViewModel model, Context context )
    {
        if (ModelState.IsValid)
        {
            UserAccount userAccount = new UserAccount();
            userAccount.Email = model.Email;
            userAccount.Password = model.Password;

            try
            {
                context.UserAccounts.Add(userAccount);
                context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = "Пользователь успешно зарегистрирован!";
            }
            catch(DbUpdateException ex)
            {
                ModelState.AddModelError("", "Такой Email уже существует!");
                return View(model);
            }

            return View();
        }
        
        return View(model);
    }

    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(LoginViewModel model, Context context)
    {
        if (ModelState.IsValid)
        {
            var user = context.UserAccounts.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user != null)
            {
                // cookie

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("Name", user.Email),
                    new Claim(ClaimTypes.Role, "User")
                };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                return RedirectToAction("Privacy");
            }
            else
            {
                ModelState.AddModelError("", "Введен некорректный Email или пароль!");
            }
        }
        
        return View();
    }


    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index");
        
    }

    [Authorize]
    public IActionResult Privacy()
    {
       
        return View();
    }
}