using Microsoft.AspNetCore.Mvc;
using TaskManager.BusinessLogic.Services;
using TaskManager.DataAccess.Entities;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class AssignmentController(IAssignmentService assignmentService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> Create(string title, string description)
        {
            await assignmentService.CreateAsync(title, description);
            return Created();
        }

        [HttpGet("assignments")]
        public async Task<ActionResult> GetAll()
        {
            var result = await assignmentService.GetAllAsync();
            return Ok(result);
        }
    }
}
