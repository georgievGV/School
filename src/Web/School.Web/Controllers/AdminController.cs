namespace School.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis;
    using School.Data.Models;
    using School.Services.Data;
    using School.Web.ViewModels.Administration.Dashboard;

    public class AdminController : Controller
    {
        private readonly IClassService classService;
        private readonly ISubjectService subjectService;

        public AdminController(
            IClassService classService,
            ISubjectService subjectService)
        {
            this.classService = classService;
            this.subjectService = subjectService;
        }

        public IActionResult Index()
        {
            var model = new ClassListViewModel();
            model.Classes = this.classService.GetClasses().OrderBy(c => c.ClassNumber).ThenBy(c => c.Specialty).ToList();

            return this.View(model);
        }

        public IActionResult ClassSettings(ClassBaseModel input)
        {
            var model = new ClassSettingsViewModel();
            var subjectsDb = this.subjectService.GetSubjects(input.Id).OrderBy(s => s.Name).ToList();
            foreach (var subject in subjectsDb)
            {
                var subjectModel = new SubjectModel
                {
                    Name = subject.Name,
                    ClassNumber = subject.ClassNumber,
                    ClassSpecialty = subject.ClassSpecialty,
                    IsChecked = false,
                };

                model.Subjects.Add(subjectModel);
            }

            return this.View(model);
        }

        [HttpPost]
        public IActionResult ClassSettings(ClassSettingsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currClass = this.classService.GetClassById(input.Id);
            var currentSubjects = new List<Subject>();

            foreach (var subject in input.SubjectNames)
            {
                var currentSubject = new Subject
                {
                    Name = subject,
                    ClassNumber = currClass.ClassNumber,
                    ClassSpecialty = currClass.Specialty,
                };

                currentSubjects.Add(currentSubject);
            }

            this.classService.AddSubject(currentSubjects);

            return this.Redirect($"/Admin/ClassSettins?id={input.Id}");
        }

        public IActionResult CreateClass()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreateClass(ClassInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("CreateClass", input);
            }

            this.classService.CreateClass(input.ClassNumber, input.Specialty.ToUpper());

            return this.Redirect("/Admin");
        }

        public IActionResult CreateSubject()
        {
            var model = new SubjectInputModel();
            var allSubjects = this.subjectService.GetSubjects().Where(s => s.ClassSpecialty == "NotSet");
            model.Subjects = allSubjects;

            return this.View(model);
        }

        [HttpPost]
        public IActionResult CreateSubject(SubjectInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            this.subjectService.CreateSubject(input.Name, input.ClassNumber);

            return this.Redirect("/Admin/CreateSubject");
        }

        private List<SubjectModel> GetAllSubjectsOrdered()
        {
            var subjects = this.subjectService.GetSubjects().Where(s => s.ClassSpecialty == "NotSet").ToList();
            var subjectsOrdered = new List<SubjectModel>();
            foreach (var subject in subjects)
            {
                var subjectModel = new SubjectModel
                {
                    Name = subject.Name,
                    ClassNumber = subject.ClassNumber,
                    ClassSpecialty = subject.ClassSpecialty,
                    IsChecked = false,
                };

                subjectsOrdered.Add(subjectModel);
            }

            subjectsOrdered = subjectsOrdered.OrderBy(x => x.ClassNumber).ThenBy(x => x.ClassSpecialty).ThenBy(x => x.Name).ToList();

            return subjectsOrdered;
        }
    }

}
