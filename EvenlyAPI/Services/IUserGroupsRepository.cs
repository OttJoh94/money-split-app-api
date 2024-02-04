using EvenlyAPI.Models;

namespace EvenlyAPI.Services
{
	public interface IUserGroupsRepository
	{
		IEnumerable<UserGroupModel?> GetAll();
		UserGroupModel? GetById(int userId, int groupId);
		IEnumerable<UserGroupModel?> Add(UserGroupModel newUserGroup);
		UserGroupModel? Update(int userId, int groupId, UserGroupModel updatedUserGroup);
		void Delete(int userId, int groupId);
	}
}
