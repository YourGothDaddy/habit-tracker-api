namespace HabitTracker.Application.Auth.Dtos
{
    public class AuthResponse
    {
        public required string Token { get; init; }
        public required Guid UserId { get; init; }
        public required string DisplayName { get; init; }
    }
}
