namespace ProjektRadar.Models;

public record ArchitectureConflict(
    string Title,
    string SourceA,
    string SourceB,
    string DeveloperImpact,
    string RecommendedInterpretation);
