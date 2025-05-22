using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jovian_Project_Backend.Models
{
    public class InfoActor
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid InfoID { get; set; }

        [Required]
        public Guid ActorID { get; set; }

        public bool? IsUpdated { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string? Justification { get; set; }

        // Navigation properties
        [ForeignKey(nameof(InfoID))]
        public required Info Info { get; set; }

        [ForeignKey(nameof(ActorID))]
        public required Actor Actor { get; set; }
    }
}