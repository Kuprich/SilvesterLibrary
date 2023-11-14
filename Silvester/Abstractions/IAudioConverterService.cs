namespace Silvester.Abstractions;

public interface IAudioConverterService<T> where T : IServiceConfiguration
{
    /// <summary>
    /// Convert audio file to .wav
    /// </summary>
    /// <param name="audioFilePath">Path to source audio file</param>
    /// <returns>Path to the converted audiofile</returns>
    string ConvertToWav(string audioFilePath);

    IAudioConverterService<T> Configure(T configuration);
}