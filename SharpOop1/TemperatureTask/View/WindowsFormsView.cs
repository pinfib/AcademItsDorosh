using Academits.Dorosh.TemperatureTask.Model;
using System.Windows.Forms;

namespace Academits.Dorosh.TemperatureTask.View
{
    public class WindowsFormsView : IView
    {
        private TemperatureConverter _temperatureConverter;

        public WindowsFormsView(TemperatureConverter temperatureConverter)
        {
            _temperatureConverter = temperatureConverter;
        }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(_temperatureConverter));
        }
    }
}