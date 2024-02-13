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
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetAsync()
        {
            return Ok(await repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetAsync(int id)
        {
            return Ok(await repo.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> PostAsync(ExpenseModel newExpense)
        {
            return Ok(await repo.AddAsync(newExpense));
        }

        [HttpPut]
        public async Task<ActionResult<ExpenseModel>> PutAsync(int id, ExpenseModel newExpense)
        {
            return Ok(await repo.UpdateAsync(id, newExpense));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await repo.DeleteAsync(id);
            return Ok();
        }
    }
}
