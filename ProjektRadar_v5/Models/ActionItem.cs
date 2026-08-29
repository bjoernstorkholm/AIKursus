using System;

namespace ProjektRadar.Models;

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
