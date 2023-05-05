namespace School.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using School.Services.Data;
    using School.Web.ViewModels;
    using School.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IStudentService studentService;
        private readonly ITeacherService teacherService;

        public HomeController(
            IStudentService studentService,
            ITeacherService teacherService)
        {
            this.studentService = studentService;
            this.teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var studentsCount = this.studentService.GetStudentCount();
            var teachersCount = this.teacherService.GetTeachersCount();
            var model = new IndexViewModel
            {
                Students = studentsCount,
                Teachers = teachersCount,
            };

            return this.View(model);
        }

        public IActionResult Privacy()
        { 
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
