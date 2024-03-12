using Microsoft.AspNetCore.Mvc;
using ResourceManagementSystem.Areas.Admin.BAL;
using ResourceManagementSystem.BAL;
using ResourceManagementSystem.Models;
using System.Data;

namespace ResourceManagementSystem.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminController : Controller
	{
		[Route("Admin/Dashboard")]
		public IActionResult AdminDashboard()
		{
			if (HttpContext.Session.GetString("SessionKeyAccessLevelName") == "Admin")
			{
				UserModel user = new BAL_Base().GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("SessionKeyEmployeeID")));
				AdminBAL bal = new();
				DataTable dt = bal.GetEmployeesByOrganizationID(Convert.ToInt32(HttpContext.Session.GetInt32("SessionKeyOrganizationID")));
				ViewBag.Data = user;
				return View(dt);
			}
			else
			{
				return RedirectToAction("DisplayError", "Error");
			}
		}
	}
}
