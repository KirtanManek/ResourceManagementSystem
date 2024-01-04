using ResourceManagementSystem.Areas.Authentication.DAL;
using ResourceManagementSystem.Areas.Authentication.Models;

namespace ResourceManagementSystem.Areas.Authentication.BAL
{
    public class LoginBal
    {
        public Dictionary<string, string> Login(LoginModel model)
        {
            LoginDal DAL = new();
            Dictionary<string, string> result = DAL.Login(model);
            return result;
        }

        public void UpdateLastLogin(string EmployeeEmail)
        {
            LoginDal DAL = new();
            DAL.UpdateLastLogin(EmployeeEmail);
        }
    }
}
