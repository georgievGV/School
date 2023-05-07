namespace School.Services.Data
{
    using System;
    using System.Linq;

    using School.Data;
    using School.Data.Models;

    public class StudentService : IStudentService
    {
        public StudentService(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; set; }

        public Student Create(string firstName, string middleName, string lastName, string email, string mobileNumber, string address)
        {
            var student = new Student(firstName, middleName, lastName, email, mobileNumber, address);

            if (!Validator.CheckIfExist(student, this.DbContext))
            {
                this.DbContext.Students.Add(student);
                this.DbContext.SaveChanges();
            }
            else
            {
                student = null;
            }

            return student;
        }

        public StudentRequest CreateStudentRequest(
            string firstName, string middleName, string lastName, string email, string mobileNumber, string address, int classNumber, string Specialty)
        {
            var request = new StudentRequest(firstName, middleName, lastName, email, mobileNumber, address, classNumber, Specialty);
            this.DbContext.StudentRequests.Add(request);
            this.DbContext.SaveChanges();

            return request;
        }

        public StudentRequest GetStudentRequestById(string id)
        {
            var request = this.DbContext.StudentRequests.FirstOrDefault(x => x.Id == id);

            return request;
        }

        public Student GetStudentById(string id)
        {
            var student = this.DbContext.Students.FirstOrDefault(x => x.Id == id);
            return student;
        }

        public int GetStudentCount()
        {
            return this.DbContext.Students.Count();
        }

        public void AddToClass(Student student, Class @class)
        {
            student.Class = @class;
            this.DbContext.SaveChanges();
        }

        /* public void SetNumberInClass()
         {
             var orderedStudentList = this.@class.Students.OrderBy(x => x.FirstName).ThenBy(x => x.MiddleName).ThenBy(x => x.LastName).ToList();
             var number = 0;

             foreach (var student in orderedStudentList)
             {
                 number++;
                 student.NumberInClass = number;
             }

             this.DbContext.SaveChanges();
         }*/

        public void AddStudentBook(Student student, StudentBook studentBook)
        {
            student.StudentBook = studentBook;
            this.DbContext.SaveChanges();
        }

        public void AddParent(Student student, Parent parent)
        {
            var studentParent = new StudentParent
            {
                Student = student,
                Parent = parent,
            };

            student.Parents.Add(studentParent);
            this.DbContext.SaveChanges();
        }
    }
}
