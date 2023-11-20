namespace Silvester.Abstractions;

public interface IRecognitionService<TConfig, TResult>
    where TConfig : IServiceConfiguration
    where TResult : ITranscribeResult
{
    IRecognitionService<TConfig, TResult> Configure(TConfig configuration);
    TResult? Transcribe(string audioFilePath);
    Task<TResult?> TranscribeAsync(string audioFilePath);
    TResult? Result { get; set; }
}
