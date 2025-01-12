using EmployeeAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAPI.DAL.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Настройка свойства Name
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Настройка свойства Surname
        builder.Property(e => e.Surname)
            .IsRequired()
            .HasMaxLength(100);

        // Настройка отношения с Position
        builder.HasOne(e => e.Position) // Каждый Employee связан с одной Position
            .WithMany(p => p.Employees) // У Position есть список Employees
            .HasForeignKey(e => e.PositionId) // Внешний ключ в таблице Employee
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Удаление Position не удаляет связанных Employees

        // Настройка отношения с Department
        builder.HasOne(e => e.Department) // Каждый Employee связан с одним Department
            .WithMany(d => d.Employees) // У Department есть список Employees
            .HasForeignKey(e => e.DepartmentId) // Внешний ключ в таблице Employee
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull); // Удаление Department устанавливает DepartmentId в null

        // Дополнительные настройки, если нужно
    }
}