namespace School.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PersonInputModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Your first name should have at least 3 simbols!")]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Your middle name should have at least 3 simbols!")]
        [MaxLength(20)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Your last name should have at least 3 simbols!")]
        [MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Your mobile number should be 10 simbols!")]
        [MaxLength(10)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Your address should have at least 10 simbols!")]
        [MaxLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
