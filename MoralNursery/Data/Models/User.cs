using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoralNursery.Data.Models
{
	public class User
	{
		
		public int Id { get; set; }
        [Required]
        [StringLength(200)]
		public string? FullName { get; set; }
		[Required]
		[StringLength(200)]
		public string Username { get; set; }

		[Required]
		[StringLength(200)]
		public string PasswordHash { get; set; }

		
		[StringLength(50)]
		public string? PasswordSalt { get; set; }

		[StringLength(100)]
		public string? PhoneNumber { get; set; }

		public string? Address { get; set; }

		[StringLength(200)]
		public string? Email { get; set; }

		[DefaultValue(true)]
		public bool? IsActive { get; set; }
		public ICollection<Role> Roles { get; set; }
	}
}
