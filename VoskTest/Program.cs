using VoskTest;



RecognizeService recognizeService = new RecognizeService(
    audioFilePath: "test_ru.wav",
    modelPath: "model_ru",
    sampleRate: 48_000,
    logLevel: 0);

AudioConvertService.ConvertToWav("test.mp3");

recognizeService.DemoBytes();

//DemoBytes(model);
//DemoFloats(model);
//DemoSpeaker(model);
