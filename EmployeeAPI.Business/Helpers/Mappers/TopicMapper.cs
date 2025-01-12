using EmployeeAPI.Business.DTOs.Topic;

namespace EmployeeAPI.Business.Helpers.Mappers;

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