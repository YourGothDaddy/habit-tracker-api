namespace HabitTracker.Infrastructure.Persistence.Configurations;
using HabitTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HabitConfiguration : IEntityTypeConfiguration<Habit>
{
    public void Configure(EntityTypeBuilder<Habit> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(h => h.Color)
            .IsRequired()
            .HasMaxLength(7);

        builder.Property(h => h.Frequency)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasIndex(h => h.UserId);
    }
}