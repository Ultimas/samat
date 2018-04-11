using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using test_website.Models;

namespace test_website.Services
{
    public class CollegeManager : IDisposable
    {
        private ApplicationDbContext _db;

        public CollegeManager()
        {
            _db = new ApplicationDbContext();
        }

        public collegecreatestatus Create(string name)
        {
            try
            {
                if (_db.Colleges.Any(t => t.Name == name))
                    return collegecreatestatus.duplicate;
                _db.Colleges.Add(new CollegeModel { Name = name });
                _db.SaveChanges();
                return collegecreatestatus.success;
            }
            catch
            {}
            return collegecreatestatus.failed;
        }

        public void Delete(int id)
        {
            var college=_db.Colleges.FirstOrDefault(t => t.Id == id);
            if (college != null)
            {
                _db.Colleges.Remove(college);
                //should delete all rows that their foreign key is CollegeId
                _db.EducationalGroups.RemoveRange(_db.EducationalGroups.Where(t => t.CollegeId == id));
                _db.ResearchGroups.RemoveRange(_db.ResearchGroups.Where(t => t.CollegeId == id));
                _db.SaveChanges();
            }
        }
        
        public List<CollegeViewModel> List()
        {
            return _db.Colleges.Select(t=>new CollegeViewModel { Name = t.Name, Id = t.Id }).OrderBy(t=>t.Name).ToList();
        }

        public CollegeModel Find(int id)
        {
            return _db.Colleges.FirstOrDefault(t => t.Id == id);
        }

        public collegecreatestatus Update(EditCollegeBindingModel model)
        {
            try
            {
                if (_db.Colleges.Any(t => t.Id != model.Id && t.Name == model.Name))
                    return collegecreatestatus.duplicate;
                else if (_db.Colleges.Any(t => t.Id == model.Id))
                {
                    var college = _db.Colleges.FirstOrDefault(t => t.Id == model.Id);
                    college.Name = model.Name;
                    _db.SaveChanges();
                    return collegecreatestatus.success;
                }
            }
            catch {}
            return collegecreatestatus.failed;
        }

        public void Dispose()
        {
            _db = null;
        }

        public enum collegecreatestatus
        {   
            failed=1,
            success=2,
            duplicate=3,
        }
    }
}