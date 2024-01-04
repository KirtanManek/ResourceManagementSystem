using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ResourceManagementSystem.Areas.Authentication.BAL;
using ResourceManagementSystem.Areas.Authentication.Models;
using System.Data;

namespace ResourceManagementSystem.Areas.Authentication.Controllers
{
    public class LoginController() : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Authentication/Login")]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidUser(model))
                {
                    LoginBal bal = new();
                    bal.UpdateLastLogin(model.EmployeeEmail);
                    Dictionary<string, string> result = bal.Login(model);
                    return RedirectToDashboard(result["AccessLevel"]);
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

        #region IsValidUser
        private bool IsValidUser(LoginModel model)
        {
            LoginBal bal = new();
            Dictionary<string, string> result = bal.Login(model);
            if (!result.IsNullOrEmpty())
            {
                HttpContext.Session.SetInt32("SessionKeyAccessLevelID", Convert.ToInt32(result["AccessLevelID"]));
                HttpContext.Session.SetString("SessionKeyEmployeeEmail", result["EmployeeEmail"].ToString());
                HttpContext.Session.SetInt32("SessionKeyOrganizationID", Convert.ToInt32(result["OrganizationID"]));
                return true;
            }
            return false;

        }
        #endregion

        #region Redirect to dashboard
        private RedirectToActionResult RedirectToDashboard(string accessLevel)
        {
            switch (accessLevel)
            {
                case "Global Admin":
                    return RedirectToAction("GlobalAdminDashboard", "GlobalAdmin", new { area = "GlobalAdmin" });
                case "Admin":
                    return RedirectToAction("AdminDashboard", "Admin", new { area = "Admin" });
                case "Manager":
                    return RedirectToAction("ManagerDashboard", "Manager", new { area = "Employee" });
                case "Employee":
                    return RedirectToAction("EmployeeDashboard", "Employee", new { area = "Employee" });
                default:
                    return RedirectToAction("DisplayError", "Error");
            }
        }
        #endregion

        #region LogOut
        public void LogOut()
        {
            try
            {
                HttpContext.Session.Clear();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
