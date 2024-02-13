using EvenlyAPI.Database;
using EvenlyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvenlyAPI.Services
{
    //TODO: Gör denna repon mer bulletproof
    public class UsersRepository(EvenlyDbContext context) : IUsersRepository
    {
        private readonly EvenlyDbContext context = context;

        /// <summary>
        /// Adds a new user and returns an updated list of all users
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>IEnumerable<UserModel></returns>
        public async Task<IEnumerable<UserModel>> AddAsync(UserModel newUser)
        {
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            return await GetAllAsync();
        }

        public async Task DeleteAsync(int id)
        {
            UserModel? userToRemove = await GetByIdAsync(id);
            if (userToRemove != null)
            {
                context.Users.Remove(userToRemove);
                await context.SaveChangesAsync();
                //TODO: Crashes if user has expense connected to it.
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<UserModel?> UpdateAsync(int id, UserModel updatedUser)
        {
            UserModel? currentUser = await GetByIdAsync(id);

            if (currentUser != null)
            {
                currentUser.Name = updatedUser.Name;
                await context.SaveChangesAsync();
            }

            return currentUser;
        }
    }
}
