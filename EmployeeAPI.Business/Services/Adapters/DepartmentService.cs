using EmployeeAPI.Business.DTOs.Department;

namespace EmployeeAPI.Business.Services.Adapters;

public class DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : IDepartmentService
{
    public async Task<GetDepartmentDto> GetById(Guid id)
    {
        var department = await departmentRepository.GetById(id, ["Employees"]);
        
        if(department == null)
        {
            throw new BaseHttpException("Department not found", 404);
        }
        
        return mapper.Map<GetDepartmentDto>(department);
    }

    public async Task Update(UpdateDepartmentDto dto)
    {
        // Checking if department exists
        var department = await departmentRepository.GetById(dto.Id, ["Employees"]);
        
        if(department == null)
        {
            throw new BaseHttpException("Department not found", 404);
        }
        
        var updatedDepartment = mapper.Map<Department>(dto);
        
        departmentRepository.Update(updatedDepartment);
        
        await departmentRepository.SaveChangesAsync();
    }

    public List<GetDepartmentDto> GetAll()
    {
        var departments = departmentRepository.GetAll(["Employees"]).ToList();
        return mapper.Map<List<GetDepartmentDto>>(departments);
    }

    public async Task Delete(Guid id)
    {
        var department = await departmentRepository.GetById(id, []);
        
        if(department == null)
        {
            throw new BaseHttpException("Department not found", 404);
        }
        
        departmentRepository.Delete(department);
        
        await departmentRepository.SaveChangesAsync();
    }
    
    public async Task<GetDepartmentDto> Create(CreateDepartmentDto dto)
    {
        var isDepartmentNameExist = await departmentRepository.IsExist(x => x.Name == dto.Name);
        
        if(isDepartmentNameExist)
        {
            throw new BaseHttpException("Department with this name already exists", 400);
        }
        
        var department = mapper.Map<Department>(dto);
        
        await departmentRepository.Create(department);
        
        await departmentRepository.SaveChangesAsync();
        
        return mapper.Map<GetDepartmentDto>(department);
    }
}