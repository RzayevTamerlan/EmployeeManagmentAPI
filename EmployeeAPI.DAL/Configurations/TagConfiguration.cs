using EmployeeAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAPI.DAL.Configurations;

public class TagConfiguration
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        // Настройка свойства Name
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Настройка отношения "многие-ко-многим" с Assignment
        builder.HasMany(t => t.Assignments) // У Tag может быть много Assignments
            .WithMany(a => a.Tags)          // У Assignment может быть много Tags
            .UsingEntity<Dictionary<string, object>>( // Промежуточная таблица
                "AssignmentTag", // Имя промежуточной таблицы
                j => j.HasOne<Assignment>() // Настройка связи с Assignment
                    .WithMany()
                    .HasForeignKey("AssignmentId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Tag>()        // Настройка связи с Tag
                    .WithMany()
                    .HasForeignKey("TagId")
                    .OnDelete(DeleteBehavior.Cascade));

        // Дополнительные настройки, если они понадобятся
    }
}