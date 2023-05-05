namespace School.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    using School.Data;
    using School.Data.Models;

    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Subject CreateSubject(string name, int classNumber)
        {
            var subject = new Subject(name, classNumber);

            if (!Validator.CheckIfExist(subject, this.dbContext))
            {
                this.dbContext.Subjects.Add(subject);
                this.dbContext.SaveChanges();
            }
            else
            {
                subject = null;
            }

            return subject;
        }

        public List<Subject> GetSubjects(params string[] classId)
        {
            var subjects = new List<Subject>();

            if (classId.Length == 0)
            {
                subjects = this.dbContext.Subjects.ToList();

                return subjects;
            }

            subjects = this.dbContext.Subjects.Where(s => s.ClassId == classId[0]).ToList();

            return subjects;
        }

        public void DeleteSubject(string id)
        {
            var subject = this.dbContext.Subjects
                .FirstOrDefault(s => s.Id == id);
            this.dbContext.Subjects.Remove(subject);
            this.dbContext.SaveChanges();
        }

        public void DeleteSubject(string name, int classNumber)
        {
            var subject = this.dbContext.Subjects
                .FirstOrDefault(s => s.Name == name && s.ClassNumber == classNumber && s.ClassSpecialty == "NotSet");
            this.dbContext.Subjects.Remove(subject);
            this.dbContext.SaveChanges();
        }

        public void AddAbsences(int absencesCount, Subject subject, StudentBook studentBook)
        {
            var currSubject = studentBook.Subjects.First(s => s.Id == subject.Id);
            currSubject.UnExcusedAbsences = absencesCount;
            this.dbContext.SaveChanges();
        }

        public void ExcuseAbsences(int absencesCount, Subject subject, StudentBook studentBook)
        {
            var currSubject = studentBook.Subjects.First(s => s.Id == subject.Id);
            currSubject.UnExcusedAbsences -= absencesCount;
            currSubject.ExcusedAbsences += absencesCount;
            this.dbContext.SaveChanges();
        }

        public void AddGrade(Grade grade, StudentBook studentBook)
        {
            var subject = studentBook.Subjects.First(s => s.Id == grade.SubjectId);
            subject.Grades.Add(grade);
            this.dbContext.SaveChanges();
        }

        public void AddNote(Note note)
        {
            var subject = this.dbContext.Subjects.FirstOrDefault(s => s.Id == note.SubjectId);
            subject.Notes.Add(note);
            this.dbContext.SaveChanges();
        }
    }
}
