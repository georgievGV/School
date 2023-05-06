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
            var classNumber = this.classService.GetClassById(input.Id).ClassNumber;

            foreach (var subject in subjectsDb)
            {
                var subjectModel = new SubjectModel
                {
                    Name = subject.Name,
                    ClassNumber = subject.ClassNumber,
                    ClassSpecialty = subject.ClassSpecialty,
                    IsChecked = false,
                };

                model.SubjectsOwned.Add(subjectModel);
            }

            model.AvailableSubjectsToAdd = this.GetAvailableSubjectsOrdered(classNumber, model.SubjectsOwned);


            return this.View(model);
        }

        [HttpPost]
        public IActionResult ClassSettings(ClassSettingsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var header = this.HttpContext.Request.Headers.FirstOrDefault(h => h.Key == "Referer").Value;
            var id = this.GetId(header);

            var currentClass = this.classService.GetClassById(id);
            var currentSubjects = new List<Subject>();

            foreach (var subjectName in input.SubjectNames)
            {
                var currentSubject = new Subject
                {
                    Name = subjectName,
                    ClassNumber = currentClass.ClassNumber,
                    ClassSpecialty = currentClass.Specialty,
                };

                var subjectModel = new SubjectModel
                {
                    Name = subjectName,
                    ClassNumber = currentClass.ClassNumber,
                    ClassSpecialty = currentClass.Specialty,
                    IsChecked = false,
                };

                input.SubjectsOwned.Add(subjectModel);
                currentSubjects.Add(currentSubject);
            }

            input.AvailableSubjectsToAdd = this.GetAvailableSubjectsOrdered(currentClass.ClassNumber, input.SubjectsOwned);
            this.classService.AddSubject(currentClass, currentSubjects);

            return this.Redirect($"/Admin/ClassSettings?id={id}");
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

        public List<SubjectModel> GetAvailableSubjectsOrdered(int classNumber, List<SubjectModel> subjectsOwned)
        {
            var subjects = this.subjectService.GetSubjects().Where(s => s.ClassSpecialty == "NotSet" && s.ClassNumber == classNumber).ToList();
            var subjectsOrdered = new List<SubjectModel>();


            foreach (var subject in subjects)
            {
                bool isAvailable = true;

                foreach (var subjectOwned in subjectsOwned)
                {
                    if (subjectOwned.Name == subject.Name)
                    {
                        isAvailable = false;
                        break;
                    }
                }

                if (isAvailable)
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
            }

            subjectsOrdered = subjectsOrdered.OrderBy(x => x.ClassNumber).ThenBy(x => x.ClassSpecialty).ThenBy(x => x.Name).ToList();

            return subjectsOrdered;
        }

        public string GetId(string headerValue)
        {
            string symbols = "id=";
            int count = 0;
            string id = string.Empty;

            for (int i = 0; i < headerValue.Length; i++)
            {

                if (count == symbols.Length)
                {
                    if (headerValue[i] != '&')
                    {
                        id += headerValue[i];
                        continue;
                    }

                    break;
                }

                if (headerValue[i] == symbols[count])
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
            }

            return id;
        }
    }

}
