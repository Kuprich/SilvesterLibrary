using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Services;

IAudioConverterService audioConverterService = new FFMpegAudioConvertService();

var recognizer = new VoskRecognitionService()
    .WithConfigurationFromFile("VoskConfiguration.json").WithCustomModel("model-ru-full");

string convertedAudiofile = audioConverterService.ConvertToWav("Захаров.mp3");

Console.WriteLine(recognizer.RecognizeAudioFile(convertedAudiofile)?.Text);
//Console.WriteLine(recognizer.RecognizeAudioFile($"output/output_denoise.wav")?.Text);

