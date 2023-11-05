namespace Silvester.Persistence.Abstractions;

public interface IAudioConverterService
{
    /// <summary>
    /// Convert audio file to .wav
    /// </summary>
    /// <param name="audioFilePath">Path to source audio file</param>
    /// <returns>Path to the converted audiofile</returns>
    string ConvertToWav(string audioFilePath);
}
