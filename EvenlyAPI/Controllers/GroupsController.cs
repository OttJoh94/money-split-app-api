using EvenlyAPI.Models;
using EvenlyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvenlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController(IGroupsRepository repo) : ControllerBase
    {
        private readonly IGroupsRepository repo = repo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupModel>>> GetAsync()
        {
            return Ok(await repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupModel>> GetAsync(int id)
        {
            return Ok(await repo.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<GroupModel>>> PostAsync(GroupModel newGroup)
        {
            return Ok(await repo.AddAsync(newGroup));
        }

        [HttpPut]
        public async Task<ActionResult<GroupModel>> PutAsync(int id, GroupModel newGroup)
        {
            return Ok(await repo.UpdateAsync(id, newGroup));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await repo.DeleteAsync(id);
            return Ok();
        }
    }
}
