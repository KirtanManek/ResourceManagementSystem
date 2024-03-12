using System.ComponentModel.DataAnnotations;

namespace ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models
{
    public class RMS_OrganizationWiseEmployeeModel
    {
        [Display(Name = "OrganizationID")]
        public int OrganizationID { get; set; }


        [Required(ErrorMessage = "Please select access level.")]
        [Display(Name = "Access Level")]
        public required string AccessLevel { get; set; }


        [Required(ErrorMessage = "Please enter Employee Name")]
        [Display(Name = "EmployeeName")]
        public required string EmployeeName { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Contact Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Entered phone format is not valid.")]
        public required string EmployeeContact { get; set; }


        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [Display(Name = "Employee Email")]
        public required string EmployeeEmail { get; set; }


        [Required(ErrorMessage = "Please enter Employee Department")]
        [Display(Name = "Employee Department")]
        public required string EmployeeDepartment { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select the gender")]
        public required string EmployeeGender { get; set; }


        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} characters", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,16})$", ErrorMessage = "Password must contain: Minimum 8 characters, at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number, and 1 Special Character")]
        public required string Password { get; set; }


        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again!")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
