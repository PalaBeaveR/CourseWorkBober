using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantUmlClassDiagramGenerator.Attributes;

namespace App.Controls;

[PlantUmlDiagram]
public class StopwatchTimer {
  [PlantUmlIgnoreAssociation]
  private readonly Stopwatch _stopwatch = new Stopwatch();

  private int      _totalLoops = 0;
  [PlantUmlIgnoreAssociation]
  private TimeSpan _lastTick    = TimeSpan.Zero;

  public bool IsRunning => this._stopwatch.IsRunning;

  private event EventHandler<TickEventArgs>? OnOnTick;

  public event EventHandler<TickEventArgs>? OnTick {
    add => this.OnOnTick += value;
    remove => this.OnOnTick -= value;
  }

  [PlantUmlIgnoreAssociation] private TimeSpan _interval;

  [PlantUmlIgnoreAssociation]
  public TimeSpan Interval {
    get => this._interval;
    set {
      this._interval = value;
      if (this._stopwatch.IsRunning) this._stopwatch.Restart();
      this._totalLoops = 0;
    }
  }

  public StopwatchTimer() {
    Task.Factory.StartNew(this.ThreadProc);
  }

  public void Start() {
    this._totalLoops = 0;
    this._stopwatch.Start();
  }

  private void ThreadProc() {
    while (true) {
      if (!this._stopwatch.IsRunning)
        continue;

      int loops = (int)(this._stopwatch.Elapsed /
                        this._interval);

      if (loops <= this._totalLoops) continue;

      this._totalLoops = loops;
      TimeSpan elapsed = this._stopwatch.Elapsed;
      this.OnOnTick?.Invoke(this, new TickEventArgs(elapsed - this._lastTick));
      this._lastTick = elapsed;
    }
  }

  public void Stop() {
    this._stopwatch.Stop();
  }

  public void Restart() {
    this._stopwatch.Restart();
    this._totalLoops = 0;
  }
}

public class TickEventArgs(TimeSpan delta) : EventArgs {
  public TimeSpan Delta = delta;
}