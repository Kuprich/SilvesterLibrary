using Silvester.Abstractions;

namespace Silvester.Services.WhisperRecognitionService;

public class WhisperConfiguration : IServiceConfiguration
{
    public string Model { get; set; } = "ggml-base.bin";
    public string Language { get; set; } = "auto";
}


