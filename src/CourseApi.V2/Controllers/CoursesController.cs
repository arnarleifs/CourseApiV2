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
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
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
        public IActionResult UpdateCourse(int id, [FromBody]CourseDto value)
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
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}/students", Name = "GetAllStudentsByCourseId")]
        public IActionResult GetAllStudentsByCourseId(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/students", Name = "AddStudentByCourseId")]
        public IActionResult AddStudentByCourseId(int id)
        {
            return Ok();
        }
    }
}
