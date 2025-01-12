using AutoMapper;
using EmployeeAPI.Buisness.DTOs.Position;
using EmployeeAPI.Core.Entities;

namespace EmployeeAPI.Buisness.Helpers.Mappers;

public class PositionMapper : Profile
{
    public PositionMapper()
    {
        // Position
        CreateMap<GetPositionDto, Position>().ReverseMap();
        CreateMap<CreatePositionDto, Position>().ReverseMap();
        CreateMap<UpdatePositionDto, Position>().ReverseMap();
    }
}