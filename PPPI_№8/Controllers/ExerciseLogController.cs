using Fitness_Tracking.Interfaces;
using Fitness_Tracking.Models;
using Fitness_Tracking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Fitness_Tracking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/exerciselog")]
    public class ExerciseLogController : ControllerBase
    {
        private readonly IExerciseLogService _exerciseLogService;

        //IUserProgressService userProgressService
        public ExerciseLogController(IExerciseLogService exerciseLogService)
        {
            _exerciseLogService = exerciseLogService;
        }

        // GET method to retrieve the exercise log data for a given user
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ExerciseLogModel>>> GetExerciseLog(int userId)
        {
            var exerciseLogs = await _exerciseLogService.GetExerciseLog(userId);
            return Ok(exerciseLogs);
        }

        // POST method to add a new exercise log data
        [HttpPost("add")]
        public async Task<IActionResult> AddExerciseLog([FromBody] ExerciseLogModel exerciseLog)
        {
            await _exerciseLogService.AddExerciseLog(exerciseLog);
            return Ok();
        }

        // PUT method to update the exercise log data for a given user
        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateExerciseLog(int userId, [FromBody] ExerciseLogModel exerciseLog)
        {
            await _exerciseLogService.UpdateExerciseLog(userId, exerciseLog);
            return Ok();
        }

        // DELETE method to delete the exercise log data for a given user
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteExerciseLog(int userId)
        {
            await _exerciseLogService.DeleteExerciseLog(userId);
            return Ok();
        }
    }
}