namespace HabitTracker.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IHabitRepository Habits { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}