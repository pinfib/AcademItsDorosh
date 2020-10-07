using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academits.Dorosh.MinesweeperTask.Presenter;

namespace Academits.Dorosh.MinesweeperTask.View
{
    public interface IView
    {
        void SetPresenter(MinesweeperPresenter presenter);

        void StartView();

        void CreateField(int rowsCount, int columnsCount, int bombsCount);

        void GameTimerUpdate(string time);

        void ClearCell(object control);

        void OpenSurroundingCells(int column, int row);

        void SetInfo(int x, int y, int minesCount);

        void SetIcon(int x, int y, int icon);

        void Win(object sender, EventArgs e);

        void Defeat(object sender, EventArgs e);
    }
}
