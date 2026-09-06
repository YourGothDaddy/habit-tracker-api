namespace HabitTracker.Application.Habits.Commands.CreateHabit;
using HabitTracker.Application.Common.Interfaces;
using HabitTracker.Domain.Entities;
using MediatR;

public class CreateHabitCommandHandler : IRequestHandler<CreateHabitCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateHabitCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateHabitCommand request, CancellationToken cancellationToken)
    {
        var habit = new Habit(request.UserId, request.Name, request.Description, request.Frequency, request.Color);

        await _unitOfWork.Habits.AddAsync(habit, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return habit.Id;
    }
}