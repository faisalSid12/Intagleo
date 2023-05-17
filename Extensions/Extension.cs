
using Intagleo.Repository.Users;
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
            services.AddTransient<UserRepository>();
        }
    }
}
