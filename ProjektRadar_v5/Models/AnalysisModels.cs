namespace ProjektRadar.Models;

public sealed class UploadedDocument
{
    public required string Name { get; init; }
    public required string Extension { get; init; }
    public required string ContentType { get; init; }
    public long Size { get; init; }
    public required string Sha256 { get; init; }
    public string? TextPreview { get; init; }
}

public sealed class ProjectAnalysis
{
    public int RiskScore { get; init; }
    public required string RiskLevel { get; init; }
    public required string ExecutiveSummary { get; init; }
    public List<RadarMetric> RadarMetrics { get; init; } = [];
    public List<ProjectRisk> Risks { get; init; } = [];
    public List<DocumentConflict> Conflicts { get; init; } = [];
    public List<MissingDecision> MissingDecisions { get; init; } = [];
    public List<EvidenceItem> Evidence { get; init; } = [];
    public List<ActionItem> Actions { get; init; } = [];
    public List<TimelineItem> Timeline { get; init; } = [];
}

public sealed record RadarMetric(string Name, int Score);

public sealed class ProjectRisk
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Probability { get; init; }
    public required string Consequence { get; init; }
    public int Score { get; init; }
    public required string Level { get; init; }
    public required string Evidence { get; init; }
}

public sealed record DocumentConflict(
    string Title,
    string Summary,
    string SourceA,
    string SourceB,
    string Impact);

public sealed record MissingDecision(
    string Decision,
    string WhyItMatters,
    string Evidence,
    string NeededBy);

public sealed record EvidenceItem(
    string Source,
    string Quote,
    string Supports);

public sealed class ActionItem
{
    public int Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ResponsibleRole { get; set; }
    public DateTime Deadline { get; set; }
    public required string Priority { get; set; }
    public required string Status { get; set; }
    public required string Evidence { get; init; }
}

public sealed record TimelineItem(
    DateTime Date,
    string Title,
    string Type,
    string Status,
    string Detail,
    string Evidence);

public enum AppMode
{
    ProjectControl,
    ArchitectureOverview
}

public sealed class ArchitectureAnalysis
{
    public int SpecificationCoverage { get; init; }
    public required string CoverageLevel { get; init; }
    public required string ExecutiveSummary { get; init; }
    public List<ArchitectureArea> Areas { get; init; } = [];
    public List<ArchitectureRequirement> Requirements { get; init; } = [];
    public List<ArchitectureInterface> Interfaces { get; init; } = [];
    public List<ArchitectureConflict> Conflicts { get; init; } = [];
    public List<ArchitectureDecision> Decisions { get; init; } = [];
    public List<ArchitectureDependency> Dependencies { get; init; } = [];
    public List<ArchitectureQuestion> OpenQuestions { get; init; } = [];
    public List<ArchitectureTask> Tasks { get; init; } = [];
    public List<EvidenceItem> Evidence { get; init; } = [];
}

public sealed record ArchitectureArea(
    string Name,
    int Coverage,
    string Status,
    string Detail);

public sealed record ArchitectureRequirement(
    string Id,
    string Area,
    string Requirement,
    string Status,
    string Source);

public sealed record ArchitectureInterface(
    string Name,
    string From,
    string To,
    string Protocol,
    string Contract,
    string Authentication,
    string Status,
    string Evidence);

public sealed record ArchitectureConflict(
    string Title,
    string SourceA,
    string SourceB,
    string DeveloperImpact,
    string RecommendedInterpretation);

public sealed record ArchitectureDecision(
    string Topic,
    string Decision,
    string Status,
    string Source);

public sealed record ArchitectureDependency(
    string Component,
    string DependsOn,
    string Why,
    string Risk,
    string Source);

public sealed record ArchitectureQuestion(
    string Question,
    string WhyItBlocks,
    string SuggestedOwner,
    string Priority,
    string Evidence);

public sealed class ArchitectureTask
{
    public int Id { get; init; }
    public required string Title { get; set; }
    public required string Detail { get; set; }
    public required string Area { get; set; }
    public required string Priority { get; set; }
    public required string Status { get; set; }
    public required string Evidence { get; init; }
}
