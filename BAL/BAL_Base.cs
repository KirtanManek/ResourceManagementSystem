using ResourceManagementSystem.DAL;
using ResourceManagementSystem.Models;

namespace ResourceManagementSystem.BAL
{
	public class BAL_Base
	{
		public UserModel GetUser(int EmployeeID)
		{
			DAL_Base dal = new();
			return dal.GetUser(EmployeeID);
		}
	}
}
