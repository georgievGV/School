namespace School.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TeacherController : Controller
    {

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
