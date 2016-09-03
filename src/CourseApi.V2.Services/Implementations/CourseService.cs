using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.DTO;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Models.ViewModels;
using CourseApi.V2.Repositories.Base;
using CourseApi.V2.Repositories.Interfaces;
using CourseApi.V2.Services.Interfaces;

namespace CourseApi.V2.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CourseDto> GetAllCoursesBySemester(int semester)
        {
            if (semester <= 0)
            {
                throw new ValidationException();
            }
            return courseRepository.GetMany(c => c.Semester == semester).Select(cd => new CourseDto {CourseId = cd.CourseId, Semester = cd.Semester, StartDate = cd.StartDate, EndDate = cd.EndDate});
        }

        public CourseDto GetCourseById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var course = courseRepository.Get(c => c.Id == id);
            if (course == null)
            {
                throw new FileNotFoundException();
            }
            return new CourseDto
            {
                CourseId = course.CourseId,
                Semester = course.Semester,
                StartDate = course.StartDate,
                EndDate = course.EndDate
            };
        }

        public void UpdateCourse(int id, CourseViewModel course)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (course.Semester <= 0 || course.CourseId == null || 
                course.StartDate == DateTime.MinValue || course.EndDate == DateTime.MinValue)
            {
                throw new ValidationException();
            }
            if (GetCourseById(id) == null)
            {
                throw new FileNotFoundException();
            }
            var cor = courseRepository.Get(c => c.Id == id);

            cor.CourseId = course.CourseId;
            cor.Semester = course.Semester;
            cor.StartDate = course.StartDate;
            cor.EndDate = course.EndDate;

            courseRepository.Update(cor);

            unitOfWork.Commit();
        }

        public void DeleteCourseById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var course = courseRepository.Get(c => c.Id == id);
            if (course == null)
            {
                throw new FileNotFoundException();
            }
            courseRepository.Delete(course);
            unitOfWork.Commit();
        }
    }
}
