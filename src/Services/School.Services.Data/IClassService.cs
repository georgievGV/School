﻿namespace School.Services.Data
{
    using System.Collections.Generic;

    using School.Data.Models;

    public interface IClassService
    {
        void CreateClass(int classNumber, string specialty);

        Class GetClassById(string id);

        IList<Class> GetClasses();

        void AddSubject(Class @class, List<Subject> subjectst);

        IList<Subject> GetSubjects(int classNumber);

        void AddTeacher(Class @class, Teacher teacher);

        void AddClassTeacher(Class @class, Teacher teacher);

        //void AddStudent(Class @class, Student student, StudentBookService studentBookService);
    }
}
