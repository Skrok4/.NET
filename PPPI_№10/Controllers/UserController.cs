using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitness_Tracking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public UserController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> Profile(int userId)
        {
            // Get the authenticated user's profile
            var userProfile = await _userAuthenticationService.GetUserProfile(userId);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            var registered = await _userAuthenticationService.Register(user);
            if (registered)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Registration failed. Please check your input and try again.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = new UserModel { Email = email, Password = password };
            var token = await _userAuthenticationService.Login(user);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            else
            {
                return BadRequest("Login failed. Please check your credentials and try again.");
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userAuthenticationService.GetAllUsers();
            return Ok(users);
        }
    }
}
