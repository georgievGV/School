namespace School.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using School.Data.Models;
    using School.Services.Data;
    using School.Web.ViewModels;
    using School.Web.ViewModels.User;

    public class UserController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly Data.ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private IStudentService studentService;

        public UserController(
            ILogger<HomeController> logger,
            Data.ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IStudentService studentService)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.studentService = studentService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();
            var user = await this.userManager.GetUserAsync(this.User);

            if (user.StudentId != null)
            {
                model.Controller = "Student";
                model.Action = "Index";
            }
            else if (user.ParentId != null)
            {
                model.Controller = "Parent";
                model.Action = "Index";
            }
            else if (user.TeacherId != null)
            {
                model.Controller = "Teacher";
                model.Action = "Index";
            }
            else
            {
                model.Controller = "User";
                model.Action = "Index";
            }

            return this.View(model);
        }

        [Authorize]
        public IActionResult CreateStudent()
        {
            return this.View("CreatePerson");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(PersonInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("CreatePerson", input);
            }

            var student = this.studentService
                .Create(input.FirstName, input.MiddleName, input.LastName, input.Email, input.MobileNumber, input.Address);

            if (student == null)
            {
                return this.View("ErrorPersonExist");
            }

            var user = await this.userManager.GetUserAsync(this.User);
            user.StudentId = student.Id;
            this.dbContext.SaveChanges();

            return this.Redirect("/Student/Index");
        }
    }
}
