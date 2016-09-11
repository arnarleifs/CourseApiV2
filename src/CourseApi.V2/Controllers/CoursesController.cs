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
    /// <summary>
    /// This is an API service used for retrieving, adding and deleting courses
    /// in the Reykjavik University. It can also fetch students per courses
    /// </summary>
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
        /// <summary>
        /// This method gets all courses, filtered by a semester.
        /// If there is no semester provided, it will use the on-going or latest
        /// semester. You can use a query string at the end of the request to filter
        /// by semester (?semester=20101)
        /// </summary>
        /// <param name="semester">Optional semester parameter</param>
        /// <returns>A list of courses</returns>
        // GET api/v1/courses
        [HttpGet]
        [Route("", Name = "GetAllCourses")]
        public IEnumerable<CourseDto> GetAllCourses(int semester = 20163)
        {
            return courseService.GetAllCoursesBySemester(semester);
        }

        /// <summary>
        /// Gets a single course by the id of the course
        /// </summary>
        /// <param name="id">The id of the course</param>
        /// <returns>A single course</returns>
        // GET api/v1/courses/{id:int}
        [HttpGet]
        [Route("{id:int}", Name = "GetCourseById")]
        public IActionResult GetCourseById(int id)
        {
            var course = courseService.GetCourseById(id);

            return new ObjectResult(course);
        }

        /// <summary>
        /// Changes an existing course, must provide all the properties of the model
        /// in order for the model to be properly formatted.
        /// </summary>
        /// <param name="id">The id of the course changing</param>
        /// <param name="value">The actual values that will be substituted in the updated course</param>
        /// <returns>A corresponding status code for the request</returns>
        // PUT api/v1/courses/{id:int}
        [HttpPut]
        [Route("{id:int}", Name = "UpdateCourse")]
        public IActionResult UpdateCourse(int id, [FromBody]CourseViewModel value)
        {
            courseService.UpdateCourse(id, ModelState.IsValid, new CourseDto {CourseId = value.CourseId, Semester = value.Semester, StartDate = value.StartDate, EndDate = value.EndDate, MaxStudents = value.MaxStudents});
            return new NoContentResult();
        }

        /// <summary>
        /// Deletes an existing course
        /// </summary>
        /// <param name="id">The id of the course</param>
        /// <returns>Status code if the request was successful or not</returns>
        // DELETE api/v1/courses/{id:int}
        [HttpDelete]
        [Route("{id:int}", Name = "DeleteCourse")]
        public IActionResult DeleteCourse(int id)
        {
            courseService.DeleteCourseById(id);
            return StatusCode(204);
        }

        /// <summary>
        /// Gets all students which are registered in a specific course,
        /// there is a need to provide a valid course id.
        /// </summary>
        /// <param name="id">Id of the course</param>
        /// <returns>A list of students registered in the course with the given course id. Could be an empty list though.</returns>
        [HttpGet]
        [Route("{id:int}/students", Name = "GetAllStudentsByCourseId")]
        public IActionResult GetAllStudentsByCourseId(int id)
        {
            var students = studentService.GetAllStudentsByCourseId(id);
            return new ObjectResult(students);
        }

        /// <summary>
        /// Adds a single student to a course, the course is matched with the course id
        /// </summary>
        /// <param name="id">The id of the course</param>
        /// <param name="student">The student object. All properties must be provided, otherwise he will not be added to the course.</param>
        /// <returns>A HTTP Status code, which indicates whether the request was successful or not.</returns>
        [HttpPost]
        [Route("{id:int}/students", Name = "AddStudentByCourseId")]
        public IActionResult AddStudentByCourseId(int id, [FromBody]StudentViewModel student)
        {
            studentService.AddStudentByCourseId(id, ModelState.IsValid, new StudentDto { Ssn = student.Ssn, Name = student.Name });
            return StatusCode(201);
        }

        /// <summary>
        /// Adds a student on a waiting list which is available for each course, if the course is full the student can decide
        /// to be added to a waiting list
        /// </summary>
        /// <param name="id">Id of the course</param>
        /// <param name="student">Information about the student which is about to be added to the waiting list for this course</param>
        /// <returns>The resource created or an error code indicating something went wrong.</returns>
        [HttpPost]
        [Route("{id:int}/waitinglist", Name = "AddStudentToWaitingListByCourseId")]
        public IActionResult AddStudentToWaitingListByCourseId(int id, [FromBody]StudentViewModel student)
        {
            studentService.AddStudentToWaitingListByCourseId(id, ModelState.IsValid,
                new StudentDto {Name = student.Name, Ssn = student.Ssn});
            return StatusCode(201);
        }

        [HttpGet]
        [Route("{id:int}/waitinglist", Name = "GetAllStudentsOnWaitingListByCourseId")]
        public IActionResult GetAllStudentsOnWaitingListByCourseId(int id)
        {
            var students = studentService.GetAllStudentsOnWaitingListByCourseId(id);
            return new ObjectResult(students);
        } 
    }
}
