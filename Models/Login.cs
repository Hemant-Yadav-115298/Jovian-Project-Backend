using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jovian_Project_Backend.Models
{
    public class Login
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Password { get; set; }

        // Foreign Key to Actor
        public Guid? ActorID { get; set; }

        [ForeignKey("ActorID")]
        public virtual Actor? Actor { get; set; }
    }
}
