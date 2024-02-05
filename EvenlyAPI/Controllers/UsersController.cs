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
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult<IEnumerable<UserModel>> Post(UserModel newUser)
        {
            return Ok(repo.Add(newUser));
        }

        [HttpPut]
        public ActionResult<UserModel> Put(int id, UserModel newUser)
        {
            return Ok(repo.Update(id, newUser));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
