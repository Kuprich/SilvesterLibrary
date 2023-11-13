using Silvester.Persistence.Abstractions;

namespace Silvester.Persistence.Services.WhishperRecognitionService;

public class WhishperConfiguration : IServiceConfiguration
{
    public string Model { get; set; } = "ggml-base.bin";
    public string Language { get; set; } = "auto";
}


