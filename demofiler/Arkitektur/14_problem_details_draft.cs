// Scratch file from architecture pairing session. Not production code.
public sealed record ApiProblem(
    string Type,
    string Title,
    int Status,
    string? Detail,
    string? CorrelationId);

// TODO: align with RFC 9457 / ASP.NET Core ProblemDetails.
// TODO: decide validation error extension format.
