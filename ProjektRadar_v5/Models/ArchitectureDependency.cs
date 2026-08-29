namespace ProjektRadar.Models;

public sealed record ArchitectureDependency(
    string Component,
    string DependsOn,
    string Why,
    string Risk,
    string Source);
