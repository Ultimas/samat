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
    public class StaffController : Controller
    {
        public ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // GET: Staff
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var personelid=db.Roles.FirstOrDefault(t => t.Name == "Personel").Id;
            var personels=UserManager.Users.Where(t => t.Roles.Any(a => a.RoleId == personelid)).Select(o => new UserViewModels
            { FirstName = o.FirstName, LastName = o.LastName, id = o.Id }).ToList();
            return View(personels);
        }

        public ActionResult CreateStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateStaff(CreateStaffBindingModel model)
        {
            if (!UserManager.Users.Any(t => t.UserName == model.UserName || t.NationalCode == model.NationalCode))
            {
                ApplicationUser staff = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    NationalCode = model.NationalCode,
                    UserName = model.UserName,
                };
                await UserManager.CreateAsync(staff, model.Password);
                await UserManager.AddToRoleAsync(staff.Id, "Personel");
                return RedirectToAction("Index");
            }
            else
                ViewBag.DuplicateUser = Fa.DuplicateUser;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteStaff(string id)
        {
            var staff = UserManager.Users.FirstOrDefault(t => t.Id == id);
            await UserManager.DeleteAsync(staff);
            return RedirectToAction("Index");
        }
        
        public async Task<ActionResult> EditStaff(string id)
        {
            var staff = UserManager.Users.FirstOrDefault(t => t.Id == id);
            var set = new EditStaffBindingModel
            {
                FirstName=staff.FirstName,
                LastName=staff.LastName,
                NationalCode=staff.NationalCode,
                UserName=staff.UserName,
            };
            return View(set);
        }

        [HttpPost]
        public async Task<ActionResult> EditStaff(EditStaffBindingModel model)
        {
            var staff = UserManager.Users.FirstOrDefault(t => t.Id == model.id);
            if(!UserManager.Users.Any(t=>(t.Id!=model.id) && (t.NationalCode==model.NationalCode || t.UserName == model.UserName)))
            {
                staff.FirstName = model.FirstName;
                staff.LastName = model.LastName;
                staff.NationalCode = model.NationalCode;
                staff.UserName = model.UserName;
                if (model.Password != null)
                {
                    var token = await UserManager.GeneratePasswordResetTokenAsync(staff.Id);
                    await UserManager.ResetPasswordAsync(staff.Id,token,model.Password);
                }
                await UserManager.UpdateAsync(staff);
                return RedirectToAction("Index", "Staff");
            }
            else
                ViewBag.RepUser = Fa.DuplicateUser;
            return View();
        }
    }
}