using EvenlyAPI.Database;
using EvenlyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvenlyAPI.Services
{
	public class ExpensesRepository(EvenlyDbContext context) : IExpensesRepository
	{
		private readonly EvenlyDbContext context = context;

		public IEnumerable<ExpenseModel> Add(ExpenseModel entity)
		{
			context.Expenses.Add(entity);
			context.SaveChanges();

			return GetAll();
		}

		public void Delete(int id)
		{
			ExpenseModel? expense = GetById(id);
			if (expense != null)
			{
				context.Expenses.Remove(expense);
				context.SaveChanges();
			}
		}

		public IEnumerable<ExpenseModel> GetAll()
		{
			return context.Expenses.ToList();
		}

		public ExpenseModel? GetById(int id)
		{
			return context.Expenses.FirstOrDefault(e => e.ExpenseId == id);
		}

		public ExpenseModel? Update(int id, ExpenseModel updatedExpense)
		{
			ExpenseModel? currentExpense = GetById(id);
			if (currentExpense != null)
			{
				currentExpense.Description = updatedExpense.Description;
				currentExpense.Amount = updatedExpense.Amount;
				currentExpense.DateOfExpense = updatedExpense.DateOfExpense;
				currentExpense.UserId = updatedExpense.UserId;
				currentExpense.GroupId = updatedExpense.GroupId;

				context.Entry(currentExpense).State = EntityState.Modified;
				context.SaveChanges();
			}

			return GetById(id);
		}
	}
}
