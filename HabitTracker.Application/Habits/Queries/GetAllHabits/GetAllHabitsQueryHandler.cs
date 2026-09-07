namespace HabitTracker.Application.Habits.Queries.GetAllHabits
{
    using HabitTracker.Application.Common.Interfaces;
    using HabitTracker.Application.Habits.Dtos;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetAllHabitsQueryHandler : IRequestHandler<GetAllHabitsQuery, List<HabitDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllHabitsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<HabitDto>> Handle(GetAllHabitsQuery request, CancellationToken cancellationToken)
        {
            var habits = await _unitOfWork.Habits.GetAllForUserAsync(request.UserId, cancellationToken);
            return habits.Select(HabitDto.FromEntity).ToList();
        }
    }
}
