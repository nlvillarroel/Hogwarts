using Students.Models;
using System;
using System.Collections.Generic;

namespace Students.StudentData
{
    public interface IStudentData
    {
        List<Student> GetStudents();

        Student GetStudent(Guid Id);

        Student AddStudent(Student student);

        void DeleteStudent(Student student);

        Student EditStudent(Student student);

    }
}
