using EmployeeAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAPI.DAL.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        // Настройка отношения "один-ко-многим"
        builder.HasMany(d => d.Employees) // Position имеет много Employee
            .WithOne(e => e.Position)   // Каждый Employee связан с одним Position
            .HasForeignKey(e => e.PositionId) // Внешний ключ в таблице Employee
            .OnDelete(DeleteBehavior.Cascade);  // Удаление Position приводит к удалению связанных Employee
    }
}