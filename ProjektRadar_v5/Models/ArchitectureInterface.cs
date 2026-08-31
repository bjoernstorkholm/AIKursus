namespace ProjektRadar.Models;

public record ArchitectureInterface(
    string Name,
    string From,
    string To,
    string Protocol,
    string Contract,
    string Authentication,
    string Status,
    string Evidence);
