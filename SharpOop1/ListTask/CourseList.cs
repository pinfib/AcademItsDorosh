using System;
using System.Text;

namespace Academits.Dorosh.ListTask
{
    public class CourseList<T>
    {
        public ListItem<T> Head { get; set; }

        //private int Count { get; }

        public CourseList()
        {
        }

        public CourseList(ListItem<T> head)
        {
            Head = head;
        }

        public int GetSize()
        {
            int i = 0;

            for (ListItem<T> current = Head; current != null; current = current.Next, i++) ;

            return i;
        }

        public T GetValue()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст, нельзя получить значение.");
            }

            return Head.Data;
        }

        public T GetValue(int index)
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст, нельзя получить значение.");
            }

            int size = GetSize();

            if (index >= size)
            {
                throw new ArgumentException(string.Format("Передан индекс [{0}], длина списка - {1}", index, size), nameof(index));
            }

            ListItem<T> current = Head;

            for (int i = 0; i != index && current.Next != null; i++, current = current.Next) ;

            return current.Data;
        }

        public T SetValue(int index, T data)        // Выдает старое значение
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст, нельзя изменить значение.");
            }

            int size = GetSize();

            if (index >= size || index < 0)
            {
                throw new ArgumentException(string.Format("Передан индекс [{0}], длина списка - {1}", index, size), nameof(index));
            }

            ListItem<T> current = Head;

            for (int i = 0; i < index && current.Next != null; i++, current = current.Next) ;

            T oldData = current.Data;
            current.Data = data;

            return oldData;
        }

        public void Add(T item)
        {
            ListItem<T> tmpItem = new ListItem<T>(item, Head);

            Head = tmpItem;
        }

        public void Insert(int index, T item)
        {
            int size = GetSize();

            if (index > size || index < 0)
            {
                throw new ArgumentException(string.Format("Передан индекс [{0}], длина списка - {1}", index, size), nameof(index));
            }

            if (index == 0)
            {
                Add(item);
            }
            else
            {
                ListItem<T> current = Head;
                ListItem<T> previous = null;

                for (int i = 0; i < index && current != null; previous = current, current = current.Next, i++) ;

                previous.Next = new ListItem<T>(item, current);
            }
        }

        public T RemoveAt(int index)                // Выдает старое значение
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст, нельзя удалять элементы.");
            }

            int size = GetSize();

            if (index >= size || index < 0)
            {
                throw new ArgumentException(string.Format("Передан индекс [{0}], длина списка - {1}", index, size), nameof(index));
            }

            T oldData;

            if (index == 0)
            {
                oldData = Head.Data;

                RemoveFirst();
            }
            else
            {
                ListItem<T> current = Head;
                ListItem<T> previous = null;

                for (int i = 0; i < index && current != null; previous = current, current = current.Next, i++) ;

                oldData = current.Data;
                previous.Next = current.Next;
            }

            return oldData;
        }

        public bool Remove(T item)                  // Выдает true, если элемент был удален
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст, нельзя удалять элементы.");
            }

            for (ListItem<T> current = Head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (current.Data.Equals(item))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirst()                      // Выдает старое значение
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст, нельзя удалять элементы.");
            }

            T oldData = Head.Data;

            Head = Head.Next;

            return oldData;
        }

        public void Revers()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст.");
            }

            ListItem<T> current = Head.Next;
            Head.Next = null;

            while (current != null)
            {
                ListItem<T> next = current.Next;    // сохранить ссылку на следущий элемент после текущего
                current.Next = Head;                // поменять местами текущий элемент и голову
                Head = current;
                current = next;                     // текущий элемент указывает на оставшуюся часть списка
            }
        }

        public void CopyTo(CourseList<T> newList)
        {
            int size = GetSize() - 1;

            for (int i = size; i >= 0; i--)
            {
                newList.Add(GetValue(i));
            }
        }

        public override string ToString()
        {
            StringBuilder tmpString = new StringBuilder();

            for (ListItem<T> current = Head; current != null; current = current.Next)
            {
                tmpString.AppendFormat(" [ {0} ] ", current.Data);
            }

            tmpString.AppendFormat("Длина списка - {0}", GetSize());

            return tmpString.ToString();
        }
    }
}