using Newtonsoft.Json;
using Silvester.Domain.Models;
using Vosk;

namespace Silvester.Persistence.Services;

public class VoskRecognitionService
{
    private class Configuration
    {
        public string? Model { get; set; }
        public int SampleRate { get; set; } = 48_000;
        public int BufferSize { get; set; } = 16_000;
    }
    private Configuration _configuration = new();

    private void SetVoskLogLevel(int logLevel) => Vosk.Vosk.SetLogLevel(logLevel);

    public VoskFinalResult? RecognizeAudioFile(string audioFilePath)
    {
        SetVoskLogLevel(0);
        return DemoBytes(audioFilePath);
    }

    public VoskRecognitionService WithSampleRate(int sampleRate)
    {
        _configuration.SampleRate = sampleRate;
        return this;
    }
    public VoskRecognitionService WithCustomModel(string modelFileName)
    {
        _configuration.Model = modelFileName;
        return this;
    }
    public VoskRecognitionService WithConfigurationFromFile(string configurationFilePath)
    {
        if (JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configurationFilePath)) is Configuration cfg)
            _configuration = cfg;

        return this;
    }

    VoskFinalResult? DemoBytes(string audioFilePath)
    {
        Model voskModel = new(_configuration.Model);
        VoskRecognizer rec = new(voskModel, _configuration.SampleRate);
        rec.SetMaxAlternatives(0);
        rec.SetWords(true);

        using (Stream source = File.OpenRead(audioFilePath))
        {
            byte[] buffer = new byte[_configuration.BufferSize];
            int bytesRead;

            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                rec.AcceptWaveform(buffer, bytesRead);
        }

        return JsonConvert.DeserializeObject<VoskFinalResult>(rec.FinalResult());

    }
}

