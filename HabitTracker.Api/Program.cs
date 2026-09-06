namespace HabitTracker.Api;

using HabitTracker.Application.Common.Interfaces;
using HabitTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
            typeof(HabitTracker.Application.Habits.Commands.CreateHabit.CreateHabitCommand).Assembly));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}