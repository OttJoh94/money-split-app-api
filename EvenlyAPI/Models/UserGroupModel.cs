using System.ComponentModel.DataAnnotations.Schema;

namespace EvenlyAPI.Models
{
	public class UserGroupModel
	{
		[Column("user_id")]
		public int UserId { get; set; }
		public UserModel? User { get; set; }
		[Column("group_id")]
		public int GroupId { get; set; }
		public GroupModel? Group { get; set; }
		[Column("balance", TypeName = "DECIMAL(10,2)")]
		public decimal Balance { get; set; }
		public List<ExpenseModel> Expenses { get; set; } = new();
	}
}
