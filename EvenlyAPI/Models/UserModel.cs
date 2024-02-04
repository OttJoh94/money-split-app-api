using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvenlyAPI.Models
{
	public class UserModel
	{
		[Key]
		[Column("user_id")]
		public int UserId { get; set; }
		[Column("name")]
		public string Name { get; set; } = null!;
		public List<UserGroupModel> UserGroups { get; set; } = new();
	}
}
