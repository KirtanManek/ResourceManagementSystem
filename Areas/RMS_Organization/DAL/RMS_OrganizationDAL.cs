using Microsoft.Data.SqlClient;
using ResourceManagementSystem.Areas.RMS_Organization.Models;
using System.Data;

namespace ResourceManagementSystem.Areas.RMS_Organization.DAL
{
    public class RMS_OrganizationDAL : ResourceManagementSystem.DAL.DAL_Helpers
    {
        #region Register Organization
        public static int RegisterOrganization(RMS_OrganizationModel rms)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new("PR_RMS_Organization_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrganizationContact", rms.OrganizationContact);
            cmd.Parameters.AddWithValue("@OrganizationEmail", rms.OrganizationEmail);
            cmd.Parameters.AddWithValue("@OrganizationAddress", rms.OrganizationAddress);
            cmd.Parameters.AddWithValue("@OrganizationName", rms.OrganizationName);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        #endregion
    }
}
