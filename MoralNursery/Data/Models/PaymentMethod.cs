using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoralNursery.Data.Models
{
	public class PaymentMethod
	{
		
		public int Id { get; set; }

		[StringLength(50)]
		[Required]
		public string PaymentMethodName { get; set; }
	}
}
