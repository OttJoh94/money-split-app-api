using EvenlyAPI.Database;
using EvenlyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvenlyAPI.Services
{
	public class UserGroupsRepository(EvenlyDbContext context) : IUserGroupsRepository
	{
		private readonly EvenlyDbContext context = context;

		public IEnumerable<UserGroupModel?> Add(UserGroupModel newUserGroup)
		{
			context.UserGroups.Add(newUserGroup);
			context.SaveChanges();

			return GetAll();
		}

		public void Delete(int userId, int groupId)
		{
			UserGroupModel? userGroup = GetById(userId, groupId);
			if (userGroup != null)
			{
				context.UserGroups.Remove(userGroup);
				context.SaveChanges();
			}
		}

		public IEnumerable<UserGroupModel?> GetAll()
		{
			List<UserGroupModel> allUserGroups = context.UserGroups.ToList();
			List<UserGroupModel?> projectedUserGroups = new();

			foreach (var userGroup in allUserGroups)
			{
				projectedUserGroups.Add(GetById(userGroup.UserId, userGroup.GroupId));
			}

			return projectedUserGroups;
		}

		public UserGroupModel? GetById(int userId, int groupId)
		{
			return context.UserGroups
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
						Description = e.Description
					}).ToList()
				}).FirstOrDefault(u => u.UserId == userId && u.GroupId == groupId);
		}

		public UserGroupModel? Update(int userId, int groupId, UserGroupModel updatedUserGroup)
		{
			UserGroupModel? currentUserGroup = GetById(userId, groupId);
			if (currentUserGroup != null)
			{
				currentUserGroup.Balance = updatedUserGroup.Balance;

				//TODO: Här har vi ett error: affectedRows blir 0
				int affectedRows = context.SaveChanges();
				if (affectedRows > 0)
				{
					// Ändringarna sparades framgångsrikt
				}
			}


			return GetById(userId, groupId);
		}
	}
}
