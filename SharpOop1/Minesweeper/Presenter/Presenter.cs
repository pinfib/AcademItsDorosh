using Academits.Dorosh.MinesweeperTask.Model;
using Academits.Dorosh.MinesweeperTask.View;
using System;
using System.Windows.Forms;

namespace Academits.Dorosh.MinesweeperTask.Presenter
{
    public class MinesweeperPresenter
    {
        private Minesweeper _model;

        private IView _view;

        //TODO: можно enum???
        //public Dictionary<string, int[]> difficultModes;

        public MinesweeperPresenter(Minesweeper model)
        {
            _model = model;
        }

        public void SetView(IView view)
        {
            _view = view;
            _model.Win += _view.Win;
            _model.Defeat += _view.Defeat;
        }

        public void StartNewGame()
        {
            CreateField(9, 10);
            _view.SetBombsCount(10);
        }

        public void CreateField(int cellsCount, int minesCount)
        {

            _model.CreateField(cellsCount, minesCount);
            _view.CreateField(cellsCount);
        }

        public void NewGameButton_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        public void FieldButton_Click(object sender, EventArgs e) //MouseEventArgs
        {
            CellButton button = sender as CellButton;

            //if (e.Button == MouseButtons.Left)
            //{
            int x = button.X;
            int y = button.Y;

            _view.ClearCell(sender);

            int bombsCount = _model.CheckBomb(x, y);

            if (bombsCount < 0)
            {
                _view.SetIcon(x, y, 0);
            }
            else if (bombsCount > 0)
            {
                _view.SetInfo(x, y, bombsCount);
            }
            else
            {
                _view.OpenSurroundingCells(x, y);
            }

            //else if (e.Button == MouseButtons.Right)
            //{

            //}
        }
    }
}
