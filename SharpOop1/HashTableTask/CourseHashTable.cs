using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.HashTableTask
{
    class CourseHashTable<T> : ICollection<T>
    {
        private List<T>[] data;

        private int modCount;

        private int length;

        public int Count
        {
            get
            {
                return length;
            }
            set
            {
                if (value >= 0)
                {
                    length = value;
                }
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public CourseHashTable()
        {
            int capacity = 20;

            data = new List<T>[capacity];

            for (int i = 0; i < capacity; i++)
            {
                data[i] = new List<T>();
            }
        }

        public CourseHashTable(int capacity)
        {
            data = new List<T>[capacity];

            for (int i = 0; i < capacity; i++)
            {
                data[i] = new List<T>();
            }
        }

        private int GetKey(T item)
        {
            return Math.Abs(item.GetHashCode() % data.Length);
        }

        public void Add(T item)
        {
            int key = GetKey(item);

            data[key].Add(item);

            Count++;

            modCount++;
        }

        public void Clear()
        {
            foreach (List<T> e in data)
            {
                e.Clear();
            }

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            int key = GetKey(item);

            return data[key].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length < arrayIndex + Count)
            {
                throw new ArgumentException(string.Format("Целевой массив размера {0}, в него нельзя скопировать еще {1} элементов", array.Length, Count), nameof(array));
            }

            int currentIndex = arrayIndex;

            foreach (List<T> e in data)
            {
                int listCount = e.Count;

                e.CopyTo(array, currentIndex);

                currentIndex += listCount;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < data.Length; i++)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException("Список был изменен, нельзя продолжить цикл.");
                }

                if (data[i] != null)
                {
                    foreach (T e in data[i])
                    {
                        yield return e;
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            int key = GetKey(item);

            bool isDeleted = data[key].Remove(item);

            if (isDeleted)
            {
                Count--;

                modCount++;
            }

            return isDeleted;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder tmpString = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                tmpString.Append(i);
                tmpString.Append(" - ");

                if (data[i].Count == 0)
                {
                    tmpString.Append("пусто");
                }
                else
                {
                    foreach (T e in data[i])
                    {
                        tmpString.AppendFormat("[ {0} ] ", e);
                    }
                }

                tmpString.AppendLine();
            }

            return tmpString.ToString();
        }
    }
}