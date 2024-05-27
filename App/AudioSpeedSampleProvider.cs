using NAudio.Wave;
using PlantUmlClassDiagramGenerator.Attributes;

namespace App;

[PlantUmlDiagram]
public class AudioSpeedSampleProvider : ISampleProvider {
  [PlantUmlIgnoreAssociation]
  private BufferedWaveProvider _bufferedWaveProvider;

  [PlantUmlIgnoreAssociation] private ISampleProvider _sampleProvider;

  public int SpeedMultiplier = 0;


  public AudioSpeedSampleProvider(WaveFormat wave_format) {
    this._bufferedWaveProvider = new BufferedWaveProvider(wave_format);
    this._sampleProvider       = this._bufferedWaveProvider.ToSampleProvider();
  }

  public void Clear() {
    this._bufferedWaveProvider.ClearBuffer();
  }

  public int Read(float[] buffer, int offset, int count) {
    switch (this.SpeedMultiplier) {
    case 0:
      return this._sampleProvider.Read(buffer, offset, count);
    case > 0: {
      // Fast

      float[] buff = new float[count * this.SpeedMultiplier];

      int read = this._sampleProvider.Read(
        buff, 0, count * this.SpeedMultiplier
      );

      int   sampleIndex = 0;
      float average     = 0;

      for (int i = 0; i < buff.Length; i++) {
        average += buff[i];

        if (i % this.SpeedMultiplier != 0) continue;

        average /= this.SpeedMultiplier;

        buffer[offset + sampleIndex] = average;
        average                      = 0;
        sampleIndex++;
      }

      return sampleIndex;
    }
    case < 0: {
      // Slow
      int multiplier  = -this.SpeedMultiplier;
      int needSamples = (int)Math.Ceiling(count / (decimal)multiplier);

      float[] buff = new float[needSamples];

      int read = this._sampleProvider.Read(buff, 0, needSamples);

      int sampleIndex = 0;

      for (int i = 0; i < buff.Length; i++) {
        for (int n = 0; n < multiplier; n++) {
          buffer[sampleIndex] = buff[i];
          sampleIndex++;
        }
      }

      return sampleIndex;
    }
    }
  }

  public void AddSamples(byte[] buffer, int offset, int count) {
    this._bufferedWaveProvider.AddSamples(buffer, offset, count);
  }

  [PlantUmlIgnoreAssociation]
  public WaveFormat WaveFormat => this._bufferedWaveProvider.WaveFormat;
}