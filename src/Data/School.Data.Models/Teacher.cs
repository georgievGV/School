namespace School.Data.Models
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        public Teacher()
            : base()
        {
        }

        public Teacher(string firstName, string middleName, string lastName, string email, string mobileNumber, string address)
            : base(firstName, middleName, lastName, email, mobileNumber, address)
        {
            this.Subjects = new HashSet<TeacherSubject>();
            this.Classes = new HashSet<ClassTeacher>();
        }

        public virtual Class MyClass { get; set; }

        public virtual ICollection<TeacherSubject> Subjects { get; set; }

        public virtual ICollection<ClassTeacher> Classes { get; set; }
    }
}
