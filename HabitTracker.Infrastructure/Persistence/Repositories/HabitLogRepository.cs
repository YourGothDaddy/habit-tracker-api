namespace HabitTracker.Infrastructure.Persistence.Repositories
{
    using HabitTracker.Application.Common.Interfaces;
    using HabitTracker.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class HabitLogRepository : IHabitLogRepository
    {
        private readonly AppDbContext _context;

        public HabitLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HabitLog?> GetByHabitAndDateAsync(Guid habitId, DateOnly date, CancellationToken cancellationToken)
        {
            return await _context.HabitLogs
                .FirstOrDefaultAsync(l => l.HabitId == habitId && l.Date == date, cancellationToken);
        }

        public async Task<List<HabitLog>> GetAllForHabitAsync(Guid habitId, CancellationToken cancellationToken)
        {
            return await _context.HabitLogs
                .Where(l => l.HabitId == habitId)
                .OrderBy(l => l.Date)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(HabitLog log, CancellationToken cancellationToken)
        {
            await _context.HabitLogs.AddAsync(log, cancellationToken);
        }

        public void Remove(HabitLog log)
        {
            _context.HabitLogs.Remove(log);
        }
    }
}