namespace HabitTracker.Application.Habits.Dtos;
using HabitTracker.Domain.Entities;

public class HabitDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public HabitFrequency Frequency { get; init; }
    public string Color { get; init; } = string.Empty;
    public bool IsArchived { get; init; }
    public DateTime CreatedAtUtc { get; init; }

    public static HabitDto FromEntity(Habit habit)
    {
        return new HabitDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            Frequency = habit.Frequency,
            Color = habit.Color,
            IsArchived = habit.IsArchived,
            CreatedAtUtc = habit.CreatedAtUtc
        };
    }
}