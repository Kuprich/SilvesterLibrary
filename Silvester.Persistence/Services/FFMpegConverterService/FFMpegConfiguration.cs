﻿using Silvester.Persistence.Abstractions;

namespace Silvester.Persistence.Services.FFMpegConverterService;

public class FFMpegConfiguration : IAudioConverterServiceConfiguration
{
    public string ArrndnModel { get; set; } = "cb.rnnn";
    public int SamplingRate { get; set; } = 48_000;
}