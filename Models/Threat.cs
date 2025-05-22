
public class Threat
{
    public Guid ID { get; set; }
    public Guid InfoID { get; set; }
    public string Name { get; set; }
    public DateTime? ScanDate { get; set; }
    public Guid? ScanID { get; set; }
    public string ThreatTitle { get; set; }
    public string ThreatDescription { get; set; }
    public string Categories { get; set; }
    public string Remediation { get; set; }
    public DateTime? ThreatDate { get; set; }
    public string Justification { get; set; }
    public string Risk { get; set; }
    public bool? IsUpdated { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public string Status { get; set; }

    // Navigation property
    public Info Info { get; set; }
}
