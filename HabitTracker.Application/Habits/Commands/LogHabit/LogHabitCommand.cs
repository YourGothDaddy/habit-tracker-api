namespace HabitTracker.Application.Habits.Commands.LogHabit
{
    using MediatR;

    public class LogHabitCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid HabitId { get; set; }
        public required DateOnly Date { get; init; }
        public double? Value { get; init; }
        public string? Note { get; init; }
    }
}