using Microsoft.AspNetCore.Mvc;

namespace TaskInterview.Controllers
{
    public class SessionControllerBase : ControllerBase
    {
        protected int GetUserId()
        {
            var id = HttpContext.Session.GetInt32("UserId");
            if (id == null) throw new Exception("User not logged in");
            return id.Value;
        }

        protected string GetUserRole()
        {
            return HttpContext.Session.GetString("Role") ?? "User";
        }
    }
}
