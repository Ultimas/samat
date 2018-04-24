using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test_website.Models
{
    public class ProjectAttachmentsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectModel Project { get; set; }

        public int ProjectId { get; set; }

        public byte[] Attachment { get; set; }

    }
}