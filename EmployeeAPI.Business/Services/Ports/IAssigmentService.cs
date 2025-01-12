using EmployeeAPI.Business.DTOs.Assigment;

namespace EmployeeAPI.Business.Services.Ports;

public interface IAssigmentService
{
    Task<GetAssignmentDto> GetById (Guid id);
    Task Update(UpdateAssigmentDto dto);
    List<GetAssignmentDto> GetAll();
    Task Delete(Guid id);
    Task<GetAssignmentDto> Create(CreateAssigmentDto dto);
    Task MakeAssigmentCompleted(Guid id);
}