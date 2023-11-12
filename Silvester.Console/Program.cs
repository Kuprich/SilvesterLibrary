using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Extensions;
using Silvester.Persistence.Services.FFMpegConverterService;
using Silvester.Persistence.Services.VoskRecognitionService;



IAudioConverterServiceConfiguration ffmpegConfiguration = new FFMpegConfiguration()
    .WithConfigurationFromFile("FFMpegConfiguration.json");
    //.WithArrndnModel("cb.rnnn")
    //.WithSamplingRate(48_000);

IAudioConverterService ffmpeg = new FFMpegConverterService()
    .Configure(ffmpegConfiguration);

IRecognitionServiceConfiguration voskConfiguration = new VoskConfiguration()
    //.WithConfigurationFromFile("VoskConfiguration.json");
    .WithModel("src/model-ru")
    .WithSampleRate(48_000)
    .WithBufferSize(16_000);

IRecognitionService vosk = new VoskRecognitionService()
    .Configure(voskConfiguration);



string convertedAudiofile = ffmpeg.ConvertToWav("src/Захаров.mp3");

var result = vosk.Transcribe(convertedAudiofile);

Console.WriteLine(result?.Text);
