using Silvester.Abstractions;
using Silvester.Services.FFMpegConverterService;
using Silvester.Services.WhisperRecognitionService;


// initialize FFMpeg converter service
IAudioConverterService<FFMpegConfiguration> ffmpeg = new FFMpegService(
    new FFMpegConfiguration
    {
        ArrndnModel = "src/ffmpeg/cb.rnnn",
        SamplingRate = 16000
    });

// initialize whisper recognition service
IRecognitionService<WhisperConfiguration, WhisperResult> whisper = new WhisperService(
    new WhisperConfiguration()
    {
        Model = "src/whisper/ggml-base.bin",
        Language = "auto"
    });

string convertedAudiofile = ffmpeg.ConvertToWav("src/small.mp3");

var result = await whisper.TranscribeAsync(convertedAudiofile);

Console.WriteLine($"{new string('-', 30)}\n\n{result}\n\n{new string('-', 30)}");

Console.ReadKey();

