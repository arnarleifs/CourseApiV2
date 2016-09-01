using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.DTO;

namespace CourseApi.V2.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        void AddCourse(CourseDto course);
    }
}
