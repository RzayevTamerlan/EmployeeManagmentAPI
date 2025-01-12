using EmployeeAPI.Business.DTOs.Position;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController(IPositionService positionService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var position = await positionService.GetById(id);
        return Ok(position);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var positions = positionService.GetAll();
        return Ok(positions);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await positionService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePositionDto dto)
    {
        await positionService.Update(dto);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePositionDto dto)
    {
        var position = await positionService.Create(dto);

        return Ok(position);
    }
}