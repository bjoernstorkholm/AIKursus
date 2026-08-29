namespace ProjektRadar.Models;

public sealed record ArchitectureDecision(
    string Topic,
    string Decision,
    string Status,
    string Source);
