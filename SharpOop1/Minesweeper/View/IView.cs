using Academits.Dorosh.MinesweeperTask.Presenter;
using System;

namespace Academits.Dorosh.MinesweeperTask.View
{
    public interface IView
    {
        void StartView();

        void SetPresenter(MinesweeperPresenter presenter);

        void CreateField(int cellsCount);

        void SetBombsCount(int BombsCount);

        void UpdateField();

        void ClearCell(object control);

        void OpenSurroundingCells(int column, int row);

        void SetInfo(int x, int y, int minesCount);

        void SetIcon(int x, int y, int icon);

        void Win(object sender, EventArgs e);

        void Defeat(object sender, EventArgs e);
    }
}