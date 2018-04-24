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
    public class ProjectController : Controller
    {
        public EmployerManager EmployerManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<EmployerManager>();
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

        public ExecuterManager ExecuterManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ExecuterManager>();
            }
        }

        public ProjectManager ProjectManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ProjectManager>();
            }
        }

        // GET: Project
        public ActionResult Index()
        {
            var projects = ProjectManager.List();
            return View(projects);
        }

        public ActionResult CreateProject()
        {
            ViewBag.Employers = EmployerManager.List();
            var colleges = CollegeManager.List();
            ViewBag.College = colleges;
            ViewBag.ResearchGroup = ResearchGroupManager.List();
            if (colleges.Count > 0)
            {

                var educationalgroup = EducationalGroupManager.FindByCollegeId(colleges.FirstOrDefault().Id);
                ViewBag.EducationalGroup = educationalgroup;
                ViewBag.Executer = ExecuterManager.FindByCollegeId(colleges.FirstOrDefault().Id);
             }
            else
            {
                ViewBag.EducationalGroup = new List<EducationalGroupModel>();
                ViewBag.Executer = new List<ExecuterModel>();
            }
            ViewBag.ResearchGroup = ResearchGroupManager.List();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectBindingModel model)
        {
            if (!ModelState.IsValid)
                ViewBag.ModelState = ModelState;
            else
            {
                var result = ProjectManager.Create(model);
                switch (result)
                {
                    case ProjectManager.createprojectstatus.failed:
                        ViewBag.Failed = Fa.Error;
                        break;
                    case ProjectManager.createprojectstatus.duplicate:
                        ViewBag.Duplicate = Fa.DuplicateExecuter;
                        break;
                    default:
                        return RedirectToAction("Index");
                }
            }
            ViewBag.Employers = EmployerManager.List();
            var colleges = CollegeManager.List();
            ViewBag.College = colleges;
            ViewBag.ResearchGroup = ResearchGroupManager.List();
            if (colleges.Count > 0)
            {

                var educationalgroup = EducationalGroupManager.FindByCollegeId(colleges.FirstOrDefault().Id);
                ViewBag.EducationalGroup = educationalgroup;
                ViewBag.Executer = ExecuterManager.FindByCollegeId(colleges.FirstOrDefault().Id);
            }
            else
            {
                ViewBag.EducationalGroup = new List<EducationalGroupModel>();
                ViewBag.Executer = new List<ExecuterModel>();
            }
            ViewBag.ResearchGroup = ResearchGroupManager.List();
            return View(model);
        }


        public ActionResult ProjectInfo(int id)
        {
            var project=ProjectManager.Find(id);
            if (project != null)
            {
                var set = new ProjectViewModel
                {
                    Title = project.Title,
                    ProjectId = project.ProjectId,
                    Price = project.Price,
                    OverHeadPrice = project.OverHeadPrice,
                    ReceivePrice = project.ReceivePrice,
                    RemainPrice = project.RemainPrice,
                    PaymentPrice = project.PaymentPrice,
                    MainContractId = project.MainContractId,
                    MainContractDate = Utility.DateToString(project.MainContractDate),
                    InternalContractId=project.MainContractId,
                    InternalContractDate=Utility.DateToString(project.InternalContractDate),
                    ProjectEndDate=Utility.DateToString(project.ProjectEndDate),
                    PhasesNum=project.PhasesNum,
                    ProjectStatus=project.ProjectStatus,
                    ProjectType=project.ProjectType,
                    Explain=project.Explain,
                    Id=project.Id,
                };
                set.Employer = EmployerManager.Find(project.EmployerId).Name;
                var executer = ExecuterManager.FindExecuter(project.ExecuterId);
                set.Executer = executer.FirstName + " " + executer.LastName;
                set.College = CollegeManager.Find(project.CollegeId).Name;
                set.EducationalGroup = EducationalGroupManager.Find(project.EducationalGroupId).Name;
                set.ResearchGroup = ResearchGroupManager.Find(project.ResearchGroupId).Name;
                ViewBag.ProjectInfo = set;
                return View();
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public ActionResult DeleteProject(int id)
        {
            ProjectManager.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditProject(int id)
        {
            var project = ProjectManager.Find(id);
            if (project != null)
            {
                var set = new EditProjectBindingModel
                {
                    ProjectId = project.ProjectId,
                    Title = project.Title,
                    EmployerId = project.EmployerId,
                    CollegeId = project.CollegeId,
                    EducationalGroupId = project.EducationalGroupId,
                    ExecuterId = project.ExecuterId,
                    ResearchGroupId = project.ResearchGroupId,
                    Price = project.Price,
                    OverHeadPrice = project.OverHeadPrice,
                    ReceivePrice = project.ReceivePrice,
                    RemainPrice = project.RemainPrice,
                    PaymentPrice = project.PaymentPrice,
                    MainContractId = project.MainContractId,
                    MainContractDateStr = Utility.DateToString(project.MainContractDate),
                    InternalContractId = project.MainContractId,
                    InternalContractDateStr = Utility.DateToString(project.InternalContractDate),
                    ProjectEndDateStr = Utility.DateToString(project.ProjectEndDate),
                    PhasesNum = project.PhasesNum,
                    ProjectStatus = project.ProjectStatus,
                    ProjectType = project.ProjectType,
                    Explain = project.Explain,
                };
                var colleges = CollegeManager.List();
                ViewBag.College = colleges;
                ViewBag.EducationalGroup = EducationalGroupManager.FindByCollegeId(project.CollegeId);
                ViewBag.ResearchGroup = ResearchGroupManager.List();
                ViewBag.Employers = EmployerManager.List();
                ViewBag.Executer = ExecuterManager.FindByCollegeId(project.CollegeId);
                return View(set);
            }
            return RedirectToAction("Index");
        }
    }
}