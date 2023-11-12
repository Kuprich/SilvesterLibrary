using FFMpegCore;
using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Extensions;

namespace Silvester.Persistence.Services.FFMpegConverterService;

public class FFMpegConverterService : IAudioConverterService
{
    public FFMpegConfiguration Configuration { get; set; } = new FFMpegConfiguration();
    public IAudioConverterService Configure(IAudioConverterServiceConfiguration configuration)
    {
        Configuration = (FFMpegConfiguration)configuration;
        return this;
    }

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
}
