namespace Academits.Dorosh.TemperatureTask.Model
{
    public class TemperatureConverter
    {
        public double GetKelvinFormCelsius(double celsiusDegrees)
        {
            return celsiusDegrees + 273.15;
        }

        public double GetFahrenheitFormCelsius(double celsiusDegrees)
        {
            return celsiusDegrees * 9 / 5 + 32;
        }

        public double GetCelsiusFromKelvin(double kelvinDegrees)
        {
            return kelvinDegrees - 273.15;
        }

        public double GetCelsiusFromFahrenheit(double fahrenheitDegrees)
        {
            return (fahrenheitDegrees - 32) * 5 / 9;
        }
    }
}