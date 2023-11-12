using Silvester.Domain.Models;

namespace Silvester.Persistence.Abstractions;

public interface IRecognitionService
{
    IRecognitionService Configure(IRecognitionServiceConfiguration configuration);
    VoskFinalResult Transcribe(string audioFilePath);
}

public interface IRecognitionServiceConfiguration
{

}