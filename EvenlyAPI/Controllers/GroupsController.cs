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
		public ActionResult<IEnumerable<GroupModel>> Get()
		{
			return Ok(repo.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<GroupModel> Get(int id)
		{
			return Ok(repo.GetById(id));
		}

		[HttpPost]
		public ActionResult<IEnumerable<GroupModel>> Post(GroupModel newGroup)
		{
			return Ok(repo.Add(newGroup));
		}

		[HttpPut]
		public ActionResult<GroupModel> Put(int id, GroupModel newGroup)
		{
			return Ok(repo.Update(id, newGroup));
		}

		[HttpDelete]
		public ActionResult Delete(int id)
		{
			repo.Delete(id);
			return Ok();
		}
	}
}
