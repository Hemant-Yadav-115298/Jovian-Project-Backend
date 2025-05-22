using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Jovian_Project_Backend.Models
{
    public class Threat
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid InfoID { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public DateTime? ScanDate { get; set; }
        public Guid? ScanID { get; set; }

        public string? ThreatTitle { get; set; }
        public string? ThreatDescription { get; set; }
        public string? Categories { get; set; }
        public string? Remediation { get; set; }
        public DateTime? ThreatDate { get; set; }
        public string? Justification { get; set; }

        [StringLength(20)]
        [RegularExpression("^(high|medium|low)$", ErrorMessage = "Risk must be one of: 'high', 'medium', 'low'.")]
        public string? Risk { get; set; }

        public bool? IsUpdated { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        [StringLength(50)]
        [RegularExpression("^(notstarted|needinvestigation|notapplicable|mitigated)$", ErrorMessage = "Status must be one of: 'notstarted', 'needinvestigation', 'notapplicable', 'mitigated'.")]
        public string? Status { get; set; }

        // Navigation property
        [ForeignKey(nameof(InfoID))]
        public required Info Info { get; set; }
    }
}