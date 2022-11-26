using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Model;

namespace WebApplication2.Controllers
{
   
        [Authorize]
        public class AccountController : Controller
        {
            private readonly UserManager<IdentityUser> userManager;
            private readonly SignInManager<IdentityUser> signInManager;
       
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
            {
                ViewBag.returnUrl = returnUrl;
                return View(new LogIn());
            }
            [HttpPost]
            [AllowAnonymous]
            public async Task<IActionResult> Login(LogIn model, string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    IdentityUser user = await userManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    {
                        await signInManager.SignOutAsync();
                        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                        if (result.Succeeded)
                        {
                        RedirectToActionResult redirectResult = new RedirectToActionResult("Index", "Home", new { @area = "Admin", @Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab" });
                        return redirectResult;
                    }
                    }
                    ModelState.AddModelError(nameof(LogIn.UserName), "Неверный логин или пароль");
                }
                return View(model);
            }

            [Authorize]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    }

