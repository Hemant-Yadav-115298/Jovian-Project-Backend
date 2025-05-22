
public class InfoActor
{
    public Guid ID { get; set; }
    public Guid InfoID { get; set; }
    public Guid ActorID { get; set; }
    public bool? IsUpdated { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string Justification { get; set; }

    // Navigation properties
    public Info Info { get; set; }
    public Actor Actor { get; set; }
}
