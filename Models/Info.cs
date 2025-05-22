using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jovian_Project_Backend.Models
{
    public class Info
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(200)]
        public required string Name { get; set; }

        [Required]
        [StringLength(200)]
        public required string RepoName { get; set; }

        public DateTime? ScanDate { get; set; }
        public bool? IsUpdated { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        [StringLength(50)]
        [RegularExpression("^(notstarted|needinvestigation|notapplicable|mitigated)$", ErrorMessage = "Status must be one of: 'notstarted', 'needinvestigation', 'notapplicable', 'mitigated'.")]
        public required string Status { get; set; }

        // Navigation properties
        public required ICollection<ThreatDiagram> ThreatDiagrams { get; set; }
        public required ICollection<Threat> Threats { get; set; }
        public required ICollection<InfoActor> InfoActors { get; set; }
    }
}
