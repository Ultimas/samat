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
    public class ExecuterController : Controller
    {
        public ExecuterManager ExecuterManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ExecuterManager>();
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

        public ResearchGroupManager ResearchGroupManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ResearchGroupManager>();
            }
        }

        // GET: Executer
        public ActionResult Index()
        {
            var executers = ExecuterManager.List();
            return View(executers);
        }

        public ActionResult CreateExecuter()
        {
            var colleges = CollegeManager.List();
            ViewBag.College = colleges;
            if (colleges.Count > 0)
                ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(colleges.FirstOrDefault().Id);
            else
                ViewBag.EducationalGroup = new List<EducationalGroupModel>();
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateExecuter(CreateExecuterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ModelState = ModelState;
            }
            else
            {
                var result = ExecuterManager.Create(model);
                switch (result)
                {
                    case ExecuterManager.ExecuterStatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case ExecuterManager.ExecuterStatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateExecuter;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            var colleges = CollegeManager.List();
            ViewBag.College = colleges;
            if (colleges.Count > 0)
                ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(colleges.FirstOrDefault().Id);
            else
                ViewBag.EducationalGroup = new List<EducationalGroupModel>();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult DeleteExecuter(int id)
        {
            ExecuterManager.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditExecuter(int id)
        {
            var executer = ExecuterManager.FindExecuter(id);
            if (executer != null)
            {
                var set = new EditExecuterBindingModel
                {
                    FirstName = executer.FirstName,
                    LastName = executer.LastName,
                    MasterId = executer.MasterId,
                    CollegeId = executer.CollegeId,
                    EducationalGroupId = executer.EducationalGroupId,                    
                    Email =executer.Email,
                    Phone=executer.Phone,
                    Explain=executer.Explain,
                };
                ViewBag.ExecuterResearchgroup = ExecuterManager.FindExecuterResearchGroups(id);
                var colleges = CollegeManager.List();
                ViewBag.College = colleges;
                ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(executer.CollegeId);
                ViewBag.ResearchGroup = ResearchGroupManager.List();
                return View(set);
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult EditExecuter(EditExecuterBindingModel model)
        {
            return RedirectToAction("Index");
        }

        public ActionResult ResearchGroupSelection()
        {
            return View(ResearchGroupManager.List());
        }

        public ActionResult ExecuterOfCollege(int id)
        {
            var executer = ExecuterManager.FindByCollegeId(id);
            return PartialView(executer);
        }
    }
}