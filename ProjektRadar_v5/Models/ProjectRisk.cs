namespace ProjektRadar.Models;

public sealed class ProjectRisk
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Probability { get; init; }
    public required string Consequence { get; init; }
    public int Score { get; init; }
    public required string Level { get; init; }
    public required string Evidence { get; init; }
}
