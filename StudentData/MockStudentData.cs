

using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.StudentData
{
    public class MockStudentData : IStudentData
    {

        private List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id=Guid.NewGuid(),
                Name="Name1"
            },
            new Student()
            {
                Id = Guid.NewGuid(),
                Name = "Name2"
            },
            new Student()
            {
                Id = Guid.NewGuid(),
                Name = "Name3"
            },
        };
        public Student AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);
            return student;
        }

        public void DeleteStudent(Student student)
        {
            students.Remove(student);
        }

        public Student EditStudent(Student student)
        {
            var realstudent = GetStudent(student.Id);
            realstudent.Name = student.Name;
            return realstudent;

        }

        public Student GetStudent(Guid Id)
        {
            return students.SingleOrDefault(x => x.Id == Id);
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
