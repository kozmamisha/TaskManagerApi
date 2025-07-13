using Microsoft.AspNetCore.Mvc;
using TaskManager.BusinessLogic.DTO;
using TaskManager.BusinessLogic.Interfaces;
using TaskManager.DataAccess.Entities;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("task")]
    public class AssignmentController(IAssignmentService assignmentService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> Create(string title, string description, Guid groupId)
        {
            await assignmentService.CreateAsync(title, description, groupId);
            return Created();
        }

        [HttpGet("tasks")]
        public async Task<ActionResult> GetAll()
        {
            var result = await assignmentService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetOne([FromRoute] Guid id)
        {
            var result = await assignmentService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAssignmentDto dto)
        {
            await assignmentService.UpdateAsync(id, dto);
            return NoContent();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await assignmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
