using System.ComponentModel.DataAnnotations;

namespace MoralNursery.Data.Models
{
	public class Payment
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }

		public int RegisterId { get; set; }

		public Register Register { get; set; }

		public DateTime AddedIn { get; set; }

		[Required]
        [Range(0, double.MaxValue, ErrorMessage = "Enter Number. ")]
        public float Amount { get; set; }
		public int PaymentMethodId { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
	}
}
