namespace HabitTracker.Application.Habits.Queries.GetHabitById
{
    using HabitTracker.Application.Habits.Dtos;
    using MediatR;

    public class GetHabitByIdQuery : IRequest<HabitDto?>
    {
        public required Guid Id { get; init; }
        public Guid UserId { get; set; }
    }
}