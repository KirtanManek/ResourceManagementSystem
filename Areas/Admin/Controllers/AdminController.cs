using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.BAL;
using ResourceManagementSystem.Models;

namespace ResourceManagementSystem.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminController : Controller
	{
		[Route("Admin/Dashboard")]
		public IActionResult AdminDashboard()
		{
			//if (HttpContext.Session.GetString("SessionKeyAccessLevelName") == "Admin")
			//{

			//}
			//else
			//{
			//	return RedirectToAction("DisplayError", "Error");
			//}
			UserModel user = new BAL_Base().GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("SessionKeyEmployeeID")));
			ViewBag.Data = user;
			return View();
		}
	}
}
