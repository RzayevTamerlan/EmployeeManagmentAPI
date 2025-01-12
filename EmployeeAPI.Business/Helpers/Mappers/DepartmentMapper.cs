using EmployeeAPI.Business.DTOs.Department;

namespace EmployeeAPI.Business.Helpers.Mappers;

public class DepartmentMapper : Profile
{
    public DepartmentMapper()
    {
        // Department
        CreateMap<GetDepartmentDto, Department>().ReverseMap();
        CreateMap<CreateDepartmentDto, Department>().ReverseMap();
        CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
    }
}