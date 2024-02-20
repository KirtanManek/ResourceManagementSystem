using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.BAL;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;

namespace ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Controllers
{
    [Area("RMS_OrganizationWiseEmployee")]
    public class RMS_OrganizationWiseEmployeeController : Controller
    {
        [Route("/RegisterEmployee")]
        [HttpGet]
        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [Route("/RegisterEmployee")]
        [HttpPost]
        public IActionResult RegisterEmployee(RMS_OrganizationWiseEmployeeModel rms)
        {
            string AccessLevel;
            if(rms.AccessLevelID.Equals(5))
            {
				AccessLevel = "Admin";
			}
			else if(rms.AccessLevelID.Equals(6))
            {
				AccessLevel = "Manager";
			}
            else
            {
                AccessLevel = "Employee";
            }
            int result = RMS_OrganizationWiseEmployeeBAL.RegisterEmployee(rms, AccessLevel);
            if (result != 1)
            {
                Console.WriteLine("Error in inserting data");
                ViewData["ErrorMessage"] = "Error in inserting data";
            }
            return RedirectToAction("AdminDashboard", "Admin", new { area = "Admin" });
        }
    }
}
