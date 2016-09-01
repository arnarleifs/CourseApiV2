using CourseApi.V2.Models.DTO;

namespace CourseApi.V2.Services.Interfaces
{
    public interface ICourseService
    {
        void AddCourse(CourseDto course);
    }
}
