using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test_website.Models;

namespace test_website.Services
{
    public class ResearchGroupManager : IDisposable
    {
        private ApplicationDbContext _db;
        public ResearchGroupManager()
        {
            _db = new ApplicationDbContext();
        }

        public researchgroupcreatestatus Create(CreateResearchGroupBindingModel model)
        {
            try
            {
                if (_db.ResearchGroups.Any(t => t.Name == model.Name && t.CollegeId == model.CollegeId && t.EducationalGroupId == model.EducationalGroupId))
                    return researchgroupcreatestatus.duplicate;
                _db.ResearchGroups.Add(new ResearchGroupModel
                {
                    Name = model.Name,
                    CollegeId = model.CollegeId.Value,
                    EducationalGroupId = model.EducationalGroupId.Value
                });
                _db.SaveChanges();
                return researchgroupcreatestatus.success;
            }
            catch{ }
                return researchgroupcreatestatus.failed;
        }

        public List<ResearchGroupViewModel> List()
        {
            return _db.ResearchGroups.Select(t => new ResearchGroupViewModel { Name = t.Name, College = t.College.Name, EducationalGroup = t.EducationalGroup.Name, Id = t.Id }).ToList();
        }

        public void Delete(int id)
        {
            var edu = _db.ResearchGroups.FirstOrDefault(t => t.Id == id);
            if (edu != null)
            {
                _db.ResearchGroups.Remove(edu);
                _db.SaveChanges();
            }
        }

        public ResearchGroupModel Find(int id)
        {
            return _db.ResearchGroups.FirstOrDefault(t => t.Id == id);
        }

        public researchgroupcreatestatus Update(EditResearchGroupBindingModel model)
        {
            try
            {
                if (_db.ResearchGroups.Any(t => t.Id != model.Id && t.Name == model.Name && t.CollegeId == model.CollegeId && t.EducationalGroupId == t.EducationalGroupId))
                    return researchgroupcreatestatus.duplicate;
                else if (_db.ResearchGroups.Any(t => t.Id == model.Id))
                {
                    var res = _db.ResearchGroups.FirstOrDefault(t => t.Id == model.Id);
                    res.Name = model.Name;
                    res.CollegeId = model.CollegeId.Value;
                    res.EducationalGroupId = model.EducationalGroupId.Value;
                    _db.SaveChanges();
                    return researchgroupcreatestatus.success;
                }
            }
            catch 
            {}
            return researchgroupcreatestatus.failed;
        }
        public void Dispose()
        {
            _db = null;
        }


        public enum researchgroupcreatestatus
        {
            failed = 1,
            success = 2,
            duplicate = 3,
        }
    }
}