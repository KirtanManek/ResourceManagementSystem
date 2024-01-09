using Microsoft.AspNetCore.Mvc;

namespace ResourceManagementSystem.Areas.GlobalAdmin.Controllers
{
    [Area("GlobalAdmin")]
    [Route("{area}/{controller}/{action}")]
    public class GlobalAdminController : Controller
    {
        public IActionResult GlobalAdminDashboard()
        {
            return View();
        }
    }
}
