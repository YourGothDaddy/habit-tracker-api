namespace HabitTracker.Domain.Entities;

public class Habit
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public HabitFrequency Frequency { get; private set; }
    public string Color { get; private set; }
    public bool IsArchived { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    private Habit() { }

    public Habit(Guid userId, string name, string? description, HabitFrequency frequency, string color)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Habit name cannot be empty.", nameof(name));
        }

        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Description = description;
        Frequency = frequency;
        Color = color;
        IsArchived = false;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public void Archive() => IsArchived = true;

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Habit name cannot be empty.", nameof(newName));
        }

        Name = newName;
    }
}