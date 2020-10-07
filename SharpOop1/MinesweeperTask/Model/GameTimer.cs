using System;
using System.Timers;

namespace Academits.Dorosh.MinesweeperTask.Model
{
    public class GameTimer : Timer
    {
        private DateTime _time;

        public EventHandler TimeUpdated;

        public GameTimer() : base(1000)
        {
            AutoReset = true;
            Enabled = false;
            Elapsed += AddSecond;
        }

        private void AddSecond(object source, ElapsedEventArgs e)
        {
            _time = _time.AddSeconds(1);

            TimeUpdated(this, new GameTimerEventArgs(_time));
        }

        public void Reset()
        {
            _time = new DateTime(0);
        }
    }
}

