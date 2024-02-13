using EvenlyAPI.Database;
using EvenlyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvenlyAPI.Services
{
    public class ExpensesRepository(EvenlyDbContext context) : IExpensesRepository
    {
        private readonly EvenlyDbContext context = context;

        public async Task<IEnumerable<ExpenseModel>> AddAsync(ExpenseModel entity)
        {
            await context.Expenses.AddAsync(entity);
            await context.SaveChangesAsync();

            return await GetAllAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ExpenseModel? expense = await GetByIdAsync(id);
            if (expense != null)
            {
                context.Expenses.Remove(expense);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExpenseModel>> GetAllAsync()
        {
            return await context.Expenses.ToListAsync();
        }

        public async Task<ExpenseModel?> GetByIdAsync(int id)
        {
            return await context.Expenses.FirstOrDefaultAsync(e => e.ExpenseId == id);
        }

        public async Task<ExpenseModel?> UpdateAsync(int id, ExpenseModel updatedExpense)
        {
            ExpenseModel? currentExpense = await GetByIdAsync(id);
            if (currentExpense != null)
            {
                currentExpense.Description = updatedExpense.Description;
                currentExpense.Amount = updatedExpense.Amount;
                currentExpense.DateOfExpense = updatedExpense.DateOfExpense;
                currentExpense.UserId = updatedExpense.UserId;
                currentExpense.GroupId = updatedExpense.GroupId;

                context.Entry(currentExpense).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            return await GetByIdAsync(id);
        }
    }
}
