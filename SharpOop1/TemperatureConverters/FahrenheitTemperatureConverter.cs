namespace Academits.Dorosh.TemperatureConverters
{
    public class FahrenheitTemperatureConverter : ITemperatureConverter
    {
        public string ScaleName => "Фаренгейт";

        public double ConvertFromCelsius(double temperature)
        {
            return temperature * 9 / 5 + 32;
        }

        public double ConvertToCelsius(double temperature)
        {
            return (temperature - 32) * 5 / 9;
        }
    }
}