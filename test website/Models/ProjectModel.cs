using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test_website.Models
{
    public class ProjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProjectId { get; set; }

        public string Title { get; set; }

        [ForeignKey("EmployerId")]
        public EmployerModel Employer { get; set; }

        public int EmployerId { get; set; }

        [ForeignKey("CollegeId")]
        public CollegeModel College { get; set; }

        public int CollegeId { get; set; }

        [ForeignKey("EducationalGroupId")]
        public EducationalGroupModel EducationalGroup { get; set; }

        public int EducationalGroupId { get; set; }

        [ForeignKey("ExecuterId")]
        public ExecuterModel Executer { get; set; }

        public int ExecuterId { get; set; }

        [ForeignKey("ResearchGroupId")]
        public ResearchGroupModel ResearchGroup { get; set; }

        public int ResearchGroupId { get; set; }

        public long? Price { get; set; }

        public long? OverHeadPrice { get; set; }

        public long? ReceivePrice { get; set; }

        public long? RemainPrice { get; set; }

        public long? PaymentPrice { get; set; }

        public string MainContractId { get; set; }

        public DateTime MainContractDate { get; set; }

        public string InternalContractId { get; set; }

        public DateTime InternalContractDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        public int? PhasesNum { get; set; }

        public int ProjectStatus { get; set; }

        public int ProjectType { get; set; }

        public string Explain { get; set; }

    }
}