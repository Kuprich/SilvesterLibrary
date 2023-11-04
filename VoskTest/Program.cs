using VoskTest;


string outputfilePath = AudioConvertService.ConvertToWav("Захаров.mp3");

RecognizeService recognizeService = new (
    modelPath: "model-ru",
    sampleRate: 48_000,
    logLevel: 0);

var result = recognizeService.RecognizeAudioFile(outputfilePath);

Console.WriteLine(result.Text);

//DemoBytes(model);
//DemoFloats(model);
//DemoSpeaker(model);
