using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Extensions;
using Silvester.Persistence.Services;
using Silvester.Persistence.Services.VoskRecognitionService;

IAudioConverterService audioConverterService = new FFMpegAudioConverterService();
IRecognitionService vosk = new VoskRecognitionService();
IRecognitionServiceConfiguration voskConfiguration = new VoskConfiguration()
    .WithConfigurationFromFile("VoskConfiguration.json");

vosk.Configure(voskConfiguration);


string convertedAudiofile = audioConverterService.ConvertToWav("src/Захаров.mp3");

var result = vosk.Transcribe(convertedAudiofile);

Console.WriteLine(result?.Text);
