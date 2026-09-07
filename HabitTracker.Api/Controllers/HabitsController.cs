namespace HabitTracker.Api.Controllers
{
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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateHabitCommand command, CancellationToken cancellationToken)
        {
            var habitId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = habitId }, habitId);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HabitDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var habit = await _mediator.Send(new GetHabitByIdQuery { Id = id }, cancellationToken);
            return habit is null ? NotFound() : Ok(habit);
        }

        [HttpGet]
        public async Task<ActionResult<List<HabitDto>>> GetAll([FromQuery] Guid userId, CancellationToken cancellationToken)
        {
            var habits = await _mediator.Send(new GetAllHabitsQuery { UserId = userId }, cancellationToken);
            return Ok(habits);
        }
    }
}