using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoralNursery.Data.Models
{
	public class Student
	{
		
		public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string StudentCode { get; set; }

        [Required]
		[StringLength(200)]
		public string StudentName { get; set; }

		[Required]
		[StringLength(200)]
		public string GuardianPrimaryName { get; set; }

		[Required]
		[StringLength(50)]
		public string GuardianPrimaryTel { get; set; }

		[Required]
		[StringLength(250)]
		public string GuardianPrimaryAddress { get; set; }

		[StringLength(200)]
		public string? GuardianSecName { get; set; }

		[StringLength(50)]
		public string? GuardianSecTel { get; set; }

		[StringLength(250)]
		public string? GuardianSecAddress { get; set; }
		public string? Allergies { get; set; }
		public string? MdeicalConditions { get; set; }

		public DateTime AddedIn { get; set; }

        [Required]
        public int ClassRoomId { get; set; }

        
        public ClassRoom ClassRoom { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		[DefaultValue(true)]
		public bool IsActive { get; set; }

	}
}
