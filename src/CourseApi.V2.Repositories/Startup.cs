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
            // Here is a connection string to local db (MSSQL)
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=CourseApi;Trusted_Connection=True;";
            //services.AddDbContext<CourseDbContext>(options => options.UseSqlServer(connection));

            // Connection string to Sqlite local db file
            var file = Directory.GetCurrentDirectory() + "\\courseapi_db.db";
            services.AddDbContext<CourseDbContext>(options => options.UseSqlite("Filename=" + file));

            services.AddScoped<IDbFactory, DbFactory>();
        }
    }
}
