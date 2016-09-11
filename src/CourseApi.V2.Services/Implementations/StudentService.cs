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

        public StudentService(IStudentRepository studentRepository, IStudentRegistryRepository studentRegistryRepository, ICourseRepository courseRepository, IWaitingListRepository waitingListRepository, IUnitOfWork unitOfWork)
        {
            this.studentRepository = studentRepository;
            this.studentRegistryRepository = studentRegistryRepository;
            this.courseRepository = courseRepository;
            this.waitingListRepository = waitingListRepository;
            this.unitOfWork = unitOfWork;
        }
        public void AddStudentByCourseId(int id, bool isValid, StudentDto student)
        {
            var stud = studentRepository.Get(s => s.Ssn == student.Ssn);
            var course = courseRepository.Get(c => c.Id == id);
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (course == null)
            {
                throw new NotFoundException();
            }
            if (!isValid)
            {
                throw new ModelFormatException();
            }
            if (stud == null)
            {
                throw new NotFoundException("Student was not found in the system");
            }
            var courseCount = studentRegistryRepository.GetMany(sr => sr.CourseId == course.CourseId && sr.Semester == course.Semester).Count();
            if (courseCount >= course.MaxStudents)
            {
                // The course is full
                throw new FullException();
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

        public void AddStudentToWaitingListByCourseId(int courseId, bool isValid, StudentDto student)
        {
            var course = courseRepository.Get(c => c.Id == courseId);
            if (!isValid)
            {
                throw new ModelFormatException();
            }
            if (course == null)
            {
                throw new NotFoundException();
            }
            if (studentRepository.Get(s => s.Ssn == student.Ssn) == null)
            {
                throw new NotFoundException();
            }
            if (waitingListRepository.Get(w => w.Ssn == student.Ssn && w.CourseId == courseId) != null)
            {
                // He is already in the waiting list
                throw new DuplicateException();
            }
            if (
                studentRegistryRepository.Get(
                    sr => sr.Ssn == student.Ssn && sr.CourseId == course.CourseId && sr.Semester == course.Semester) !=
                null)
            {
                // Student is already registered in the course
                throw new DuplicateException();
            }
            waitingListRepository.Add(new WaitingList {CourseId = courseId, Ssn = student.Ssn});
            unitOfWork.Commit();
        }

        public IEnumerable<StudentDto> GetAllStudentsOnWaitingListByCourseId(int id)
        {
            if (courseRepository.Get(c => c.Id == id) == null)
            {
                throw new NotFoundException();
            }
            return
                waitingListRepository.GetMany(w => w.CourseId == id)
                    .Join(studentRepository.ReturnDbSet(), w => w.Ssn, s => s.Ssn, (list, student) => student)
                    .Select(st => new StudentDto {Name = st.Name, Ssn = st.Ssn});
        }
    }
}
 