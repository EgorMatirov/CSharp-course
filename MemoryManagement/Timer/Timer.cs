using System;
using System.Diagnostics;

namespace Timer
{
    public class Timer
    {
        private readonly Stopwatch _stopwatch;

        public Timer()
        {
            _stopwatch = new Stopwatch();
        }

        public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;

        public TimerDisposable Start()
        {
            _stopwatch.Restart();
            return new TimerDisposable(this);
        }

        public TimerDisposable Continue()
        {
            _stopwatch.Start();
            return new TimerDisposable(this);
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }

        public class TimerDisposable : IDisposable
        {
            private readonly Timer _timer;

            public TimerDisposable(Timer timer)
            {
                _timer = timer;
            }

            public void Dispose()
            {
                _timer.Stop();
            }
        }
    }
}