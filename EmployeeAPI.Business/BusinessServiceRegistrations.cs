using System.Reflection;
using EmployeeAPI.Business.Services.Adapters;
using FluentValidation.AspNetCore;

namespace EmployeeAPI.Business;

public static class BusinessServiceRegistrations
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BusinessServiceRegistrations));
        services.AddScoped<IAuthService,AuthService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService,DepartmentService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IAssigmentService, AssigmentService>();
        services.AddControllers()
            .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
    }
}