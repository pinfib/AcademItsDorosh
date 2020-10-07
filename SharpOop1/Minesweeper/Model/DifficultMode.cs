namespace Academits.Dorosh.MinesweeperTask.Model
{
    public struct DifficultMode
    {
        public int RowsCount { get; }
        public int ColumnsCount { get; }
        public int BombsCount { get; }

        public DifficultMode(int rowsCount, int columnsCount, int bombsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            BombsCount = bombsCount;
        }
    }
}