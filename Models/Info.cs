
public class Info
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string RepoName { get; set; }
    public DateTime? ScanDate { get; set; }
    public bool? IsUpdated { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public string Status { get; set; }

    // Navigation properties
    public ICollection<ThreatDiagram> ThreatDiagrams { get; set; }
    public ICollection<Threat> Threats { get; set; }
    public ICollection<InfoActor> InfoActors { get; set; }
}
