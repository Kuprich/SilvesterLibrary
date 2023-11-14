using Newtonsoft.Json;
using Silvester.Abstractions;

namespace Silvester.Extensions;

public static class IServiceConfigurationExtensions
{
    public static T WithConfigurationFromFile<T>(this T configuration, string jsonConfigurationFilePath)
        where T : IServiceConfiguration
    {
        if (JsonConvert.DeserializeObject<T>(File.ReadAllText(jsonConfigurationFilePath)) is T cfg)
            configuration = cfg;

        return configuration;
    }
}