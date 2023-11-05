using Newtonsoft.Json;
using Vosk;
using VoskTest.Models;

namespace VoskTest;

public class RecognizeService
{
    private Model _model;

    public RecognizeService(string modelPath, int sampleRate = 48_000, int logLevel = 0)
    {
        _modelPath = modelPath;
        _sampleRate = sampleRate;

        SetLogLevel(logLevel);
        _model = new(_modelPath);
    }

    private string _modelPath;
    private int _sampleRate;
    public static void SetLogLevel(int logLevel) => Vosk.Vosk.SetLogLevel(logLevel);

    public VoskFinalResult? RecognizeAudioFile(string audioFilePath)
    {
        return DemoBytes(audioFilePath);
    }

    VoskFinalResult? DemoBytes(string audioFilePath)
    {
        VoskRecognizer rec = new(_model, _sampleRate);
        rec.SetMaxAlternatives(0);
        rec.SetWords(true);

        using (Stream source = File.OpenRead(audioFilePath))
        {
            var bufferlength = new FileInfo(audioFilePath).Length;
            byte[] buffer = new byte[16_000];
            int bytesRead;

            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                rec.AcceptWaveform(buffer, bytesRead);
        }

        return JsonConvert.DeserializeObject<VoskFinalResult>(rec.FinalResult());

    }

}
