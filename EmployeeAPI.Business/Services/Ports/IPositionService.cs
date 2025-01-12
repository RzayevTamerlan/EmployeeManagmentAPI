using EmployeeAPI.Business.DTOs.Position;

namespace EmployeeAPI.Business.Services.Ports;

public interface IPositionService
{
    Task<GetPositionDto> GetById (Guid id);
    Task Update(UpdatePositionDto dto);
    List<GetPositionDto> GetAll();
    Task Delete(Guid id);
    Task<GetPositionDto> Create(CreatePositionDto dto);
}