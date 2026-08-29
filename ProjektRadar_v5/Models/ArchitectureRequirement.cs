namespace ProjektRadar.Models;

public sealed record ArchitectureRequirement(
    string Id,
    string Area,
    string Requirement,
    string Status,
    string Source);
