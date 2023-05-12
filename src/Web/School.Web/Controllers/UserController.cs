namespace School.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IStudentService studentService;
        private readonly IClassService classService;
        private readonly ISubjectService subjectService;

        public UserController(
            ILogger<HomeController> logger,
            Data.ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IStudentService studentService,
            IClassService classService,
            ISubjectService subjectService)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.studentService = studentService;
            this.classService = classService;
            this.subjectService = subjectService;
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
        public IActionResult CreateStudentRequest()
        {
            var model = new PersonInputModel();
            model.ClassesSelectList = this.PopulateClasses();

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateStudentRequest(PersonInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("CreatePerson", input);
            }


            var classNumber = input.ClassNumber;
            var request = this.studentService.CreateStudentRequest(
            input.FirstName, input.MiddleName, input.LastName, input.Email, input.MobileNumber, input.Address, classNumber, input.Specialty);
            var user = await this.userManager.GetUserAsync(this.User);
            user.PersonReqiestId = request.Id;

            this.dbContext.SaveChanges();
            return this.Redirect("/Student/Index");
        }


        public IActionResult GetSpecialtiesByClassNumber(int classNumber)
        {
            var specialties = this.GetSpecialties(classNumber);
            return this.Json(specialties);
        }

        private List<SelectListItem> PopulateClasses()
        {
            var previousClassNumber = 0;
            var classes = this.classService.GetClasses();
            var selectList = new List<SelectListItem>();

            for (int i = 0; i < classes.Count; i++)
            {
                if (classes[i].ClassNumber != previousClassNumber)
                {
                    var selectListItem = new SelectListItem
                    {
                        Text = classes[i].ClassNumber.ToString(),
                        Value = classes[i].ClassNumber.ToString(),
                    };

                    selectList.Add(selectListItem);
                    previousClassNumber = classes[i].ClassNumber;
                }
            }

            return selectList;
        }

        private List<SelectListItem> GetSpecialties(int classNumber = 1)
        {
            var classList = this.classService.GetClasses().Where(c => c.ClassNumber == classNumber).ToList();
            var specialties = new List<SelectListItem>();
            foreach (var @class in classList)
            {
                if (@class.Specialty != "NotSet")
                {
                    var specialty = new SelectListItem()
                    {
                        Value = @class.Specialty,
                        Text = @class.Specialty.ToString(),
                    };

                    specialties.Add(specialty);
                }
            }

            return specialties;
        }

        private string GetJsonClassNSubjects()
        {
            var currClassNumber = 0;
            var classes = this.classService.GetClasses();
            var selectList = new List<SelectListItem>();

            for (int i = 0; i < classes.Count; i++)
            {
                if (classes[i].ClassNumber != currClassNumber)
                {
                    var selectListItem = new SelectListItem
                    {
                        Text = classes[i].ClassNumber.ToString(),
                    };

                    var specialties = this.classService.GetSpecialties(classes[i].ClassNumber);
                    for (int j = 0; j < specialties.Count; j++)
                    {
                        if (j + 1 < specialties.Count)
                        {
                            selectListItem.Value += specialties[j] + ", ";
                        }
                        else
                        {
                            selectListItem.Value += specialties[j];
                        }
                    }

                    selectList.Add(selectListItem);
                    currClassNumber = classes[i].ClassNumber;
                }
            }

            var jsonData = JsonSerializer.Serialize(selectList);

            return jsonData;
        }
    }
}
