using EmployeeAPI.Business.DTOs.Assigment;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssigmentController(IAssigmentService assigmentService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var assignment = await assigmentService.GetById(id);
        return Ok(assignment);
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var assignment = assigmentService.GetAll();
        return Ok(assignment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await assigmentService.Delete(id);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateAssigmentDto dto)
    {
        await assigmentService.Update(dto);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAssigmentDto dto)
    {
        var department = await assigmentService.Create(dto);

        return Ok(department);
    }
    
    [HttpPost("complete/{id}")]
    public async Task<IActionResult> CompleteAssigment(Guid id)
    {
        await assigmentService.MakeAssigmentCompleted(id);
        return NoContent();
    }
}