using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL.Context;
using EmployeeAPI.DAL.Repositories.Ports;

namespace EmployeeAPI.DAL.Repositories.Adapters;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(EmployeeAPIDbContext context) : base(context)
    {
    }
}