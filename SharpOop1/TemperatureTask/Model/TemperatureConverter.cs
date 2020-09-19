using System;
using System.Collections.Generic;
using System.Reflection;

namespace Academits.Dorosh.TemperatureTask.Model
{
    public class TemperatureConverter
    {
        readonly Assembly _assembly;

        public List<string> List { get; private set; }

        public TemperatureConverter()
        {
            //_assembly = Assembly.LoadFrom("..\\..\\..\\TemperatureConverters\\bin\\Debug\\TemperatureConverters.dll");
            _assembly = Assembly.LoadFrom("..\\..\\Model\\TemperatureConverters.dll");

            var types = _assembly.GetTypes();

            if (types == null)
            {
                throw new ArgumentNullException(nameof(types), "Не удалось получить перечень классов из сборки");
            }

            List = new List<string>();

            foreach (var type in types)
            {
                if (type.GetInterface("IConverter") != null)
                {
                    List.Add(type.Name);
                }
            }
        }

        private object CreateClassInstance(string scale)
        {
            var сlassInstance = _assembly.CreateInstance($"Academits.Dorosh.TemperatureConverters.{scale}");

            if (сlassInstance == null)
            {
                throw new ArgumentNullException(nameof(сlassInstance), "Не удалось создать класс.");
            }

            return сlassInstance;
        }

        private MethodInfo GetMethod(object classInstance, string methodName)
        {
            var method = classInstance.GetType().GetMethod(methodName);

            if (method == null)
            {
                throw new ArgumentNullException(nameof(method), "Не удалось вызвать метод.");
            }

            return method;
        }

        public double ConvertTemperature(double temperature, string currentScale, string resultScale)
        {
            var converterToCelsius = CreateClassInstance(currentScale);
            var getCelsiusTemperature = GetMethod(converterToCelsius, "ConvertToCelsius");
            var celsiusTemperature = getCelsiusTemperature.Invoke(converterToCelsius, new object[] { temperature });

            var converterFromCelsius = CreateClassInstance(resultScale);
            var getResultTemperature = GetMethod(converterFromCelsius, "ConvertFromCelsius");
            var resultTemperature = getResultTemperature.Invoke(converterFromCelsius, new object[] { celsiusTemperature });

            return Convert.ToDouble(resultTemperature);
        }
    }
}