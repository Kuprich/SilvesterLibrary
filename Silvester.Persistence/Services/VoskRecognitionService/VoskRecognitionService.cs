using Newtonsoft.Json;
using Silvester.Domain.Models;
using Silvester.Persistence.Abstractions;
using Vosk;

namespace Silvester.Persistence.Services.VoskRecognitionService;

public class VoskRecognitionService : IRecognitionService
{

    public VoskConfiguration Configuration { get; set; }

    private void SetVoskLogLevel(int logLevel) => Vosk.Vosk.SetLogLevel(logLevel);
    
    public IRecognitionService Configure(IRecognitionServiceConfiguration configuration)
    {
        Configuration = (VoskConfiguration)configuration;
        return this;
    }

    public VoskFinalResult Transcribe(string audioFilePath)
    {
        SetVoskLogLevel(0);
        return DemoBytes(audioFilePath);
    }
    VoskFinalResult? DemoBytes(string audioFilePath)
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

        return JsonConvert.DeserializeObject<VoskFinalResult>(rec.FinalResult());
    }
}




