using EmployeeAPI.Business.DTOs.Topic;

namespace EmployeeAPI.Business.Services.Ports;

public interface ITopicService
{
    Task<GetTopicDto> GetById (Guid id);
    Task Update(UpdateTopicDto dto);
    List<GetTopicDto> GetAll();
    Task Delete(Guid id);
    Task<GetTopicDto> Create(CreateTopicDto dto);
}