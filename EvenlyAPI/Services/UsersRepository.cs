using EvenlyAPI.Database;
using EvenlyAPI.Models;

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
		public IEnumerable<UserModel> Add(UserModel newUser)
		{
			context.Users.Add(newUser);
			context.SaveChanges();

			return context.Users;
		}

		public void Delete(int id)
		{
			UserModel? userToRemove = context.Users.FirstOrDefault(u => u.UserId == id);
			if (userToRemove != null)
			{
				context.Users.Remove(userToRemove);
				context.SaveChanges();
			}
		}

		public IEnumerable<UserModel> GetAll()
		{
			return context.Users.ToList();
		}

		public UserModel? GetById(int id)
		{
			return context.Users.FirstOrDefault(u => u.UserId == id);
		}

		public UserModel? Update(int id, UserModel updatedUser)
		{
			UserModel? currentUser = context.Users.FirstOrDefault(u => u.UserId == id);

			if (currentUser != null)
			{
				currentUser.Name = updatedUser.Name;
				context.SaveChanges();
			}

			return currentUser;
		}
	}
}
