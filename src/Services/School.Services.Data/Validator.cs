namespace School.Services.Data
{
    using System.Linq;

    using School.Data;
    using School.Data.Models;

    public class Validator
    {
        public static bool CheckIfExist(Class @class, ApplicationDbContext dbContext)
        {
            return dbContext.Classes
                .Any(c => c.ClassNumber == @class.ClassNumber && c.Specialty == @class.Specialty);
        }

        public static bool CheckIfExist(Subject subject, ApplicationDbContext dbContext)
        {
            return dbContext.Subjects
                .Any(s => s.Name == subject.Name && s.ClassNumber == subject.ClassNumber && s.ClassSpecialty == subject.ClassSpecialty);
        }

        public static bool CheckIfExist(Teacher teacher, ApplicationDbContext dbContext)
        {
            return dbContext.Teachers
                .Any( t => t.FirstName == teacher.FirstName && t.MiddleName == teacher.MiddleName && t.LastName == teacher.LastName
                && t.MobileNumber == teacher.MobileNumber && t.Email == teacher.Email);
        }

        public static bool CheckIfExist(Student student, ApplicationDbContext dbContext)
        {
            return dbContext.Students
                .Any(s => s.FirstName == student.FirstName && s.MiddleName == student.MiddleName && s.LastName == student.LastName
                && s.MobileNumber == student.MobileNumber && s.Email == student.Email);
        }

        public static bool CheckIfExist(Parent parent, ApplicationDbContext dbContext)
        {
            return dbContext.Parents
                .Any(p => p.FirstName == parent.FirstName && p.MiddleName == parent.MiddleName && p.LastName == parent.LastName
                && p.MobileNumber == parent.MobileNumber && p.Email == parent.Email);
        }
    }
}
