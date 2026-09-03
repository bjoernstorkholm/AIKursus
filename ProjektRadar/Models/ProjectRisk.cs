namespace ProjektRadar.Models;

public record ProjectRisk(
    string Title,
    string Description,
    string Probability,
    string Consequence,
    int Score,
    string Level,
    string Evidence);
