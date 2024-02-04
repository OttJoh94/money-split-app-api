using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvenlyAPI.Models
{
	public class ExpenseModel
	{
		[Key]
		[Column("expense_id")]
		public int ExpenseId { get; set; }
		[Column("description")]
		public string Description { get; set; } = null!;
		[Column("amount", TypeName = "decimal(10,2)")]
		public decimal Amount { get; set; }
		[Column("date_of_expense")]
		public DateTime DateOfExpense { get; set; } = DateTime.Now;
		[Column("user_id")]
		public int UserId { get; set; }
		[Column("group_id")]
		public int GroupId { get; set; }
		public UserGroupModel UserGroup { get; set; } = null!;
	}
}
