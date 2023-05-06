namespace School.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using School.Web.ViewModels.Student;
    using School.Web.ViewModels.StudentBook;
    using School.Web.ViewModels.Teacher;

    public class ClassSettingsViewModel
    {

        public ClassSettingsViewModel()
        {
            this.Students = new List<StudentModel>();
            this.Teachers = new List<TeacherModel>();
            this.SubjectsOwned = new List<SubjectModel>();
            this.StudentBooks = new List<StudentBookModel>();
            this.AvailableSubjectsToAdd = new List<SubjectModel>();
        }

        public string Id { get; set; }

        public int ClassNumber { get; set; }

        public List<StudentModel> Students { get; set; }

        public List<TeacherModel> Teachers { get; set; }

        public List<SubjectModel> SubjectsOwned { get; set; }

        public List<SubjectModel> AvailableSubjectsToAdd { get; set; }

        public List<StudentBookModel> StudentBooks { get; set; }

        public List<string> SubjectNames { get; set; }
    }
}
