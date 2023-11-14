using FFMpegCore.Arguments;

namespace Silvester.Extensions.FFmpeg;

/// <summary>
/// FFmpeg extention. Argument which downmix both channels
/// </summary>
public class DownmixBothChannelsArgument : IArgument
{
    public string Text => $"-ac 1";
}
