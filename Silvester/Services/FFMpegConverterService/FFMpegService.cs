using FFMpegCore;
using Silvester.Abstractions;
using Silvester.Extensions.FFmpeg;

namespace Silvester.Services.FFMpegConverterService;

public class FFMpegService : IAudioConverterService<FFMpegConfiguration>
{
    public FFMpegConfiguration Configuration { get; set; } = new FFMpegConfiguration();

    public FFMpegService(FFMpegConfiguration configuration)
        => Configure(configuration);

    public string ConvertToWav(string audioFilePath)
    {
        string outputDirecroty = Path.Combine(Environment.CurrentDirectory, "output");

        if (!Directory.Exists(outputDirecroty))
            Directory.CreateDirectory(outputDirecroty);

        string outputAudioFileName = Path.Combine(Environment.CurrentDirectory, "output", "output.wav");
        FFMpegArguments
            .FromFileInput(audioFilePath)
            .OutputToFile(outputAudioFileName, true, options => options
                .WithAudioSamplingRate(Configuration.SamplingRate)
                .WithArgument(new DownmixBothChannelsArgument())
                .WithAudioFilters(options => options
                    .ArnndnDenoise(Configuration.ArrndnModel)))
            .ProcessSynchronously();

        return outputAudioFileName;
    }

    public IAudioConverterService<FFMpegConfiguration> Configure(FFMpegConfiguration configuration)
    {
        Configuration = configuration;
        return this;
    }
}
