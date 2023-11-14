using Silvester.Abstractions;
using System.Text;
using Whisper.net;

namespace Silvester.Services.WhisperRecognitionService;

public class WhisperResult : ITranscribeResult
{
    public List<SegmentData>? Segments { get; set; } = new();

    public override string ToString()
    {
        if (Segments == null || Segments.Count == 0) return string.Empty;

        var sb = new StringBuilder();

        foreach (var segment in Segments)
        {
            sb.Append($"{segment.Text}");
        }

        return sb.ToString().Trim();
    }
}
