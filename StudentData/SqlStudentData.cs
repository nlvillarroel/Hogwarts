using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.StudentData
{
    public class SqlStudentData : IStudentData
    {
        private StudentContext _studentContext;

        public SqlStudentData(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public Student AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
            return student;
        }

        public void DeleteStudent(Student student)
        {
            _studentContext.Students.Remove(student);
            _studentContext.SaveChanges();
        }

        public Student EditStudent(Student student)
        {
            var realstudent = _studentContext.Students.Find(student.Id);
            if (realstudent != null)
            {
                realstudent.Name = student.Name;
                realstudent.LastName = student.LastName;
                realstudent.Age= student.Age;
                realstudent.LegalId= student.LegalId;
                realstudent.House = student.House;
                _studentContext.Students.Update(realstudent);
                _studentContext.SaveChanges();
            }
            return student;

        }

        public Student GetStudent(Guid Id)
        {
            var student =_studentContext.Students.Find(Id);
            return student;
        }

        public List<Student> GetStudents()
        {
           return _studentContext.Students.ToList();
        }
    }
}
