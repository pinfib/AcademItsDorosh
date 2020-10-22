using Academits.Dorosh.TemperatureTask.Model;
using Academits.Dorosh.TemperatureTask.View;
using System;
using System.Windows.Forms;

namespace Academits.Dorosh.TemperatureTask
{
    public static class TemperatureProgram
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var temperatureConverter = new TemperatureConverter();

                var view = new WindowsFormsView(temperatureConverter);

                view.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}