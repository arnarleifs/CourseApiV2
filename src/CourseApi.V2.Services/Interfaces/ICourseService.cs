﻿using System.Collections.Generic;
using CourseApi.V2.Models.DTO;
using CourseApi.V2.Models.ViewModels;

namespace CourseApi.V2.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAllCoursesBySemester(int semester);
        CourseExtendedDto GetCourseById(int id);
        void UpdateCourse(int id, CourseDto course);
        void DeleteCourseById(int id);
    }
}
