using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Repositories.DAL;

namespace CourseApi.V2.Repositories.Base
{
    public class DbFactory : Disposable, IDbFactory
    {
        private CourseDbContext context;

        public DbFactory(CourseDbContext context)
        {
            this.context = context;
        }
        public CourseDbContext Init()
        {
            return context;
        }

        protected override void DisposeCore()
        {
            context?.Dispose();
        }
    }
}
