using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Web;
using System.Globalization;
using System.Linq;

namespace test_website.Models
{
    // Models used as parameters to AccountController actions.

    public class LoginBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredUserName)]
        [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = Fa.UserNameChar)]
        [Display(Name = Fa.UserName)]
        public string UserName { get; set; }

        [Required(ErrorMessage = Fa.RequiredPassword)]
        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [Display(Name = Fa.Password)]
        public string Password { get; set; }

        [Display(Name = Fa.RememberMe)]
        public bool RememberMe { get; set; }

    }

    public class CreateAdminBindingModel
    {
        [Required(ErrorMessage = Fa.EnterName)]
        [Display(Name = Fa.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Fa.EnterLastName)]
        [Display(Name = Fa.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Fa.EnterNationalCode)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [StringLength(10, ErrorMessage = Fa.NationalLength, MinimumLength = 10)]
        [Display(Name = Fa.NationalCode)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = Fa.RequiredUserName)]
        [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = Fa.UserNameChar)]
        [Display(Name = Fa.UserName)]
        public string UserName { get; set; }

        [Required(ErrorMessage = Fa.RequiredPassword)]
        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = Fa.RequiredPassword)]
        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.ConfirmPassword)]
        [Compare("Password", ErrorMessage = Fa.SamePassword)]
        public string ConfirmPassword { get; set; }

    }

    public class EditAdminBindingModel
    {
        [Required(ErrorMessage = Fa.EnterName)]
        [Display(Name = Fa.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Fa.EnterLastName)]
        [Display(Name = Fa.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Fa.EnterNationalCode)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [StringLength(10, ErrorMessage = Fa.NationalLength, MinimumLength = 10)]
        [Display(Name = Fa.NationalCode)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = Fa.RequiredUserName)]
        [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = Fa.UserNameChar)]
        [Display(Name = Fa.UserName)]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.Password)]
        public string Password { get; set; }

        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.ConfirmPassword)]
        [Compare("Password", ErrorMessage = Fa.SamePassword)]
        public string ConfirmPassword { get; set; }

        public string id { get; set; }

    }

    public class CreateStaffBindingModel
    {
        [Required(ErrorMessage = Fa.EnterName)]
        [Display(Name = Fa.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Fa.EnterLastName)]
        [Display(Name = Fa.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Fa.EnterNationalCode)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [StringLength(10, ErrorMessage = Fa.NationalLength, MinimumLength = 10)]
        [Display(Name = Fa.NationalCode)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = Fa.RequiredUserName)]
        [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = Fa.UserNameChar)]
        [Display(Name = Fa.UserName)]
        public string UserName { get; set; }

        [Required(ErrorMessage = Fa.RequiredPassword)]
        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = Fa.RequiredPassword)]
        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.ConfirmPassword)]
        [Compare("Password", ErrorMessage = Fa.SamePassword)]
        public string ConfirmPassword { get; set; }

    }

    public class EditStaffBindingModel
    {
        [Required(ErrorMessage = Fa.EnterName)]
        [Display(Name = Fa.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Fa.EnterLastName)]
        [Display(Name = Fa.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Fa.EnterNationalCode)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [StringLength(10, ErrorMessage = Fa.NationalLength, MinimumLength = 10)]
        [Display(Name = Fa.NationalCode)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = Fa.RequiredUserName)]
        [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = Fa.UserNameChar)]
        [Display(Name = Fa.UserName)]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.Password)]
        public string Password { get; set; }

        [MinLength(6, ErrorMessage = Fa.PasswordChar)]
        [DataType(DataType.Password)]
        [Display(Name = Fa.ConfirmPassword)]
        [Compare("Password", ErrorMessage = Fa.SamePassword)]
        public string ConfirmPassword { get; set; }

        public string id { get; set; }
    }
    public class CreateCollegeBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredCollegeName)]
        [Display(Name = Fa.CollegeName)]
        public string Name { get; set; }
    }
    public class EditCollegeBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredCollegeName)]
        [Display(Name = Fa.CollegeName)]
        public string Name { get; set; }

        public int Id { get; set; }
    }


    public class CreateEducationalGroupBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredEducationalGroupName)]
        [Display(Name = Fa.EducationalGroupName)]
        public string Name { get; set; }

        [Required]
        public int? CollegeId { get; set; }
    }
    public class EditEducationalGroupBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredEducationalGroupName)]
        [Display(Name = Fa.EducationalGroupName)]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required]
        public int? CollegeId { get; set; }
    }

    public class CreateResearchGroupBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredResearchGroupName)]
        [Display(Name = Fa.ResearchGroupName)]
        public string Name { get; set; }

        [Required]
        public int? CollegeId { get; set; }

        [Required]
        public int? EducationalGroupId { get; set; }

    }

    public class EditResearchGroupBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredResearchGroupName)]
        [Display(Name = Fa.ResearchGroupName)]
        public string Name { get; set; }

        [Required]
        public int? CollegeId { get; set; }

        [Required]
        public int? EducationalGroupId { get; set; }

        public int Id { get; set; }
    }

    public class CreateEmployerBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredEmployerName)]
        [Display(Name = Fa.EmployerName)]
        public string Name { get; set; }

        [Required(ErrorMessage = Fa.EnterNationalCode)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [Display(Name = Fa.NationalCode)]
        public string IdentityNumber { get; set; }

        [Required]
        public EmployerTypes? EmployerType { get; set; }

        [Required]
        public SecurityClass? SecurityClass { get; set; }
    }

    public class EditEmployerBindingModel
    {
        [Required(ErrorMessage = Fa.RequiredEmployerName)]
        [Display(Name = Fa.EmployerName)]
        public string Name { get; set; }

        [Required(ErrorMessage = Fa.EnterNationalCode)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [Display(Name = Fa.NationalCode)]
        public string IdentityNumber { get; set; }

        [Required]
        public EmployerTypes? EmployerType { get; set; }

        [Required]
        public SecurityClass? SecurityClass { get; set; }

        public int Id { get; set; }
    }

    public class CreateExecuterBindingModel
    {
        [Required(ErrorMessage = Fa.EnterName)]
        [Display(Name = Fa.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Fa.EnterLastName)]
        [Display(Name = Fa.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Fa.EnterMasterId)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [Display(Name = Fa.MasterId)]
        public string MasterId { get; set; }

        [Required]
        public int? CollegeId { get; set; }

        [Required]
        public int? EducationalGroupId { get; set; }

        public int[] ResearchGroupIds { get; set; }

        [Display(Name = Fa.Email)]
        [Required(ErrorMessage = Fa.RequiredEmail)]
        [EmailAddress(ErrorMessage = Fa.EmailValidation)]
        public string Email { get; set; }

        [Display(Name = Fa.PhoneNumber)]
        [Phone(ErrorMessage = Fa.RequiredPhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = Fa.Explain)]
        public string Explain { get; set; }
    }

    public class EditExecuterBindingModel
    {
        [Required(ErrorMessage = Fa.EnterName)]
        [Display(Name = Fa.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Fa.EnterLastName)]
        [Display(Name = Fa.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Fa.EnterMasterId)]
        [RegularExpression("[0-9]+", ErrorMessage = Fa.NationalChar)]
        [Display(Name = Fa.MasterId)]
        public string MasterId { get; set; }

        [Required]
        public int? CollegeId { get; set; }

        [Required]
        public int? EducationalGroupId { get; set; }

        public int[] ResearchGroupIds { get; set; }

        [Display(Name = Fa.Email)]
        [Required(ErrorMessage = Fa.RequiredEmail)]
        [EmailAddress(ErrorMessage = Fa.EmailValidation)]
        public string Email { get; set; }

        [Display(Name = Fa.PhoneNumber)]
        [Phone(ErrorMessage = Fa.RequiredPhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = Fa.Explain)]
        public string Explain { get; set; }

        public int Id { get; set; }
    }

    public class CreateProjectBindingModel
    {
        [Display(Name = Fa.ProjectId)]
        [Required(ErrorMessage = Fa.RequiredProjectId)]
        public string ProjectId { get; set; }

        [Display(Name = Fa.Title)]
        [Required(ErrorMessage = Fa.RequiredTitle)]
        public string Title { get; set; }

        [Required]
        public int? EmployerId { get; set; }

        [Required]
        public int? CollegeId { get; set; }

        [Required]
        public int? EducationalGroupId { get; set; }

        [Required]
        public int? ExecuterId { get; set; }

        [Required]
        public int? ResearchGroupId { get; set; }

        [Display(Name = Fa.Price)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? Price { get; set; }

        [Display(Name = Fa.OverHeadPrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? OverHeadPrice { get; set; }

        [Display(Name = Fa.ReceivePrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? ReceivePrice { get; set; }

        [Display(Name = Fa.RemainPrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? RemainPrice { get; set; }

        [Display(Name = Fa.PaymentPrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? PaymentPrice { get; set; }

        [Display(Name = Fa.MainContractId)]
        [Required(ErrorMessage = Fa.RequiredMainContractId)]
        public string MainContractId { get; set; }

        [Display(Name = Fa.MainContractDate)]
        [Required(ErrorMessage = Fa.RequiredMainContractDate)]
        public string MainContractDateStr { get; set; }

        public DateTime? MainContractDate
        {
            get
            {
                return Utility.StringToDate(MainContractDateStr);
            }
        }

        [Display(Name = Fa.InternalContractId)]
        [Required(ErrorMessage = Fa.RequiredInternalContractId)]
        public string InternalContractId { get; set; }

        [Display(Name = Fa.InternalContractDate)]
        [Required(ErrorMessage = Fa.RequiredInternalContractDate)]
        public string InternalContractDateStr { get; set; }

        public DateTime? InternalContractDate
        {
            get
            {
                return Utility.StringToDate(InternalContractDateStr);
            }
        }

        [Display(Name = Fa.ProjectEndTime)]
        public string ProjectEndDateStr { get; set; }

        public DateTime? ProjectEndDate
        {
            get
            {
                return Utility.StringToDate(ProjectEndDateStr);
            }
        }

        [Display(Name = Fa.PhaseNum)]
        public int? PhasesNum { get; set; }

        [Required]
        public int? ProjectStatus { get; set; }

        [Required]
        public int? ProjectType { get; set; }

        [Display(Name = Fa.Explain)]
        public string Explain { get; set; }

        public HttpPostedFileBase[] Attachments { get; set; }

    }

    public class EditProjectBindingModel
    {
        [Display(Name = Fa.ProjectId)]
        [Required(ErrorMessage = Fa.RequiredProjectId)]
        public string ProjectId { get; set; }

        [Display(Name = Fa.Title)]
        [Required(ErrorMessage = Fa.RequiredTitle)]
        public string Title { get; set; }

        [Required]
        public int? EmployerId { get; set; }

        [Required]
        public int? CollegeId { get; set; }

        [Required]
        public int? EducationalGroupId { get; set; }

        [Required]
        public int? ExecuterId { get; set; }

        [Required]
        public int? ResearchGroupId { get; set; }

        [Display(Name = Fa.Price)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? Price { get; set; }

        [Display(Name = Fa.OverHeadPrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? OverHeadPrice { get; set; }

        [Display(Name = Fa.ReceivePrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? ReceivePrice { get; set; }

        [Display(Name = Fa.RemainPrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? RemainPrice { get; set; }

        [Display(Name = Fa.PaymentPrice)]
        [DataType(DataType.Currency, ErrorMessage = Fa.PriceChar)]
        public long? PaymentPrice { get; set; }

        [Display(Name = Fa.MainContractId)]
        [Required(ErrorMessage = Fa.RequiredMainContractId)]
        public string MainContractId { get; set; }

        [Display(Name = Fa.MainContractDate)]
        [Required(ErrorMessage = Fa.RequiredMainContractDate)]
        public string MainContractDateStr { get; set; }

        public DateTime? MainContractDate
        {
            get
            {
                return Utility.StringToDate(MainContractDateStr);
            }
        }

        [Display(Name = Fa.InternalContractId)]
        [Required(ErrorMessage = Fa.RequiredInternalContractId)]
        public string InternalContractId { get; set; }

        [Display(Name = Fa.InternalContractDate)]
        [Required(ErrorMessage = Fa.RequiredInternalContractDate)]
        public string InternalContractDateStr { get; set; }

        public DateTime? InternalContractDate
        {
            get
            {
                return Utility.StringToDate(InternalContractDateStr);
            }
        }

        [Display(Name = Fa.ProjectEndTime)]
        public string ProjectEndDateStr { get; set; }

        public DateTime? ProjectEndDate
        {
            get
            {
                return Utility.StringToDate(ProjectEndDateStr);
            }
        }

        [Display(Name = Fa.PhaseNum)]
        public int? PhasesNum { get; set; }

        [Required]
        public int? ProjectStatus { get; set; }

        [Required]
        public int? ProjectType { get; set; }

        [Display(Name = Fa.Explain)]
        public string Explain { get; set; }

        public HttpPostedFileBase[] Attachments { get; set; }

    }


    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
