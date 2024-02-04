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
		public ActionResult<IEnumerable<UserGroupModel>> Get()
		{
			return Ok(repo.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<UserGroupModel> Get(int userId, int groupId)
		{
			return Ok(repo.GetById(userId, groupId));
		}

		[HttpPost]
		public ActionResult<IEnumerable<UserGroupModel>> Post(UserGroupModel newUserGroup)
		{
			return Ok(repo.Add(newUserGroup));
		}

		[HttpPut]
		public ActionResult<UserGroupModel> Put(int userId, int groupId, decimal newBalance)
		{
			return Ok(repo.UpdateBalance(userId, groupId, newBalance));
		}

		[HttpDelete]
		public ActionResult Delete(int userId, int groupId)
		{
			repo.Delete(userId, groupId);
			return Ok();
		}
	}
}
