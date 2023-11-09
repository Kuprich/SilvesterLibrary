using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Services;

IAudioConverterService audioConverterService = new FFMpegAudioConvertService();

var recognizer = new VoskRecognitionService()
    .WithConfigurationFromFile("VoskConfiguration.json").WithCustomModel("src/model-ru");

string convertedAudiofile = audioConverterService.ConvertToWav("src/Захаров.mp3");

var result = recognizer.RecognizeAudioFile(convertedAudiofile);

Console.WriteLine(result?.Text);
