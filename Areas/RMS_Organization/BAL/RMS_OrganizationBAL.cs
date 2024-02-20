using ResourceManagementSystem.Areas.RMS_Organization.DAL;
using ResourceManagementSystem.Areas.RMS_Organization.Models;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;

namespace ResourceManagementSystem.Areas.RMS_Organization.BAL
{
    public class RMS_OrganizationBAL
    {
		#region Register Organization
		public static void RegisterOrganization(RMS_OrganizationModel org, RMS_OrganizationWiseEmployeeModel emp)
		{
			RMS_OrganizationDAL r = new();
			r.RegisterOrganization(org, emp);
		}
		#endregion
	}
}
