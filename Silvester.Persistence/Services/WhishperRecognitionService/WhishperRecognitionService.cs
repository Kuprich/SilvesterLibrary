using Silvester.Persistence.Abstractions;
using Whisper.net;

namespace Silvester.Persistence.Services.WhishperRecognitionService;

public class WhishperRecognitionService : IRecognitionService<WhishperConfiguration, WhishperResult>
{
    WhishperConfiguration Configuration { get; set; } = new WhishperConfiguration();

    public WhishperRecognitionService(WhishperConfiguration configuration) => Configure(configuration);

    public IRecognitionService<WhishperConfiguration, WhishperResult> Configure(WhishperConfiguration configuration)
    {
        Configuration = configuration;
        return this;
    }

    public WhishperResult Transcribe(string audioFilePath)
    {
        using var whisperFactory = WhisperFactory.FromPath(Configuration.Model);

        using var processor = whisperFactory.CreateBuilder()
            .WithLanguage(Configuration.Language)
            .Build();

        using var fileStream = File.OpenRead(audioFilePath);

        Task.Run(async () =>
        {
            await foreach (var result in processor.ProcessAsync(fileStream))
            {
                Console.WriteLine($"{result.Start}->{result.End}: {result.Text}");
            }
        }).Wait();

        return null;
    }
}


