using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.BAL;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;

namespace ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Controllers
{
    [Area("RMS_OrganizationWiseEmployee")]
    [Route("[controller]/[action]")]
    public class RMS_OrganizationWiseEmployeeController : Controller
    {
        //[Route("/RegisterEmployee")]
        [HttpGet]
        public IActionResult RegisterEmployee(string AccessLevel)
        {
			RMS_OrganizationWiseEmployeeViewModel Employee = new()
			{
				AccessLevel = AccessLevel
			};
			return View(Employee);
        }

        //[Route("/RegisterEmployee")]
        [HttpPost]
        public IActionResult RegisterEmployee(RMS_OrganizationWiseEmployeeViewModel Employee)
        {

            if(HttpContext.Session.GetInt32("SessionKeyOrganizationID") == null)
            {
                return RedirectToAction("Login", "Login", new { area = "Authentication" });
            }
            int result = RMS_OrganizationWiseEmployeeBAL.RegisterEmployee(Employee.Rms, (int)HttpContext.Session.GetInt32("SessionKeyOrganizationID"), Employee.AccessLevel);
            if (result != 1)
            {
                Console.WriteLine("Error in inserting data");
                ViewData["ErrorMessage"] = "Error in inserting data";
            }
            return RedirectToAction("AdminDashboard", "Admin", new { area = "Admin" });
        }
    }
}
