using EmployeeAPI.Business.DTOs.Position;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/positions")]
public class PositionController(IPositionService positionService) : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var position = await positionService.GetById(id);
        return Ok(position);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult GetAll()
    {
        var positions = positionService.GetAll();
        return Ok(positions);
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await positionService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> Update(UpdatePositionDto dto)
    {
        await positionService.Update(dto);
        return NoContent();
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<IActionResult> Create(CreatePositionDto dto)
    {
        var position = await positionService.Create(dto);

        return Ok(position);
    }
}