using Silvester.Abstractions;
using Silvester.Extensions;
using Silvester.Extensions.FFmpeg;
using Silvester.Services.FFMpegConverterService;
using Silvester.Services.VoskRecognitionService;

// initialize FFMpeg configuration
var ffmpegConfiguration = new FFMpegConfiguration()
    .WithConfigurationFromFile("Services/FFMpegConfiguration.json")
    .WithSampleRate(48000);

// initialize FFMpeg converter service
IAudioConverterService<FFMpegConfiguration> ffmpeg = new FFMpegService(ffmpegConfiguration);

// initialize Vosk recognition service
IRecognitionService<VoskConfiguration, VoskResult> vosk = new VoskService(
    new VoskConfiguration()
        .WithConfigurationFromFile("Services/VoskConfiguration.json"));

string convertedAudiofile = ffmpeg.ConvertToWav("src/small.mp3");

var result = vosk.Transcribe(convertedAudiofile);

Console.WriteLine($"{new string('-', 30)}\n\n{result}\n\n{new string('-', 30)}");
