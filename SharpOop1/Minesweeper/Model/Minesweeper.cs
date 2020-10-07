using System;
using System.Collections.Generic;

namespace Academits.Dorosh.MinesweeperTask.Model
{
    public class Minesweeper
    {
        private bool[,] _field;

        private int _closedCells;

        private int _bombsCount;

        public static Dictionary<string, DifficultMode> DifficultModes { get; }

        public event EventHandler Win;

        public event EventHandler Defeat;

        static Minesweeper()
        {
            DifficultModes = new Dictionary<string, DifficultMode>
            {
                ["Newbie"] = new DifficultMode ( 9, 9, 10 ),
                ["Dilettant"] = new DifficultMode ( 16, 16, 40),
                ["Expert"] = new DifficultMode ( 16, 30, 99 )
            };
        }

        public Minesweeper() : this(9, 9, 10)
        {
        }

        public Minesweeper(int rowsCount, int columnsCount, int bombsCount)
        {
            CreateField(rowsCount, columnsCount, bombsCount);
        }

        public void CreateField(int rowsCount, int columnsCount, int bombsCount)
        {
            _closedCells = rowsCount * columnsCount;

            _bombsCount = bombsCount;

            _field = new bool[rowsCount, columnsCount];

            Random random = new Random();

            for (int i = 0; i < bombsCount; i++)
            {
                while (true)
                {
                    int x = random.Next(0, rowsCount);
                    int y = random.Next(0, columnsCount);

                    if (_field[x, y])
                    {
                        continue;
                    }

                    _field[x, y] = true;

                    break;
                }
            }
        }

        public int CheckBomb(int x, int y)
        {
            if (_field[x, y])
            {
                Defeat(this, EventArgs.Empty);
                return -1;
            }

            int sideLength = _field.GetLength(0);
            int countBombs = 0;

            int sideWidth = x + 1;
            int sideHeight = y + 1;

            _closedCells--;

            if (_closedCells == _bombsCount)
            {
                Win(this, EventArgs.Empty);
            }

            for (int i = y - 1; i <= sideHeight; i++)
            {
                for (int j = x - 1; j <= sideWidth; j++)
                {
                    if (i < 0 || j < 0 || i >= sideLength || j >= sideLength)
                    {
                        continue;
                    }

                    countBombs += Convert.ToInt32(_field[j, i]);
                }
            }

            return countBombs;
        }

        public int[,] OpenAllBombs()
        {
            int[,] bombsCoordinates = new int[2, _bombsCount];
            int bombsLeft = _bombsCount;

            int sideLength = _field.GetLength(0);
            int k = 0;

            for (int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j < sideLength; j++)
                {
                    if (_field[j, i])
                    {
                        bombsCoordinates[k, 0] = j;
                        bombsCoordinates[k, 1] = i;

                        k++;
                        bombsLeft--;
                    }

                    if (_bombsCount == bombsLeft)
                    {
                        break;
                    }
                }
            }

            return bombsCoordinates;
        }
    }
}
