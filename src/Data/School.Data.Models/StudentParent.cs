namespace School.Data.Models
{
    public class StudentParent
    {
        public string StudentId { get; set; }

        public virtual Student Student { get; set; }

        public string ParentId { get; set; }

        public virtual Parent Parent { get; set; }
    }
}
