using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_website.Models;
using test_website.Services;

namespace test_website.Controllers
{
    public class EmployerController : Controller
    {
        public EmployerManager EmployerManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<EmployerManager>();
            }
        }
        // GET: Employer
        public ActionResult Index()
        {
            var employers = EmployerManager.List();
            return View(employers);
        }
        
        public ActionResult CreateEmployer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployer(CreateEmployerBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ModelState = ModelState;
            }
            else
            {
                var result = EmployerManager.Create(model);
                switch (result)
                {
                    case EmployerManager.employerstatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case EmployerManager.employerstatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateEmployer;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteEmployer(int id)
        {
            EmployerManager.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditEmployer(int id)
        {
            var employer = EmployerManager.Find(id);
            var set = new EditEmployerBindingModel
            {
                Name = employer.Name,
                IdentityNumber = employer.IdentityNumber,
                EmployerType = employer.EmployerTypeId,
                SecurityClass = employer.SecurityClassId,
            };
            ViewBag.EmployerType = employer.EmployerTypeId;
            ViewBag.SecurityClass = employer.SecurityClassId;
            return View(set);
        }

        [HttpPost]
        public ActionResult EditEmployer(EditEmployerBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ModelState = ModelState;
            }
            else
            {
                var result = EmployerManager.Update(model);
                switch (result)
                {
                    case EmployerManager.employerstatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case EmployerManager.employerstatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateEmployer;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            ViewBag.EmployerType = model.EmployerType;
            ViewBag.SecurityClass = model.SecurityClass;
            return View(model);
        }
    }
}