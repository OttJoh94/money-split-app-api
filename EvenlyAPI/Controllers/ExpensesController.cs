using EvenlyAPI.Models;
using EvenlyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvenlyAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpensesController(IExpensesRepository repo) : ControllerBase
	{
		private readonly IExpensesRepository repo = repo;

		[HttpGet]
		public ActionResult<IEnumerable<ExpenseModel>> Get()
		{
			return Ok(repo.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<ExpenseModel> Get(int id)
		{
			return Ok(repo.GetById(id));
		}

		[HttpPost]
		public ActionResult<IEnumerable<ExpenseModel>> Post(ExpenseModel newExpense)
		{
			return Ok(repo.Add(newExpense));
		}

		[HttpPut]
		public ActionResult<ExpenseModel> Put(int id, ExpenseModel newExpense)
		{
			return Ok(repo.Update(id, newExpense));
		}

		[HttpDelete]
		public ActionResult Delete(int id)
		{
			repo.Delete(id);
			return Ok();
		}
	}
}
