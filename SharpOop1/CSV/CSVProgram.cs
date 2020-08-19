using System;

namespace Academits.Dorosh.Csv
{
    class CsvProgram
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Необходимо указать путь к исходному файлу.");
            }
            else if (args.Length == 1)
            {
                CsvConverter.ConvertFromCsv(args[0]);

                Console.WriteLine("Конвертирование выполнено.");
            }
            else
            {
                CsvConverter.ConvertFromCsv(args[0], args[1]);

                Console.WriteLine("Конвертирование выполнено.");
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}