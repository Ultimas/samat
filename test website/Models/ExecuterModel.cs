using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test_website.Models
{
    public class ExecuterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MasterId { get; set; }
        
        [ForeignKey("CollegeId")]
        public CollegeModel College { get; set; }

        public int CollegeId { get; set; }

        [ForeignKey("EducationalGroupId")]
        public EducationalGroupModel EducationalGroup { get; set; }

        public int EducationalGroupId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Explain { get; set; }
    }
}