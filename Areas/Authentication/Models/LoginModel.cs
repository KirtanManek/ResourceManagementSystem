using System.ComponentModel.DataAnnotations;

namespace ResourceManagementSystem.Areas.Authentication.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Employee Email")]
        public required string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "Keep me signed in")]
        public bool RememberMe { get; set; }

        public int OrganizationID { get; set; }
    }
}
