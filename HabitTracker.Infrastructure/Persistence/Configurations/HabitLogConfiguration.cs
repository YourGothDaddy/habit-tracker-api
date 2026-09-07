namespace HabitTracker.Infrastructure.Persistence.Configurations
{
    using HabitTracker.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HabitLogConfiguration : IEntityTypeConfiguration<HabitLog>
    {
        public void Configure(EntityTypeBuilder<HabitLog> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Date)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(l => l.Note)
                .HasMaxLength(500);

            builder.HasIndex(l => new { l.HabitId, l.Date })
                .IsUnique();
        }
    }
}