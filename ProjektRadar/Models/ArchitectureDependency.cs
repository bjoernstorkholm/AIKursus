namespace ProjektRadar.Models;

public record ArchitectureDependency(
    string Component,
    string DependsOn,
    string Why,
    string Risk,
    string Source);
