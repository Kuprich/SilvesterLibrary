## Silvester

This utility allows you to extract text from an audio file

Silvester project is based on following two speech recognition services: [Vosk](https://alphacephei.com/vosk/) and [Whishper](https://github.com/sandrohanea/whisper.net)

Audio pre-processing role performed [FFmpeg](https://ffmpeg.org/): *Converting to wav and Noise reduction*

## Input and output data

Input:
    Audiofile with the following extensios: .mp3, .wav

Output:
    The result depends on the service when you used - [Vosk](https://alphacephei.com/vosk/) or [Whishper](https://github.com/sandrohanea/whisper.net)


## Requirements


1. For the [Vosk](https://alphacephei.com/vosk/) service to work, you need to select a recognition  model, which can be [downloaded here]()

1. Similar to Vosk, the [Whishper](https://github.com/sandrohanea/whisper.net) service also needs a model. Read more details [here](https://github.com/ggerganov/whisper.cpp/tree/master/models)

1. [FFmpeg](https://ffmpeg.org/) uses (AI based) [arrnndn](https://ffmpeg.org/ffmpeg-filters.html#arnndn)  command  to reduce background noise. Trained models (files.rnnn) [available here](https://github.com/GregorR/rnnoise-models). You need to download and use one of the files.

## Samples and Examples

*Example of using the Vosk service [available here](https://github.com/Kuprich/SilvesterLibrary/blob/dev/Silvester.VoskDemo/Program.cs).
And in [this example](https://github.com/Kuprich/SilvesterLibrary/blob/dev/Silvester.WhisperDemo/Program.cs) the whisper service is used*

Previously described services can use configuration files in json format

**Example FFMpegConfiguration.json file for FFMpeg service**

```json
{
  "arrndnModel": "src/ffmpeg/cb.rnnn",
  "samplingRate": 48000
}
```


>**Info:**
> Whishper service works only with audiofiles which use 16 kHz sampling rate. 
> For Vosk it is my recommended to use a sampling rate of 48kHz 

**Example of configuring the FFMpeg service**

An example of using the silverster library can be [seen here](https://github.com/Kuprich/SilvesterLibrary/blob/dev/Silvester.Console/Program.cs)

```C#
IAudioConverterService<FFMpegConfiguration> ffmpeg = new FFMpegService(
    new FFMpegConfiguration()
        .WithConfigurationFromFile("Services/FFMpegConfiguration.json"));
```
You can prepare an audio file for recognition with the following command:
```C#
string convertedAudiofile = ffmpeg.ConvertToWav("src/Test.mp3");
```


**Example of configuring the speech recognition services**

Configuring whishper service: 

```C#
IRecognitionService<WhishperConfiguration, WhishperResult> whisper = new WhishperService(
    new WhishperConfiguration()
        .WithConfigurationFromFile("Services/WhishperConfiguration.json"));
```

Vosk service is configured in the same way as described above:

```C#
IRecognitionService<VoskConfiguration, VoskResult> vosk = new VoskService(
    new VoskConfiguration()
        .WithConfigurationFromFile("Services/VoskConfiguration.json"));
```


You can start the recognition process, for example, using whispher as follows:

```C#
var result = whisper.Transcribe(convertedAudiofile);
```



