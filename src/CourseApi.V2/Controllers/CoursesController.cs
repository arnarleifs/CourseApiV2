using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseApi.V2.Models.DTO;
using CourseApi.V2.Services.Interfaces;
using CourseApi.V2.Models.ViewModels;

namespace CourseApi.V2.Controllers
{
    [Route("api/v1/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IStudentService studentService;
        public CoursesController(ICourseService courseService, IStudentService studentService)
        {
            this.courseService = courseService;
            this.studentService = studentService;
        }
        // GET api/v1/courses
        [HttpGet]
        [Route("", Name = "GetAllCourses")]
        public IEnumerable<CourseDto> GetAllCourses(int semester = 20153)
        {
            return courseService.GetAllCoursesBySemester(semester);
        }

        // GET api/v1/courses/{id:int}
        [HttpGet]
        [Route("{id:int}", Name = "GetCourseById")]
        public IActionResult GetCourseById(int id)
        {
            var course = courseService.GetCourseById(id);

            return new ObjectResult(course);
        }

        // PUT api/v1/courses/{id:int}
        [HttpPut]
        [Route("{id:int}", Name = "UpdateCourse")]
        public IActionResult UpdateCourse(int id, [FromBody]CourseViewModel value)
        {
            courseService.UpdateCourse(id, value);
            return new NoContentResult();
        }

        // DELETE api/v1/courses/{id:int}
        [HttpDelete]
        [Route("{id:int}", Name = "DeleteCourse")]
        public IActionResult DeleteCourse(int id)
        {
            courseService.DeleteCourseById(id);
            return StatusCode(204);
        }

        [HttpGet]
        [Route("{id:int}/students", Name = "GetAllStudentsByCourseId")]
        public IActionResult GetAllStudentsByCourseId(int id)
        {
            var students = studentService.GetAllStudentsByCourseId(id);
            return new ObjectResult(students);
        }

        [HttpPost]
        [Route("{id:int}/students", Name = "AddStudentByCourseId")]
        public IActionResult AddStudentByCourseId(int id, [FromBody]StudentViewModel student)
        {
            studentService.AddStudentByCourseId(id, new StudentDto { Ssn = student.Ssn, Name = student.Name });
            return StatusCode(201);
        }
    }
}
