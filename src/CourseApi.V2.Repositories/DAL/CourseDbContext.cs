using CourseApi.V2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseApi.V2.Repositories.DAL
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }

        // Declaring the entity models, which are mapped to the db
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseTemplate> CourseTemplate { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentRegistry> StudentRegistry { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Mapping keys
            builder.Entity<Course>(course =>
                course.HasKey(i => i.Id));
            builder.Entity<CourseTemplate>(ct =>
                ct.HasKey(cti => cti.Name));
            builder.Entity<Student>(s =>
                s.HasKey(si => si.Ssn));
            builder.Entity<StudentRegistry>(sr =>
                sr.HasKey(srt => srt.Ssn));
            builder.Entity<StudentRegistry>(sr =>
                sr.HasKey(srt => srt.CourseId));
        }
    }
}
