using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Controls
{
    // Code from: https://stackoverflow.com/a/24843946
    public class MultimediaTimer : IDisposable
    {
        private bool _disposed = false;
        private int _interval, _resolution;
        private UInt32 _timerId;

        // Hold the timer callback to prevent garbage collection.
        private readonly MultimediaTimerCallback _callback;

        public MultimediaTimer()
        {
            this._callback   = new MultimediaTimerCallback(this.TimerCallbackMethod);
            this.Resolution = 5;
            this.Interval      = 10;
        }

        ~MultimediaTimer()
        {
            this.Dispose(false);
        }

        public int Interval
        {
            get
            {
                return this._interval;
            }
            set
            {
                this.CheckDisposed();

                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");

                this._interval = value;
                if (this.Resolution > this.Interval) this.Resolution = value;
            }
        }

        // Note minimum resolution is 0, meaning highest possible resolution.
        public int Resolution
        {
            get
            {
                return this._resolution;
            }
            set
            {
                this.CheckDisposed();

                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");

                this._resolution = value;
            }
        }

        public bool IsRunning
        {
            get { return this._timerId != 0; }
        }

        public void Start()
        {
            this.CheckDisposed();

            if (this.IsRunning)
                throw new InvalidOperationException("Timer is already running");

            // Event type = 0, one off event
            // Event type = 1, periodic event
            UInt32 userCtx = 0;
            this._timerId = NativeMethods.TimeSetEvent((uint)this.Interval, (uint)this.Resolution, this._callback, ref userCtx, 1);
            if (this._timerId == 0)
            {
                int error = Marshal.GetLastWin32Error();
                throw new Win32Exception(error);
            }
        }

        public void Stop()
        {
            this.CheckDisposed();

            if (!this.IsRunning)
                throw new InvalidOperationException("Timer has not been started");

            this.StopInternal();
        }

        private void StopInternal()
        {
            NativeMethods.TimeKillEvent(this._timerId);
            this._timerId = 0;
        }

        public event EventHandler OnElapsed;

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void TimerCallbackMethod(uint id, uint msg, ref uint user_ctx, uint rsv1, uint rsv2)
        {
            EventHandler? handler = this.OnElapsed;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void CheckDisposed()
        {
            if (this._disposed)
                throw new ObjectDisposedException("MultimediaTimer");
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed)
                return;

            this._disposed = true;
            if (this.IsRunning)
            {
                this.StopInternal();
            }

            if (disposing)
            {
                this.OnElapsed = null;
                GC.SuppressFinalize(this);
            }
        }
    }

    internal delegate void MultimediaTimerCallback(UInt32 id, UInt32 msg, ref UInt32 user_ctx, UInt32 rsv1, UInt32 rsv2);

    internal static class NativeMethods
    {
        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeSetEvent")]
        internal static extern UInt32 TimeSetEvent(UInt32 ms_delay, UInt32 ms_resolution, MultimediaTimerCallback callback, ref UInt32 user_ctx, UInt32 event_type);

        [DllImport("winmm.dll", SetLastError = true, EntryPoint = "timeKillEvent")]
        internal static extern void TimeKillEvent(UInt32 u_timer_id);
    }
}
