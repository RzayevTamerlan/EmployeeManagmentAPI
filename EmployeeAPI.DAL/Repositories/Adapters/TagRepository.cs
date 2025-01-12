using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL.Context;
using EmployeeAPI.DAL.Repositories.Ports;

namespace EmployeeAPI.DAL.Repositories.Adapters;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(EmployeeAPIDbContext context) : base(context)
    {
    }
}