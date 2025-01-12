using EmployeeAPI.Business.DTOs.Position;
using EmployeeAPI.Business.Exceptions;
using EmployeeAPI.Business.Services.Ports;

namespace EmployeeAPI.Business.Services.Adapters;

public class PositionService(
    IPositionRepository positionRepository,
    IMapper mapper) : IPositionService
{
    public async Task<GetPositionDto> GetById(Guid id)
    {
        var position = await positionRepository.GetById(id, ["Employees"]);

        if (position == null)
        {
            throw new BaseHttpException("Position not found", 404);
        }

        return mapper.Map<GetPositionDto>(position);
    }

    public async Task Update(UpdatePositionDto dto)
    {
        // Checking if position exists
        var position = await positionRepository.GetById(dto.Id, ["Employees"]);

        if (position == null)
        {
            throw new BaseHttpException("Position not found", 404);
        }

        var updatedPosition = mapper.Map<Position>(dto);

        positionRepository.Update(updatedPosition);

        await positionRepository.SaveChangesAsync();
    }

    public List<GetPositionDto> GetAll()
    {
        var positions = positionRepository.GetAll(["Employees"]).ToList();
        return mapper.Map<List<GetPositionDto>>(positions);
    }

    public async Task Delete(Guid id)
    {
        var position = await positionRepository.GetById(id, []);

        if (position == null)
        {
            throw new BaseHttpException("Position not found", 404);
        }

        positionRepository.Delete(position);

        await positionRepository.SaveChangesAsync();
    }

    public async Task<GetPositionDto> Create(CreatePositionDto dto)
    {
        var isPositionNameExist = await positionRepository.IsExist(x => x.Name == dto.Name);

        if (isPositionNameExist)
        {
            throw new BaseHttpException("Position with this name already exists", 400);
        }

        var position = mapper.Map<Position>(dto);

        await positionRepository.Create(position);

        await positionRepository.SaveChangesAsync();

        return mapper.Map<GetPositionDto>(position);
    }
}