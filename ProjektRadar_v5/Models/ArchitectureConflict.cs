namespace ProjektRadar.Models;

public sealed record ArchitectureConflict(
    string Title,
    string SourceA,
    string SourceB,
    string DeveloperImpact,
    string RecommendedInterpretation);
