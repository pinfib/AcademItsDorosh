using Academits.Dorosh.MinesweeperTask.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Academits.Dorosh.MinesweeperTask.View
{
    public partial class MainWindow : Form, IView
    {
        private MinesweeperPresenter _presenter;

        private TableLayoutPanel _gameField;

        private BombsCountLabel _bombsCountLabel;

        private GameTimerLabel _gameTimer;

        public MainWindow(MinesweeperPresenter presenter)
        {
            _presenter = presenter;

            InitializeComponent();

            newGameButton.Click += _presenter.StartNewGame;

            _bombsCountLabel = new BombsCountLabel();
            infoTableLayoutPanel.Controls.Add(_bombsCountLabel, 0, 0);

            _gameTimer = new GameTimerLabel();
            infoTableLayoutPanel.Controls.Add(_gameTimer, 3, 0);

            CreateField(9, 9, 10);
            //_presenter.CreateField(9, 9, 10);
            //_presenter.StartNewGame(this, EventArgs.Empty);
        }

        public void StartView()
        {
            
            Application.Run(this);
        }

        public void SetPresenter(MinesweeperPresenter presenter)
        {
            _presenter = presenter;
        }

        public void CreateField(int rowsCount, int columnsCount, int bombsCount)
        {
            _gameTimer.Reset();
            _bombsCountLabel.SetBombsCount(bombsCount);

            if (_gameField != null)
            {
                _gameField.Dispose();
            }

            int fieldLength = 30;

            _gameField = new TableLayoutPanel();
            _gameField.ColumnCount = columnsCount;
            _gameField.RowCount = rowsCount;
            _gameField.Name = "mineField";
            _gameField.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            _gameField.Margin = new Padding(0);
            _gameField.Padding = new Padding(0);
            _gameField.Width = columnsCount * fieldLength;     
            _gameField.Height = rowsCount * fieldLength;           
            _gameField.AutoSize = true;
            _gameField.TabIndex = 0;
            _gameField.Location = new Point(10, 73);
            _gameField.BackColor = Color.White;

            for (int i = 0; i < rowsCount; i++)
            {
                _gameField.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, fieldLength));
                _gameField.RowStyles.Add(new RowStyle(SizeType.Absolute, fieldLength));

                for (int j = 0; j < columnsCount; j++)
                {
                    CellButton button = new CellButton(j, i, fieldLength);

                    button.MouseDown += new MouseEventHandler(_presenter.FieldButtonLeftClick);
                    button.MouseDown += new MouseEventHandler(_presenter.FieldButtonRightClick);
                    button.CellFlagged += new EventHandler(_bombsCountLabel.DecreaseBombsCounter);
                    button.CellCleared += new EventHandler(_bombsCountLabel.IncreaseBombsCounter);

                    _gameField.Controls.Add(button, j, i);
                }
            }

            mainTableLayoutPanel.Controls.Add(_gameField, 0, 1);

            _gameTimer.Start();
        }

        public void UpdateField()
        {
            _gameField.Refresh();
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
                label.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)), true);

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
                    default:
                        label.ForeColor = Color.Black;
                        break;
                }

                label.Text = bombsCount.ToString();

                _gameField.Controls.Add(label, x, y);
            }
        }

        public void SetIcon(int x, int y, int icon) //TODO: enum
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

        public void Win(object sender, EventArgs e)
        {
            _gameTimer.Stop();
            MessageBox.Show("Вы победили!");
        }

        public void Defeat(object sender, EventArgs e)
        {
            _gameTimer.Stop();
            MessageBox.Show("Вы проиграли!");
        }
    }
}
