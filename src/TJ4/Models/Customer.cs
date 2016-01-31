using System.ComponentModel.DataAnnotations;

namespace TJ4.Models
{
    public class Customer  
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Display(Name = "Telephone Number")]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
