using Microsoft.Data.SqlClient;
using ResourceManagementSystem.Areas.Authentication.Models;
using System.Data;
namespace ResourceManagementSystem.Areas.Authentication.DAL
{
    public class LoginDal : ResourceManagementSystem.DAL.DAL_Helpers
    {
        #region Login
        public Dictionary<string, string> Login(LoginModel model)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                conn.Open();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_RMS_OrganizationWiseEmployee_GetLoginInfo";
                cmd.Parameters.AddWithValue("@EmployeeEmail", model.EmployeeEmail);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                Console.WriteLine(model.EmployeeEmail + "   " + model.Password);
                using SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, string> loginInfo = [];
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        loginInfo.Add("EmployeeID", reader["EmployeeID"].ToString());
                        loginInfo.Add("OrganizationID", reader["OrganizationID"].ToString());
                        loginInfo.Add("EmployeeName", reader["EmployeeName"].ToString());
                        loginInfo.Add("EmployeeEmail", reader["EmployeeEmail"].ToString());
                        loginInfo.Add("EmployeeContact", reader["EmployeeContact"].ToString());
                        loginInfo.Add("EmployeeDepartment", reader["EmployeeDepartment"].ToString());
                        loginInfo.Add("EmployeeGender", reader["EmployeeGender"].ToString());
                        loginInfo.Add("AccessLevelID", reader["AccessLevelID"].ToString());
                        loginInfo.Add("AccessLevelName", reader["AccessLevelName"].ToString());
                        loginInfo.Add("Password", reader["Password"].ToString());
                        loginInfo.Add("Created", reader["Created"].ToString());
                        loginInfo.Add("Modified", reader["Modified"].ToString());
                        loginInfo.Add("LastLogin", reader["LastLogin"].ToString());
                    }
                }
                return loginInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region UpdateLastLogin
        public void UpdateLastLogin(int EmployeeID)
        {
            try
            {
                using SqlConnection conn = new(ConnectionString);
                using SqlCommand cmd = new("PR_RMS_OrganizationWiseEmployee_UpdateLastLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
