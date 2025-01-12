using EmployeeAPI.Business.DTOs.Assigment;
using Microsoft.AspNetCore.Identity;

namespace EmployeeAPI.Business.Services.Adapters;

public class AssigmentService(
    IAssigmentRepository assigmentRepository, 
    ITagRepository tagRepository, 
    UserManager<Employee> userManager,
    IMapper mapper) : IAssigmentService
{
    public async Task<GetAssignmentDto> GetById(Guid id)
    {
        var assignment = await assigmentRepository.GetById(id, ["Tags", "Topic", "Employee"]); 
        
        if (assignment == null)
        {
            throw new BaseHttpException("Assignment not found", 404);
        }
        
        return mapper.Map<GetAssignmentDto>(assignment);
    }

    public async Task Update(UpdateAssigmentDto dto)
    {
        var entity = mapper.Map<Assignment>(dto);
        assigmentRepository.Update(entity);
        
        await assigmentRepository.SaveChangesAsync();
    }

    public List<GetAssignmentDto> GetAll()
    {
        var assignments = assigmentRepository.GetAll(["Employee", "Tags", "Topic"]).ToList();
        return mapper.Map<List<GetAssignmentDto>>(assignments);
    }

    public async Task Delete(Guid id)
    {
        var assigment = await this.GetById(id);
        if (assigment == null)
        {
            throw new BaseHttpException("Assigment not found", 404);
        }
        
        assigmentRepository.Delete(mapper.Map<Assignment>(assigment));
        
        await assigmentRepository.SaveChangesAsync();
    }

    public async Task<GetAssignmentDto> Create(CreateAssigmentDto dto)
    {
        var employee = await userManager.FindByIdAsync($"{dto.EmployeeId}");
        
        if(employee == null)
        {
            throw new BaseHttpException("Employee not found", 404);
        }
        
        var tags = tagRepository.FindAllTracking(x => dto.Tags.Contains(x.Id)).ToList();
        
        if(tags.Count != dto.Tags.Count)
        {
            throw new BaseHttpException("Some tags not found", 404);
        }
        
        dto.Tags = [];
        
        var assignment = mapper.Map<Assignment>(dto);
        assignment.Employee = employee;
        assignment.Tags = tags;
        
        await assigmentRepository.Create(assignment);
        
        await assigmentRepository.SaveChangesAsync();
        
        return mapper.Map<GetAssignmentDto>(assignment);
    }

    public async Task MakeAssigmentCompleted(Guid id)
    {
        var assignment = await assigmentRepository.GetById(id);
        
        if (assignment == null)
        {
            throw new BaseHttpException("Assignment not found", 404);
        }
        
        assignment.IsCompleted = true;
        
        assigmentRepository.Update(assignment);
        
        await assigmentRepository.SaveChangesAsync();
    }
}