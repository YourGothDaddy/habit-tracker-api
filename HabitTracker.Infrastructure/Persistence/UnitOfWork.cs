namespace HabitTracker.Infrastructure.Persistence;
using HabitTracker.Application.Common.Interfaces;
using HabitTracker.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Habits = new HabitRepository(context);
    }

    public IHabitRepository Habits { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}