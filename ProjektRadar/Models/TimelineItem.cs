using System;

namespace ProjektRadar.Models;

public record TimelineItem(
    DateTime Date,
    string Title,
    string Type,
    string Status,
    string Detail,
    string Evidence);
