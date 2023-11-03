using FFMpegCore.Arguments;

namespace VoskTest.Extensions;

/// <summary>
/// Downmix both channels
/// </summary>
public class DownmixBothChannelsArgument : IArgument
{
    public string Text => $"-ac 1";
}
