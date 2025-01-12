using EmployeeAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAPI.DAL.Configurations;

public class AssigmentConfiguration
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        // Настройка свойства Name
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(200);

        // Настройка свойства Description
        builder.Property(a => a.Description)
            .HasMaxLength(500);

        // Настройка свойства Deadline
        builder.Property(a => a.Deadline)
            .IsRequired();

        // Настройка отношения с Topic
        builder.HasOne(a => a.Topic) // Каждый Assignment связан с одним Topic
            .WithMany(t => t.Assignments) // У Topic есть много Assignments
            .HasForeignKey(a => a.TopicId) // Внешний ключ в таблице Assignment
            .OnDelete(DeleteBehavior.Cascade); // Удаление Topic удаляет связанные Assignments

        // Настройка отношения с Employee
        builder.HasOne(a => a.Employee) // Каждый Assignment связан с одним Employee
            .WithMany()                 // Нет навигационного свойства для списка Assignment в Employee
            .HasForeignKey(a => a.EmployeeId) // Внешний ключ в таблице Assignment
            .OnDelete(DeleteBehavior.SetNull); // Удаление Employee оставляет поле EmployeeId равным null
    }
}