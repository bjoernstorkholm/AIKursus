namespace ProjektRadar.Models;

public sealed record ArchitectureQuestion(
    string Question,
    string WhyItBlocks,
    string SuggestedOwner,
    string Priority,
    string Evidence);
