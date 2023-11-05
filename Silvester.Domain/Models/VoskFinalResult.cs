namespace Silvester.Domain.Models;

public class VoskFinalResult
{
    public List<VoskWord> Result = new();
    public string? Text { get; set; }
    public override string? ToString() => Text;
}
