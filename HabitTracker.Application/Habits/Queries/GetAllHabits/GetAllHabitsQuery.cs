namespace HabitTracker.Application.Habits.Queries.GetAllHabits
{

    using HabitTracker.Application.Habits.Dtos;
    using MediatR;

    public class GetAllHabitsQuery : IRequest<List<HabitDto>>
    {
        public required Guid UserId { get; init; }
    }
}