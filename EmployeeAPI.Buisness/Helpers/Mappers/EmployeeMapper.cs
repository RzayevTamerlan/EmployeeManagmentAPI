using AutoMapper;
using EmployeeAPI.Buisness.DTOs.Employee;
using EmployeeAPI.Core.Entities;

namespace EmployeeAPI.Buisness.Helpers.Mappers;

public class EmployeeMapper : Profile
{
    public EmployeeMapper()
    {
        // Employee
        CreateMap<GetEmployeeDto, Employee>().ReverseMap();
        CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
        CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
    }
}