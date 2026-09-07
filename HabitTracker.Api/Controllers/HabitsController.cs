namespace HabitTracker.Api.Controllers
{
    using System.Security.Claims;
    using HabitTracker.Application.Habits.Commands.CreateHabit;
    using HabitTracker.Application.Habits.Dtos;
    using HabitTracker.Application.Habits.Queries.GetAllHabits;
    using HabitTracker.Application.Habits.Queries.GetHabitById;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HabitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HabitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private Guid GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? User.FindFirst("sub")?.Value
                ?? throw new UnauthorizedAccessException("User id claim not found.");

            return Guid.Parse(userIdClaim);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateHabitCommand command, CancellationToken cancellationToken)
        {
            command.UserId = GetCurrentUserId();

            var habitId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = habitId }, habitId);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HabitDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetHabitByIdQuery { Id = id, UserId = GetCurrentUserId() };
            var habit = await _mediator.Send(query, cancellationToken);
            return habit is null ? NotFound() : Ok(habit);
        }

        [HttpGet]
        public async Task<ActionResult<List<HabitDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllHabitsQuery { UserId = GetCurrentUserId() };
            var habits = await _mediator.Send(query, cancellationToken);
            return Ok(habits);
        }
    }
}