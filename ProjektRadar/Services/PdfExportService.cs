using System.Globalization;
using System.Text;
using ProjektRadar.Models;

namespace ProjektRadar.Services;

public sealed class PdfExportService
{
    public byte[] Create(ProjectAnalysis analysis)
    {
        var lines = new List<string>
        {
            "ProjektRadar - ledelsesoverblik",
            $"Samlet risikoniveau: {analysis.RiskLevel} ({analysis.RiskScore}/100)",
            string.Empty,
            "Ledelsesresume",
            analysis.ExecutiveSummary,
            string.Empty,
            "Prioriterede handlinger"
        };

        foreach (var action in analysis.Actions.OrderBy(a => a.Deadline))
        {
            lines.Add($"- {action.Title} | {action.ResponsibleRole} | {action.Deadline:dd-MM-yyyy} | {action.Priority} | {action.Status}");
        }

        lines.Add(string.Empty);
        lines.Add("Vigtigste risici");
        foreach (var risk in analysis.Risks.OrderByDescending(r => r.Score))
        {
            lines.Add($"- {risk.Title}: {risk.Level} ({risk.Score}/100)");
        }

        return BuildSinglePagePdf(lines);
    }

    public byte[] Create(ArchitectureAnalysis analysis)
    {
        var lines = new List<string>
        {
            "ProjektRadar - arkitekturoverblik",
            $"Specifikationsdaekning: {analysis.SpecificationCoverage}% ({analysis.CoverageLevel})",
            string.Empty,
            "Udviklerresume",
            analysis.ExecutiveSummary,
            string.Empty,
            "Vigtigste konflikter"
        };

        foreach (var conflict in analysis.Conflicts)
        {
            lines.Add($"- {conflict.Title}: {conflict.RecommendedInterpretation}");
        }

        lines.Add(string.Empty);
        lines.Add("Start her");
        foreach (var task in analysis.Tasks)
        {
            lines.Add($"- {task.Title} | {task.Area} | {task.Priority} | {task.Status}");
        }

        lines.Add(string.Empty);
        lines.Add("Aabne spoergsmaal");
        foreach (var question in analysis.OpenQuestions)
        {
            lines.Add($"- {question.Priority}: {question.Question}");
        }

        return BuildSinglePagePdf(lines);
    }

    private static byte[] BuildSinglePagePdf(IEnumerable<string> rawLines)
    {
        var content = new StringBuilder();
        content.AppendLine("BT");
        content.AppendLine("/F1 11 Tf");
        content.AppendLine("50 790 Td");
        content.AppendLine("14 TL");

        foreach (var raw in WrapLines(rawLines, 92).Take(48))
        {
            content.Append('(').Append(EscapePdfText(raw)).AppendLine(") Tj");
            content.AppendLine("T*");
        }

        content.AppendLine("ET");

        var contentBytes = Encoding.Latin1.GetBytes(content.ToString());
        var objects = new List<byte[]>
        {
            Encoding.ASCII.GetBytes("<< /Type /Catalog /Pages 2 0 R >>"),
            Encoding.ASCII.GetBytes("<< /Type /Pages /Kids [3 0 R] /Count 1 >>"),
            Encoding.ASCII.GetBytes("<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Resources << /Font << /F1 4 0 R >> >> /Contents 5 0 R >>"),
            Encoding.ASCII.GetBytes("<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>"),
            Combine(Encoding.ASCII.GetBytes($"<< /Length {contentBytes.Length} >>\nstream\n"), contentBytes, Encoding.ASCII.GetBytes("endstream"))
        };

        using var stream = new MemoryStream();
        WriteAscii(stream, "%PDF-1.4\n%ProjectRadar\n");

        var offsets = new List<long> { 0 };
        for (var i = 0; i < objects.Count; i++)
        {
            offsets.Add(stream.Position);
            WriteAscii(stream, $"{i + 1} 0 obj\n");
            stream.Write(objects[i]);
            WriteAscii(stream, "\nendobj\n");
        }

        var xrefPosition = stream.Position;
        WriteAscii(stream, $"xref\n0 {objects.Count + 1}\n");
        WriteAscii(stream, "0000000000 65535 f \n");
        for (var i = 1; i < offsets.Count; i++)
        {
            WriteAscii(stream, offsets[i].ToString("D10", CultureInfo.InvariantCulture) + " 00000 n \n");
        }

        WriteAscii(stream, $"trailer\n<< /Size {objects.Count + 1} /Root 1 0 R >>\nstartxref\n{xrefPosition}\n%%EOF");
        return stream.ToArray();
    }

    private static IEnumerable<string> WrapLines(IEnumerable<string> rawLines, int maxLength)
    {
        foreach (var rawLine in rawLines)
        {
            if (string.IsNullOrWhiteSpace(rawLine))
            {
                yield return string.Empty;
                continue;
            }

            var words = rawLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var current = new StringBuilder();
            foreach (var word in words)
            {
                if (current.Length > 0 && current.Length + word.Length + 1 > maxLength)
                {
                    yield return current.ToString();
                    current.Clear();
                }

                if (current.Length > 0)
                {
                    current.Append(' ');
                }
                current.Append(word);
            }

            if (current.Length > 0)
            {
                yield return current.ToString();
            }
        }
    }

    private static string EscapePdfText(string value) => value
        .Replace("\\", "\\\\", StringComparison.Ordinal)
        .Replace("(", "\\(", StringComparison.Ordinal)
        .Replace(")", "\\)", StringComparison.Ordinal);

    private static void WriteAscii(Stream stream, string value)
    {
        var bytes = Encoding.ASCII.GetBytes(value);
        stream.Write(bytes);
    }

    private static byte[] Combine(params byte[][] arrays)
    {
        var length = arrays.Sum(a => a.Length);
        var result = new byte[length];
        var offset = 0;
        foreach (var array in arrays)
        {
            Buffer.BlockCopy(array, 0, result, offset, array.Length);
            offset += array.Length;
        }
        return result;
    }
}
