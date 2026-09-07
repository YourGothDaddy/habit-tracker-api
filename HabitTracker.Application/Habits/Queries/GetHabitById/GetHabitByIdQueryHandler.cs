namespace HabitTracker.Application.Habits.Queries.GetHabitById
{
    using HabitTracker.Application.Common.Interfaces;
    using HabitTracker.Application.Habits.Dtos;
    using MediatR;

    public class GetHabitByIdQueryHandler : IRequestHandler<GetHabitByIdQuery, HabitDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHabitByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HabitDto?> Handle(GetHabitByIdQuery request, CancellationToken cancellationToken)
        {
            var habit = await _unitOfWork.Habits.GetByIdAsync(request.Id, cancellationToken);

            if (habit is null || habit.UserId != request.UserId)
            {
                return null;
            }

            return HabitDto.FromEntity(habit);
        }
    }
}