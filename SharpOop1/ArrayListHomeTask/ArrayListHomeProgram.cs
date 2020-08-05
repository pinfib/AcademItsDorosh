using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    class ArrayListHomeProgram
    {
        static void Main()
        {
            //1.Прочитать в список все строки из файла

            Console.WriteLine();
            Console.WriteLine("=== 1 === ");
            Console.WriteLine();

            List<string> list1 = new List<string>();

            using (StreamReader reader = new StreamReader("..\\..\\input.txt"))
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    list1.Add(currentLine);
                }
            }

            Console.WriteLine("Прочитано из файла: ");

            foreach (string s in list1)
            {
                Console.WriteLine(s);
            }

            //2.Есть список из целых чисел. Удалить из него все четные числа. В этой задаче новый список создавать нельзя

            Console.WriteLine();
            Console.WriteLine("=== 2 === ");
            Console.WriteLine();

            List<int> list2 = new List<int>();

            int lenght = 31;

            for(int i = 0; i < lenght; i++)
            {
                list2.Add(i);
            }

            Console.WriteLine("Исходный список: ");
            Console.WriteLine(string.Join(", ", list2));

            for (int i = 0; i < list2.Count; i++)
            {
                if(list2[i] % 2 == 0)
                {
                    list2.RemoveAt(i);
                }
            }

            Console.WriteLine("Итоговый список: ");
            Console.WriteLine(string.Join(", ", list2));

            //3.Есть список из целых чисел, в нём некоторые числа могут повторяться.Надо создать новый список, в котором будут
            //элементы первого списка в таком же порядке, но без повторений
            //Например, был список[1, 5, 2, 1, 3, 5], должен получиться новый список[1, 5, 2, 3]

            Console.WriteLine();
            Console.WriteLine("=== 3 === ");
            Console.WriteLine();

            int[] array = new int[] { 50, 1, 2, 3, 4, 5, 2, 3, 7, 8, 9 };

            List<int> list3 = new List<int>();

            list3.AddRange(array);

            Console.WriteLine("Исходный список: ");
            Console.WriteLine(string.Join(", ", list3));

            List<int> list4 = new List<int>();

            foreach (int e in list3)
            {
                if(list4.Contains(e) == false)
                {
                    list4.Add(e);
                }
            }

            Console.WriteLine("Итоговый список: ");
            Console.WriteLine(string.Join(", ", list4));

            Console.ReadKey();
        }
    }
}
