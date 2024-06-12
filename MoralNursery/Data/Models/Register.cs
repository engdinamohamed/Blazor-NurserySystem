using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoralNursery.Data.Models
{
	public class Register
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int FeeMethodId { get; set; }
		public FeeMethod FeeMethod { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Enter Number. ")]
        public float Discount { get; set; }

		[Required]
        [Range(0, double.MaxValue, ErrorMessage = "Enter Number. ")]
        public float SubscriptionFee { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Fees must be numeric.")]
		public float BusFee { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Fees must be numeric.")]
		public float RegistrationFee { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Fees must be numeric.")]
		public float CostumesFee { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Fees must be numeric.")]
		public float BooksFee { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		[Required]
		public DateTime AddedIn { get; set; }

		[Required]
        public int UserId { get; set; }
		public User User { get; set; }

		

		

	}
}
