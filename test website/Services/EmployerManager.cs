using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test_website.Models;

namespace test_website.Services
{
    public class EmployerManager : IDisposable
    {
        private ApplicationDbContext _db;
        public EmployerManager()
        {
            _db= new ApplicationDbContext();
        }

        public employerstatus Create(CreateEmployerBindingModel model)
        {
            try
            {
                if (_db.Employers.Any(t=>t.IdentityNumber==model.IdentityNumber))
                    return employerstatus.duplicate;
                _db.Employers.Add(new EmployerModel
                {
                    Name = model.Name,
                    IdentityNumber=model.IdentityNumber,
                    EmployerTypeId = model.EmployerType.Value,
                    SecurityClassId = model.SecurityClass.Value,
                });
                _db.SaveChanges();
                return employerstatus.success;
            }
            catch (Exception e) {}
            return employerstatus.failed;
        }

        public void Delete(int id)
        {
            var emp = _db.Employers.FirstOrDefault(t => t.Id == id);
            if (emp != null)
            {
                _db.Employers.Remove(emp);
                _db.SaveChanges();
            }
        }

        public List<EmployerViewModel> List()
        {
            return _db.Employers.Select(t => new EmployerViewModel { Name = t.Name, IdentityNumber = t.IdentityNumber, EmployerType = t.EmployerTypeId, SecurityClass = t.SecurityClassId,Id=t.Id })
                .OrderBy(t=>t.Name).ThenBy(t=>t.EmployerType).ThenBy(t=>t.SecurityClass).ToList();
        }

        public EmployerModel Find(int id)
        {
            return _db.Employers.FirstOrDefault(t => t.Id == id);
        }

        public employerstatus Update(EditEmployerBindingModel model)
        {
            try
            {
                if (_db.Employers.Any(t => t.Id != model.Id && t.IdentityNumber == model.IdentityNumber))
                    return employerstatus.duplicate;
                else if (_db.Employers.Any(t => t.Id == model.Id))
                {
                    var res = Find(model.Id);
                    res.Name = model.Name;
                    res.IdentityNumber = model.IdentityNumber;
                    res.EmployerTypeId = model.EmployerType.Value;
                    res.SecurityClassId = model.SecurityClass.Value;
                    _db.SaveChanges();
                    return employerstatus.success;
                }
            }
            catch { }
            return employerstatus.failed;
        }

        public void Dispose()
        {
            _db = null;
        }
        public enum employerstatus
        {
            failed = 1,
            success = 2,
            duplicate = 3,
        }
    }
}