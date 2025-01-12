using EmployeeAPI.Business.DTOs.Tag;

namespace EmployeeAPI.Business.Helpers.Mappers;

public class TagMapper : Profile
{
    public TagMapper()
    {
        // Tag
        CreateMap<GetTagDto, Tag>().ReverseMap();
        CreateMap<CreateTagDto, Tag>().ReverseMap();
        CreateMap<UpdateTagDto, Tag>().ReverseMap();
        CreateMap<Tag, GetTagDtoWithoutAssigments>().ReverseMap();
    }
}