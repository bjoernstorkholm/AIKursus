using System.Collections.Generic;

namespace ProjektRadar.Models;

public record ArchitectureAnalysis
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
