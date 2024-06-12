using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoralNursery.Data.Models
{
	public class FeeMethod
	{
		
		public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FeeMethodName { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Enter Number. ")]
        [Required]
        public float FeeQ { get; set; }
    }
}
