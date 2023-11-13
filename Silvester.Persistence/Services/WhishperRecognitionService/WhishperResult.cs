using Silvester.Persistence.Abstractions;
using System.Text;
using Whisper.net;

namespace Silvester.Persistence.Services.WhishperRecognitionService;

public class WhishperResult : ITranscribeResult
{
    public List<SegmentData>? Segments { get; set; }

    public override string ToString()
    {
        if (Segments == null || Segments.Count == 0) return string.Empty;

        var sb = new StringBuilder();

        foreach (var segment in Segments)
        {
            sb.Append(segment.Text);
        }

        return sb.ToString();
    }
}
