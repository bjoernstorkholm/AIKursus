using System;

namespace ProjektRadar.Models;

public sealed record TimelineItem(
    DateTime Date,
    string Title,
    string Type,
    string Status,
    string Detail,
    string Evidence);
