namespace ProjektRadar.Models;

public record DocumentConflict(
    string Title,
    string Summary,
    string SourceA,
    string SourceB,
    string Impact);
