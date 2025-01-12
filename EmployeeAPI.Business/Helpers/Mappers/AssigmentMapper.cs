using EmployeeAPI.Business.DTOs.Assigment;

namespace EmployeeAPI.Business.Helpers.Mappers;

public class AssigmentMapper : Profile
{
    public AssigmentMapper()
    {
        // Assigment
        CreateMap<Assignment, GetAssignmentDto>()
            .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.Name} {src.Employee.Surname}"))
            .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.Topic.Name))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags)) // Map Tags
            .ReverseMap();
        CreateMap<CreateAssigmentDto, Assignment>().ReverseMap();
        CreateMap<UpdateAssigmentDto, Assignment>().ReverseMap();
    }
}