using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.DTO;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Repositories.DAL;
using CourseApi.V2.Repositories.Interfaces;

namespace CourseApi.V2.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private CourseDbContext context;
        public CourseRepository(CourseDbContext context)
        {
            this.context = context;
        }
        public void AddCourse(CourseDto course)
        {
            try
            {
                context.Course.Add(new Course
                {
                    CourseId = "T-514-VEFT",
                    Semester = 20153,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3)
                });
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
