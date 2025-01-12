using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL.Context;
using EmployeeAPI.DAL.Repositories.Ports;

namespace EmployeeAPI.DAL.Repositories.Adapters;

public class AssigmentRepository : Repository<Assignment>, IAssigmentRepository
{
    public AssigmentRepository(EmployeeAPIDbContext context) : base(context)
    {
    }
}