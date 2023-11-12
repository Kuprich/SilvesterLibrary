using Newtonsoft.Json;
using Silvester.Persistence.Services.VoskRecognitionService;

namespace Silvester.Persistence.Extensions;

public static class VoskRecognitionServiceConfigurationExtention
{
    public static VoskConfiguration WithConfigurationFromFile(this VoskConfiguration configuration, string jsonConfigurationFilePath)
    {
        if (JsonConvert.DeserializeObject<VoskConfiguration>(File.ReadAllText(jsonConfigurationFilePath)) is VoskConfiguration cfg)
            configuration = cfg;

        return configuration;
    }

    public static VoskConfiguration WithCustomModel(this VoskConfiguration configuration, string modelFileName)
    {
        configuration.Model = modelFileName;
        return configuration;
    }

    public static VoskConfiguration WithSampleRate(this VoskConfiguration configuration, int sampleRate)
    {
        configuration.SampleRate = sampleRate;
        return configuration;
    }
}
