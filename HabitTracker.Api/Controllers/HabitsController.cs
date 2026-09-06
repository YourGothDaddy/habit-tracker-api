namespace HabitTracker.Api.Controllers;
using HabitTracker.Application.Habits.Commands.CreateHabit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HabitsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateHabitCommand command, CancellationToken cancellationToken)
    {
        var habitId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(Create), new { id = habitId }, habitId);
    }
}