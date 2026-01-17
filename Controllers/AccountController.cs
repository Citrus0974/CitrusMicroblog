using CitrusMicroblog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CitrusMicroblog.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userMgr;
        private SignInManager<IdentityUser> signInMgr;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            this.userMgr = userMgr;
            this.signInMgr = signInMgr;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userMgr.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInMgr.SignOutAsync();
                    if ((await signInMgr.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }


        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInMgr.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
