using Microsoft.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ResourceManagementSystem.DAL;
using System.Data;

namespace ResourceManagementSystem.Areas.Admin.DAL
{
	public class AdminDAL : DAL_Helpers
	{
		public DataTable GetEmployeesByOrganizationID(int OrganizationID)
		{
            DataTable dt = new();
            try
            {
                using SqlConnection connection = new(ConnectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RMS_OrganizationWiseEmployee_GetByOrganizationID";
                command.Parameters.AddWithValue("@OrganizationID", OrganizationID);
                using SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
	}
}
