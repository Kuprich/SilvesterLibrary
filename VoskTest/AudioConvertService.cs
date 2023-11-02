using FFMpegCore;

namespace VoskTest;

public class AudioConvertService
{
    public static void ConvertToWav(string inputAudioFilePath)
    {
        string outputAudioFileName = $"{Path.GetFileNameWithoutExtension(inputAudioFilePath)}.wav";
        FFMpegArguments
            .FromFileInput(inputAudioFilePath)
            .OutputToFile(outputAudioFileName);
    }
}
