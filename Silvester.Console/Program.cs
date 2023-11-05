using VoskTest;


RecognizeService recognizeService = new(
    modelPath: "model-ru",
    sampleRate: 48_000,
    logLevel: 0);

string outputfilePath = AudioConvertService.ConvertToWav("Захаров.mp3");

var result = recognizeService.RecognizeAudioFile(outputfilePath);

Console.WriteLine(result?.Text);
