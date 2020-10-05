namespace Academits.Dorosh.TemperatureConverters
{
    public class CelsiusTemperatureConverter : ITemperatureConverter
    {
        public string ScaleName => "Цельсий";

        public double ConvertFromCelsius(double temperature)
        {
            return temperature;
        }

        public double ConvertToCelsius(double temperature)
        {
            return temperature;
        }
    }
}