using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Repositories.Base;

namespace CourseApi.V2.Repositories.Interfaces
{
    public interface IStudentRegistryRepository : IRepository<StudentRegistry>
    {
        void MarkStudentAsDeleted(int courseId, string ssn, bool deleted);
    }
}
