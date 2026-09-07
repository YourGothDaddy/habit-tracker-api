namespace HabitTracker.Application.Habits.Queries.GetLogsForHabit
{
    using HabitTracker.Application.Common.Interfaces;
    using HabitTracker.Application.Habits.Dtos;
    using MediatR;

    public class GetLogsForHabitQueryHandler : IRequestHandler<GetLogsForHabitQuery, List<HabitLogDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLogsForHabitQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<HabitLogDto>> Handle(GetLogsForHabitQuery request, CancellationToken cancellationToken)
        {
            var habit = await _unitOfWork.Habits.GetByIdAsync(request.HabitId, cancellationToken);

            if (habit is null || habit.UserId != request.UserId)
            {
                return new List<HabitLogDto>();
            }

            var logs = await _unitOfWork.HabitLogs.GetAllForHabitAsync(request.HabitId, cancellationToken);
            return logs.Select(HabitLogDto.FromEntity).ToList();
        }
    }
}