using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using test_website.Models;

namespace test_website.Controllers
{
    public class UserController : Controller
    {

        public ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }


        // GET: User
        public ActionResult Login(int? msg=null)
        {
            switch(msg)
            {
                case 1:
                    ViewBag.LockedOut = Fa.LockedOut;
                    break;
                case 2:
                    ViewBag.Failure = Fa.Failure;
                    break;
                case 3:
                    ViewBag.Error = Fa.Error;
                    break;
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginBindingModel model)
        {
            var user = await UserManager.FindByNameAsync(model.UserName);
            
            //UserManager.AddToRoleAsync(user.Id, "Personel");
            
            //User.IsInRole("Personel");

            if (user == null /*|| !await UserManager.IsInRoleAsync(user.Id,"System")*/)
                return RedirectToAction("Login", new { msg = 2 });

            if(user.LockoutEnabled)
                return RedirectToAction("Login", new { msg = 1 });

            if (UserManager.CheckPasswordAsync(user, model.Password).Result)
            {
                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,Microsoft.Owin.Security.OAuth.OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,CookieAuthenticationDefaults.AuthenticationType);
                

                AuthenticationProperties properties = Providers.ApplicationOAuthProvider.CreateProperties(user.UserName);
                properties.IsPersistent = model.RememberMe;
                Request.GetOwinContext().Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
                                
                if (await UserManager.IsInRoleAsync(user.Id,"System"))
                    return RedirectToAction("System");
                if (await UserManager.IsInRoleAsync(user.Id, "Personel"))
                    return RedirectToAction("Staff");
                else
                    return RedirectToAction("Login");

            }

            return RedirectToAction("System", new { msg = 3 });
          
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        public ActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult System()
        {
            return View();
        }

        [Authorize]
        public ActionResult Staff()
        {
            return View();
        }
    }
}