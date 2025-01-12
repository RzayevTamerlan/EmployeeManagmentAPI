using EmployeeAPI.DAL.Repositories.Adapters;
using EmployeeAPI.DAL.Repositories.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAPI.DAL;

public static class DALServiceRegistrations
{
    public static void AddDALServices(this IServiceCollection services)
    {
        services.AddScoped<IAssigmentRepository,AssigmentRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();
    }
}