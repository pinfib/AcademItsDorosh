using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academits.Dorosh.MinesweeperTask.Model;
using Academits.Dorosh.MinesweeperTask.View;

namespace Academits.Dorosh.MinesweeperTask.Presenter
{
    public class MinesweeperPresenter
    {
        private readonly IView _view;

        private readonly MinesweeperModel _model;

        private DifficultMode _currentDifficultMode;

        public MinesweeperPresenter(IView view, MinesweeperModel model)
        {
            _view = view;
            _model = model;

            _view.SetPresenter(this);
            
            _currentDifficultMode = _model.DifficultModes["Test"];

            _model.Timer.TimeUpdated += GameTimerUpdate;
            _model.Timer.SynchronizingObject = (ISynchronizeInvoke)_view;

            _model.Win += Win;
            _model.Defeat += Defeat;

            StartNewGame(this, EventArgs.Empty);

            _view.StartView();
        }

        public void StartNewGame(object sender, EventArgs e)
        {
            _model.CreateField(_currentDifficultMode.RowsCount, _currentDifficultMode.ColumnsCount, _currentDifficultMode.BombsCount);
            _view.CreateField(_currentDifficultMode.RowsCount, _currentDifficultMode.ColumnsCount, _currentDifficultMode.BombsCount);

            _model.Timer.Reset();
            _model.Timer.Start();
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

        public void GameTimerUpdate(object sender, EventArgs e)
        {
            var args = e as GameTimerEventArgs;
            
            _view.GameTimerUpdate(args.Time.ToString("mm:ss"));
        }

        public void Win(object sender, EventArgs e)
        {
            _view.Win(sender, e);
            _model.Timer.Stop();
        }

        public void Defeat(object sender, EventArgs e)
        {
            _view.Defeat(sender, e);
            _model.Timer.Stop();
        }
    }
}
