using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.DTO;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Repositories.Base;
using CourseApi.V2.Repositories.DAL;
using CourseApi.V2.Repositories.Interfaces;

namespace CourseApi.V2.Repositories.Implementations
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory) {}
    }
}
