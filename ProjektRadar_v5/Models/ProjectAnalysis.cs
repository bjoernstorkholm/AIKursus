using System;
using System.Collections.Generic;

namespace ProjektRadar.Models;

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
