using Academits.Dorosh.TemperatureConverters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academits.Dorosh.TemperatureTask.Model
{
    public class TemperatureConverter
    {
        private readonly Dictionary<string, ITemperatureConverter> _converters;

        public List<string> ScalesList { get; }

        public TemperatureConverter()
        {
            var assembly = typeof(ITemperatureConverter).Assembly;

            var types = assembly.GetTypes()
                .Where(type => type.GetInterface(nameof(ITemperatureConverter)) != null)
                .ToArray();

            if (types == null)
            {
                throw new ArgumentNullException(nameof(types), "Не удалось получить перечень классов из сборки");
            }

            _converters = new Dictionary<string, ITemperatureConverter>(types.Length);

            foreach (var type in types)
            {
                var classInstance = (ITemperatureConverter)assembly.CreateInstance(type.FullName);

                if (classInstance == null)
                {
                    throw new ArgumentNullException(nameof(classInstance), "Не удалось получить экземпляр класса.");
                }

                _converters.Add(classInstance.ScaleName, classInstance);
            }

            ScalesList = _converters.Keys.ToList();
        }

        public double ConvertTemperature(double temperature, string currentScale, string resultScale)
        {
            var converterToCelsius = _converters[currentScale];
            var celsiusTemperature = converterToCelsius.ConvertToCelsius(temperature);

            var converterFromCelsius = _converters[resultScale];
            return converterFromCelsius.ConvertFromCelsius(celsiusTemperature);
        }
    }
}