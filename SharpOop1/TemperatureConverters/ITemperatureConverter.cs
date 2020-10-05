namespace Academits.Dorosh.TemperatureConverters
{
    public interface ITemperatureConverter
    {
        string ScaleName { get; }
        
        double ConvertToCelsius(double temperature);

        double ConvertFromCelsius(double temperature);
    }
}