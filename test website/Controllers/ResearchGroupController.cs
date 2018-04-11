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
    public class ResearchGroupController : Controller
    {
        public ResearchGroupManager ResearchGroupManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ResearchGroupManager>();
            }
        }

        public CollegeManager CollegeManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<CollegeManager>();
            }
        }

        public EducationalGroupManager EducationalGroupManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<EducationalGroupManager>();
            }
        }
        
        //show list of researchgroups
        // GET: ResearchGroup
        public ActionResult Index()
        {
            var researchgroups = ResearchGroupManager.List().OrderBy(t => t.College).ThenBy(t => t.EducationalGroup).ToList();
            return View(researchgroups);
        }

        public ActionResult CreateResearchGroup()
        {
            var colleges = CollegeManager.List();
            ViewBag.College = colleges;
            if (colleges.Count >0)
                ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(colleges.FirstOrDefault().Id);
            else
                ViewBag.EducationalGroup = new List<EducationalGroupModel>();
            return View();
        }

        [HttpPost]
        public ActionResult CreateResearchGroup(CreateResearchGroupBindingModel model)
        {
            //validation of model that collegeid and educationalgroup should be required
            if (!ModelState.IsValid)
            {
                ViewBag.ModelState = ModelState;
            }
            //if model is valid
            else
            {
                var result = ResearchGroupManager.Create(model);
                switch (result)
                {
                    case ResearchGroupManager.researchgroupcreatestatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case ResearchGroupManager.researchgroupcreatestatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateEducationalGroup;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            //if researchgroupcreatestatus was failed or duplicate or modelstate is invalid should assign viewbags
            var colleges = CollegeManager.List();
            ViewBag.College = colleges;
            if (colleges.Count > 0)
                ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(colleges.FirstOrDefault().Id);
            else
                ViewBag.EducationalGroup = new List<EducationalGroupModel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteResearchGroup(int id)
        {
            ResearchGroupManager.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditResearchGroup(int id)
        {
            var researchgroup = ResearchGroupManager.Find(id);
            if (researchgroup != null)
            {
                var set = new EditResearchGroupBindingModel
                {
                    Name = researchgroup.Name,
                    CollegeId = researchgroup.CollegeId,
                    EducationalGroupId = researchgroup.EducationalGroupId,
                };
                var colleges = CollegeManager.List();
                ViewBag.College = colleges;
                ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(researchgroup.CollegeId);
                return View(set);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditResearchGroup(EditResearchGroupBindingModel model)
        {
            //validation of model that collegeid and educationalgroup should be required
            if (!ModelState.IsValid)
            {
                ViewBag.ModelState = ModelState;
            }
            //if model is valid
            else
            {
                var result = ResearchGroupManager.Update(model);
                switch (result)
                {
                    case ResearchGroupManager.researchgroupcreatestatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case ResearchGroupManager.researchgroupcreatestatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateResearchGroup;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            var colleges = CollegeManager.List();
            ViewBag.College = colleges;
            ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(model.CollegeId.Value);
            return View(model);
        }
    }
}