namespace ProjektRadar.Models;

public record ArchitectureQuestion(
    string Question,
    string WhyItBlocks,
    string SuggestedOwner,
    string Priority,
    string Evidence);
