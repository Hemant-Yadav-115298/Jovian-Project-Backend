using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jovian_Project_Backend.Models
{

public class Actor
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(200)]
        public required string Name { get; set; }

        [Required]
        [StringLength(200)]
        [EmailAddress]
        public required string Email { get; set; }

        public DateTime? AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [StringLength(50)]
        [RegularExpression("^(enable|disable)$", ErrorMessage = "Status must be either 'enable' or 'disable'.")]
        public string? Status { get; set; }

        [StringLength(50)]
        [RegularExpression("^(systemuser|individual)$", ErrorMessage = "Type must be either 'systemuser' or 'individual'.")]
        public string? Type { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        // Navigation property
        public required ICollection<InfoActor> InfoActors { get; set; }
    }
}
