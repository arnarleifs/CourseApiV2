using System.IO;
using System.Reflection;
using CourseApi.V2.Repositories.Base;
using CourseApi.V2.Repositories.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CourseApi.V2.Repositories
{
    public static class Startup
    {
        public static void Initialize(IServiceCollection services)
        {
            // Connection string to Sqlite local db file
            var file = Directory.GetCurrentDirectory() + "\\courseapi_db.db";
            services.AddDbContext<CourseDbContext>(options => options.UseSqlite("Filename=" + file));

            // Should drop database, and run a SQL script which creates tables and seed data for each execution
            // this would ensure the same data each time

            services.AddScoped<IDbFactory, DbFactory>();
        }
    }
}
