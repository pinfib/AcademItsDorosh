namespace Academits.Dorosh.TemperatureConverters
{
    public class KelvinTemperatureConverter : ITemperatureConverter
    {
        public string ScaleName => "Кельвин";

        public double ConvertFromCelsius(double temperature)
        {
            return temperature + 273.15;
        }

        public double ConvertToCelsius(double temperature)
        {
            return temperature - 273.15;
        }
    }
}