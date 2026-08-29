namespace ProjektRadar.Models;

public sealed record DocumentConflict(
    string Title,
    string Summary,
    string SourceA,
    string SourceB,
    string Impact);
