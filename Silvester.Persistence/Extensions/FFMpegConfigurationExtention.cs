using Newtonsoft.Json;
using Silvester.Persistence.Services.FFMpegConverterService;

namespace Silvester.Persistence.Extensions;

public static class FFMpegConfigurationExtention
{
    public static FFMpegConfiguration WithConfigurationFromFile(this FFMpegConfiguration configuration, string jsonConfigurationFilePath)
    {
        if (JsonConvert.DeserializeObject<FFMpegConfiguration>(File.ReadAllText(jsonConfigurationFilePath)) is FFMpegConfiguration cfg)
            configuration = cfg;

        return configuration;
    }

    public static FFMpegConfiguration WithArrndnModel(this FFMpegConfiguration configuration, string modelFileName)
    {
        configuration.ArrndnModel = modelFileName;
        return configuration;
    }

    public static FFMpegConfiguration WithSamplingRate(this FFMpegConfiguration configuration, int samplingRate)
    {
        configuration.SamplingRate = samplingRate;
        return configuration;
    }
}
