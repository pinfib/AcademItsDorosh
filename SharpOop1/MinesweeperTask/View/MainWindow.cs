using Academits.Dorosh.MinesweeperTask.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Academits.Dorosh.MinesweeperTask.View
{
    public partial class MainWindow : Form, IView
    {
        public MinesweeperPresenter _presenter;

        private TableLayoutPanel _gameField;

        private int _bombsCounter;

        public int BombsCounter
        {
            get
            {
                return _bombsCounter;
            }
            set
            {
                _bombsCounter = value;
                bombsCounterLabel.Text = _bombsCounter.ToString();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetPresenter(MinesweeperPresenter presenter)
        {
            _presenter = presenter;

            startNewGameButton.Click += _presenter.StartNewGame;
        }

        public void StartView()
        {
            Application.Run(this);
        }

        public void CreateField(int rowsCount, int columnsCount, int bombsCount)
        {
            if (_gameField != null)
            {
                _gameField.Dispose();
            }

            int fieldLength = 30;

            _gameField = new TableLayoutPanel();
            _gameField.ColumnCount = columnsCount;
            _gameField.RowCount = rowsCount;
            _gameField.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            _gameField.Margin = new Padding(0);
            _gameField.Padding = new Padding(0);
            _gameField.Width = columnsCount * fieldLength;
            _gameField.Height = rowsCount * fieldLength;
            _gameField.AutoSize = true;
            _gameField.TabIndex = 0;
            _gameField.BackColor = Color.White;

            for (int y = 0; y < rowsCount; y++)
            {
                _gameField.RowStyles.Add(new RowStyle(SizeType.Absolute, fieldLength));

                for (int x = 0; x < columnsCount; x++)
                {
                    _gameField.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, fieldLength));

                    CellButton button = new CellButton(x, y, fieldLength);

                    button.MouseDown += new MouseEventHandler(_presenter.FieldButtonLeftClick);
                    button.MouseDown += new MouseEventHandler(_presenter.FieldButtonRightClick);
                    button.CellFlagged += new EventHandler(DecreaseBombsCounter);
                    button.CellCleared += new EventHandler(IncreaseBombsCounter);

                    _gameField.Controls.Add(button, x, y);
                }
            }

            gameFieldPanel.Controls.Add(_gameField);

            BombsCounter = bombsCount;
        }

        private void DecreaseBombsCounter(object sender, EventArgs e)
        {
            BombsCounter--;
        }

        private void IncreaseBombsCounter(object sender, EventArgs e)
        {
            BombsCounter++;
        }

        public void ClearCell(object control)
        {
            CellButton currentButton = control as CellButton;
            currentButton.Dispose();
        }

        public void OpenSurroundingCells(int column, int row)
        {
            int sideLength = _gameField.ColumnCount;

            int sideWidth = column + 1;
            int sideHeight = row + 1;

            for (int i = row - 1; i <= sideHeight; i++)
            {
                for (int j = column - 1; j <= sideWidth; j++)
                {
                    if (i < 0 || j < 0 || i >= sideLength || j >= sideLength)
                    {
                        continue;
                    }

                    CellButton button = _gameField.GetControlFromPosition(j, i) as CellButton;

                    if (button != null && !button.IsFlagged())
                    {
                        _presenter.FieldButtonLeftClick(button, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    }
                }
            }
        }

        public void SetInfo(int x, int y, int bombsCount)
        {
            if (bombsCount > 0)
            {
                Label label = new Label();
                label.Margin = new Padding(0);
                label.Padding = new Padding(0);
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 204, true);

                switch (bombsCount)
                {
                    case 1:
                        label.ForeColor = Color.Blue;
                        break;
                    case 2:
                        label.ForeColor = Color.Green;
                        break;
                    case 3:
                        label.ForeColor = Color.Red;
                        break;
                    case 4:
                        label.ForeColor = Color.DarkBlue;
                        break;
                    case 5:
                        label.ForeColor = Color.Maroon;
                        break;
                    case 6:
                        label.ForeColor = Color.Turquoise;
                        break;
                    case 7:
                        label.ForeColor = Color.Black;
                        break;
                    case 8:
                        label.ForeColor = Color.Gray;
                        break;
                }

                label.Text = bombsCount.ToString();

                _gameField.Controls.Add(label, x, y);
            }
        }

        public void SetIcon(int x, int y, int icon)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Margin = new Padding(0);
            pictureBox.Padding = new Padding(0);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            switch (icon)
            {
                case 0:
                    pictureBox.Image = Image.FromFile(@"../../View/Images/explodingBomb.png");
                    break;
                case 1:
                    pictureBox.Image = Image.FromFile(@"../../View/Images/markedBomb.png");
                    break;
                default:
                    pictureBox.Image = Image.FromFile(@"../../View/Images/bomb.png");
                    break;
            }

            _gameField.Controls.Add(pictureBox, x, y);
        }

        public void GameTimerUpdate(string time)
        {
            gameTimerLabel.Text = time;
        }

        public void Win(object sender, EventArgs e)
        {
            MessageBox.Show("Вы победили!");
            _gameField.Enabled = false;
        }

        public void Defeat(object sender, EventArgs e)
        {
            MessageBox.Show("Вы проиграли!");
            _gameField.Enabled = false;
        }
    }
}
