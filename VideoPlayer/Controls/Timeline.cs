using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlantUmlClassDiagramGenerator.Attributes;

namespace App.Controls {
  [PlantUmlDiagram]
  public partial class Timeline : UserControl {
    private const uint TimelinePadding = 20;

    private event EventHandler? OnOnSliderDrag;

    public event EventHandler? OnSliderDrag {
      add => this.OnOnSliderDrag += value;
      remove => this.OnOnSliderDrag -= value;
    }

    public const uint Max = 10000;
    private uint _value;
    private uint LineWidth => (uint)this.Width - Timeline.TimelinePadding * 2;

    public double Percent => this.Value / (double)Timeline.Max;

    public uint Value {
      get => this._value;
      set {
        this._value = value;

        if (this.IsHandleCreated) {
          this.Invoke(this.Refresh);
        }
      }
    }

    public Timeline() {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint            |
                    ControlStyles.DoubleBuffer,
                    true
                   );
    }

    private const uint HandleDiameter = 10;
    private const uint HandleRadius   = Timeline.HandleDiameter / 2;

    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      Graphics g   = e.Graphics;
      Pen      pen = new Pen(Color.Red);
      pen.Width    = 5;
      pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
      pen.EndCap   = System.Drawing.Drawing2D.LineCap.Round;
      int y = this.Height / 2;
      g.DrawLine(
                 pen, new Point((int)Timeline.TimelinePadding,               y),
                 new Point((int)(Timeline.TimelinePadding + this.LineWidth), y)
                );
      pen.Color = Color.Blue;
      g.DrawEllipse(
                    pen,
                    Timeline.TimelinePadding +
                    this.LineWidth * this.Value / (float)Timeline.Max -
                    Timeline.HandleRadius, y - Timeline.HandleRadius,
                    Timeline.HandleDiameter, Timeline.HandleDiameter
                   );
    }

    protected override void OnMouseClick(MouseEventArgs e) {
      base.OnMouseClick(e);
      this.MoveTimeToCursor(e);
    }

    protected override void OnMouseMove(MouseEventArgs e) {
      base.OnMouseMove(e);
      this.MoveTimeToCursor(e);
    }

    private void MoveTimeToCursor(MouseEventArgs e) {
      if (e.Button != MouseButtons.Left) {
        return;
      }

      long x = Math.Min(
                       Math.Max(e.X - Timeline.TimelinePadding, 0),
                       this.LineWidth
                      );
      double percent = x == 0 ? 0 : x / (double)this.LineWidth;
      this.Value = (uint)(Timeline.Max * percent);
      this.OnOnSliderDrag?.Invoke(this, EventArgs.Empty);
    }
  }
}