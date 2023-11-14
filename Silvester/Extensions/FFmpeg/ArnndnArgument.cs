using FFMpegCore.Arguments;

namespace Silvester.Extensions.FFmpeg;

public class ArnndnArgument : IAudioFilterArgument
{
    private readonly string _model;
    private readonly int _mix;

    public ArnndnArgument(string model, int mix = 1)
    {
        _model = model;
        _mix = mix;
    }
    public string Key => "arnndn";

    public string Value => $"m={_model}:mix={_mix}";
}
