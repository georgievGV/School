namespace School.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using School.Data.Common.Models;

    public class StudentBook
    {
        public StudentBook()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Subjects = new HashSet<Subject>();
        }

        public StudentBook(Student student)
            : this()
        {
            this.Student = student;
            this.Class = student.Class;
        }

        [Required]
        public string Id { get; init; }

        public string StudentId { get; set; }

        public virtual Student Student { get; set; }

        public string ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
