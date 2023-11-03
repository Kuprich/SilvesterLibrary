using FFMpegCore;
using VoskTest.Extensions;

namespace VoskTest;

public class AudioConvertService
{
    public static string ConvertToWav(string inputAudioFilePath)
    {
        string outputDirecroty = Path.Combine(Environment.CurrentDirectory, "output");

        if (!Directory.Exists(outputDirecroty))
            Directory.CreateDirectory(outputDirecroty);

        string outputAudioFileName = Path.Combine(Environment.CurrentDirectory, "output", "output.wav");
        FFMpegArguments
            .FromFileInput(inputAudioFilePath)
            .OutputToFile(outputAudioFileName, true, options => options
                .WithAudioSamplingRate(48_000)
                .WithArgument(new DownmixBothChannelsArgument()))
            .ProcessSynchronously();

        return outputAudioFileName;
    }
}
