namespace HabitTracker.Application.Habits.Dtos
{
    using HabitTracker.Domain.Entities;

    public class HabitLogDto
    {
        public Guid Id { get; init; }
        public Guid HabitId { get; init; }
        public DateOnly Date { get; init; }
        public double? Value { get; init; }
        public string? Note { get; init; }

        public static HabitLogDto FromEntity(HabitLog log)
        {
            return new HabitLogDto
            {
                Id = log.Id,
                HabitId = log.HabitId,
                Date = log.Date,
                Value = log.Value,
                Note = log.Note
            };
        }
    }
}