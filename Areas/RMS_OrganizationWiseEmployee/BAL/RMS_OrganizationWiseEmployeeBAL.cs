﻿using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;

namespace ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.BAL
{
    public class RMS_OrganizationWiseEmployeeBAL
    {
        #region Register Employee
        public static int RegisterEmployee(RMS_OrganizationWiseEmployeeModel rms, string AccessLevel)
        {
            return DAL.RMS_OrganizationWiseEmployeeDAL.RegisterEmployee(rms, AccessLevel);
        }
        #endregion
    }
}
