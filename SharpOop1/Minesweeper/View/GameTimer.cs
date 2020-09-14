using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MinesweeperTask.View
{
    public class GameTimer : Label
    {
        int _second;
        int _minute;
        int _hour;

        Timer _timer;

        public GameTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Count;

            Dock = DockStyle.Fill;
            AutoSize = true;
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            BorderStyle = BorderStyle.Fixed3D;
            Font = new System.Drawing.Font("NewsGoth Cn BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Margin = new Padding(10, 20, 10, 20);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Reset()
        {
            _second = 0;
            _minute = 0;
            _hour = 0;
        }

        public void Count(object sender, EventArgs e)
        {
            _second++;

            if (_second == 60)
            {
                _second = 0;
                _minute++;

                if (_minute == 60)
                {
                    _minute = 0;
                    _hour++;

                    if (_hour == 12)
                    {
                        _hour = 0;
                    }
                }
            }

            Text = ToString();
        }

        public override string ToString()
        {
            return $"{_hour:00} : {_minute:00} : {_second:00}";
        }
    }
}
