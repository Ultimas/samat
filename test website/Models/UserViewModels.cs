using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_website.Models
{
    //this package has class for page indexes
    public class UserViewModels
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string id { get; set; }
    }

    public class CollegeViewModel
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
    
    public class EducationalGroupViewModel
    {
        public string EducationalGroupName { get; set; }

        public string College { get; set; }

        public int Id { get; set; } 
    }

    public class ResearchGroupViewModel
    {
        public string Name { get; set; }

        public string College { get; set; }

        public string EducationalGroup { get; set; }

        public int Id { get; set; }
    }
 
    public class EmployerViewModel
    {
        public string Name { get; set; }

        public string IdentityNumber { get; set; }

        public EmployerTypes EmployerType { get; set; }

        public SecurityClass SecurityClass { get; set; }

        public int Id { get; set; }
    }

    public class ExecuterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MasterId { get; set; }

        public string College { get; set; }

        public string EducationalGroup { get; set; }

        public string[] ResearchGroup { get; set; }

        public int Id { get; set; }
    }
}