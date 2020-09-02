﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private T[] _items;

        public int Count { get; private set; }

        private int _capacity;

        private int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Передано значение вместимости {value}, количество элементов в списке {Count}. Вместимость нельзя установить меньше количества элементов.");
                }

                if (_capacity == value)
                {
                    return;
                }

                Array.Resize(ref _items, value);

                _capacity = value;

                _modCount++;
            }
        }

        private int _modCount;

        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;

                _modCount++;
            }
        }

        public bool IsReadOnly => false;

        public ArrayList()
        {
            _capacity = 5;

            _items = new T[Capacity];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                capacity = 0;
            }

            _capacity = capacity;

            _items = new T[Capacity];
        }

        public void Add(T item)
        {
            if (Count >= _items.Length)
            {
                IncreaseCapacity();
            }

            _items[Count] = item;

            Count++;

            _modCount++;
        }

        private void IncreaseCapacity()
        {
            if (Capacity == 0)
            {
                Capacity = 2;
            }
            else
            {
                Capacity *= 2;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _items[i] = default;
            }

            Count = 0;

            _modCount++;
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Целевой массив имеет значение null", nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Значение параметра arrayIndex меньше 0.");
            }

            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentException("Число элементов в исходной коллекции ICollection<T> больше доступного места от положения, заданного значением параметра arrayIndex, до конца массива назначения array.");
            }

            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i] == null && item == null)
                {
                    return i;
                }

                if (_items[i] != null && _items[i].Equals(item))
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
                throw new ArgumentOutOfRangeException($"Передан индекс {index}, значение индекса должно быть от 0 до {Count}");
            }

            if (Count >= _items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = item;

            Count++;

            _modCount++;
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
                throw new ArgumentOutOfRangeException($"Передан индекс {index}, значение индекса должно быть от 0 до {Count - 1}");
            }

            if (index < Count - 1)
            {
                Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            }

            Count--;

            _items[Count] = default;

            _modCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = _modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (currentModCount != _modCount)
                {
                    throw new InvalidOperationException("Список был изменен, нельзя продолжить цикл.");
                }

                yield return _items[i];
            }
        }

        public void TrimExcess()
        {
            Capacity = Count;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[ ");

            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append($"{_items[i]:0.##}");

                if (i != Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append(" ]");

            stringBuilder.Append($" длина списка - {Count}, вместимость - {Capacity}");

            return stringBuilder.ToString();
        }
    }
}