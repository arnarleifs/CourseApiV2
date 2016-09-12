using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Repositories.Base;
using CourseApi.V2.Repositories.Interfaces;

namespace CourseApi.V2.Repositories.Implementations
{
    public class StudentRegistryRepository : RepositoryBase<StudentRegistry>, IStudentRegistryRepository
    {
        public StudentRegistryRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public void MarkStudentAsDeleted(int courseId, string ssn)
        {
            var studentRegistry = Get(s => s.CourseId == courseId && s.Ssn == ssn);
            studentRegistry.IsDeleted = true;
            Update(studentRegistry);
        }
    }
}
