using ResourceManagementSystem.Areas.Admin.DAL;
using System.Data;

namespace ResourceManagementSystem.Areas.Admin.BAL
{
	public class AdminBAL
	{
        public DataTable GetEmployeesByOrganizationID(int OrganizationID)
		{
            AdminDAL dal = new();
            return dal.GetEmployeesByOrganizationID(OrganizationID);
        }
	}
}
