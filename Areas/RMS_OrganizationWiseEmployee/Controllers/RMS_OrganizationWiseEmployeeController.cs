using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.BAL;
using ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Models;

namespace ResourceManagementSystem.Areas.RMS_OrganizationWiseEmployee.Controllers
{
    public class RMS_OrganizationWiseEmployeeController : Controller
    {
        [HttpPost]
        public ActionResult RegisterEmployee(RMS_OrganizationWiseEmployeeModel rms)
        {
            int result = RMS_OrganizationWiseEmployeeBAL.RegisterEmployee(rms);
            if (result != 1)
            {
                Console.WriteLine("Error in inserting data");
                ViewData["ErrorMessage"] = "Error in inserting data";
            }
            return View();
        }
    }
}
