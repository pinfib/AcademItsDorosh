using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academits.Dorosh.MinesweeperTask.Model;
using Academits.Dorosh.MinesweeperTask.View;
using Academits.Dorosh.MinesweeperTask.Presenter;

namespace Academits.Dorosh.MinesweeperTask
{
    static class MinesweeperProgram
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MinesweeperPresenter presenter = new MinesweeperPresenter(new Minesweeper());

            IView view = new MainWindow(presenter);
            presenter.SetView(view);

            view.StartView();
        }
    }
}
