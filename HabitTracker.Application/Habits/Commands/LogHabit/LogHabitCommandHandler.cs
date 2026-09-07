namespace HabitTracker.Application.Habits.Commands.LogHabit
{
    using HabitTracker.Application.Common.Interfaces;
    using HabitTracker.Domain.Entities;
    using MediatR;

    public class LogHabitCommandHandler : IRequestHandler<LogHabitCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogHabitCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(LogHabitCommand request, CancellationToken cancellationToken)
        {
            var habit = await _unitOfWork.Habits.GetByIdAsync(request.HabitId, cancellationToken);

            if (habit is null || habit.UserId != request.UserId)
            {
                throw new UnauthorizedAccessException("Habit not found or not owned by this user.");
            }

            var existing = await _unitOfWork.HabitLogs.GetByHabitAndDateAsync(request.HabitId, request.Date, cancellationToken);

            if (existing is not null)
            {
                throw new InvalidOperationException("This habit is already logged for this date.");
            }

            var log = new HabitLog(request.HabitId, request.Date, request.Value, request.Note);

            await _unitOfWork.HabitLogs.AddAsync(log, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return log.Id;
        }
    }
}