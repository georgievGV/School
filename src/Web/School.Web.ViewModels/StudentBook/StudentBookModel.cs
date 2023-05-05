namespace School.Web.ViewModels.StudentBook
{
    using System.Collections.Generic;

    using School.Web.ViewModels.Administration.Dashboard;
    using School.Web.ViewModels.Student;

    public class StudentBookModel
    {
        public StudentModel Student { get; set; }

        public string ClassName { get; set; }

        public List<SubjectModel> Subjects { get; set; }
    }
}
