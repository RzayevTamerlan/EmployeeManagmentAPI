using EmployeeAPI.Business.DTOs.Topic;

namespace EmployeeAPI.Business.Services.Adapters;

public class TopicService(
    ITopicRepository topicRepository,
    IMapper mapper
    ) : ITopicService
{
    public async Task<GetTopicDto> GetById(Guid id)
    {
        var position = await topicRepository.GetById(id, ["Assignments"]);

        if (position == null)
        {
            throw new BaseHttpException("Topic not found", 404);
        }

        return mapper.Map<GetTopicDto>(position);
    }

    public async Task Update(UpdateTopicDto dto)
    {
        // Checking if topic exists
        var topic = await topicRepository.GetById(dto.Id, ["Assignments"]);
        
        if(topic == null)
        {
            throw new BaseHttpException("Topic not found", 404);
        }
        
        var updatedDepartment = mapper.Map<Topic>(dto);
        
        topicRepository.Update(updatedDepartment);
        
        await topicRepository.SaveChangesAsync();
    }

    public List<GetTopicDto> GetAll()
    {
        var topics = topicRepository.GetAll(["Assignments"]).ToList();
        return mapper.Map<List<GetTopicDto>>(topics);
    }

    public async Task Delete(Guid id)
    {
        var topic = await topicRepository.GetById(id, []);
        
        if(topic == null)
        {
            throw new BaseHttpException("Topic not found", 404);
        }
        
        topicRepository.Delete(topic);
        
        await topicRepository.SaveChangesAsync();
    }

    public async Task<GetTopicDto> Create(CreateTopicDto dto)
    {
        var isTopicNameExist = await topicRepository.IsExist(x => x.Name == dto.Name);
        
        if(isTopicNameExist)
        {
            throw new BaseHttpException("Topic with this name already exists", 400);
        }
        
        var topic = mapper.Map<Topic>(dto);
        
        await topicRepository.Create(topic);
        
        await topicRepository.SaveChangesAsync();
        
        return mapper.Map<GetTopicDto>(topic);
    }
}