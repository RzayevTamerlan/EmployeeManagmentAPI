using EmployeeAPI.Buisness.DTOs.Topic;
using EmployeeAPI.Core.Entities;
using AutoMapper;

namespace EmployeeAPI.Buisness.Helpers.Mappers;

public class TopicMapper : Profile
{
    public TopicMapper()
    {
        // Topic
        CreateMap<GetTopicDto, Topic>().ReverseMap();
        CreateMap<CreateTopicDto, Topic>().ReverseMap();
        CreateMap<UpdateTopicDto, Topic>().ReverseMap();
    }
}