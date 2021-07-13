using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Models;
using Students.StudentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentData _studentData;
        public StudentsController(IStudentData studentData)
        {
            _studentData = studentData;
        }

        [HttpGet("/getstudents")]
        public IActionResult Get()
        {
            return Ok(_studentData.GetStudents());
        }


        [HttpGet("/getstudent/{id}")]
        public IActionResult Get(Guid id)
        {
            var student = _studentData.GetStudent(id);
            
            if (student!=null)
            {
                return Ok(student);
            }

            return NotFound($"Student {id} not found");
        }


        [HttpPost("/addstudent")]
        public IActionResult Add(Student student)
        {
            _studentData.AddStudent(student);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + student.Id, student);
        }

        [HttpDelete("/removestudent/{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = _studentData.GetStudent(id);

            if (student != null)
            {
                _studentData.DeleteStudent(student);
                return Ok();
            }

            return NotFound($"Student {id} not found");
        }


        [HttpPatch("/updatestudent/{id}")]
        public IActionResult editStudent(Guid id, Student student)
        {
            var actualstudent = _studentData.GetStudent(id);

            if (actualstudent != null)
            {
                student.Id = actualstudent.Id;
                _studentData.EditStudent(student);
                return Ok();
            }

            return NotFound($"Student {id} not found");
        }


    }
}
