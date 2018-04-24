using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using test_website.Models;

namespace test_website.Services
{
    public class ProjectManager : IDisposable
    {
        private ApplicationDbContext _db;

        public ProjectManager()
        {
            _db = new ApplicationDbContext();
        }

        public createprojectstatus Create(CreateProjectBindingModel model)
        {
            try
            {
                if (_db.Projects.Any(t => t.ProjectId == model.ProjectId))
                    return createprojectstatus.duplicate;

                var project =_db.Projects.Add(new ProjectModel
                {
                    ProjectId = model.ProjectId,
                    Title = model.Title,
                    EmployerId=model.EmployerId.Value,
                    CollegeId = model.CollegeId.Value,
                    EducationalGroupId = model.EducationalGroupId.Value,
                    ExecuterId = model.ExecuterId.Value,
                    ResearchGroupId = model.ResearchGroupId.Value,
                    Price = model.Price,
                    OverHeadPrice = model.OverHeadPrice,
                    ReceivePrice = model.ReceivePrice,
                    RemainPrice = model.RemainPrice,
                    PaymentPrice = model.PaymentPrice,
                    MainContractId = model.MainContractId,
                    MainContractDate = model.MainContractDate.Value,
                    InternalContractId = model.InternalContractId,
                    InternalContractDate = model.InternalContractDate.Value,
                    ProjectEndDate = model.ProjectEndDate,
                    PhasesNum = model.PhasesNum,
                    ProjectStatus = model.ProjectStatus.Value,
                    ProjectType = model.ProjectType.Value,
                    Explain = model.Explain,
                });
                _db.SaveChanges();
                if (model.Attachments != null)
                {
                    if (model.Attachments.First()!=null)
                    {
                        foreach (var a in model.Attachments)
                        {
                            if (a.ContentLength > 0)
                            {
                                byte[] data;
                                using (var reader = new BinaryReader(a.InputStream))
                                {
                                    data = reader.ReadBytes(a.ContentLength);
                                }
                                _db.ProjectAttachments.Add(new ProjectAttachmentsModel
                                {
                                    ProjectId = project.Id,
                                    Attachment = data,
                                });
                            }
                        }
                        _db.SaveChanges();
                    }
                }
                return createprojectstatus.success;
            }
            catch { }
            return createprojectstatus.failed;
        }

        public List<ProjectViewModel> List()
        {
            return _db.Projects.Select(t => new ProjectViewModel
            {
                Title = t.Title,
                Employer = t.Employer.Name,
                Executer = (t.Executer.FirstName + t.Executer.LastName),
                College = t.College.Name,
                EducationalGroup = t.EducationalGroup.Name,
                Price = t.Price.Value,
                Id = t.Id
            }).OrderBy(t => t.Employer).ThenBy(t => t.Executer).ToList();
        }

        public ProjectModel Find(int id)
        {
            return _db.Projects.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(int id)
        {
            var project = _db.Projects.FirstOrDefault(t => t.Id == id);
            var attachments = _db.ProjectAttachments.Where(t => t.ProjectId==id);
            if (project != null)
            {
                _db.Projects.Remove(project);
                _db.ProjectAttachments.RemoveRange(attachments);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db = null;
        }
        public enum createprojectstatus
        {
            failed = 1,
            success = 2,
            duplicate = 3,
        }

    }
}