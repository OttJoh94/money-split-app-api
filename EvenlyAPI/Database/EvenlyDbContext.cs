using EvenlyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EvenlyAPI.Database
{
	public class EvenlyDbContext(DbContextOptions<EvenlyDbContext> options) : DbContext(options)
	{
		public DbSet<UserModel> Users { get; set; }
		public DbSet<ExpenseModel> Expenses { get; set; }
		public DbSet<GroupModel> Groups { get; set; }
		public DbSet<UserGroupModel> UserGroups { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserGroupModel>().HasKey(u => new { u.UserId, u.GroupId });

			modelBuilder.Entity<ExpenseModel>().HasKey(u => u.ExpenseId);

			modelBuilder.Entity<ExpenseModel>()
				.HasOne(e => e.UserGroup)
				.WithMany(e => e.Expenses)
				.HasForeignKey(e => new { e.UserId, e.GroupId })
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<UserModel>().HasData(
				new UserModel() { UserId = 1, Name = "Otto" },
				new UserModel() { UserId = 2, Name = "Hilda" },
				new UserModel() { UserId = 3, Name = "Eva" },
				new UserModel() { UserId = 4, Name = "Sören" }
				);

			modelBuilder.Entity<GroupModel>().HasData(
				new GroupModel() { GroupId = 1, GroupName = "Simrishamnsgatan" },
				new GroupModel() { GroupId = 2, GroupName = "Familjen Johansson" }
				);

			modelBuilder.Entity<UserGroupModel>().HasData(
			   new UserGroupModel() { UserId = 1, GroupId = 1, Balance = 0 },
			   new UserGroupModel() { UserId = 2, GroupId = 1, Balance = 0 },
			   new UserGroupModel() { UserId = 1, GroupId = 2, Balance = 0 },
			   new UserGroupModel() { UserId = 3, GroupId = 2, Balance = 0 },
			   new UserGroupModel() { UserId = 4, GroupId = 2, Balance = 0 }
			   );

			modelBuilder.Entity<ExpenseModel>().HasData(
				new ExpenseModel() { ExpenseId = 1, Amount = 200, DateOfExpense = new DateTime(2023, 01, 01), Description = "Seeded expense", UserId = 1, GroupId = 1 });
		}
	}
}
