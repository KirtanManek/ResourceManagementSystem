using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Areas.RMS_Organization.BAL;
using ResourceManagementSystem.Areas.RMS_Organization.Models;

namespace ResourceManagementSystem.Areas.RMS_Organization.Controllers
{
    [Area("RMS_Organization")]
    public class RMS_OrganizationController : Controller
    {
        [Route("/RegisterOrganization")]
		[HttpGet]
		public IActionResult RegisterOrganization()
        {
            return View();
        }

		[Route("/RegisterOrganization")]
		[HttpPost]
		public IActionResult RegisterOrganization(RMS_CombinedOrganizationEmployeeModel comb)
		{
			RMS_OrganizationBAL.RegisterOrganization(comb.org, comb.emp);
			return RedirectToAction("Login", "Login", new { area = "Authentication" });
		}
	}
}
