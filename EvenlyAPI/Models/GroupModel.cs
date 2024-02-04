using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvenlyAPI.Models
{
	public class GroupModel
	{
		[Key]
		[Column("group_id")]
		public int GroupId { get; set; }
		[Column("group_name")]
		public string GroupName { get; set; } = null!;
		public List<UserGroupModel> UserGroups { get; set; } = new();
	}
}
