using AutoMapper;
using EmployeeAPI.Buisness.DTOs.Department;
using EmployeeAPI.Core.Entities;

namespace EmployeeAPI.Buisness.Helpers.Mappers;

public class DepartmentMapper : Profile
{
    public DepartmentMapper()
    {
        // Department
        CreateMap<GetDepartmentDto, Department>().ReverseMap();
        CreateMap<CreateDepartmentDto, Department>().ReverseMap();
        CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
    }
}