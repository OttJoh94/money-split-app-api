using EvenlyAPI.Database;
using EvenlyAPI.Models;

namespace EvenlyAPI.Services
{
	public class GroupsRepository(EvenlyDbContext context) : IGroupsRepository
	{
		private readonly EvenlyDbContext context = context;

		public IEnumerable<GroupModel> Add(GroupModel newGroup)
		{
			context.Groups.Add(newGroup);
			context.SaveChanges();

			return GetAll();
		}

		public void Delete(int id)
		{
			GroupModel? group = GetById(id);

			if (group != null)
			{
				context.Groups.Remove(group);
				context.SaveChanges();
			}
		}

		public IEnumerable<GroupModel> GetAll()
		{
			return context.Groups;
		}

		public GroupModel? GetById(int id)
		{
			return context.Groups.FirstOrDefault(g => g.GroupId == id);
		}

		public GroupModel? Update(int id, GroupModel updatedGroup)
		{
			GroupModel? currentGroup = GetById(id);

			if (currentGroup != null)
			{
				currentGroup.GroupName = updatedGroup.GroupName;
				context.SaveChanges();
			}

			return currentGroup;
		}
	}
}
