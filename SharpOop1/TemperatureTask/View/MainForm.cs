using Academits.Dorosh.TemperatureTask.Model;
using System;
using System.Windows.Forms;

namespace Academits.Dorosh.TemperatureTask.View
{
    public partial class MainForm : Form
    {
        readonly private TemperatureConverter _temperatureConverter;

        public MainForm(TemperatureConverter temperatureConverter)
        {
            _temperatureConverter = temperatureConverter;

            InitializeComponent();

            foreach (var scale in _temperatureConverter.List)
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
                double currentTemperature = Convert.ToDouble(currentTemperatureTextBox.Text);

                double resultTemperature = _temperatureConverter.ConvertTemperature(currentTemperature, currentScaleListBox.SelectedItem.ToString(), resultScaleListBox.SelectedItem.ToString());

                resultTemperatureTextBox.Text = resultTemperature.ToString();
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

        private void currentTemperatureTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getResultButton_Click(sender, e);
            }
        }
    }
}