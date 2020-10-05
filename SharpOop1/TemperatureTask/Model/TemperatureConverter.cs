using Academits.Dorosh.TemperatureConverters;
using System;
using System.Collections.Generic;
using System.Reflection;


namespace Academits.Dorosh.TemperatureTask.Model
{
    public class TemperatureConverter
    {
        private readonly Assembly _assembly;

        private readonly Dictionary<string, ITemperatureConverter> _converters;

        public List<string> ScalesList { get; }

        public TemperatureConverter()
        {
            _assembly = typeof(ITemperatureConverter).Assembly;

            var types = _assembly.GetTypes();

            if (types == null)
            {
                throw new ArgumentNullException(nameof(types), "Не удалось получить перечень классов из сборки");
            }

            ScalesList = new List<string>();
            _converters = new Dictionary<string, ITemperatureConverter>(types.Length);

            foreach (var type in types)
            {
                if (type.GetInterface(nameof(ITemperatureConverter)) != null)
                {
                    var classInstance = (ITemperatureConverter)_assembly.CreateInstance(type.FullName);

                    if (classInstance == null)
                    {
                        throw new ArgumentNullException(nameof(classInstance), "Не удалось получить экземпляр класса.");
                    }

                    ScalesList.Add(classInstance.ScaleName);

                    _converters.Add(classInstance.ScaleName, classInstance);
                }
            }
        }

        public double ConvertTemperature(double temperature, string currentScale, string resultScale)
        {
            var converterToCelsius = _converters[currentScale];
            var celsiusTemperature = converterToCelsius.ConvertToCelsius(temperature);

            var converterFromCelsius = _converters[resultScale];
            var resultTemperature = converterFromCelsius.ConvertFromCelsius(celsiusTemperature);

            return Convert.ToDouble(resultTemperature);
        }
    }
}