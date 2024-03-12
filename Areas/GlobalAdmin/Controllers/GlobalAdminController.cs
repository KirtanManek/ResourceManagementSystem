using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.BAL;
using ResourceManagementSystem.Models;

namespace ResourceManagementSystem.Areas.GlobalAdmin.Controllers
{
    [Area("GlobalAdmin")]
    public class GlobalAdminController : Controller
    {
        [Route("GlobalAdmin/Dashboard")]
        public IActionResult GlobalAdminDashboard()
        {
			if (HttpContext.Session.GetString("SessionKeyAccessLevelName") == "Global Admin")
			{
				UserModel user = new BAL_Base().GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("SessionKeyEmployeeID")));
				ViewBag.Data = user;
				return View();
			}
			else
			{
				return RedirectToAction("DisplayError", "Error");
			}
		}
    }
}
