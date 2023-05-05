namespace School.Services.Data
{
    using School.Data;
    using School.Data.Models;
    using System.Linq;

    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext dbContext;

        public TeacherService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Teacher Create(string firstName, string middleName, string lastName, string email, string mobileNumber, string address)
        {
            var teacher = new Teacher(firstName, middleName, lastName, email, mobileNumber, address);

            if (!Validator.CheckIfExist(teacher, this.dbContext))
            {
                this.dbContext.Teachers.Add(teacher);
                this.dbContext.SaveChanges();
            }

            return teacher;
        }

        public void AddClass(Class @class, Teacher teacher)
        {
            var currClass = new ClassTeacher
            {
                Class = @class,
                Teacher = teacher,
            };

            teacher.Classes.Add(currClass);
            this.dbContext.SaveChanges();
        }

        public void AddSubject(Subject subject, Teacher teacher)
        {
            var currSubject = new TeacherSubject
            {
                Subject = subject,
                Teacher = teacher,
            };

            teacher.Subjects.Add(currSubject);
            this.dbContext.SaveChanges();
        }

        public int GetTeachersCount()
        {
            var teachersCount = this.dbContext.Teachers.Count();

            return teachersCount;
        }
    }
}
