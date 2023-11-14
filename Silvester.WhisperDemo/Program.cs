using Silvester.Abstractions;
using Silvester.Extensions;
using Silvester.Services.FFMpegConverterService;
using Silvester.Services.WhisperRecognitionService;

// initialize FFMpeg configuration
var ffmpegConfiguration = new FFMpegConfiguration()
    .WithConfigurationFromFile("Services/FFMpegConfiguration.json");

// initialize FFMpeg converter service
IAudioConverterService<FFMpegConfiguration> ffmpeg = new FFMpegService(ffmpegConfiguration);

// initialize whisper recognition service
IRecognitionService<WhisperConfiguration, WhisperResult> whisper = new WhisperService(
    new WhisperConfiguration()
        .WithConfigurationFromFile("Services/WhisperConfiguration.json"));

string convertedAudiofile = ffmpeg.ConvertToWav("src/test.wav");

var result = whisper.Transcribe(convertedAudiofile);

Console.WriteLine($"{new string('-', 30)}\n\n{result}\n\n{new string('-', 30)}");



