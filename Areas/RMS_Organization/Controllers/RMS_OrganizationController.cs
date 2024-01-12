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
		public IActionResult RegisterOrganization(RMS_OrganizationModel rms)
		{
			int result = RMS_OrganizationBAL.RegisterOrganization(rms);
			HttpContext.Session.SetInt32("SessionKeyOrganizationID", result);
			return RedirectToAction("AdminDashboard", "Admin", new { area = "Admin" });
		}
	}
}
