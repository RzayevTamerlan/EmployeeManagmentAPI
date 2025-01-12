using System.Reflection;
using EmployeeAPI.Buisness.Services.Adapters;
using EmployeeAPI.Buisness.Services.Ports;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.Buisness;

public static class BusinessServiceRegistrations
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BusinessServiceRegistrations));
        services.AddScoped<IAuthService,AuthService>();
        services.AddControllers()
            .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
    }
}