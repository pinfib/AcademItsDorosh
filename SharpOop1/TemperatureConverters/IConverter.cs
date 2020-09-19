namespace Academits.Dorosh.TemperatureConverters
{
    public interface IConverter
    {
        double ConvertToCelsius(double temperature);

        double ConvertFromCelsius(double temperature);
    }
}