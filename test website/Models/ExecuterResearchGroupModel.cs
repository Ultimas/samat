using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test_website.Models
{
    public class ExecuterResearchGroupModel
    {
        [ForeignKey("ExeuterId")]
        public ExecuterModel Executer { get; set; }

        [Key]
        [Column(Order =0)]
        public int ExeuterId { get; set; }

        [ForeignKey("ResearchGroupId")]
        public ResearchGroupModel ResearchGroup { get; set; }

        [Key]
        [Column(Order =1)]
        public int ResearchGroupId { get; set; }
    }
}