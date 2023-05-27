using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Fitness_Tracking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/goal")]
    public class GoalController : ControllerBase
    {
        public IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }
        // Retrieves the goal for a specific user
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetGoal(int userId)
        {
            var goal = await _goalService.GetGoal(userId);
            return Ok(goal);
        }

        // Adds a goal for a specific user
        [HttpPost("add")]
        public async Task<IActionResult> AddGoal(GoalModel goal)
        {
            await _goalService.AddGoal(goal);
            return Ok();
        }

        // Updates the goal for a specific user
        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateGoal(int userId, GoalModel goal)
        {
            await _goalService.UpdateGoal(userId, goal);
            return Ok();
        }

        // Deletes the goal for a specific user
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteGoal(int userId)
        {
            await _goalService.DeleteGoal(userId);
            return Ok();
        }
    }
}