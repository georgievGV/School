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

        public StudentController(
            UserManager<ApplicationUser> userManager,
            IStudentService studentService)
        {
            this.userManager = userManager;
            this.studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var student = this.studentService.GetStudent(user.StudentId);
            var model = new StudentModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                ClassName = student.Class?.ClassNumber.ToString() + " " + student.Class?.Specialty.ToString(),
            };

            return this.View(model);
        }
    }
}
