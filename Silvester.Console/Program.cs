using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Services.Extensions;
using Silvester.Persistence.Services.FFMpegConverterService;
using Silvester.Persistence.Services.VoskRecognitionService;
using Silvester.Persistence.Services.WhishperRecognitionService;

IAudioConverterService<FFMpegConfiguration> ffmpeg = new FFMpegConverterService(
    new FFMpegConfiguration()
        .WithConfigurationFromFile("FFMpegConfiguration.json"));

IRecognitionService<VoskConfiguration, VoskResult> vosk = new VoskRecognitionService(
    new VoskConfiguration()
        .WithConfigurationFromFile("VoskConfiguration.json"));


IRecognitionService<WhishperConfiguration, WhishperResult> whisper = new WhishperRecognitionService(
    new WhishperConfiguration()
        .WithConfigurationFromFile("WhishperConfiguration.json"));

string convertedAudiofile = ffmpeg.ConvertToWav("src/Захаров.mp3");

var result = whisper.Transcribe(convertedAudiofile);

Console.WriteLine(result);
