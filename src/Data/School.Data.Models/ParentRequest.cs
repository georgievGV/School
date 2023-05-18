namespace School.Data.Models
{
    public class ParentRequest : Person
    {
        public string StudentFirstName { get; set; }

        public string StudentMiddleName { get; set; }

        public string StudentLastName { get; set; }

        public int StudentClassNumber { get; set; }

        public string StudentClassSpecialty { get; set; }
    }
}
