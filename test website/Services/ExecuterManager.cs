using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test_website.Models;

namespace test_website.Services
{
    public class ExecuterManager : IDisposable
    {
        private ApplicationDbContext _db;

        public ExecuterManager()
        {
            _db = new ApplicationDbContext();
        }
        public ExecuterStatus Create(CreateExecuterBindingModel model)
        {
            try
            {
                if (_db.Executers.Any(t => t.MasterId == model.MasterId))
                    return ExecuterStatus.duplicate;
                var executer=_db.Executers.Add(new ExecuterModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MasterId = model.MasterId,
                    CollegeId = model.CollegeId.Value,
                    EducationalGroupId = model.EducationalGroupId.Value,
                    Email = model.Email,
                    Phone = model.Phone,
                    Explain = model.Explain,
                });
                _db.SaveChanges();
                if (model.ResearchGroupIds != null)
                {
                    foreach (var a in model.ResearchGroupIds)
                    {
                        _db.ExecuterResearchGroups.Add(new ExecuterResearchGroupModel
                        {
                            ExeuterId = executer.Id,
                            ResearchGroupId = a,
                        });
                    }
                    _db.SaveChanges();
                }
                return ExecuterStatus.success;
            }
            catch {}
            return ExecuterStatus.failed;
        }

        public List<ExecuterViewModel> List()
        {
            return _db.Executers.Select(t => new ExecuterViewModel {
                FirstName = t.FirstName,
                LastName = t.LastName,
                MasterId = t.MasterId,
                College = t.College.Name,
                EducationalGroup = t.EducationalGroup.Name,
                Id=t.Id }).OrderBy(t=>t.College).ThenBy(t=>t.EducationalGroup).ThenBy(t=>t.LastName).ThenBy(t=>t.FirstName).ToList();
        }

        public void Delete(int id)
        {
            var executer = _db.Executers.FirstOrDefault(t => t.Id==id);
            var researchgroups = _db.ExecuterResearchGroups.Where(t => t.ExeuterId == id);
            if (executer != null)
            {
                _db.Executers.Remove(executer);
                _db.ExecuterResearchGroups.RemoveRange(researchgroups);
                _db.SaveChanges();
            }
            
        }

        public ExecuterModel FindExecuter(int id)
        {
            return _db.Executers.FirstOrDefault(t => t.Id == id);
        }

        public List<ExecuterResearchGroupModel> FindExecuterResearchGroups(int id)
        {
            return _db.ExecuterResearchGroups.Where(t => t.ExeuterId == id).ToList();
        }

        public void Dispose()
        {
            _db = null;
        }
        public enum ExecuterStatus
        {
            failed = 1,
            success = 2,
            duplicate = 3,
        }
    }
}