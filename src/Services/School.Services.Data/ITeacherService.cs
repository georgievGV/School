namespace School.Services.Data
{
    using School.Data.Models;

    public interface ITeacherService
    {
        Teacher Create(string firstName, string middleName, string lastName, string email, string mobileNumber, string address);

        void AddClass(Class @class, Teacher teacher);

        void AddSubject(Subject subject, Teacher teacher);

        int GetTeachersCount();
    }
}
