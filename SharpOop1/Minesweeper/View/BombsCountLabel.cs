using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academits.Dorosh.MinesweeperTask.View
{
    class BombsCountLabel : Label
    {
        private int _bombsCount;
        
        public BombsCountLabel()
        {
            Dock = DockStyle.Fill;
            AutoSize = true;
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            BorderStyle = BorderStyle.Fixed3D;
            Font = new System.Drawing.Font("NewsGoth Cn BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Margin = new Padding(10, 20, 10, 20);
            Text = _bombsCount.ToString();
        }

        internal void SetBombsCount(int bombsCount)
        {
            _bombsCount = bombsCount;
            Text = _bombsCount.ToString();
        }

        public void IncreaseBombsCounter(object sender, EventArgs e)
        {
            _bombsCount++;
            Text = _bombsCount.ToString();
        }

        public void DecreaseBombsCounter(object sender, EventArgs e)
        {
            _bombsCount--;
            Text = _bombsCount.ToString();
        }
    }
}
