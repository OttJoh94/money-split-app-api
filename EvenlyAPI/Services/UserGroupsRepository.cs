using EvenlyAPI.Database;
using EvenlyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvenlyAPI.Services
{
    public class UserGroupsRepository(EvenlyDbContext context) : IUserGroupsRepository
    {
        private readonly EvenlyDbContext context = context;

        public async Task<IEnumerable<UserGroupModel?>> AddAsync(UserGroupModel newUserGroup)
        {
            //Checks if there already is a UserGroup with that name
            if (await context.UserGroups.FirstOrDefaultAsync(u => u.UserId == newUserGroup.UserId && u.GroupId == newUserGroup.GroupId) == null)
            {
                await context.UserGroups.AddAsync(newUserGroup);
                await context.SaveChangesAsync();
            }

            return await GetAllAsync();
        }

        public async Task DeleteAsync(int userId, int groupId)
        {
            UserGroupModel? userGroup = await GetByIdAsync(userId, groupId);
            if (userGroup != null)
            {
                context.UserGroups.Remove(userGroup);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserGroupModel?>> GetAllAsync()
        {
            List<UserGroupModel> allUserGroups = await context.UserGroups.ToListAsync();
            List<UserGroupModel?> projectedUserGroups = new();

            foreach (var userGroup in allUserGroups)
            {
                projectedUserGroups.Add(await GetByIdAsync(userGroup.UserId, userGroup.GroupId));
            }

            return projectedUserGroups;
        }

        public async Task<UserGroupModel?> GetByIdAsync(int userId, int groupId)
        {
            //Projects the usergroup to avoid circular errors.
            return await context.UserGroups
                .Include(u => u.User)
                .Include(u => u.Group)
                .Include(u => u.Expenses)
                .Select(u => new UserGroupModel()
                {
                    UserId = u.UserId,
                    GroupId = u.GroupId,
                    Balance = u.Balance,
                    User = new UserModel()
                    {
                        UserId = u.UserId,
                        Name = u.User!.Name,
                    },
                    Group = new GroupModel()
                    {
                        GroupId = u.GroupId,
                        GroupName = u.Group!.GroupName
                    },
                    Expenses = u.Expenses.Select(e => new ExpenseModel()
                    {
                        ExpenseId = e.ExpenseId,
                        Description = e.Description,
                        Amount = e.Amount,
                        DateOfExpense = e.DateOfExpense,
                        UserId = e.UserId,
                        GroupId = e.GroupId,
                    }).ToList()
                }).FirstOrDefaultAsync(u => u.UserId == userId && u.GroupId == groupId);
        }

        public async Task<UserGroupModel?> UpdateBalanceAsync(int userId, int groupId, decimal newBalance)
        {
            UserGroupModel? currentUserGroup = await GetByIdAsync(userId, groupId);
            if (currentUserGroup != null)
            {
                currentUserGroup.Balance += newBalance;
                context.Entry(currentUserGroup).State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
            return await GetByIdAsync(userId, groupId);
        }
    }
}
