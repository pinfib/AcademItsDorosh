using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academits.Dorosh.MinesweeperTask.View
{
    public class CellButton : Button
    {
        public int Flag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public event EventHandler CellFlagged;
        public event EventHandler CellCleared;

        public CellButton(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetFlag()
        {
            Flag++;


            if (Flag == 3)
            {
                Flag = 0;

                CellCleared(this, EventArgs.Empty);
            }
            else
            {
                CellFlagged(this, EventArgs.Empty);
            }
        }
    }
}
