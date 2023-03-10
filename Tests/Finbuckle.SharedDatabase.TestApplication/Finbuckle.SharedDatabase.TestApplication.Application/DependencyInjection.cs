using System.Reflection;
using AutoMapper;
using Finbuckle.SharedDatabase.TestApplication.Application.Common.Validation;
using Finbuckle.SharedDatabase.TestApplication.Application.Implementation;
using Finbuckle.SharedDatabase.TestApplication.Application.Interfaces;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace Finbuckle.SharedDatabase.TestApplication.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IValidationService, ValidationService>();
            return services;
        }
    }
}