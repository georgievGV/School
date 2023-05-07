namespace School.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using School.Data.Models;
    using School.Web.ViewModels.User;

    public class PersonInputModel
    {
        public PersonInputModel()
        {
            this.SpecialtiesSelectList = new List<SelectListItem>();
            this.ClassesSelectList = new List<SelectListItem>();
        }

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

        public List<Class> Classes { get; set; }

        public string SelectedClass { get; set; }

        public string SelectedSpecialty { get; set; }

        [Required]
        public List<SelectListItem> ClassesSelectList { get; set; }

        [Required]
        public List<SelectListItem> SpecialtiesSelectList { get; set; }

        public string ClassId { get; set; }
    }
}
