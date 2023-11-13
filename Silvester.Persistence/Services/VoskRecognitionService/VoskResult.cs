using Silvester.Persistence.Abstractions;

namespace Silvester.Persistence.Services.VoskRecognitionService;

public class VoskResult : ITranscribeResult
{
    public List<VoskPartialResult> Result = new();
    public string? Text { get; set; }
    public override string? ToString() => Text;
}

public class VoskPartialResult
{
    public double Conf { get; set; }
    public double End { get; set; }
    public double Start { get; set; }
    public string? Word { get; set; }

    public override string? ToString() => Word;
}


