using Silvester.Services.FFMpegConverterService;

namespace Silvester.Extensions.FFmpeg;

public static class FFMpegConfigurationExtentions
{
    public static FFMpegConfiguration WithSampleRate(this FFMpegConfiguration configuration, int samplingRate)
    {
        configuration.SamplingRate = samplingRate;
        return configuration;
    }
}
