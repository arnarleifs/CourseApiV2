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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IStudentRegistryRepository studentRegistryRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IWaitingListRepository waitingListRepository;
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IStudentRepository studentRepository, IStudentRegistryRepository studentRegistryRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.studentRepository = studentRepository;
            this.studentRegistryRepository = studentRegistryRepository;
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }
        public void AddStudentByCourseId(int id, bool isValid, StudentDto student)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (courseRepository.Get(c => c.Id == id) == null)
            {
                throw new NotFoundException();
            }
            if (!isValid)
            {
                throw new ModelFormatException();
            }
            var stud = studentRepository.Get(s => s.Ssn == student.Ssn);
            var course = courseRepository.Get(c => c.Id == id);
            if (stud == null)
            {
                // Add student if he does not exist in the database
                studentRepository.Add(new Student {Name = student.Name, Ssn = student.Ssn});
                unitOfWork.Commit();
            }
            if (studentRegistryRepository.Get(sr => sr.CourseId == course.CourseId && sr.Ssn == student.Ssn) == null)
            {
                // Connect the user to the course, if it hasn't already
                studentRegistryRepository.Add(new StudentRegistry {CourseId = course.CourseId, Ssn = student.Ssn, Semester = course.Semester});
                unitOfWork.Commit();
            }
        }

        public IEnumerable<StudentDto> GetAllStudentsByCourseId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (courseRepository.Get(c => c.Id == id) == null)
            {
                throw new NotFoundException();
            }
            var course = courseRepository.Get(c => c.Id == id);

            var students =
                studentRegistryRepository.GetMany(sr => sr.CourseId == course.CourseId)
                    .Join(studentRepository.ReturnDbSet(), sr => sr.Ssn, s => s.Ssn, (registry, student) => student)
                    .Select(cdto => new StudentDto
                    {
                        Name = cdto.Name,
                        Ssn = cdto.Ssn
                    });

            return students;
        }

        public void AddStudentToWaitingListByCourseId(bool isValid, StudentDto student)
        {
            
        }
    }
}
