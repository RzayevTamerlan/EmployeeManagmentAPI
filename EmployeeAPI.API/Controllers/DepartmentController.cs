using EmployeeAPI.Business.DTOs.Department;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/departments")]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var department = await departmentService.GetById(id);
        return Ok(department);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult GetAll()
    {
        var departments = departmentService.GetAll();
        return Ok(departments);
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await departmentService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> Update(UpdateDepartmentDto dto)
    {
        await departmentService.Update(dto);
        return NoContent();
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> Create(CreateDepartmentDto dto)
    {
        var department = await departmentService.Create(dto);

        return Ok(department);
    }
}