using System;
using System.Collections.Generic;
using System.Linq;
using CourseApi.V2.Models.DTO;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Models.Exceptions;
using CourseApi.V2.Repositories.Base;
using CourseApi.V2.Repositories.Interfaces;
using CourseApi.V2.Services.Interfaces;

namespace CourseApi.V2.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly ICourseTemplateRepository courseTemplateRepository;
        private readonly IStudentService studentService;
        private readonly IStudentRegistryRepository studentRegistryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IStudentService studentService, ICourseTemplateRepository courseTemplateRepository, IStudentRegistryRepository studentRegistryRepository)
        {
            this.courseRepository = courseRepository;
            this.courseTemplateRepository = courseTemplateRepository;
            this.studentRegistryRepository = studentRegistryRepository;
            this.studentService = studentService;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CourseDto> GetAllCoursesBySemester(int semester)
        {
            if (semester <= 0)
            {
                throw new ModelFormatException();
            }
            return
                courseRepository.GetMany(c => c.Semester == semester)
                    .Select(
                        cd =>
                            new CourseDto
                            {
                                Id = cd.Id,
                                CourseId = cd.CourseId,
                                Semester = cd.Semester,
                                StartDate = cd.StartDate,
                                EndDate = cd.EndDate,
                                NumberOfStudents = studentService.GetAllStudentsByCourseId(cd.Id).ToList().Count,
                                MaxStudents = cd.MaxStudents
                            });
        }

        public CourseExtendedDto GetCourseById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var course = courseRepository.Get(c => c.Id == id);
            if (course == null)
            {
                throw new NotFoundException();
            }
            var students = studentService.GetAllStudentsByCourseId(course.Id).ToList();
            string name = "";
            if (courseTemplateRepository.Get(ct => ct.CourseId == course.CourseId) != null)
            {
                name = courseTemplateRepository.Get(ct => ct.CourseId == course.CourseId).Name;
            }
            return new CourseExtendedDto
            {
                Id = course.Id,
                CourseId = course.CourseId,
                Semester = course.Semester,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Students = students,
                NumberOfStudents = students.Count,
                Name = name,
                MaxStudents = course.MaxStudents
            };
        }

        public void UpdateCourse(int id, bool isValid, CourseDto course)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!isValid)
            {
                throw new ModelFormatException();
            }
            if (GetCourseById(id) == null)
            {
                throw new NotFoundException();
            }
            var cor = courseRepository.Get(c => c.Id == id);

            cor.CourseId = course.CourseId;
            cor.Semester = course.Semester;
            cor.StartDate = course.StartDate;
            cor.EndDate = course.EndDate;
            cor.MaxStudents = course.MaxStudents;

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
                throw new NotFoundException();
            }
            courseRepository.Delete(course);
            unitOfWork.Commit();
        }

        public CourseDto AddCourse(bool isValid, CourseDto course)
        {
            if (!isValid)
            {
                throw new ModelFormatException();
            }
            if (courseRepository.Get(c => c.CourseId == course.CourseId && c.Semester == course.Semester) != null)
            {
                throw new DuplicateException();
            }
            courseRepository.Add(new Course {CourseId = course.CourseId, Semester = course.Semester, StartDate = course.StartDate, EndDate = course.EndDate, MaxStudents = course.MaxStudents});
            unitOfWork.Commit();

            return new CourseDto
            {
                Id = course.Id,
                CourseId = course.CourseId,
                Semester = course.Semester,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                MaxStudents = course.MaxStudents,
                NumberOfStudents = studentService.GetAllStudentsByCourseId(GetLatestId()).Count()
            };
        }

        public int GetLatestId()
        {
            return courseRepository.GetAll().OrderByDescending(c => c.Id).FirstOrDefault().Id;
        }
    }
}
