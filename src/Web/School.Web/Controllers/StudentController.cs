namespace School.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using School.Data.Models;
    using School.Services.Data;
    using School.Web.ViewModels.Student;

    public class StudentController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IStudentService studentService;
        private readonly IClassService classService;

        public StudentController(
            UserManager<ApplicationUser> userManager,
            IStudentService studentService,
            IClassService classService)
        {
            this.userManager = userManager;
            this.studentService = studentService;
            this.classService = classService;
        }

        public IActionResult Index()
        {
            var model = new StudentModel();

            return this.View(model);
        }
    }
}
