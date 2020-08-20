using System;

namespace Academits.Dorosh.ArrayListTask
{
    class ArrayListProgram
    {
        static void Main(string[] args)
        {
            CourseArrayList<int> list = new CourseArrayList<int> { 0, 1, 2, 3, 4 };

            Console.WriteLine("Исходный список:");
            Console.WriteLine(list);

            try
            {
                int element = 5;

                Console.WriteLine("Содержит ли список элемент {0}? {1}", element, list.Contains(element));
                Console.WriteLine("Индекс элемента {0} - {1}", element, list.IndexOf(element));
                Console.WriteLine();

                list.Add(element);
                Console.WriteLine("Вставка элемента со значением [{0}] в конец:", element);
                Console.WriteLine(list);
                Console.WriteLine();

                list.Insert(list.Count, element);
                Console.WriteLine("Вставка по индексу элемента со значением [{0}] в конец:", element);
                Console.WriteLine(list);
                Console.WriteLine();

                int index = 2;

                list.Insert(index, element);
                Console.WriteLine("Вставка элемента со значением [{0}] по индексу [{1}]:", element, index);
                Console.WriteLine(list);
                Console.WriteLine();

                list.Remove(element);
                Console.WriteLine("Удаление элемента со значением  [{0}]:", element);
                Console.WriteLine(list);
                Console.WriteLine();

                list.RemoveAt(index);
                Console.WriteLine("Удаление по индексу [{0}]:", index);
                Console.WriteLine(list);
                Console.WriteLine();

                list.TrimExcess();
                Console.WriteLine("Уменьшение вместимости:");
                Console.WriteLine(list);
                Console.WriteLine();

                list.Add(5);
                Console.WriteLine("Добавление элемента:");
                Console.WriteLine(list);
                Console.WriteLine();

                Console.WriteLine("Тест итератора:");
                foreach (int e in list)
                {
                    Console.WriteLine("foreach: {0}", e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}