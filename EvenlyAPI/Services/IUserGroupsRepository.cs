using EvenlyAPI.Models;

namespace EvenlyAPI.Services
{
	public interface IUserGroupsRepository
	{
		IEnumerable<UserGroupModel?> GetAll();
		UserGroupModel? GetById(int userId, int groupId);
		IEnumerable<UserGroupModel?> Add(UserGroupModel newUserGroup);
		UserGroupModel? UpdateBalance(int userId, int groupId, decimal newBalance);
		void Delete(int userId, int groupId);
	}
}
