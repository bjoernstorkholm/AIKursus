namespace ProjektRadar.Models;

public record MissingDecision(
    string Decision,
    string WhyItMatters,
    string Evidence,
    string NeededBy);
