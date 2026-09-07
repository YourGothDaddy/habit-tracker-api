namespace HabitTracker.Application.Habits.Queries.GetLogsForHabit
{
    using HabitTracker.Application.Habits.Dtos;
    using MediatR;

    public class GetLogsForHabitQuery : IRequest<List<HabitLogDto>>
    {
        public Guid UserId { get; set; }
        public required Guid HabitId { get; init; }
    }
}