namespace HabitTracker.Application.Habits.Commands.CreateHabit
{
    using HabitTracker.Domain.Entities;
    using MediatR;

    public class CreateHabitCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required HabitFrequency Frequency { get; init; }
        public required string Color { get; init; }
    }
}