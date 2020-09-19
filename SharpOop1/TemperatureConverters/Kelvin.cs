namespace Academits.Dorosh.TemperatureConverters
{
    public class Kelvin : IConverter
    {
        public Kelvin()
        {
        }

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