using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test_website.Models;

namespace test_website.Services
{
    public class EducationalGroupManager : IDisposable
    {
        private ApplicationDbContext _db;


        public EducationalGroupManager()
        {
            _db = new ApplicationDbContext();
        }

        public educationalgroupcreatestatus Create(CreateEducationalGroupBindingModel model)
        {
            try
            {
                if (_db.EducationalGroups.Any(t => t.Name == model.Name && t.CollegeId == model.CollegeId))
                    return educationalgroupcreatestatus.duplicate;
                _db.EducationalGroups.Add(new EducationalGroupModel
                {
                    Name = model.Name,
                    CollegeId = model.CollegeId.Value,
                });
                _db.SaveChanges();
                return educationalgroupcreatestatus.success;
            }
            catch { }
            return educationalgroupcreatestatus.failed;
        }

        public void Delete(int id)
        {
            var edu = _db.EducationalGroups.FirstOrDefault(t => t.Id == id);
            if (edu != null)
            {
                //should delete all rows that their foreign key is EducationalGroupId
                _db.ResearchGroups.RemoveRange(_db.ResearchGroups.Where(t => t.EducationalGroupId == id));
                _db.EducationalGroups.Remove(edu);
                _db.SaveChanges();
            }
        }

        public List<EducationalGroupViewModel> List()
        {
            return _db.EducationalGroups.Select(t => new EducationalGroupViewModel { EducationalGroupName = t.Name, College = t.College.Name ,Id=t.Id}).ToList();
        }

        public EducationalGroupModel Find(int id)
        {
            return _db.EducationalGroups.FirstOrDefault(t => t.Id == id);
        }

        public educationalgroupcreatestatus Update(EditEducationalGroupBindingModel model)
        {
            try
            {
                if (_db.EducationalGroups.Any(t => t.Id != model.Id && t.Name == model.Name && t.CollegeId == model.CollegeId))
                    return educationalgroupcreatestatus.duplicate;
                else if (_db.EducationalGroups.Any(t => t.Id == model.Id))
                {
                    var edu = _db.EducationalGroups.FirstOrDefault(t => t.Id == model.Id);
                    edu.Name = model.Name;
                    edu.CollegeId = model.CollegeId.Value;
                    _db.SaveChanges();
                    return educationalgroupcreatestatus.success;

                }
            }
            catch { }
            return educationalgroupcreatestatus.failed;
        }

        public List<EducationalGroupModel> FindByCollegeId(int id)
        {
                return _db.EducationalGroups.Where(t => t.CollegeId == id).ToList();
        }

        public void Dispose()
        {
            _db = null;
        }
        
        public enum educationalgroupcreatestatus
        {
            failed=1,
            success=2,
            duplicate=3,
        }
    }
}