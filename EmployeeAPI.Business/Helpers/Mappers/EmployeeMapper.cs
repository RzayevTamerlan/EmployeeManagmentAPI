using EmployeeAPI.Business.DTOs.Employee;

namespace EmployeeAPI.Business.Helpers.Mappers;

public class EmployeeMapper : Profile
{
    public EmployeeMapper()
    {
        // Employee
        CreateMap<Employee, GetEmployeeDto>()
            .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
        CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
        CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
    }
}