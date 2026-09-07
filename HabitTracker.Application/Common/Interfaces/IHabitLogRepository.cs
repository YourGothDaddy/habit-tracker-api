namespace HabitTracker.Application.Common.Interfaces
{
    using HabitTracker.Domain.Entities;

    public interface IHabitLogRepository
    {
        Task<HabitLog?> GetByHabitAndDateAsync(Guid habitId, DateOnly date, CancellationToken cancellationToken);
        Task<List<HabitLog>> GetAllForHabitAsync(Guid habitId, CancellationToken cancellationToken);
        Task AddAsync(HabitLog log, CancellationToken cancellationToken);
        void Remove(HabitLog log);
    }
}