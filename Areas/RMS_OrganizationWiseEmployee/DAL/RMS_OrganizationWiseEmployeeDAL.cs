using Microsoft.Data.SqlClient;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;
using System.Data;

namespace ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.DAL
{
    public class RMS_OrganizationWiseEmployeeDAL : ResourceManagementSystem.DAL.DAL_Helpers
    {
        #region Register Employee
        public static int RegisterEmployee(RMS_OrganizationWiseEmployeeModel rms)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("PR_RMS_OrganizationWiseEmployee_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrganizationID", rms.OrganizationID);
            cmd.Parameters.AddWithValue("@AccessLevelID", rms.AccessLevelID);
            cmd.Parameters.AddWithValue("@EmployeeName", rms.EmployeeName);
            cmd.Parameters.AddWithValue("@EmployeeContact", rms.EmployeeContact);
            cmd.Parameters.AddWithValue("@EmployeeEmail", rms.EmployeeEmail);
            cmd.Parameters.AddWithValue("@EmployeeDepartment", rms.EmployeeDepartment);
            cmd.Parameters.AddWithValue("@EmployeeGender", rms.EmployeeGender);
            cmd.Parameters.AddWithValue("@Password", rms.ConfirmPassword);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        #endregion
    }
}
