using System;

namespace Academits.Dorosh
{
    class RangeProgram
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("МЕНЮ");
                Console.WriteLine();
                Console.WriteLine("1. Проверка вхождения числа в заданный диапазон");
                Console.WriteLine("2. Операции над множествами, готовые тесты");
                Console.WriteLine("3. Операции над множествами, ввести свои отрезки");
                Console.WriteLine("4. Выход");
                Console.WriteLine();
                Console.WriteLine("Выберите пункт (только номер): ");

                string UserChoice = Console.ReadLine();

                if (UserChoice.Equals("1"))
                {
                    Range range = RangeCreation.GetRange();

                    Console.WriteLine("Вы ввели диапазон от {0} до {1}.", range.From, range.To);
                    Console.WriteLine("Его длина: {0}", range.GetLength());

                    Console.Write("Введите значение, чтобы проверить входит ли оно в заданный диапазон: ");
                    double number = Convert.ToDouble(Console.ReadLine());

                    if (range.IsInside(number))
                    {
                        Console.WriteLine("Значение {0} входит в заданный диапазон.", number);
                    }
                    else
                    {
                        Console.WriteLine("Значение {0} не входит в заданный диапазон.", number);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу...");

                    Console.ReadKey();

                    continue;
                }

                if (UserChoice.Equals("2"))
                {
                    Range[] A =
                    {
                        new Range(1,10),
                        new Range(1, 5),
                        new Range(1, 20),
                        new Range(1, 10),
                        new Range(1, 10)
                    };

                    Range[] B =
{
                        new Range(5, 15),
                        new Range(5, 10),
                        new Range(5, 10),
                        new Range(15, 20),
                        new Range(1, 10)
                    };

                    for (int i = 0; i < A.Length; i++)
                    {
                        Console.Write("Отрезок 1: ");
                        RangePrint.Print(A[i]);

                        Console.Write("Отрезок 2: ");
                        RangePrint.Print(B[i]);

                        Console.WriteLine();
                        Console.WriteLine("Объединение: ");
                        RangePrint.Print(A[i].Union(B[i]));

                        Console.WriteLine();
                        Console.WriteLine("Пересечение: ");
                        RangePrint.Print(A[i].Intersection(B[i]));

                        Console.WriteLine();
                        Console.WriteLine("Разность: ");
                        RangePrint.Print(A[i].Complement(B[i]));

                        Console.WriteLine();
                        Console.WriteLine("======================");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу...");

                    Console.ReadKey();

                    continue;
                }

                if (UserChoice.Equals("3"))
                {
                    Console.WriteLine("Введите отрезок 1: ");
                    Range A = RangeCreation.GetRange();
                    Console.WriteLine();

                    Console.WriteLine("Введите отрезок 2: ");
                    Range B = RangeCreation.GetRange();

                    Console.WriteLine();
                    Console.WriteLine("Объединение: ");
                    RangePrint.Print(A.Union(B));

                    Console.WriteLine();
                    Console.WriteLine("Пересечение: ");
                    RangePrint.Print(A.Intersection(B));

                    Console.WriteLine();
                    Console.WriteLine("Разность: ");
                    RangePrint.Print(A.Complement(B));

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу...");

                    Console.ReadKey();

                    continue;
                }

                if (UserChoice.Equals("4"))
                {
                    break;
                }
            }
        }
    }
}