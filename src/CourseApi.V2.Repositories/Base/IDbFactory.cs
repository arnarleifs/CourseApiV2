using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Repositories.DAL;

namespace CourseApi.V2.Repositories.Base
{
    public interface IDbFactory : IDisposable
    {
        CourseDbContext Init();
    }
}
