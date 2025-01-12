using EmployeeAPI.Business.DTOs.Topic;
using EmployeeAPI.Business.Services.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicController(ITopicService topicService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var position = await topicService.GetById(id);
        return Ok(position);
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var positions = topicService.GetAll();
        return Ok(positions);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await topicService.Delete(id);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateTopicDto dto)
    {
        await topicService.Update(dto);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTopicDto dto)
    {
        var position = await topicService.Create(dto);

        return Ok(position);
    }
}