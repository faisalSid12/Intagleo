using Intagleo.Repository.Courses;
using Intagleo.Repository.Students;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Extensions
{
    public static class Extension
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddTransient<StudentRepository>();
            services.AddTransient<CourseRepository>();
            /*            
                        services.AddTransient<CustomerRepository>();*/
        }
    }
}
