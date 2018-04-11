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
    public class CollegeController : Controller
    {
        public CollegeManager CollegeManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<CollegeManager>();
            }
        }

        // GET: College
        public ActionResult Index()
        {
            return View(CollegeManager.List().OrderBy(t=>t.Name).ToList());
        }

        public ActionResult CreateCollege()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCollege(CreateCollegeBindingModel model)
        {
            var result=CollegeManager.Create(model.Name);
            switch (result)
            {
                case CollegeManager.collegecreatestatus.failed:
                    ViewBag.Failed = Fa.Error;
                    return View();
                case CollegeManager.collegecreatestatus.duplicate:
                    ViewBag.Duplicate = Fa.DuplicateCollege;
                    return View();
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeleteCollege(int id)
        {
            CollegeManager.Delete(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult EditCollege(int id)
        {
            var college = CollegeManager.Find(id);
            if (college != null)
            {
                var set = new EditCollegeBindingModel
                {
                    Name = college.Name
                };
                return View(set);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCollege(EditCollegeBindingModel model)
        {
            var result = CollegeManager.Update(model);
            switch (result)
            {
                case CollegeManager.collegecreatestatus.failed:
                    ViewBag.Failed = Fa.Error;
                    break;
                  case CollegeManager.collegecreatestatus.duplicate:
                    ViewBag.Duplicate = Fa.DuplicateEducationalGroup;
                    break;
                default:
                    return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}