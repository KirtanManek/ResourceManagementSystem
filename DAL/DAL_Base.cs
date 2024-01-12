using Microsoft.Data.SqlClient;
using ResourceManagementSystem.Models;
using System.Data;

namespace ResourceManagementSystem.DAL
{
	public class DAL_Base : DAL_Helpers
	{
		public UserModel GetUser(int EmployeeID)
		{
			UserModel model = new();
			using SqlConnection conn = new(ConnectionString);
			using SqlCommand cmd = new("PR_RMS_OrganizationWiseEmployee_GetEmployeeByID", conn);
			cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
			cmd.CommandType = CommandType.StoredProcedure;
			conn.Open();
			using SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				model.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
				model.EmployeeName = reader["EmployeeName"].ToString();
				model.EmployeeEmail = reader["EmployeeEmail"].ToString();
				model.EmployeeContact = reader["EmployeeContact"].ToString();
				model.AccessLevelName = reader["AccessLevelName"].ToString();
				model.OrganizationID = Convert.ToInt32(reader["OrganizationID"]);
				model.EmployeeDepartment = reader["EmployeeDepartment"].ToString();
				model.EmployeeGender = reader["EmployeeGender"].ToString();
			}
			conn.Close();
			return model;
		}
	}
}
