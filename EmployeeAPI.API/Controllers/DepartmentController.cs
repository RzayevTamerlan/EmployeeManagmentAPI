using EmployeeAPI.Business.DTOs.Department;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var department = await departmentService.GetById(id);
        return Ok(department);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var departments = departmentService.GetAll();
        return Ok(departments);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await departmentService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateDepartmentDto dto)
    {
        await departmentService.Update(dto);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDepartmentDto dto)
    {
        var department = await departmentService.Create(dto);

        return Ok(department);
    }
}