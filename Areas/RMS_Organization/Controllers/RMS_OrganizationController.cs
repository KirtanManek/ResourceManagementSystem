using Microsoft.AspNetCore.Mvc;

namespace ResourceManagementSystem.Areas.RMS_Organization.Controllers
{
    public class RMS_OrganizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
