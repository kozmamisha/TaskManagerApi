using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.BusinessLogic.DTO;
using TaskManager.BusinessLogic.Interfaces;
using TaskManager.DataAccess.Enums;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("group")]
    public class GroupController(IGroupService groupService) : ControllerBase
    {
        [Authorize(nameof(PermissionEnum.Create))]
        [HttpPost("create")]
        public async Task<ActionResult> Create(string name)
        {
            await groupService.CreateAsync(name);
            return Created();
        }

        [Authorize(nameof(PermissionEnum.Read))]
        [HttpGet("groups")]
        public async Task<ActionResult> GetAll()
        {
            var result = await groupService.GetAllAsync();
            return Ok(result);
        }
        
        [Authorize(nameof(PermissionEnum.Read))]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetOne([FromRoute] Guid id)
        {
            var result = await groupService.GetByIdAsync(id);
            return Ok(result);
        }

        [Authorize(nameof(PermissionEnum.Update))]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGroupDto dto)
        {
            await groupService.UpdateAsync(id, dto);
            return NoContent();
        }

        [Authorize(nameof(PermissionEnum.Delete))]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await groupService.DeleteAsync(id);
            return NoContent();
        }
    }
}
