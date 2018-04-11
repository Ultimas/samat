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
    public class EducationalGroupController : Controller
    {
        public EducationalGroupManager EducationalGroupManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<EducationalGroupManager>();
            }
        }

        public CollegeManager CollegeManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<CollegeManager>();
            }
        }

        // GET: EducationalGroup
        public ActionResult Index()
        {
            var a = EducationalGroupManager.List().OrderBy(t => t.College).ThenBy(t=>t.EducationalGroupName).ToList();
            return View(a);
        }

        public ActionResult CreateEducationalGroup()
        {
            ViewBag.College = CollegeManager.List();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducationalGroup(CreateEducationalGroupBindingModel model)
        {
            //validation of model that collegeid should be required
            if (!ModelState.IsValid)
            {
                ViewBag.ModelState = ModelState;
            }
            else
            {
                var result = EducationalGroupManager.Create(model);
                switch (result)
                {
                    case EducationalGroupManager.educationalgroupcreatestatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case EducationalGroupManager.educationalgroupcreatestatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateEducationalGroup;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            //assign collegelist for return to this view
            ViewBag.College = CollegeManager.List();
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteEducationalGroup(int id)
        {
            EducationalGroupManager.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditEducationalGroup(int id)
        {
            var edu = EducationalGroupManager.Find(id);
            if (edu != null)
            {
                var editeducationalgroup = new EditEducationalGroupBindingModel
                {
                    Name = edu.Name,
                    CollegeId = edu.CollegeId
                };
                ViewBag.College = CollegeManager.List();
                return View(editeducationalgroup);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditEducationalGroup(EditEducationalGroupBindingModel model)
        {
            //validation of model that collegeid should be required
            if (!ModelState.IsValid)
            {
                ViewBag.ModelState = ModelState;
            }
            //if model is valid
            else
            {
                var result = EducationalGroupManager.Update(model);
                switch (result)
                {
                    case EducationalGroupManager.educationalgroupcreatestatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case EducationalGroupManager.educationalgroupcreatestatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateEducationalGroup;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            ViewBag.College = CollegeManager.List();
            return View(model);
        }

        public ActionResult educationalgroupofcolleges(int id)
        {
            var educationalgroup= EducationalGroupManager.FindByCollegeId(id);
            return PartialView(educationalgroup);
        }
    }
}