using EvenlyAPI.Models;

namespace EvenlyAPI.Services
{
    public interface IUserGroupsRepository
    {
        Task<IEnumerable<UserGroupModel?>> GetAllAsync();
        Task<UserGroupModel?> GetByIdAsync(int userId, int groupId);
        Task<IEnumerable<UserGroupModel?>> AddAsync(UserGroupModel newUserGroup);
        Task<UserGroupModel?> UpdateBalanceAsync(int userId, int groupId, decimal newBalance);
        Task DeleteAsync(int userId, int groupId);
    }
}
