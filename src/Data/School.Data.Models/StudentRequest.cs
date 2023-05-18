namespace School.Data.Models
{
    public class StudentRequest : Person
    {
        public StudentRequest(
            string firstName, string middleName, string lastName, string email, string mobileNumber, string address, int classNumber, string specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Email = email;
            this.MobileNumber = mobileNumber;
            this.Address = address;
            this.ClassNumber = classNumber;
            this.Specialty = specialty;
        }

        public int ClassNumber { get; set; }

        public string Specialty { get; set; }
    }
}
