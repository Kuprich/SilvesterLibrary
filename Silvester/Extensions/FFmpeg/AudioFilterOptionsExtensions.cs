using FFMpegCore.Arguments;

namespace Silvester.Extensions.FFmpeg;

public static class AudioFilterOptionsExtensions
{
    /// <summary>
    /// Reduce noise from speech using Recurrent Neural Networks.
    /// </summary>
    /// <param name="model">Set train model file to load. This option is always required.</param>
    /// <param name="mix">Set how much to mix filtered samples into final output. Allowed range is from -1 to 1. Default value is 1. Negative values are special, they set how much to keep filtered noise in the final filter output. Set this option to -1 to hear actual noise removed from input signal.</param>
    /// <returns></returns>
    public static AudioFilterOptions ArnndnDenoise(this AudioFilterOptions options, string model, int mix = 1)
    {
        options.Arguments.Add(new ArnndnArgument(model, mix));
        return options;
    }
}
