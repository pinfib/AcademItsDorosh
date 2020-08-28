using System;
using System.Collections.Generic;
using System.IO;

namespace Academits.Dorosh.ArrayListHomeTask
{
    class ArrayListHomeProgram
    {
        static void Main()
        {
            // 1. Прочитать в список все строки из файла

            Console.WriteLine();
            Console.WriteLine("=== 1 ===");
            Console.WriteLine();

            List<string> listFromFile = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\input.txt"))
                {
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        listFromFile.Add(currentLine);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("ОШИБКА: Файл не найден. {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ОШИБКА: {0}", e.Message);
            }

            if (listFromFile.Count == 0)
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                Console.WriteLine("Прочитано из файла: ");

                foreach (string s in listFromFile)
                {
                    Console.WriteLine(s);
                }
            }

            // 2. Есть список из целых чисел. Удалить из него все четные числа. В этой задаче новый список создавать нельзя

            Console.WriteLine();
            Console.WriteLine("=== 2 ===");
            Console.WriteLine();

            List<int> integersList = new List<int> { 1, 2, 2, 2, 3 };

            Console.WriteLine("Исходный список: ");
            Console.WriteLine(string.Join(", ", integersList));

            int i = 0;

            while (i < integersList.Count)
            {
                if (integersList[i] % 2 == 0)
                {
                    integersList.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine("Итоговый список: ");
            Console.WriteLine(string.Join(", ", integersList));

            // 3. Есть список из целых чисел, в нём некоторые числа могут повторяться. Надо создать новый список, в котором будут
            // элементы первого списка в таком же порядке, но без повторений
            // Например, был список[1, 5, 2, 1, 3, 5], должен получиться новый список[1, 5, 2, 3]

            Console.WriteLine();
            Console.WriteLine("=== 3 ===");
            Console.WriteLine();

            List<int> mixedIntegersList = new List<int> { 50, 1, 2, 3, 4, 5, 2, 3, 7, 8, 9 };

            Console.WriteLine("Исходный список: ");
            Console.WriteLine(string.Join(", ", mixedIntegersList));

            List<int> uniqueIntegersList = new List<int>(mixedIntegersList.Count);

            foreach (int e in mixedIntegersList)
            {
                if (!uniqueIntegersList.Contains(e))
                {
                    uniqueIntegersList.Add(e);
                }
            }

            Console.WriteLine("Итоговый список: ");
            Console.WriteLine(string.Join(", ", uniqueIntegersList));

            Console.ReadKey();
        }
    }
}