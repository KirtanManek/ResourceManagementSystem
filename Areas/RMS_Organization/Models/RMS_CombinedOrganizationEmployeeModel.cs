using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;

namespace ResourceManagementSystem.Areas.RMS_Organization.Models
{
	public class RMS_CombinedOrganizationEmployeeModel
	{
		public RMS_OrganizationModel org { get; set; }
		public RMS_OrganizationWiseEmployeeModel emp { get; set; }
	}
}
