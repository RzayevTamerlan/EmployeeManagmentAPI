using EmployeeAPI.Business.DTOs.Position;

namespace EmployeeAPI.Business.Helpers.Mappers;

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