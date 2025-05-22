
public class ThreatDiagram
{
    public Guid ID { get; set; }
    public Guid InfoID { get; set; }
    public string SequenceDiagram { get; set; }
    public string FlowDiagram { get; set; }

    // Navigation property
    public Info Info { get; set; }
}
