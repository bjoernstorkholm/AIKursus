namespace ProjektRadar.Models;

public record ArchitectureTask
{
    public int Id { get; init; }
    public required string Title { get; set; }
    public required string Detail { get; set; }
    public required string Area { get; set; }
    public required string Priority { get; set; }
    public required string Status { get; set; }
    public required string Evidence { get; init; }
}
