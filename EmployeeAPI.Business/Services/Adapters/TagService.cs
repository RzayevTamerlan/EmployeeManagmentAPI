using EmployeeAPI.Business.DTOs.Tag;

namespace EmployeeAPI.Business.Services.Adapters;

public class TagService(ITagRepository tagRepository, IMapper mapper) : ITagService
{
    public async Task<GetTagDto> GetById(Guid id)
    {
        var tag = await tagRepository.GetById(id, ["Assignments"]);

        if (tag == null)
        {
            throw new BaseHttpException("Tag not found", 404);
        }

        return mapper.Map<GetTagDto>(tag);
    }

    public async Task Update(UpdateTagDto dto)
    {
        var tag = await tagRepository.GetById(dto.Id, ["Assignments"]);

        if (tag == null)
        {
            throw new BaseHttpException("Tag not found", 404);
        }
        
        var updatedTag = mapper.Map<Tag>(dto);
        
        tagRepository.Update(updatedTag);
        
        await tagRepository.SaveChangesAsync();
    }

    public List<GetTagDto> GetAll()
    {
        var tags = tagRepository.GetAll();

        return mapper.Map<List<GetTagDto>>(tags);
    }

    public async Task Delete(Guid id)
    {
        var tag = await tagRepository.GetById(id);

        if (tag == null)
        {
            throw new BaseHttpException("Tag not found", 404);
        }

        tagRepository.Delete(tag);
        
        await tagRepository.SaveChangesAsync();
    }

    public async Task<GetTagDto> Create(CreateTagDto dto)
    {
        var isTagNameUsed = await tagRepository.IsExist(x => x.Name == dto.Name);
        
        if (isTagNameUsed)
        {
            throw new BaseHttpException("This tag name is already used", 409);
        }
        
        var tag = mapper.Map<Tag>(dto);
        
        await tagRepository.Create(tag);
        
        await tagRepository.SaveChangesAsync();
        
        return mapper.Map<GetTagDto>(tag);
    }
}