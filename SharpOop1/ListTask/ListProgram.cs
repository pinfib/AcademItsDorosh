using System;

namespace Academits.Dorosh.ListTask
{
    class ListProgram
    {
        public static void MethodsTests(List<int> list)
        {
            Console.WriteLine($"Исходный список: {list}");
            Console.WriteLine();

            int item = -50;
            int index = 0;

            for (int i = 0; i < 6; i++)
            {
                int deletedItem;
                List<int> tmpList = list.CopyTo();

                try
                {
                    switch (i)
                    {
                        case 0:
                            tmpList.Reverse();
                            Console.Write($"Разворот списка. ");
                            break;
                        case 1:
                            tmpList.Insert(index, item);
                            Console.Write($"В список по индексу {index} добавлен элемент [ {item} ]. ");
                            break;
                        case 2:
                            tmpList.AddFirst(item - 10);
                            Console.Write($"В начало списка добавлен элемент [ {item - 10} ]. ");
                            break;
                        case 3:
                            deletedItem = tmpList.RemoveAt(index);
                            Console.Write($"Удаляется элемент по индексу {index}, он содержал значение {deletedItem}. ");
                            break;
                        case 4:
                            deletedItem = tmpList.RemoveFirst();
                            Console.Write($"Удален первый элемент. Его значение [{deletedItem}]. ");
                            break;
                        case 5:
                            item = tmpList.GetValue(1);
                            bool isDeleted = tmpList.Remove(item);
                            Console.Write($"Удаляется элемент со значением [{item}]. Успешно? {isDeleted}. ");
                            break;
                    }

                    Console.WriteLine($"Итоговый список: {tmpList}");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.AddFirst(30);
            list.AddFirst(20);
            list.AddFirst(10);
            list.AddFirst(0);

            MethodsTests(list);

            /*
            try // тест копирования
            {
                List<int> list2 = list.CopyTo();
                Console.WriteLine("Копирование списка.");
                Console.WriteLine($"Исходный список: {list}");
                list.SetValue(1, -333);
                Console.WriteLine($"Новый спиок: {list2}");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }*/

            // Тест индексов

            Console.WriteLine();
            Console.WriteLine($"Исходный список: {list}");

            try // крайние индексы
            {
                Console.WriteLine($"Значение по индексу 0: {list.GetValue(0)}");
                Console.WriteLine($"Значение по индексу {list.Count - 1}: {list.GetValue(list.Count - 1)}");

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try // за границами списка
            {
                Console.WriteLine($"Значение по индексу -1: {list.GetValue(-1)}");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try // за границами списка
            {
                Console.WriteLine($"Значение по индексу {list.Count}: {list.GetValue(list.Count)}");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try // в границах списка
            {
                Console.WriteLine($"Значение по индексу {1}: {list.GetValue(1)}");
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