using System.ComponentModel.DataAnnotations;

namespace ResourceManagementSystem.Areas.RMS_Organization.Models
{
    public class RMS_OrganizationModel
    {
        [Display(Name = "OrganizationID")]
        public int OrganizationID { get; set; }

        [Required(ErrorMessage = "Please enter Organization Name")]
        [Display(Name = "OrganizationName")]
        public required string OrganizationName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Organization Contact")]
        [Required(ErrorMessage = "Contact Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Entered phone format is not valid.")]
        public required string OrganizationContact { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [Display(Name = "Organization Email")]
        public required string OrganizationEmail { get; set; }

        [Display(Name = "Organization Address")]
        public required string OrganizationAddress { get; set; }
    }
}
