using EmployeeAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAPI.DAL.Configurations;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        // Настройка свойства Name
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Настройка отношения "один-ко-многим" с Assignment
        builder.HasMany(t => t.Assignments) // Topic имеет много Assignments
            .WithOne(a => a.Topic)         // Каждый Assignment связан с одним Topic
            .HasForeignKey(a => a.TopicId) // Внешний ключ в таблице Assignment
            .OnDelete(DeleteBehavior.Cascade); // Удаление Topic приводит к удалению Assignments
    }
}