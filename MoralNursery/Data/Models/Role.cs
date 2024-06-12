using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoralNursery.Data.Models
{
	public class Role
	{
		
		
		public int Id { get; set; }
		[StringLength(200)]
		[Required]
		public string RoleName { get; set; }
		// Define navigation property for users
		public ICollection<User> Users { get; set; }

        // Define navigation property for functions
        //public int FunctionsId { get; set; }
        public ICollection<Function> Functions { get; set; }
	}
}
