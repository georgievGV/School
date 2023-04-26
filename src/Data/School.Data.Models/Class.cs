namespace School.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Class
    {
        public Class()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Students = new HashSet<Student>();
            this.Subjects = new HashSet<Subject>();
            this.Teachers = new HashSet<ClassTeacher>();
            this.StudentBooks = new HashSet<StudentBook>();
        }

        [Required]
        public string Id { get; init; }

        [Required]
        [MaxLength(2)]
        public int ClassNumber { get; init; }

        [Required]
        [MaxLength(20)]
        public string Specialty { get; init; }

        [ForeignKey("Teacher")]
        public string ClassTeacherId { get; set; }

        public virtual Teacher ClassTeacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<ClassTeacher> Teachers { get; set; }

        public virtual ICollection<StudentBook> StudentBooks { get; set; }
    }
}
