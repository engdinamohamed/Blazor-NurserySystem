using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoralNursery.Data.Models
{
	public class ClassRoom
	{
		
		public int Id { get; set; }

		
		[Required]
        [StringLength(50)]
        public string ClassName { get; set; }

		
	}
}
