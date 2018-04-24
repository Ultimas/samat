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

    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string ProjectId { get; set; }

        public string Title { get; set; }

        public string Employer { get; set; }

        public string College { get; set; }

        public string EducationalGroup { get; set; }

        public string Executer { get; set; }

        public string ResearchGroup { get; set; }

        public long? Price { get; set; }

        public long? OverHeadPrice { get; set; }

        public long? ReceivePrice { get; set; }

        public long? RemainPrice { get; set; }

        public long? PaymentPrice { get; set; }

        public string MainContractId { get; set; }

        public string MainContractDate { get; set; }

        public string InternalContractId { get; set; }

        public string InternalContractDate { get; set; }

        public string ProjectEndDate { get; set; }

        public int? PhasesNum { get; set; }

        public int ProjectStatus { get; set; }

        public int ProjectType { get; set; }

        public string Explain { get; set; }


    }
}