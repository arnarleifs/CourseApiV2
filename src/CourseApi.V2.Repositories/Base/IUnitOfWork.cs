using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.V2.Repositories.Base
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
