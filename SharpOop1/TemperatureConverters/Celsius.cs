namespace Academits.Dorosh.TemperatureConverters
{
    public class Celsius : IConverter
    {
        public Celsius()
        {
        }

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