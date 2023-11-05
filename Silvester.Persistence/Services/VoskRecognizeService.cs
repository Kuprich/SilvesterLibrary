using Newtonsoft.Json;
using Silvester.Domain.Models;
using Silvester.Persistence.Abstractions;
using Vosk;

namespace Silvester.Persistence.Services;

public class VoskRecognizeService : IRecognizeService
{
    private void SetVoskLogLevel(int logLevel) => Vosk.Vosk.SetLogLevel(logLevel);

    public VoskFinalResult? RecognizeAudioFile(string audioFilePath)
    {
        SetVoskLogLevel(0);
        return DemoBytes(audioFilePath, "model-ru", 48_000);
    }

    VoskFinalResult? DemoBytes(string audioFilePath, string modelPath, int sampleRate)
    {
        Model voskModel = new (modelPath);
        VoskRecognizer rec = new(voskModel, sampleRate);
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
