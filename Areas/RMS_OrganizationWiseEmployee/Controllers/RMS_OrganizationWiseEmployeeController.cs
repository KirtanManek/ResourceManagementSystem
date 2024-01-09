using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.BAL;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;

namespace ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Controllers
{
    [Area("RMS_OrganizationWiseEmployee")]
    [Route("{area}/{controller}/{action}")]
    public class RMS_OrganizationWiseEmployeeController : Controller
    {
        [HttpGet]
        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterEmployee(RMS_OrganizationWiseEmployeeModel rms)
        {
            int result = RMS_OrganizationWiseEmployeeBAL.RegisterEmployee(rms);
            if (result != 1)
            {
                Console.WriteLine("Error in inserting data");
                ViewData["ErrorMessage"] = "Error in inserting data";
            }
            return RedirectToAction("GlobalAdminDashboard", "GlobalAdmin", new { area = "GlobalAdmin" });
        }
    }
}
