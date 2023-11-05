using Silvester.Domain.Models;

namespace Silvester.Persistence.Abstractions;

public interface IRecognizeService
{
    /// <summary>
    /// The method recognizes the audio file
    /// </summary>
    /// <param name="audioFilePath">Path to the file to be recognized</param>
    /// <param name="voskModelPath">Path to the file to be recognized</param>
    /// <returns>VoskFinalResult object, which represents the detailed data in the recognition process and the recognition text</returns>
    VoskFinalResult? RecognizeAudioFile(string audioFilePath);
}
