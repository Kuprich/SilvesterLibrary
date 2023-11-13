using Newtonsoft.Json;
using Silvester.Persistence.Abstractions;
using Vosk;

namespace Silvester.Persistence.Services.VoskRecognitionService;

public class VoskRecognitionService : IRecognitionService<VoskConfiguration, VoskResult>
{
    public VoskConfiguration Configuration { get; set; } = new VoskConfiguration();

    public VoskResult? Result { get; private set; }

    private void SetVoskLogLevel(int logLevel) => Vosk.Vosk.SetLogLevel(logLevel);

    public VoskRecognitionService(VoskConfiguration configuration)
        => Configure(configuration);

    public VoskResult Transcribe(string audioFilePath)
    {
        SetVoskLogLevel(0);
        return DemoBytes(audioFilePath);
    }
    VoskResult? DemoBytes(string audioFilePath)
    {
        Model voskModel = new(Configuration.Model);
        VoskRecognizer rec = new(voskModel, Configuration.SampleRate);
        rec.SetMaxAlternatives(0);
        rec.SetWords(true);

        using (Stream source = File.OpenRead(audioFilePath))
        {
            byte[] buffer = new byte[Configuration.BufferSize];
            int bytesRead;

            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                rec.AcceptWaveform(buffer, bytesRead);
        }

        Result = JsonConvert.DeserializeObject<VoskResult>(rec.FinalResult());

        return Result;
    }

    public IRecognitionService<VoskConfiguration, VoskResult> Configure(VoskConfiguration configuration)
    {
        Configuration = configuration;
        Result = new();
        return this;
    }
}



