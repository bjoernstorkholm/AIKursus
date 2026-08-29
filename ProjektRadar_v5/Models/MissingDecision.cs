namespace ProjektRadar.Models;

public sealed record MissingDecision(
    string Decision,
    string WhyItMatters,
    string Evidence,
    string NeededBy);
