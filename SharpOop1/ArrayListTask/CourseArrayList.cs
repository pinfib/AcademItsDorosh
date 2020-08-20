using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.ArrayListTask
{
    public class CourseArrayList<T> : IList<T>
    {
        private T[] items;

        private int _length;

        public int Count
        {
            get
            {
                return _length;
            }
            set
            {
                if (value >= 0)
                {
                    _length = value;
                }
            }
        }

        private int _capacity;

        private int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                IncreaseCapacity(value);

                _capacity = value;
            }
        }

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

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public CourseArrayList()
        {
            _capacity = 5;

            items = new T[Capacity];
        }

        public CourseArrayList(int capacity)
        {
            _capacity = capacity;

            items = new T[Capacity];
        }

        public void Add(T item)
        {
            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = item;

            Count++;
        }

        private void IncreaseCapacity()
        {
            Capacity *= 2;
        }

        private void IncreaseCapacity(int capacity)
        {
            if (capacity < Count)
            {
                throw new ArgumentException(string.Format("Передано значение вместимости {0}, количество элементов в списке {1}. Вместимость нельзя установить меньше количества элементов.", capacity, Count), nameof(capacity));
            }

            T[] old = items;

            items = new T[capacity];

            Array.Copy(old, 0, items, 0, capacity < old.Length ? capacity : old.Length);
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
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
            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
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
            if (index < 0 || index > Count)
            {
                throw new ArgumentException(string.Format("Передан индекс {0}, значение индекса должно быть от 0 до {1}", index, Count), nameof(index));
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;

            Count++;
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
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException(string.Format("Передан индекс {0}, значение индекса должно быть от 0 до {1}", index, Count - 1), nameof(index));
            }

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
            {
                yield return items[i];
            }
        }

        public void TrimExcess()
        {
            Capacity = Count;
        }

        public override string ToString()
        {
            StringBuilder tmpString = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                tmpString.AppendFormat("[ {0:0.##} ] ", items[i]);
            }

            tmpString.AppendFormat("длина списка - {0}, вместимость - {1}", Count, Capacity);

            return tmpString.ToString();
        }
    }
}