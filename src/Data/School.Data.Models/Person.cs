namespace School.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Person
    {
        public Person()
        {
            this.Id = Guid.NewGuid().ToString();

        }

        public Person(string firstName, string middleName, string lastName, string email, string mobileNumber, string address)
            : this()
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Email = email;
            this.MobileNumber = mobileNumber;
            this.Address = address;
        }

        [MaxLength(255)]
        public string Id { get; init; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(20)]
        public string MiddleName { get; init; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; init; }

        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
