using ResourceManagementSystem.Areas.RMS_Organization.Models;

namespace ResourceManagementSystem.Areas.RMS_Organization.BAL
{
    public class RMS_OrganizationBAL
    {
        #region Register Organization
        public static int RegisterOrganization(RMS_OrganizationModel rms)
        {
            return ResourceManagementSystem.Areas.RMS_Organization.DAL.RMS_OrganizationDAL.RegisterOrganization(rms);
        }
        #endregion
    }
}
