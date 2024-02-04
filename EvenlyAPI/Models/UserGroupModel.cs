using System.ComponentModel.DataAnnotations.Schema;

namespace EvenlyAPI.Models
{
	public class UserGroupModel
	{
		[Column("user_id")]
		public int UserId { get; set; }
		public UserModel User { get; set; } = null!;
		[Column("group_id")]
		public int GroupId { get; set; }
		public GroupModel Group { get; set; } = null!;
		[Column("balance", TypeName = "DECIMAL(10,2)")]
		public decimal Balance { get; set; }
		public virtual List<ExpenseModel> Expenses { get; set; } = null!;
	}
}
