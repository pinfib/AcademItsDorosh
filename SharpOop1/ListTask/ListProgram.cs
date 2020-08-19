using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Dorosh.ListTask
{
    class ListProgram
    {
        static void Main(string[] args)
        {
            ListItem<int> head = new ListItem<int>(0, null); 

            CourseList<int> list = new CourseList<int>(head);

            list.Add(1);
            list.Add(2);
            list.Add(3);
            /*
            int index = 1;
            Console.WriteLine(list.ToString());
            Console.WriteLine("Значение в голове списка = {0}", list.GetValue());
            Console.WriteLine("Значение по индексу {0} = {1}", index, list.GetValue(index));


            int item = -50;
            list.SetValue(index, item);

            Console.WriteLine(list.ToString());

            list.SetValue(index, 2);

            list.Insert(2, item);

            Console.WriteLine(list.ToString());

            list.Remove(item);

            Console.WriteLine(list.ToString());

            list.RemoveFirst();

            Console.WriteLine(list.ToString());
            

            list.Revers();

            Console.WriteLine(list.ToString());
            */

            CourseList<int> list2 = new CourseList<int>(new ListItem<int>(-50, null));
            list.CopyTo(list2);

            Console.WriteLine(list2.ToString());

            Console.ReadKey();
        }
    }
}
