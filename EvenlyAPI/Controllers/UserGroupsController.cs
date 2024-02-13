using EvenlyAPI.Models;
using EvenlyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvenlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupsController(IUserGroupsRepository repo) : ControllerBase
    {
        private readonly IUserGroupsRepository repo = repo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroupModel>>> GetAsync()
        {
            return Ok(await repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroupModel>> GetAsync(int userId, int groupId)
        {
            return Ok(await repo.GetByIdAsync(userId, groupId));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserGroupModel>>> PostAsync(UserGroupModel newUserGroup)
        {
            return Ok(await repo.AddAsync(newUserGroup));
        }

        [HttpPut]
        public async Task<ActionResult<UserGroupModel>> PutAsync(int userId, int groupId, decimal newBalance)
        {
            return Ok(await repo.UpdateBalanceAsync(userId, groupId, newBalance));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int userId, int groupId)
        {
            await repo.DeleteAsync(userId, groupId);
            return Ok();
        }
    }
}
