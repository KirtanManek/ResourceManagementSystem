using Microsoft.AspNetCore.Mvc;

namespace ResourceManagementSystem.Areas.RMS_Organization.Controllers
{
    [Area("RMS_Organization")]
    [Route("{controller}/{action}")]
    public class RMS_OrganizationController : Controller
    {
        public IActionResult RegisterOrganization()
        {
            return View();
        }
    }
}
