using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoralNursery.Data.Models
{
	public class Function
	{
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[StringLength(200)]
		[Required]
		public string FunctionName { get; set; }
        [StringLength(200)]
        [Required]
        public string FunctionDescription { get; set; }
        //public int RolesId { get; set; }
        public ICollection<Role> Roles { get; set; }
	}
}
