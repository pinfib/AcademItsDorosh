using System;

namespace Academits.Dorosh.ListTask
{
    class ListProgram
    {
        static void Main(string[] args)
        {
            CourseList<int> list = new CourseList<int>();

            list.Add(30);
            list.Add(20);
            list.Add(10);
            list.Add(0);

            try
            {
                int index = 3;

                Console.WriteLine(list.ToString());
                Console.WriteLine("Значение в голове списка = {0}", list.GetValue());
                Console.WriteLine("Значение по индексу {0} = {1}", index, list.GetValue(index));

                Console.WriteLine();

                int deletedItem = list.RemoveAt(index);
                Console.WriteLine("Удаляется элемент по индексу {0}, он содержал значение {1}. Итоговый список: ", index, deletedItem);
                Console.WriteLine(list.ToString());

                Console.WriteLine();

                list.Insert(index, deletedItem);
                Console.WriteLine("Удаленный элемент вставлен обратно. Итоговый список: ");
                Console.WriteLine(list.ToString());

                Console.WriteLine();

                int item = -50;
                list.Insert(index, item);
                Console.WriteLine("В список по индексу {0} добавлен элемент [ {1} ]. Итоговый список: ", index, item);
                Console.WriteLine(list.ToString());

                Console.WriteLine();

                bool isDeleted = list.Remove(item);
                Console.WriteLine("Удаляется элемент со значением [{0}]. Успешно? {1}. Итоговый список: ", item, isDeleted);
                Console.WriteLine(list.ToString());

                Console.WriteLine();

                deletedItem = list.RemoveFirst();
                Console.WriteLine("Удален первый элемент. Его значение [{0}]. Итоговый список: ", deletedItem);
                Console.WriteLine(list.ToString());

                Console.WriteLine();

                list.Revers();
                Console.WriteLine("Разворот списка:");
                Console.WriteLine(list.ToString());

                Console.WriteLine();

                CourseList<int> list2 = new CourseList<int>();
                list.CopyTo(list2);
                Console.WriteLine("Копирование списка.");
                Console.WriteLine("Исходный список: ");
                Console.WriteLine(list.ToString());
                Console.WriteLine("Новый спиок: ");
                Console.WriteLine(list2.ToString());

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}