using AutoMapper;
using EmployeeAPI.Buisness.DTOs.Assigment;
using EmployeeAPI.Core.Entities;

namespace EmployeeAPI.Buisness.Helpers.Mappers;

public class AssigmentMapper : Profile
{
    public AssigmentMapper()
    {
        // Assigment
        CreateMap<GetAssignmentDto,Assignment>().ReverseMap();
        CreateMap<CreateAssigmentDto, Assignment>().ReverseMap();
        CreateMap<UpdateAssigmentDto, Assignment>().ReverseMap();
    }
}