using VoskTest;


string outputfilePath = AudioConvertService.ConvertToWav("Захаров1.mp3");

RecognizeService recognizeService = new (
    audioFilePath: outputfilePath,
    modelPath: "model_ru",
    sampleRate: 48_000,
    logLevel: 0);

recognizeService.DemoBytes();

//DemoBytes(model);
//DemoFloats(model);
//DemoSpeaker(model);
