using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL.Context;
using EmployeeAPI.DAL.Repositories.Ports;

namespace EmployeeAPI.DAL.Repositories.Adapters;

public class TopicRepository : Repository<Topic>, ITopicRepository
{
    public TopicRepository(EmployeeAPIDbContext context) : base(context)
    {
    }
}