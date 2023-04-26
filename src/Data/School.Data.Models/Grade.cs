namespace School.Data.Models
{
    using System;

    public class Grade
    {
        public Grade()
        {
        }

        public Grade(int value)
        {
            this.SetGradeValue(value);
        }

        public int Id { get; set; }

        public virtual GradeType Value { get; private set; }

        public string SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        private void SetGradeValue(int gradeValue)
        {
            this.Value = gradeValue switch
            {
                2 => GradeType.Poor,
                3 => GradeType.Average,
                4 => GradeType.Good,
                5 => GradeType.Verygood,
                6 => GradeType.Excellent,
                _ => throw new ArgumentException("The Grade must be between 2 and 6"),
            };

        }
    }
}
