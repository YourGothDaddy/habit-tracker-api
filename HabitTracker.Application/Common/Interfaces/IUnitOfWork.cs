namespace HabitTracker.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IHabitRepository Habits { get; }
    IHabitLogRepository HabitLogs { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}