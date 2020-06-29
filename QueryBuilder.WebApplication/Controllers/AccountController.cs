using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QueryBuilder.WebApplication.Models.ViewModels;
using QueryBuilder.Client.Services.Interfaces;
namespace QueryBuilder.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly IClient client;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,IClient client)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.client = client;
        }
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var login = await client.GetLogin(loginModel.Name, loginModel.Password);
                if (!login.IsNull())
                {
                    IdentityUser user =
                    await userManager.FindByNameAsync(loginModel.Name);
                    if (user != null)
                    {
                        await signInManager.SignOutAsync();
                        if ((await signInManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                        }
                    }
                }
                else
                {
                    IdentityUser user =
                    await userManager.FindByNameAsync(loginModel.Name);
                    if (user!=null)
                    {
                        await userManager.DeleteAsync(user);
                    }
                }
                
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            client.Logout();
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}