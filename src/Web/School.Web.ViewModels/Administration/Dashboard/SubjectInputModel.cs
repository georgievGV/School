namespace School.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using School.Data.Models;

    public class SubjectInputModel
    {
        public SubjectInputModel()
        {
            this.Subjects = new List<Subject>();
        }
        [Required]
        public string Name { get; set; }

        [Required]
        public int ClassNumber { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }
    }
}
