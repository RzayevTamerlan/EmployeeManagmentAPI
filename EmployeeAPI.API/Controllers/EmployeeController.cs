using EmployeeAPI.Business.DTOs.Employee;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await employeeService.GetById(id, ["Position", "Department"]);
        return Ok(employee);
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var positions = employeeService.GetAll(["Position", "Department"]);
        return Ok(positions);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await employeeService.Delete(id);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeDto dto)
    {
        await employeeService.Update(dto);
        return NoContent();
    }

}