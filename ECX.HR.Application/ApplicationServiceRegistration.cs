using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using ECX.HR.Application.Contracts.Infrastructure;
using ECX.HR.Application.Models;

namespace ECX.HR.Application
{

    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }


    }
}
