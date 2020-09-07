using Academits.Dorosh.TemperatureTask.Model;
using Academits.Dorosh.TemperatureTask.View;
using System;


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
            TemperatureConverter temperatureConverter = new TemperatureConverter();

            IView view = new WindowsFormsView(temperatureConverter);

            view.Start();
        }
    }
}