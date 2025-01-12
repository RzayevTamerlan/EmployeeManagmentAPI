using EmployeeAPI.Business.DTOs.Tag;

namespace EmployeeAPI.Business.Services.Ports;

public interface ITagService
{
    Task<GetTagDto> GetById (Guid id);
    Task Update(UpdateTagDto dto);
    List<GetTagDto> GetAll();
    Task Delete(Guid id);
    Task<GetTagDto> Create(CreateTagDto dto);
}