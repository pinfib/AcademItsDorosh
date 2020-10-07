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

        private string _difficultMode;

        public MinesweeperPresenter(Minesweeper model)
        {
            _model = model;
            _difficultMode = "Newbie";
        }

        public void SetView(IView view)
        {
            _view = view;
            _model.Win += _view.Win;
            _model.Defeat += _view.Defeat;
        }

        public void StartNewGame(object sender, EventArgs e)
        {
            var mode = Minesweeper.DifficultModes[_difficultMode];

            CreateField(mode.RowsCount, mode.ColumnsCount, mode.BombsCount);
        }

        public void CreateField(int rowsCount, int columnsCount, int bombsCount)
        {
            _model.CreateField(rowsCount, columnsCount, bombsCount);
            _view.CreateField(rowsCount, columnsCount, bombsCount);
        }

        public void FieldButtonLeftClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CellButton button = sender as CellButton;

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
            }
        }

        public void FieldButtonRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CellButton button = sender as CellButton;

                button.SetFlag();
            }
        }
    }
}
