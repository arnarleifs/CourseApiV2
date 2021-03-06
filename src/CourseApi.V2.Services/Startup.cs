﻿using CourseApi.V2.Repositories.Base;
using CourseApi.V2.Repositories.Implementations;
using CourseApi.V2.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CourseApi.V2.Services
{
    public static class Startup
    {
        public static void Initialize(IServiceCollection services)
        {
            Repositories.Startup.Initialize(services);
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentRegistryRepository, StudentRegistryRepository>();
            services.AddTransient<ICourseTemplateRepository, CourseTemplateRepository>();
            services.AddTransient<IWaitingListRepository, WaitingListRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
