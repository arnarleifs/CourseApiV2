using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Repositories.DAL;

namespace CourseApi.V2.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private CourseDbContext context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public CourseDbContext DbContext => context ?? (context = dbFactory.Init());

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
