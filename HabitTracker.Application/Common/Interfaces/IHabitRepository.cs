namespace HabitTracker.Application.Common.Interfaces;
using HabitTracker.Domain.Entities;

public interface IHabitRepository
{
    Task<Habit?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Habit>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken);
    Task AddAsync(Habit habit, CancellationToken cancellationToken);
    void Remove(Habit habit);
}