namespace HabitTracker.Infrastructure.Persistence.Repositories;
using HabitTracker.Application.Common.Interfaces;
using HabitTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class HabitRepository : IHabitRepository
{
    private readonly AppDbContext _context;

    public HabitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Habit?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Habits
            .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
    }

    public async Task<List<Habit>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Habits
            .Where(h => h.UserId == userId && !h.IsArchived)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Habit habit, CancellationToken cancellationToken)
    {
        await _context.Habits.AddAsync(habit, cancellationToken);
    }

    public void Remove(Habit habit)
    {
        _context.Habits.Remove(habit);
    }
}