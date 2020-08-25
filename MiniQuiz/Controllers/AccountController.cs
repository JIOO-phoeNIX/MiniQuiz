using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniQuiz.Models;

namespace MiniQuiz.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email
                };

                var createResult = await userManager.CreateAsync(user, registerViewModel.Password);

                if (createResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        return Redirect(ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                }

                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password,
                    loginViewModel.RememberMe, false);

                if (result.Succeeded)
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        return Redirect(ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home", new { area = "Admin" });               

                ModelState.AddModelError("", "Email doesn't exist, register instead");
                ModelState.AddModelError("", "Please login again");
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "Admin"});
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
                return Json(true);
            else
                return Json($"Email {email} already taken");
        }
    }
}
