using EvenlyAPI.Models;
using EvenlyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvenlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersRepository repo) : ControllerBase
    {
        private readonly IUsersRepository repo = repo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAsync()
        {
            return Ok(await repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetAsync(int id)
        {
            return Ok(await repo.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserModel>>> PostAsync(UserModel newUser)
        {
            return Ok(await repo.AddAsync(newUser));
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> PutAsync(int id, UserModel newUser)
        {
            return Ok(await repo.UpdateAsync(id, newUser));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await repo.DeleteAsync(id);
            return Ok();
        }
    }
}
