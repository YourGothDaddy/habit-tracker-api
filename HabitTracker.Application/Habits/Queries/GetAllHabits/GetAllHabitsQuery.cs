namespace HabitTracker.Application.Habits.Queries.GetAllHabits
{
    using HabitTracker.Application.Habits.Dtos;
    using MediatR;

    public class GetAllHabitsQuery : IRequest<List<HabitDto>>
    {
        public Guid UserId { get; set; }
    }
}