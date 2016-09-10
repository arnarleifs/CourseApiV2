using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.DTO;

namespace CourseApi.V2.Services.Interfaces
{
    public interface IStudentService
    {
        void AddStudentByCourseId(int id, bool isValid, StudentDto student);
        IEnumerable<StudentDto> GetAllStudentsByCourseId(int id);
        void AddStudentToWaitingListByCourseId(bool isValid, StudentDto student);
    }
}
