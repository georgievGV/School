namespace School.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Subject
    {
        public Subject(string name, int classNumber, string classSpecialty)
            : this()
        {
            this.Name = name;
            this.ClassNumber = classNumber;
            this.ClassSpecialty = classSpecialty;
        }

        public Subject()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UnExcusedAbsences = 0;
            this.ExcusedAbsences = 0;
            this.Grades = new List<Grade>();
            this.Teachers = new HashSet<TeacherSubject>();
            this.Notes = new HashSet<Note>();
        }

        [Required]
        public string Id { get; init; }

        [Required]
        [MaxLength(20)]
        public string Name { get; init; }

        [Required]
        public int ClassNumber { get; init; }

        [Required]
        public string ClassSpecialty { get; set; }

        [Required]
        public int UnExcusedAbsences { get; set; }

        [Required]
        public int ExcusedAbsences { get; set; }

        public string ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ICollection<TeacherSubject> Teachers { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
