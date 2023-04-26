namespace School.Data.Models
{
    using System.Collections.Generic;

    public class Student : Person
    {
        public Student()
        {

        }

        public Student(string firstName, string middleName, string lastName,
            string email, string mobileNumber, string address)
            : base(firstName, middleName, lastName, email, mobileNumber, address)
        {
            this.Parents = new HashSet<StudentParent>();
        }

        public int? NumberInClass { get; set; }

        public string ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual StudentBook StudentBook { get; set; }

        public virtual ICollection<StudentParent> Parents { get; set; }

        public string StudentBookIds { get; set; }
    }
}
