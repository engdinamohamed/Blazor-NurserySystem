using System.ComponentModel.DataAnnotations;

namespace MoralNursery.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NurseryName { get; set; }
        [Required]
        [StringLength(50)]
        public string NurseryTel { get; set; }
        [Required]
        [StringLength(150)]
        public string NurseryAddress { get; set; }
       
        [StringLength(50)]
        public string? NurseryVat { get; set; }
    }
}
