using App.Controls;
using NAudio.Wave;
using System.Globalization;
using FFMediaToolkit.Graphics;
using PlantUmlClassDiagramGenerator.Attributes;

namespace App {
  [PlantUmlDiagram]
  public partial class VideoPlayer : UserControl {
    [PlantUmlAssociation(
      Name = "FFMVideo", Association = "o-->", LeafLabel = "_video"
    )]
    private FFMVideo? _video;

    [PlantUmlAssociation(
      Name = "OpenGLDisplay", Association = "o-->", LeafLabel = "frame"
    )]
    private int _nothing;

    [PlantUmlIgnoreAssociation] public FFMVideo? Video => this._video;
    private                            string?   _videoPath;

    public string? VideoPath {
      get => this._videoPath;
      set {
        if (value == null) {
          this.playButton.Enabled = false;

          return;
        }

        this._video = new FFMVideo(value);

        if (this._video.Size != null)
          this.frame.ImageSize = this._video.Size.Value;
        if (this._video.SampleRate != null)
          this.SetSampleRate(this._video.SampleRate.Value);

        if (this._timer.IsRunning) this._timer.Stop();
        this._timer.Interval
          = TimeSpan.FromMilliseconds(1000 / this._video.Fps);
        this.playButton.Enabled = true;
        this.RenderNextFrame(TimeSpan.FromSeconds(10));

        int? frameCount                               = this._video?.FrameCount;
        if (frameCount != null) this.timeline.Maximum = frameCount.Value;

        this._videoPath = value;
      }
    }

    [PlantUmlIgnoreAssociation] BufferedWaveProvider _bufferedWaveProvider;

    private AudioSpeedSampleProvider _sampleProvider;

    [PlantUmlIgnoreAssociation]
    private readonly DirectSoundOut _soundOut = new DirectSoundOut();

    public VideoPlayer() {
      this.InitializeComponent();
      this._timer.OnTick += this.timer1_Tick;
    }

    private void SetSampleRate(int sample_rate) {
      //      this._soundOut.Init(
      //                    new RawSourceWaveStream(
      //                                            this._audioStream,
      //                                            WaveFormat
      //                                             .CreateIeeeFloatWaveFormat(
      //                                                 sample_rate, 1
      //                                                )
      //                                           )
      //                   );

      this._bufferedWaveProvider = new BufferedWaveProvider(
        WaveFormat
         .CreateIeeeFloatWaveFormat(
            sample_rate, 1
          )
      );

      this._sampleProvider = new AudioSpeedSampleProvider(
        WaveFormat
         .CreateIeeeFloatWaveFormat(
            sample_rate, 1
          )
      );
      this._soundOut.Init(
        this._sampleProvider
      );
    }

    private readonly StopwatchTimer _timer = new StopwatchTimer();

    [PlantUmlIgnore]
    private void timer1_Tick(object? sender, TickEventArgs e) {
      this.RenderNextFrame(e.Delta);
    }

    private void playButton_Click(object sender, EventArgs e) {
      if (this._timer.IsRunning) {
        this._timer.Stop();
        this._soundOut.Pause();
        this.playButton.Text = @"⏵";
      } else {
        this._timer.Start();
        this._soundOut.Play();
        this.playButton.Text = @"⏸";
      }
    }

    [PlantUmlIgnoreAssociation] private readonly List<long> _frames = [];

    private TimeSpan? _queuedFrame;

    [PlantUmlIgnore]
    private void timeline_OnScroll(object sender, EventArgs e) {
      if (this._video?.FrameCount == null) return;
      this._timer.Restart();

      this._queuedFrame
        = this.timeline.Value / (double)this.timeline.Maximum *
          this._video.Duration;
      if (!this._timer.IsRunning)
        this.RenderNextFrame(TimeSpan.FromSeconds(10));
    }

    private void RenderNextFrame(TimeSpan delta) {
      this.fpsLabel.Invoke(
        () => this.fpsLabel.Text = ((int)(TimeSpan.FromSeconds(1) /
                                          delta)).ToString(
                CultureInfo.CurrentCulture
              )
      );

      if (this._video == null) return;

      if (this._queuedFrame != null) {
        this._video.SeekFrame(this._queuedFrame.Value);
        this._queuedFrame = null;
        this._sampleProvider.Clear();
      }


      if (!this._video.GetNextFrame(out ImageData mbBmp)) {
        this._timer.Stop();

        return;
      }

      this.frame.Image = mbBmp.Data.ToArray();

      float[]? audio = this._video.GetNextAudio();

      if (audio != null) {
        byte[] byteArray = new byte[audio.Length * sizeof(float)];
        System.Buffer.BlockCopy(audio, 0, byteArray, 0, byteArray.Length);

        this._sampleProvider.AddSamples(byteArray, 0, byteArray.Length);

        this._soundOut.Play();
      }

      this.timeline.Value = (int)(this.timeline.Maximum *
                                  (this._video.Position /
                                   this._video.Duration));
    }

    [PlantUmlIgnore]
    private void button1_Click(object sender, EventArgs e) {
      this._timer.Interval
        = TimeSpan.FromMilliseconds(1000 / this._video.Fps * 2);
      this._sampleProvider.SpeedMultiplier = -2;

      if (this._timer.IsRunning) {
        this._timer.Stop();
        this._timer.Start();
      }
    }

    [PlantUmlIgnore]
    private void button2_Click(object sender, EventArgs e) {
      this._timer.Interval = TimeSpan.FromMilliseconds(1000 / this._video.Fps);
      this._sampleProvider.SpeedMultiplier = 0;

      //      this.SetSampleRate(this._video.SampleRate);

      if (this._timer.IsRunning) {
        this._timer.Stop();
        this._timer.Start();
      }
    }

    [PlantUmlIgnore]
    private void button3_Click(object sender, EventArgs e) {
      this._timer.Interval
        = TimeSpan.FromMilliseconds(1000 / this._video.Fps / 2);
      this._sampleProvider.SpeedMultiplier = 2;

      //      this.SetSampleRate(this._video.SampleRate / 2);

      if (this._timer.IsRunning) {
        this._timer.Stop();
        this._timer.Start();
      }
    }
  }
}