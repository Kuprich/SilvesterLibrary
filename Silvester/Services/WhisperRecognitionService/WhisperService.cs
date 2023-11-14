using Silvester.Abstractions;
using Whisper.net;

namespace Silvester.Services.WhisperRecognitionService;

public class WhisperService : IRecognitionService<WhisperConfiguration, WhisperResult>
{
    WhisperConfiguration Configuration { get; set; } = new WhisperConfiguration();

    public WhisperResult? Result { get; set; }

    public WhisperService(WhisperConfiguration configuration) => Configure(configuration);

    public IRecognitionService<WhisperConfiguration, WhisperResult> Configure(WhisperConfiguration configuration)
    {
        Configuration = configuration;
        Result = new();
        return this;
    }

    public WhisperResult? Transcribe(string audioFilePath)
    {
        using var whisperFactory = WhisperFactory.FromPath(Configuration.Model);

        using var processor = whisperFactory.CreateBuilder()
            .WithLanguage(Configuration.Language)
            .Build();

        using var fileStream = File.OpenRead(audioFilePath);

        Task.Run(async () =>
        {
            await foreach (var segment in processor.ProcessAsync(fileStream))
            {
                Result?.Segments?.Add(segment);
            }
        }).Wait();

        return Result;
    }
}


