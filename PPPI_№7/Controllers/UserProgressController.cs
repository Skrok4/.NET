using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;
using Fitness_Tracking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fitness_Tracking.Controllers
{
    [ApiController]
    [Route("api/userprogress")]
    public class UserProgressController : ControllerBase
    {
        private readonly IUserProgressService _userProgressService;

        public UserProgressController(IUserProgressService userProgressService)
        {
            _userProgressService = userProgressService;
        }

        // Retrieves the user progress for a specific user
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<UserProgressModel>>> GetUserProgress(int userId)
        {
            var userProgress = await _userProgressService.GetUserProgress(userId);
            if (userProgress != null)
            {
                var filteredProgress = await _userProgressService.GetFilteredUserProgress(userId);
                return filteredProgress;
            }
            return new List<UserProgressModel>();
        }

        // Adds user progress for a specific user
        [HttpPost("add")]
        public async Task<IActionResult> AddUserProgress(UserProgressModel userProgress)
        {
            await _userProgressService.AddUserProgress(userProgress);
            return Ok();
        }

        // Updates user progress for a specific user
        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUserProgress(int userId, UserProgressModel userProgress)
        {
            await _userProgressService.UpdateUserProgress(userId, userProgress);
            return Ok();
        }

        // Deletes user progress for a specific user
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUserProgress(int userId)
        {
            await _userProgressService.DeleteUserProgress(userId);
            return Ok();
        }
    }
}
