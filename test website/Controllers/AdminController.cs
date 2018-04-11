using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using test_website.Models;

namespace test_website.Controllers
{
    public class AdminController : Controller
    {

        public ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // GET: Admin
        //System Home Page
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var adminid = db.Roles.FirstOrDefault(a => a.Name == "Admin").Id;
            var admins = UserManager.Users.Where(t => t.Roles.Any(r => r.RoleId == adminid)).Select(t => new UserViewModels
            { FirstName = t.FirstName, LastName = t.LastName, id = t.Id }).ToList();
            return View(admins);
        }

        //System can create new admin 
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdmin(CreateAdminBindingModel model)
        {
            if (!UserManager.Users.Any(t => t.UserName == model.UserName || t.NationalCode == model.NationalCode))
            {
                ApplicationUser admin = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    NationalCode = model.NationalCode,
                    UserName = model.UserName,
                };
                await UserManager.CreateAsync(admin,model.Password);
                await UserManager.AddToRoleAsync(admin.Id, "Admin");
                return RedirectToAction("Index", "Admin");
            }
            else
                ViewBag.RepUser = Fa.DuplicateUser;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAdmin(string id)
        {
            var admin = UserManager.Users.FirstOrDefault(t => t.Id == id);
            await UserManager.DeleteAsync(admin);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditAdmin(string id)
        {
            var admin = UserManager.Users.FirstOrDefault(t => t.Id == id);
            var editadmin = new EditAdminBindingModel
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                NationalCode = admin.NationalCode,
                UserName = admin.UserName,
            };
            return View(editadmin);
        }

        [HttpPost]
        public async Task<ActionResult> EditAdmin(EditAdminBindingModel model)
        {
          
            var admin = UserManager.Users.FirstOrDefault(t => t.Id == model.id);
            if (!UserManager.Users.Any(t => (t.Id!=model.id) &&(t.NationalCode == model.NationalCode || t.UserName == model.UserName)))
            {
                admin.FirstName = model.FirstName;
                admin.LastName = model.LastName;
                admin.NationalCode = model.NationalCode;
                admin.UserName = model.UserName;
                if (model.Password != null)
                {
                    var token = await UserManager.GeneratePasswordResetTokenAsync(admin.Id);
                    await UserManager.ResetPasswordAsync(admin.Id, token, model.Password);
                }
                await UserManager.UpdateAsync(admin);
                return RedirectToAction("Index", "Admin");
            }
            else
                ViewBag.RepUser = Fa.DuplicateUser;
            return View();
        }
    }
}