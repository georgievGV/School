namespace School.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using School.Data.Models;

    public class ClassInputModel
    {
        [Required]
        [Range(1, 12, ErrorMessage = "class number must be between 1 and 12")]
        [Display(Name = "class number")]
        public int ClassNumber { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "specialty")]
        public string Specialty { get; set; }
    }
}
