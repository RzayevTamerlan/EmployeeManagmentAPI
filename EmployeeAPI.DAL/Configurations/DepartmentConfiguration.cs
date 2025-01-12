using EmployeeAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAPI.DAL.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        // Настройка отношения "один-ко-многим"
        builder.HasMany(d => d.Employees) // Department имеет много Employee
            .WithOne(e => e.Department)   // Каждый Employee связан с одним Department
            .HasForeignKey(e => e.DepartmentId) // Внешний ключ в таблице Employee
            .OnDelete(DeleteBehavior.Cascade);  // Удаление Department приводит к удалению связанных Employee
    }
}