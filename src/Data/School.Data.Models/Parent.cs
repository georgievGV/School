namespace School.Data.Models
{
    using System.Collections.Generic;

    public class Parent : Person
    {

        public Parent()
        {
            
        }

        public Parent(string firstName, string middleName, string lastName,
            string email, string mobileNumber, string address)
            : base(firstName, middleName, lastName, email, mobileNumber, address)
        {
            this.Students = new HashSet<StudentParent>();
        }

        public virtual ICollection<StudentParent> Students { get; set; }
    }
}
