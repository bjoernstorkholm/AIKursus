using System;
using System.Collections.Generic;

namespace ProjektRadar.Models;

public record UploadedDocument
{
    public required string Name { get; init; }
    public required string Extension { get; init; }
    public required string ContentType { get; init; }
    public long Size { get; init; }
    public required string Sha256 { get; init; }
    public string? TextPreview { get; init; }
}
