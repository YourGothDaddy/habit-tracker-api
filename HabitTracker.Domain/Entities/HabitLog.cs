namespace HabitTracker.Domain.Entities
{
    public class HabitLog
    {
        public Guid Id { get; private set; }
        public Guid HabitId { get; private set; }
        public DateOnly Date { get; private set; }
        public double? Value { get; private set; }
        public string? Note { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }

        private HabitLog() { }

        public HabitLog(Guid habitId, DateOnly date, double? value, string? note)
        {
            if (date > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                throw new ArgumentException("Cannot log a habit for a future date.", nameof(date));
            }

            Id = Guid.NewGuid();
            HabitId = habitId;
            Date = date;
            Value = value;
            Note = note;
            CreatedAtUtc = DateTime.UtcNow;
        }
    }
}