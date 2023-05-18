namespace School.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ParentController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
