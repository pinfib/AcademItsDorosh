using Academits.Dorosh.TemperatureTask.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Academits.Dorosh.TemperatureTask.View
{
    public partial class MainForm : Form
    {
        private TemperatureConverter _temperatureConverter;

        private Dictionary<int, Func<double, double>> _currentTemperature;

        private Dictionary<int, Func<double, double>> _resultTemperature;

        private enum Scales
        {
            Celsius = 0,
            Kelvin = 1,
            Fahrenheit = 2
        }

        public MainForm(TemperatureConverter temperatureConverter)
        {
            _temperatureConverter = temperatureConverter;

            int scalesCount = Enum.GetValues(typeof(Scales)).Length;

            _currentTemperature = new Dictionary<int, Func<double, double>>(scalesCount)  // перевести текущую температуру в Цельсий
            {
                [0] = (x) => x,                                             // если текущая температура в градусах Цельсия, ничего не делать
                [1] = _temperatureConverter.GetCelsiusFromKelvin,
                [2] = _temperatureConverter.GetCelsiusFromFahrenheit
            };

            _resultTemperature = new Dictionary<int, Func<double, double>>(scalesCount)
            {
                [0] = (x) => x,
                [1] = _temperatureConverter.GetKelvinFormCelsius,
                [2] = _temperatureConverter.GetFahrenheitFormCelsius
            };

            InitializeComponent();

            foreach (Scales scale in Enum.GetValues(typeof(Scales)))
            {
                currentScaleListBox.Items.Add(scale);
                resultScaleListBox.Items.Add(scale);
            }

            currentScaleListBox.SetSelected(0, true);
            resultScaleListBox.SetSelected(1, true);
        }

        private void getResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                double currentTemperature = Convert.ToDouble(currentTemperatureTextBox.Text);                   // получение текущей температуры

                int currentScale = (int)Enum.Parse(typeof(Scales), currentScaleListBox.SelectedItem.ToString());    // получение значения константы Scales
                int resultScale = (int)Enum.Parse(typeof(Scales), resultScaleListBox.SelectedItem.ToString());

                if (currentScale == resultScale)
                {
                    resultTemperatureTextBox.Text = currentTemperature.ToString();
                }
                else
                {
                    currentTemperature = _currentTemperature[currentScale](currentTemperature);  // текщую температуру перевести в шкалу Цельсия
                    double resultTemperature = _resultTemperature[resultScale](currentTemperature);  // перевести из Целься в выбранную шкалу

                    resultTemperature = Math.Round(resultTemperature, 2);

                    resultTemperatureTextBox.Text = resultTemperature.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}