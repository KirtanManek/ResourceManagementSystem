using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ResourceManagementSystem.Areas.Authentication.BAL;
using ResourceManagementSystem.Areas.Authentication.Models;

namespace ResourceManagementSystem.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    [Route("{area}/{controller}/{action}")]
    public class LoginController() : Controller
    {
        [HttpGet]
        [Route("/Authentication/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Authentication/Login")]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                LoginBal bal = new();
                Dictionary<string, string> result = bal.Login(model);
                if (!result.IsNullOrEmpty())
                {
                    bal.UpdateLastLogin(Convert.ToInt32(result["EmployeeID"]));
                    HttpContext.Session.SetString("SessionKeyAccessLevelName", result["AccessLevelName"].ToString());
                    HttpContext.Session.SetString("SessionKeyEmployeeEmail", result["EmployeeEmail"].ToString());
                    HttpContext.Session.SetInt32("SessionKeyOrganizationID", Convert.ToInt32(result["OrganizationID"]));
                    return RedirectToDashboard(result["AccessLevelName"]);
                }
                else
                {
                    ViewData["LoginError"] = "Invalid Username or Password";
                    ViewData["ErrorMessage"] = "Invalid Username or Password";
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            else
            {
                ViewData["LoginError"] = "Invalid Model";
                ViewData["ErrorMessage"] = "Invalid Model";
            }
            return View("Login", model);
        }

        #region Redirect to dashboard
        private RedirectToActionResult RedirectToDashboard(string accessLevel)
        {
			return accessLevel switch
			{
				"Global Admin" => RedirectToAction("GlobalAdminDashboard", "GlobalAdmin", new { area = "GlobalAdmin" }),
				"Admin" => RedirectToAction("AdminDashboard", "Admin", new { area = "Admin" }),
				"Manager" => RedirectToAction("ManagerDashboard", "Manager", new { area = "Employee" }),
				"Employee" => RedirectToAction("EmployeeDashboard", "Employee", new { area = "Employee" }),
				_ => RedirectToAction("DisplayError", "Error"),
			};
		}
        #endregion

        #region LogOut
        public void LogOut()
        {
            try
            {
                HttpContext.Session.Clear();
                Response.Redirect("/Authentication/Login");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
