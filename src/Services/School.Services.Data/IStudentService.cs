namespace School.Services.Data
{
    using School.Data.Models;

    public interface IStudentService
    {
        Student Create(string firstName, string middleName, string lastName, string email, string mobileNumber, string address);

        Student GetStudent(string id);

        int GetStudentCount();

        void AddToClass(Student student, Class @class);

        //void SetNumberInClass();

        void AddStudentBook(Student student, StudentBook studentBook);

        void AddParent(Student student, Parent parent);
    }
}
