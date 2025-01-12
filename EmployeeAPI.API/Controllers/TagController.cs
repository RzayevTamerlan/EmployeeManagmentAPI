using EmployeeAPI.Business.DTOs.Tag;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController(ITagService tagService) : ControllerBase
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagById(Guid id)
    {
        var tag = await tagService.GetById(id);
        return Ok(tag);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tags = tagService.GetAll();
        return Ok(tags);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await tagService.Delete(id);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTagDto dto)
    {
        await tagService.Update(dto);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTagDto dto)
    {
        var tag = await tagService.Create(dto);
        return CreatedAtAction(nameof(GetTagById), new { id = tag.Id }, tag);
    }
}