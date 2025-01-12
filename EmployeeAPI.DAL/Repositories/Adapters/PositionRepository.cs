using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL.Context;
using EmployeeAPI.DAL.Repositories.Ports;

namespace EmployeeAPI.DAL.Repositories.Adapters;

public class PositionRepository : Repository<Position>, IPositionRepository
{
    public PositionRepository(EmployeeAPIDbContext context) : base(context)
    {
    }
}