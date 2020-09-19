namespace Academits.Dorosh.TemperatureConverters
{
    public class Fahrenheit : IConverter
    {
        public Fahrenheit()
        {
        }

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