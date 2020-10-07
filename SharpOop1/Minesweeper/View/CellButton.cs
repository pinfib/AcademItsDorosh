using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academits.Dorosh.MinesweeperTask.View
{
    public class CellButton : Button
    {
        private bool _flag;
        
        //public int Flag { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public event EventHandler CellFlagged;
        public event EventHandler CellCleared;

        public CellButton(int x, int y, int size)
        {
            X = x;
            Y = y;

            Dock = DockStyle.Fill;
            Margin = new Padding(0);
            Padding = new Padding(0);
            MinimumSize = new Size(size, size);
            Name = "button";
            TabIndex = 0;
            Text = "";
            UseVisualStyleBackColor = true;
        }

        public void SetFlag()
        {
            if(_flag)
            {
                _flag = false;

                Image = null;

                CellCleared(this, EventArgs.Empty);
            }
            else
            {
                _flag = true;

                Image = Image.FromFile(@"../../View/Images/Mark1.png");

                CellFlagged(this, EventArgs.Empty);
            }
        }

        public bool IsFlagged()
        {
            return _flag;
        }
    }
}
