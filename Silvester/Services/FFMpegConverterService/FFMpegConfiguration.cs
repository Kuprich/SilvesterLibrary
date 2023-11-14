using Silvester.Abstractions;

namespace Silvester.Services.FFMpegConverterService;

public class FFMpegConfiguration : IServiceConfiguration
{
    public string ArrndnModel { get; set; } = "cb.rnnn";
    public int SamplingRate { get; set; } = 48_000;
}