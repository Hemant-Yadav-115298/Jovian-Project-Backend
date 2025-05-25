public class InfoSummaryDto
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
    public required string RepoName { get; set; }
    public DateTime? ScanDate { get; set; }
    public bool? IsUpdated { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public string? Status { get; set; }
}