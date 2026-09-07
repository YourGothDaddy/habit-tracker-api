namespace HabitTracker.Api.Controllers
{
    using HabitTracker.Application.Auth.Dtos;
    using HabitTracker.Application.Common.Interfaces;
    using HabitTracker.Infrastructure.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                DisplayName = request.DisplayName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email!, user.DisplayName);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                DisplayName = user.DisplayName
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email!, user.DisplayName);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                DisplayName = user.DisplayName
            });
        }
    }
}
