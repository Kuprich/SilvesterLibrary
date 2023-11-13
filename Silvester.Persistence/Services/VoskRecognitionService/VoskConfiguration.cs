using Silvester.Persistence.Abstractions;

namespace Silvester.Persistence.Services.VoskRecognitionService;

public class VoskConfiguration : IServiceConfiguration
{
    public VoskConfiguration(string? model, int sampleRate = 48_000, int bufferSize = 16_000)
    {
        Model = model;
        SampleRate = sampleRate;
        BufferSize = bufferSize;
    }
    public VoskConfiguration() { }

    public string? Model { get; set; }
    public int SampleRate { get; set; }
    public int BufferSize { get; set; }
}




