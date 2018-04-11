using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test_website.Models
{
    public class EmployerModel
    {
        public string Name { get; set; }

        public string IdentityNumber { get; set; }

        public EmployerTypes EmployerTypeId { get; set; }

        public SecurityClass SecurityClassId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
    public enum EmployerTypes
    {
        Governmental=1,
        Non_Govermental=2,
        HalfPrivate=3,
        Military=4,
    }
    public enum SecurityClass
    {
        Secret=1,
        Normal=2,
    }
}