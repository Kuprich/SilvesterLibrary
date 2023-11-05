using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Services;

IAudioConverterService audioConverterService = new FFMpegAudioConvertService();

var recognizer = new VoskRecognitionService()
    .WithConfigurationFromFile("VoskConfiguration.json");

string outputfilePath = audioConverterService.ConvertToWav("Захаров.mp3");

var result = recognizer.RecognizeAudioFile(outputfilePath);

Console.WriteLine(result?.Text);
