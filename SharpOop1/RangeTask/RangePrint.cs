using System;

namespace Academits.Dorosh
{
    class RangePrint
    {
        public static void Print(params Range[] ranges)
        {
            if (ranges == null || ranges[0] == null)
            {
                Console.Write("Нет");
                return;
            }

            foreach (Range range in ranges)
            {
                Console.WriteLine("({0}; {1})", range.From, range.To);
            }
        }
    }
}