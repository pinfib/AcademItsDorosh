using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Dorosh.ArrayListTask
{
    class ArrayListProgram
    {
        static void Main(string[] args)
        {
            CourseArrayList<int> list = new CourseArrayList<int>();

            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Console.WriteLine("исходный список: " + list);

            //int[] array1 = new int[9];
            //list.CopyTo(array1, 2);
            //Console.WriteLine("массив: " + string.Join(", ", array1));

            //int element = 5;
            //Console.WriteLine("Содержит ли список элемент {0}? {1}", element, list.Contains(element));
            //Console.WriteLine("Индекс элемента {0} - {1}", element, list.IndexOf(element));

            int element2 = -10;
            int index = 3;
            list.Insert(index, element2);
            Console.WriteLine("Вставка по индексу: " + list);

            //list.RemoveAt(index);
            //Console.WriteLine("Удаление по индексу: " + list);

            list.Remove(element2);
            Console.WriteLine("Удаление по значению: " + list);

            Console.ReadKey();
        }
    }
}
