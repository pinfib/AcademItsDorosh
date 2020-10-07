using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Dorosh.MinesweeperTask.Model
{
    public class GameTimerEventArgs : EventArgs
    {
        public DateTime Time { get; set; }

        public GameTimerEventArgs(DateTime time)
        {
            Time = time;
        }
    }
}
