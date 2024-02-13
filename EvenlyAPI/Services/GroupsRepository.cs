using EvenlyAPI.Database;
using EvenlyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvenlyAPI.Services
{
    public class GroupsRepository(EvenlyDbContext context) : IGroupsRepository
    {
        private readonly EvenlyDbContext context = context;

        public async Task<IEnumerable<GroupModel>> AddAsync(GroupModel newGroup)
        {
            await context.Groups.AddAsync(newGroup);
            await context.SaveChangesAsync();

            return await GetAllAsync();
        }

        public async Task DeleteAsync(int id)
        {
            GroupModel? group = await GetByIdAsync(id);

            if (group != null)
            {
                context.Groups.Remove(group);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GroupModel>> GetAllAsync()
        {
            return await context.Groups.ToListAsync();
        }

        public async Task<GroupModel?> GetByIdAsync(int id)
        {
            return await context.Groups.FirstOrDefaultAsync(g => g.GroupId == id);
        }

        public async Task<GroupModel?> UpdateAsync(int id, GroupModel updatedGroup)
        {
            GroupModel? currentGroup = await GetByIdAsync(id);

            if (currentGroup != null)
            {
                currentGroup.GroupName = updatedGroup.GroupName;
                await context.SaveChangesAsync();
            }

            return currentGroup;
        }
    }
}
