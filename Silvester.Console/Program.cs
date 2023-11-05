using Silvester.Persistence.Abstractions;
using Silvester.Persistence.Services;

IAudioConverterService audioConverterService = new FFMpegAudioConvertService();
IRecognizeService recognizeService = new VoskRecognizeService();


string outputfilePath = audioConverterService.ConvertToWav("Захаров.mp3");

var result = recognizeService.RecognizeAudioFile(outputfilePath);

Console.WriteLine(result?.Text);
