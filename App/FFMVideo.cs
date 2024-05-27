using FFMediaToolkit.Decoding;
using FFMediaToolkit.Graphics;
using FFMediaToolkit.Audio;
using FFmpeg.AutoGen;
using PlantUmlClassDiagramGenerator.Attributes;
using Size = System.Drawing.Size;

namespace App;

// ReSharper disable once InconsistentNaming
[PlantUmlDiagram]
public class FFMVideo: IDisposable {
  [PlantUmlIgnoreAssociation]
  private readonly MediaFile _video;

  [PlantUmlIgnoreAssociation]
  public Size? Size => this._video?.Video.Info.FrameSize;

  public int? SampleRate => this._video?.Audio.Info.SampleRate;

  [PlantUmlIgnoreAssociation]
  public VideoStreamInfo VideoInfo => this._video.Video.Info;
  [PlantUmlIgnoreAssociation]
  public MediaInfo Info => this._video.Info;
  [PlantUmlIgnoreAssociation]
  public AudioStreamInfo AudioInfo => this._video.Audio.Info;
  
  public double Fps {
    get {
      AVRational rFps = this._video.Video.Info.RealFrameRate;
      return rFps.num / (double)rFps.den;
    }
  }

  public int? FrameCount => this._video.Video.Info.NumberOfFrames;

  
  [PlantUmlIgnoreAssociation]
  public TimeSpan Position => this._video.Video.Position;
  [PlantUmlIgnoreAssociation]
  public TimeSpan Duration => this._video.Video.Info.Duration;

  public FFMVideo(string video_path) {
    try {
      this._video   = MediaFile.Open(video_path);
    } catch (Exception ex) {
      throw new Exception(@$"Could not open video file\n{ex.Message}");
    }
  }

  public void SeekFrame(TimeSpan time) {
    this._video.Video.GetFrame(time);
    Console.WriteLine("Video Time: " + this._video.Video.Position);

    this._video.Audio.GetFrame(this._video.Video.Position);
    Console.WriteLine("Audio Time: " + this._video.Audio.Position);
  }
    
  public bool GetNextFrame(out ImageData bitmap) {
    if (!this._video.Video.TryGetNextFrame(out bitmap)) return false;

    return true;

  }

  public void SkipFrame() {
    this._video.Video.GetNextFrame();
    this._video.Audio.GetNextFrame();
  }

  public float[]? GetNextAudio() {
    return this._video.Audio.TryGetNextFrame(out AudioData audio)
             ? audio.GetChannelData(0).ToArray()
             : null;
  }

  public void Dispose() {
    this._video.Dispose();
  }
}