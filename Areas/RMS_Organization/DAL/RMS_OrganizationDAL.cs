using Microsoft.Data.SqlClient;
using ResourceManagementSystem.Areas.RMS_Organization.Models;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.DAL;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;
using System.Data;

namespace ResourceManagementSystem.Areas.RMS_Organization.DAL
{
    public class RMS_OrganizationDAL : ResourceManagementSystem.DAL.DAL_Helpers
    {
        #region Register Organization
        public void RegisterOrganization(RMS_OrganizationModel org, RMS_OrganizationWiseEmployeeModel emp)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("PR_RMS_Organization_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrganizationContact", org.OrganizationContact);
            cmd.Parameters.AddWithValue("@OrganizationEmail", org.OrganizationEmail);
            cmd.Parameters.AddWithValue("@OrganizationAddress", org.OrganizationAddress);
            cmd.Parameters.AddWithValue("@OrganizationName", org.OrganizationName);
            conn.Open();
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            emp.EmployeeEmail = org.OrganizationEmail;
            emp.OrganizationID = result;
            RMS_OrganizationWiseEmployeeDAL.RegisterEmployee(emp, "Admin");
        }
        #endregion
    }
}
