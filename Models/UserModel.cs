using System.ComponentModel.DataAnnotations;

namespace ResourceManagementSystem.Models
{
	public class UserModel
	{
		[Display(Name = "OrganizationID")]
		public int OrganizationID { get; set; }

		[Display(Name = "EmployeeID")]
		public int EmployeeID { get; set; }


		[Required(ErrorMessage = "Please select access level.")]
		[Display(Name = "Access Level")]
		public string? AccessLevelName { get; set; }


		[Required(ErrorMessage = "Please enter Employee Name")]
		[Display(Name = "EmployeeName")]
		public string? EmployeeName { get; set; }


		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Contact Number")]
		[Required(ErrorMessage = "Contact Number Required!")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Entered phone format is not valid.")]
		public string? EmployeeContact { get; set; }


		[Required(ErrorMessage = "Please enter Email")]
		[DataType(DataType.EmailAddress)]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
		[Display(Name = "Employee Email")]
		public string? EmployeeEmail { get; set; }


		[Required(ErrorMessage = "Please enter Employee Department")]
		[Display(Name = "Employee Department")]
		public string? EmployeeDepartment { get; set; }


		[Display(Name = "Gender")]
		[Required(ErrorMessage = "Please Select the gender")]
		public string? EmployeeGender { get; set; }
	}
}
