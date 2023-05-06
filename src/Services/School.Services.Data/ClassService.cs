namespace School.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using School.Data;
    using School.Data.Models;

    public class ClassService : IClassService
    {
        private readonly ApplicationDbContext dbContext;

        public ClassService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateClass(int classNumber, string specialty)
        {

            var @class = new Class { ClassNumber = classNumber, Specialty = specialty};

            if (!Validator.CheckIfExist(@class, this.dbContext))
            {
                this.dbContext.Classes.Add(@class);
                this.dbContext.SaveChanges();
            }
        }

        public Class GetClassById(string id)
        {
            var @class = this.dbContext.Classes.FirstOrDefault(c => c.Id == id);

            return @class;
        }

        public IList<Class> GetClasses()
        {
            var classes = this.dbContext.Classes.ToList();

            return classes;
        }

        public void AddSubject(Class @class, List<Subject> subjects)
        {
            foreach (var subject in subjects)
            {
                if (!Validator.CheckIfExist(subject, this.dbContext))
                {
                    @class.Subjects.Add(subject);
                }
            }

            this.dbContext.SaveChanges();
        }

        public IList<Subject> GetSubjects(int classNumber)
        {
            var subjects = this.dbContext.Subjects.Where(s => s.ClassNumber == classNumber).ToList();

            return subjects;
        }

        public void AddTeacher(Class @class, Teacher teacher)
        {
            var classTeacher = new ClassTeacher
            {
                Class = @class,
                Teacher = teacher,
            };
            @class.Teachers.Add(classTeacher);
            teacher.Classes.Add(classTeacher);
            this.dbContext.SaveChanges();
        }

        public void AddClassTeacher(Class @class, Teacher teacher)
        {
            @class.ClassTeacher = teacher;
            teacher.MyClass = @class;
            this.dbContext.SaveChanges();
        }

        /*
                public void AddStudent(Class @class, Student student, StudentBookService studentBookService)
                {
                    this._class.Students.Add(student);
                    student.Class = this._class;
                    UpdateStudentBook(@class, student, studentBookService);
                    dbContext.SaveChanges();
                }

                private void UpdateStudentBook(Class @class, Student student, StudentBookService studentBookService)
                {
                    var studentBook = studentBookService.Create();
                    studentBookService.SetStudentBook(@class, student, studentBook);
                }
        */
        private void SaveStudentBook(Student student)
        {
            //TO DO
        }
    }
}
