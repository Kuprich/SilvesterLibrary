using Vosk;

namespace VoskTest;

public class RecognizeService
{
   private Model _model;

    public RecognizeService(string audioFilePath, string modelPath, int sampleRate = 48_000, int logLevel = 0)
    {
        AudioFilePath = audioFilePath;
        ModelPath = modelPath;
        SampleRate = sampleRate;

        SetLogLevel(logLevel);
        _model = new(ModelPath);
    }

    public string AudioFilePath { get; set; }
    public string ModelPath { get; set; }
    public int SampleRate { get; set; }
    public static void SetLogLevel(int logLevel) => Vosk.Vosk.SetLogLevel(logLevel);

    public void DemoBytes()
    {
        // Demo byte buffer
        VoskRecognizer rec = new(_model, SampleRate);
        rec.SetMaxAlternatives(0);
        rec.SetWords(true);
        using (Stream source = File.OpenRead(AudioFilePath))
        {
            byte[] buffer = new byte[SampleRate];
            int bytesRead;
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (rec.AcceptWaveform(buffer, bytesRead))
                {
                    Console.WriteLine(rec.Result());
                }
                else
                {
                    Console.WriteLine(rec.PartialResult());
                }
            }
        }
        Console.WriteLine(rec.FinalResult());
    }

    public void DemoFloats(Model model)
    {
        // Demo float array
        VoskRecognizer rec = new VoskRecognizer(model, 48000.0f);
        using (Stream source = File.OpenRead("test_ru.wav"))
        {
            byte[] buffer = new byte[48000];
            int bytesRead;
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                float[] fbuffer = new float[bytesRead / 2];
                for (int i = 0, n = 0; i < fbuffer.Length; i++, n += 2)
                {
                    fbuffer[i] = BitConverter.ToInt16(buffer, n);
                }
                if (rec.AcceptWaveform(fbuffer, fbuffer.Length))
                {
                    Console.WriteLine(rec.Result());
                }
                else
                {
                    Console.WriteLine(rec.PartialResult());
                }
            }
        }
        Console.WriteLine(rec.FinalResult());
    }

    public void DemoSpeaker(Model model)
    {
        // Output speakers
        SpkModel spkModel = new SpkModel("model-spk");
        VoskRecognizer rec = new VoskRecognizer(model, 16000.0f);
        rec.SetSpkModel(spkModel);

        using (Stream source = File.OpenRead("test.mp3"))
        {
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (rec.AcceptWaveform(buffer, bytesRead))
                {
                    Console.WriteLine(rec.Result());
                }
                else
                {
                    Console.WriteLine(rec.PartialResult());
                }
            }
        }
        Console.WriteLine(rec.FinalResult());
    }
}
