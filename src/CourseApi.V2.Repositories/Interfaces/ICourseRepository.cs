using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.DTO;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Repositories.Base;

namespace CourseApi.V2.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
    }
}
