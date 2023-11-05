using FFMpegCore;
using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Extensions;

namespace Silvester.Persistence.Services;

public class FFMpegAudioConvertService : IAudioConverterService
{
    public string ConvertToWav(string audioFilePath)
    {
        string outputDirecroty = Path.Combine(Environment.CurrentDirectory, "output");

        if (!Directory.Exists(outputDirecroty))
            Directory.CreateDirectory(outputDirecroty);

        string outputAudioFileName = Path.Combine(Environment.CurrentDirectory, "output", "output.wav");
        FFMpegArguments
            .FromFileInput(audioFilePath)
            .OutputToFile(outputAudioFileName, true, options => options
                .WithAudioSamplingRate(48_000)
                .WithArgument(new DownmixBothChannelsArgument()))
            .ProcessSynchronously();

        return outputAudioFileName;
    }
}
