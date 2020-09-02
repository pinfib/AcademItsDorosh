using System;
using System.Text;

namespace Academits.Dorosh.ListTask
{
    public class List<T>
    {
        private ListItem<T> Head { get; set; }

        public int Count { get; private set; }

        public List()
        {
        }

        public List(T data)
        {
            Head = new ListItem<T>(data);
        }

        private ListItem<T> GetListItemByIndex(int index)
        {
            ListItem<T> current = Head;

            for (int i = 0; i != index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public int GetSize()
        {
            return Count;
        }

        public T GetFirstValue()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }

            return Head.Data;
        }

        public T GetValue(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Передан индекс [{index}], длина списка - {Count}");
            }

            ListItem<T> listItem = GetListItemByIndex(index);

            return listItem.Data;
        }

        public T SetValue(int index, T data)        // Выдает старое значение
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Передан индекс [{index}], длина списка - {Count}");
            }

            ListItem<T> listItem = GetListItemByIndex(index);

            T oldData = listItem.Data;
            listItem.Data = data;

            return oldData;
        }

        public void AddFirst(T item)
        {
            ListItem<T> tmpItem = new ListItem<T>(item, Head);

            Head = tmpItem;

            Count++;
        }

        public void Insert(int index, T item)
        {
            if (index > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Передан индекс [{index}], длина списка - {Count}");
            }

            if (index == 0)
            {
                AddFirst(item);
            }
            else
            {
                ListItem<T> previous = GetListItemByIndex(index - 1);
                ListItem<T> current = previous.Next;

                previous.Next = new ListItem<T>(item, current);

                Count++;
            }
        }

        public T RemoveAt(int index)                // Выдает старое значение
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Передан индекс [{index}], длина списка - {Count}");
            }

            T oldData;

            if (index == 0)
            {
                oldData = RemoveFirst();
            }
            else
            {
                ListItem<T> previous = GetListItemByIndex(index - 1);
                ListItem<T> current = previous.Next;

                oldData = current.Data;
                previous.Next = current.Next;

                Count--;
            }

            return oldData;
        }

        public bool Remove(T item)                  // Выдает true, если элемент был удален
        {
            if (Head == null)
            {
                return false;
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

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirst()                      // Выдает старое значение
        {
            if (Head == null)       
            {
                throw new InvalidOperationException("Список пуст");
            }

            T oldData = Head.Data;

            Head = Head.Next;

            Count--;

            return oldData;
        }

        public void Reverse()
        {
            if (Head == null || Head.Next == null) // список пуст или состоит из одного элемента
            {
                return;
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

        public List<T> CopyTo()
        {
            if (Head == null)
            {
                return new List<T>();
            }

            List<T> newList = new List<T>(Head.Data);

            newList.Count = Count;

            ListItem<T> current1 = Head.Next;
            ListItem<T> current2 = newList.Head;

            while (current1 != null)
            {
                current2.Next = new ListItem<T>(current1.Data);

                current1 = current1.Next;
                current2 = current2.Next;
            }

            return newList;
        }

        public override string ToString()
        {
            if (Head == null)
            {
                return "Список пуст";
            }

            StringBuilder stringBuilder = new StringBuilder("[ ");

            for (ListItem<T> current = Head; current != null; current = current.Next)
            {
                stringBuilder.Append(current.Data);

                if (current.Next != null)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append(" ]");

            stringBuilder.Append($" (Длина - {Count})");

            return stringBuilder.ToString();
        }
    }
}