
public class Actor
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? AddedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    // Navigation property
    public ICollection<InfoActor> InfoActors { get; set; }
}
