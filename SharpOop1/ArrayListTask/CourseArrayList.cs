using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Dorosh.ArrayListTask
{
    public class CourseArrayList<T> : IList<T>
    {
        private T[] items = new T[10];

        private int length;

        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }

            items[length] = item;

            length++;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;

            items = new T[old.Length * 2];

            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void Clear()
        {
            length = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, length);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }

            if (index >= 0)
            {
                Array.Copy(items, index, items, index + 1, length - index);

                items[index] = item;

                length++;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            length--;
        }

        IEnumerator IEnumerable.GetEnumerator() //TODO: Enumerator
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() //TODO: Enumerator
        {
            throw new NotImplementedException();
        }

        public int Capacity() //TODO: реализовать
        {
            throw new NotImplementedException();
        }

        public void TrimExcess() //TODO: реализовать
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder tmpString = new StringBuilder();

            for(int i = 0; i < length; i++)
            {
                tmpString.AppendFormat("{0, -5:0.##}", items[i]);
            }

            return tmpString.ToString();
        }
    }
}