namespace School.Data.Models
{
    public class TeacherRequest : Person
    {
        public TeacherRequest(
            string firstName, string middleName, string lastName, string email, string mobileNumber, string address)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Email = email;
            this.MobileNumber = mobileNumber;
            this.Address = address;
        }
    }
}
