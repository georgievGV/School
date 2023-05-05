namespace School.Services.Data
{
    using System.Collections.Generic;

    using School.Data.Models;

    public interface ISubjectService
    {
        Subject CreateSubject(string name, int classNumber);

        List<Subject> GetSubjects(params string[] classId);

        void DeleteSubject(string name, int classNumber);

        void DeleteSubject(string id);

        void AddAbsences(int absencesCount, Subject subject, StudentBook studentBook);

        void ExcuseAbsences(int absencesCount, Subject subject, StudentBook studentBook);

        void AddNote(Note note);

        void AddGrade(Grade grade, StudentBook studentBook);
    }
}
