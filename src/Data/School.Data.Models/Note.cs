namespace School.Data.Models
{
    using System;

    public class Note
    {
        public Note()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        public string Discription { get; set; }
    }
}
