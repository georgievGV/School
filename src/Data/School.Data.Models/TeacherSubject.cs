namespace School.Data.Models
{
    public class TeacherSubject
    {
        public string TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public string SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
