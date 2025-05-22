using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jovian_Project_Backend.Models
{
    public class ThreatDiagram
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid InfoID { get; set; }

        public string? SequenceDiagram { get; set; }
        public string? FlowDiagram { get; set; }

        // Navigation property
        [ForeignKey(nameof(InfoID))]
        public required Info Info { get; set; }
    }
}