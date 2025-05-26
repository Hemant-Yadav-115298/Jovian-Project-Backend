using Jovian_Project_Backend.Models;

public class InfoThreatDetailsDto
{
    public Info Info { get; set; }
    public List<Threat> Threats { get; set; }
    public List<ThreatDiagram> ThreatDiagrams { get; set; }
}