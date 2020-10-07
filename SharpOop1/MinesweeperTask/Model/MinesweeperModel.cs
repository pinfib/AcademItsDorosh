using System;
using System.Collections.Generic;

namespace Academits.Dorosh.MinesweeperTask.Model
{
    public class MinesweeperModel
    {
        private bool[,] _field;

        private int _closedCells;

        private int _bombsCount;

        public GameTimer Timer { get; }

        public Dictionary<string, DifficultMode> DifficultModes { get; }

        public event EventHandler Win;

        public event EventHandler Defeat;

        public MinesweeperModel()
        {
            DifficultModes = new Dictionary<string, DifficultMode>
            {
                ["Test"] = new DifficultMode(5, 11, 5),
                ["Newbie"] = new DifficultMode(9, 9, 10),
                ["Intermediate"] = new DifficultMode(16, 16, 40),
                ["Expert"] = new DifficultMode(16, 30, 99)
            };

            Timer = new GameTimer();
        }

        public void CreateField(int rowsCount, int columnsCount, int bombsCount)
        {
            _closedCells = rowsCount * columnsCount;

            _bombsCount = bombsCount;

            _field = new bool[columnsCount, rowsCount];

            Random random = new Random();

            for (int i = 0; i < bombsCount; i++)
            {
                while (true)
                {
                    int x = random.Next(0, columnsCount);
                    int y = random.Next(0, rowsCount);

                    if (_field[x, y])
                    {
                        continue;
                    }

                    _field[x, y] = true;

                    break;
                }
            }
        }

        public int CheckBomb(int x, int y) // TODO: переименовать
        {
            if (_field[x, y])
            {
                Defeat(this, EventArgs.Empty);
                return -1;
            }

            int side1Length = _field.GetLength(0);
            int side2Length = _field.GetLength(1);
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
                    if (i < 0 || j < 0 || i >= side2Length || j >= side1Length)
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
